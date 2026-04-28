# Feature: Chart Options UI

## Purpose

Display a set of options for the chart for the user to view and edit.

## Requirements

- The chart options UI collects various chart configuration options in several groups.
- It is displayed when the user selects `Tools->Options...` from the menu.

- Groups should be displayed in the order below, but may be stretched or wrapped if the container shape changes.
- The chart currently uses the Gregorian Calendar (?)
	- Alternative calendars may be supported later.
- The chart language is UK English.
	- Internationalisation could be supported later.

- The groups are described below.

### Option Group: Chart Settings

- Chart title - a text title to be displayed at the top of the chart.
	- Defaults to "YearChart".
- Day of week that a week starts on.  
	- Defaults to "Monday" ('cause that's how I like it!)
- Select short or long headings - e.g. "Feb." or "February", "Mon." or "Monday".
	- Defaults to long.
	- May need to offer more options for smaller/busier charts - e.g. single letter.

### Option Group:  Date Range Selection

- Choose the date range mode - whole year or date range.
	- Default is whole year.
- When whole year is selected, the user can set the year.
	- Default value is the current year.
	- From and To dates are disabled.  If visible, values will be set to the first and last days of the selected year.
	- Range is from 0 AD to 9999 AD - as long as calendar supports it.
- When Date Range is selected, the user can select the inclusive from and to dates:
	- Year selector is disabled.  If visible, when the from date is changed the year will update accordingly.
	- The values will default to the first and last days of the selected year.
	- The to date cannot be before the from date.

### Option Group: Extra Rows

- Additional rows may be added to the bottom of the chart via the chart options UI.
- The user may add up to 5 additional rows to the chart by providing the label text.
- A stronger border will be displayed between dated rows and the extra rows.
- Extra rows may be reordered or deleted.

### Option Group: Extra Columns

- Additional columns may be added to the right of the chart via the chart options UI.
- The user may add up to 5 additional columns to the chart by providing the label text.
- A stronger border will be displayed between dated columns and the extra columns.
- Extra columns may be reordered or deleted.

