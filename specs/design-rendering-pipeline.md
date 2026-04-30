# Design: Rendering Pipeline

## Purpose

- Describe the pipeline from data sources through to the display of the chart in order to separate the different areas and optimise rendering.

## Pipeline Details

The pipeline sequence is as follows for rendering the chart area. The intent is to reduce the work needed to display the chart: do not rebuild the model, recalculate layout, or redraw expensive content unless the inputs for that stage have changed.

### 1. Input Data Sets

For now empty, but may introduce customer data sets (e.g. holiday dates, birthdays) and public data sets (e.g. local bank holidays).

- External data sets retrieved when selected (could cache if it helps).
- Updated when data sets are added or removed.
- Updated when a user data set is updated.

### 2. Model

The model is calculated by combining the input data, relevant options, and the selected calendar (initially UK Gregorian). This provides the list of days in the selected date range and any attached semantic annotations. Initially this includes weekday/weekend classification.

- Updated if the date range is changed.
- Updated if extra rows or columns are changed.
- Updated if model-affecting chart settings are changed, such as first day of week or heading length.
- Updated if input data sets are changed.

*Note: later updates will add the ability to attach text or annotations to a cell, such as "Summer", "BST", public holiday, or personal holiday. Presentation details such as background colour should be configured in theme/style data rather than stored directly in the model.*

### 3. Canvas Area

The chart will be drawn onto a canvas area. In this document, canvas means the logical chart drawing area: the available chart rectangle for stretch view, or the printable page area for print layout and print output. View decoration, such as page shadow and workspace background, is outside the chart canvas.

- Updated if the view changes (e.g. between stretch and print views).
- Updated if the page settings are changed (e.g. page size, orientation, margins).
- Updated if the drawing surface changes (e.g. DPI/graphics units).
- Updated if the containing view size changes.

### 4. Layout Calculations

By combining the model, selected chart layout, canvas details, and render style details that affect measurement, the layout details will be calculated. This will use the available area to calculate the positions and sizes of all items in the chart.

- Updated if the model changes - which can be driven by any of the changes that affect the model.
- Updated if the canvas changes.
- Updated if the selected chart layout changes.
- Updated if measurement-affecting style changes, such as fonts or text sizes.
- The cell positions will also be available to perform hit testing via viewport coordinates.
- Pan and zoom do not recalculate chart layout when they can be represented as viewport transforms.

### 5. Rendering

Using the layout data, the chart can be rendered to the current canvas.

- Rendering will use a viewport transform to support pan and zoom features.
- Rendering should use a back buffer or cached render surface where useful to ensure smooth drawing and reduce expensive redraws.
- Updated if the canvas changes: views, page settings, drawing surface.
- Updated if the Layout changes - including changes driven by model or canvas changes.
- Updated if the theme changes (future enhancement).
- Panning and zooming should reuse the existing render surface or render data where possible.

### 6. Interaction Layer

Later, a handler layer will capture user interaction with the view - mouse movements and clicks.  This can then use the render and layout details to translate to cells, and request the render to present accordingly.

- Use an overlay to render cell hover (as the mouse moves over a cell) and selection (when user clicks on a cell) styles.
- Select a cell when clicked (if valid).
- Use viewport and layout calculations to help with hit testing and rendering positions.
- Interaction overlays should not require the model or base chart layout to be recalculated.
