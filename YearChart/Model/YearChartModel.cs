/**
 * Copyright 2009-2026 Simon J. Williams.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * Kajabity is a trade mark of Simon J. Williams.
 * 
 * http://www.kajabity.com
 */

/*
 * Created by SharpDevelop.
 * User: simon
 * Date: 04/08/2009
 * Time: 14:21
 * 
 */
using System;
using System.Globalization;
using YearChart;

namespace YearChart.Model
{
	/// <summary>
	/// Description of YearChartModel.
	/// </summary>
	public class YearChartModel
	{
		/// <summary>
		/// A class used to provide internationalised date labels.
		/// </summary>
		private readonly DateTimeFormatInfo dateTimeInfo = DateTimeFormatInfo.GetInstance( null );

        /// <summary>
		/// The number of Months of dates - excludes headings and extra columns.
		/// </summary>
		public int NumberOfMonths { get; private set; }

        /// <summary>
		/// The number of columns of dates - includes headings and extra columns.
		/// </summary>
		public int NumberOfColumns { get; private set; }

        /// <summary>
		/// The number of rows of dates - excludes headings and extra rows.
		/// </summary>
		public int NumberOfDays { get; private set; }

        /// <summary>
		/// The number of rows of days (whether blank or not) - includes headings and extra columns.
		/// </summary>
		public int NumberOfRows { get; private set; }

        /// <summary>
		/// The matrix of rows and columns of YearChartCells - 
		/// including Headings, Days, Extra columns and some may be blank.
		/// </summary>
		public YearChartCell [,] Cells { get; private set; }

        private DayOfWeek startOfWeek;

		/// <summary>
		/// Indicates which day of the week the chart begins with.
		/// </summary>
		public DayOfWeek StartOfWeek
		{
			get => startOfWeek;
            set
			{
				if( value != startOfWeek )
				{
					//changed = true;
				}

				startOfWeek = value;
			}
		}

		/// <summary>
		/// Get or set the overall year of the model - when setting, the start and end dates
		/// are set to the first and last day of the specified year.
		/// </summary>
		public int Year
		{
			get => startDate.Year;
            set
			{
				startDate = new DateTime( value, 1, 1 );
				endDate = new DateTime( value, 12, 31 );
			}
		}

		/// <summary>
		/// This method tests if the date range represents a whole year - 1st January to 31st December.
		/// Can be used to determine whether to select the 'Year' or 'Date Range' radio button.
		/// </summary>
		public bool IsWholeYear
		{
			get
			{
				if( startDate.Year == endDate.Year && startDate.Month == 1 && startDate.Day == 1 &&
				   endDate.Month == 12 && endDate.Day == 31 )
				{
					return true;
				}
				
				return false;
			}
		}

		private DateTime startDate;
		
		/// <summary>
		/// The starting date for the YearChart.
		/// Must be less than the EndDate.
		/// </summary>
		public DateTime StartDate
		{
			get => startDate;
            set => startDate = value;
        }

		private DateTime endDate;
		
		/// <summary>
		/// The end date for the YearChart.
		/// Must be greater than the StartDate.
		/// </summary>
		public DateTime EndDate
		{
			get => endDate;
            set => endDate = value;
        }

        /// <summary>
		/// Determines if the full names of Weekdays and Months will be shown (false) or 
		/// an abbreviated name (true).
		/// </summary>
		public bool Abbreviate { get; set; }

        /// <summary>
		/// The title of the YearChart - displayed at the top.
		/// </summary>
		public string Title { get; set; }

        /// <summary>
		/// A set of zero or more additional rows to be shown at the bottom of the chart.  Each entry should
		/// be a HeadingCell containing the heading for the row.
		/// </summary>
		public YearChartCell[] ExtraRows { get; set; }

        /// <summary>
		/// A set of zero or more additional columns to be shown to the right of the chart.  Each entry should
		/// be a HeadingCell containing the heading for the column.
		/// </summary>
		public YearChartCell[] ExtraColumns { get; set; }

        /// <summary>
		/// Construct the model setting the year to the current year.
		/// </summary>
		public YearChartModel()
		{
			var now = DateTime.Now;
			Year = now.Year;
			startOfWeek = DayOfWeek.Monday;
			Title = "YearChart";
			ExtraRows = [];
			ExtraColumns = [];
			Abbreviate = false;
		}

