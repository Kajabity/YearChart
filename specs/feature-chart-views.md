# Feature: Chart Views

## Purpose

Define how the chart is displayed in the main view area of the application.

## Requirements

- The selected view will be changed from two icon buttons in the right side of the status bar.
- The selected view will also be available from the `View` menu.
- Changing view must not change the chart data or print output.
- Print, print preview, and HTML export continue to use the chart renderer independently of the selected on-screen view.

### View: Stretch to Fit

- The chart will be rendered to fit the available window area with a small border around it.
- This is the default view.
- This view is selected with `View -> Fit Window`.

### View: Page Layout

- The chart will be rendered on a representation of the printed page.
- The page will be shown as a white rectangle on a neutral workspace background.
- The page rectangle will use the active paper size and orientation from Page Setup.
- The printable chart area will use the active page margins from Page Setup.
- The view will support panning with scroll bars when the page is larger than the viewport.
- The view will support zooming with standard mouse wheel zoom behaviour.
- This view is selected with `View -> Print Layout`.
