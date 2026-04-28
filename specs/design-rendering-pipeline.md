# Design: Rendering Pipeline

## Purpose

- Describe the pipeline from data sources through to the display of the chart in order to separate the different areas and optimise rendering.
## Pipeline Details

The pipeline sequence is as follows for rendering the chart area in order to reduce the activity needed to display the chart - i.e. don't recalculate the model if no underlying data has changed.

### 1. Input Data Sets

For now empty, but may introduce customer data sets (e.g. holiday dates, birthdays) and public data sets (e.g. local bank holidays).

- External data sets retrieved when selected (could cache if it helps).
- Updated when data sets are added or removed.
- Updated when a user data set is updated.

### 2. Model

Model: the model is calculated by combining the input data, relevant options and the selected calendar (i.e. UK Gregorian).  This will provide the list of days in the selected date range, and any attached attributes - initially, week day or weekend.

- Updated if the date range is changed.
- Updated if extra rows or columns are changed.
- Updated if chart settings are changed.
- Updated if input data sets are changed.

*Note: later updates will add the the ability to add text to a cell (e.g. "Summer" or "BST"), or to change cell type (a holiday cell).  Similarly, cell styles will be configured to indicate how to render these (e.g. a different background colour).*

### 3. Canvas Area

The chart will be drawn onto a canvas area which I will use here to define the available screen area (for stretch view) or the page area (print view).

- Updated if the view changes (e.g. between stretch and print views).
- Updated if the page settings are changed (e.g. page size, orientation, margins).
- Updated if the drawing surface changes (e.g. DPI/graphics units)

### 4. Layout Calculations


By combining the model, view, layout and canvas details, the layout details will be calculated.  This will use the available area to calculate the positions and sizes of all items in the chart.

- Updated if the model changes - which can be driven by any of the changes that affect the model.
- Updated if the Canvas changes.
- The cell positions will also be available to perform hit testing via viewport coordinates.

### 5. Rendering

Using the layout data, the chart can be rendered to the current canvas.

- Rendering will use a viewport transform to support pan and zoom features.
- Rendering should use a back buffer approach to ensure smooth drawing (and reduce the need to redraw too often).
- Updated if the canvas changes: views, page settings, drawing surface.
- Updated if the Layout changes - including changes driven by model or canvas changes.
- Updated if the theme changes (future enhancement).

### 6. Interaction Layer

Later, a handler layer will capture user interaction with the view - mouse movements and clicks.  This can then use the render and layout details to translate to cells, and request the render to present accordingly.

- Use an overlay to render cell hover (as the mouse moves over a cell) and selection (when user clicks on a cell) styles.
- Select a cell when clicked (if valid).
- Use viewport and layout calculations to help with hit testing and rendering positions.