		/// <summary>
		/// Call this method to regenerate the matrix using the current settings.
		/// </summary>
		public void Update()
		{
#if DEBUG
			var start = YearChartDiagnostics.StartTimer();
#endif
			CalculateSize();
			BuildMatrix();
#if DEBUG
			YearChartDiagnostics.WriteElapsed(
				$"model update ({NumberOfColumns} columns, {NumberOfRows} rows)",
				start);
#endif
		}

		
		/// <summary>
		/// This method calculates the number of rows and columns in the chart - including headings and extra rows/columns.
		/// </summary>
		private void CalculateSize()
		{
			NumberOfMonths = 0;
			NumberOfDays = 0;

			// Get the first day of the month.
			var today = new DateTime( startDate.Year, startDate.Month, 1 );

			while( today <= endDate )
			{
				var dow = startOfWeek;
				NumberOfMonths++;

				var nDays = 0;
				
				//	Skip to right day of the week.
				while( dow != today.DayOfWeek )
				{
					nDays ++;
					
					dow ++;
					if( dow > DayOfWeek.Saturday ) {
						dow = DayOfWeek.Sunday;
					}
				}

				// Skip days before the first day.
				while( today < startDate )
				{
					nDays ++;
					
					dow ++;
					if( dow > DayOfWeek.Saturday ) {
						dow = DayOfWeek.Sunday;
					}
					
					today = today.AddDays( 1 );
				}
				
				// Add days till the end of the month or end date.
				do
				{
					nDays ++;
					
					dow ++;
					if( dow > DayOfWeek.Saturday ) {
						dow = DayOfWeek.Sunday;
					}
					
					today = today.AddDays( 1 );
				}
				while( (today.Day > 1) && (today <= endDate) );

				// Store the max number of days.
				if( nDays > NumberOfDays )
				{
					NumberOfDays = nDays;
				}
			}

			//	Now include the heading and extxra rows and columns.
			NumberOfColumns = NumberOfMonths + 1 + ExtraColumns.Length;
			NumberOfRows = NumberOfDays + 1 + ExtraRows.Length;
		}

		/// <summary>
		/// This method builds the matrix of cells filling in the headings, blank cells, days
		/// and any extra rows or columns.
		/// </summary>
		private void BuildMatrix()
		{
			//	Allocate the matrix.  Null entries are blank.
			Cells = new YearChartCell[ NumberOfColumns, NumberOfRows ];

			var dow = startOfWeek;
			int row;
			
			//	Top Left corner.
			Cells[ 0, 0 ] = new HeadingCell( " " );

			for( row = 1; row <= NumberOfDays; row++ )
			{
				Cells[ 0, row ] = new HeadingCell( GetDayName( dow ++ ) );
				
				if( dow > DayOfWeek.Saturday ) {
					dow = DayOfWeek.Sunday;
				}
			}
			
			// Get the first day of the month.
			var today = new DateTime( startDate.Year, startDate.Month, 1 );
			var col = 1;

			while( today <= endDate )
			{
				Cells[ col, 0 ] = new HeadingCell( GetMonthName( today.Month ) );

				dow = startOfWeek;

				row = 1;
				
				//	Skip to right day of the week.
				while( dow != today.DayOfWeek )
				{
					Cells[ col, row++ ] = null;

					dow ++;
					if( dow > DayOfWeek.Saturday ) {
						dow = DayOfWeek.Sunday;
					}
				}

				// Skip days before the first day.
				while( today < startDate )
				{
					Cells[ col, row++ ] = null;

					dow ++;
					if( dow > DayOfWeek.Saturday ) {
						dow = DayOfWeek.Sunday;
					}
					
					today = today.AddDays( 1 );
				}
				
				// Add days till the end of the month or end date.
				do
				{
					Cells[ col, row++ ] = new DayCell( new DateTime( today.Ticks ) );

					dow ++;
					if( dow > DayOfWeek.Saturday ) {
						dow = DayOfWeek.Sunday;
					}
					
					today = today.AddDays( 1 );
				}
				while( (today.Day > 1) && (today <= endDate) );

				// Store the max number of days.
				while( row <= NumberOfDays )
				{
					Cells[ col, row++ ] = null;
				}

				col++;
			}
			
			//	Add the Extra Columns.
			foreach (var t in ExtraColumns)
            {
                Cells[ col, 0 ] = t;
				
                for( row = 1; row < NumberOfRows; row++ )
                {
                    Cells[ col, row ] = new ExtraCell();
                }

                col++;
            }

			// Add the extra rows.
			row = NumberOfRows - ExtraRows.Length;
			foreach (var t in ExtraRows)
            {
                Cells[ 0, row ] = t;
				
                for( col = 1; col < NumberOfColumns; col++ )
                {
                    Cells[ col, row ] = new ExtraCell();
                }

                row++;
            }
		}

		/// <summary>
		/// Returns the internationalised name of the month dependent on the setting of the 'Abbreviate' flag.
		/// </summary>
		/// <param name="month">The month number - 1 to 12.</param>
		/// <returns>The internationalised name of the month, short or long.</returns>
		private string GetMonthName( int month )
        {
            return Abbreviate ? dateTimeInfo.GetAbbreviatedMonthName(month) : dateTimeInfo.GetMonthName( month );
        }

		/// <summary>
		/// Returns the internationalised name of the weekday dependent on the setting of the 'Abbreviate' flag.
		/// </summary>
		/// <param name="day">The weekday number - 1 to 7.</param>
		/// <returns>The internationalised name of the weekday, short or long.</returns>
		private string GetDayName( DayOfWeek day )
        {
            return Abbreviate ? dateTimeInfo.GetAbbreviatedDayName( day ) : dateTimeInfo.GetDayName( day );
        }
	}
}
