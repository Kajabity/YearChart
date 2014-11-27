/**
 * Copyright 2009 Williams Technologies Limtied.
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
 * Kajbity is a trademark of Williams Technologies Limited.
 * 
 * http://www.kajabity.com
 */

using System;
using System.Diagnostics;

namespace YearChart
{
	/// <summary>
	/// Summary description for YearData.
	/// </summary>
	public class YearData
	{
		private static string []months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

		private string title;
		private DateTime startDate;
		private DateTime endDate;
		private string []extra = {};

		private int countWeekdays = 0;
		private int countWeekends = 0;

		//  Indicates which day of the week the chart begins with.
		private DayOfWeek firstDay = DayOfWeek.Monday;

		private bool changed = false;

		public YearDay [,]days;
		public int numColumns;
		public int numRows;

		public string[] ExtraRows
		{
			get
			{
				return extra;
			}
			set
			{
				extra = value;
				changed = true;
			}
		}

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}

		public int Year
		{
			get
			{
				return startDate.Year;
			}
			set
			{
				startDate = new DateTime( value, 1, 1 );
				endDate = new DateTime( value + 1, 1, 1 );

				Debug.WriteLine( "Start " + startDate + ", End " + endDate );
				Debug.WriteLine( "First Day " + firstDay + ", Start Day " + startDate.DayOfWeek );

				changed = true;
			}
		}

		public DayOfWeek WeekStartDay
		{
			get
			{
				return firstDay;
			}
			set
			{
				firstDay = value;
				changed = true;
			}
		}

		public YearData()
		{
			DateTime today = DateTime.Now;
			Debug.WriteLine( "Today " + today );

			Year = today.Year;
			Title = "Year Chart " + Year;

			changed = true;
		}

		public void Calculate()
		{
			if( changed )
			{
				int numMonths = (endDate.Year * 12 + endDate.Month) -
					(startDate.Year * 12 + startDate.Month);
				if( endDate.Day > 1 )
				{
					numMonths += 1;
				}

				int numDayRows = 6 + 31; //Enough!
				numColumns = 1 + numMonths;
				numRows = 1             //  Headings
					+ numDayRows    //  5 weeks - enough?
					+ extra.Length; //  Extra columns.

				Debug.WriteLine( "Rows " + numRows + ", Columns " + numColumns );
				days = new YearDay[ numRows, numColumns ];
				days[ 0, 0 ] = new YearDay( YearDayType.Heading, "" );


				countWeekdays = 0;
				countWeekends = 0;

				int month = 1;
				DateTime dt = startDate;
				int index = 1 + (7 - (int) firstDay + (int) dt.DayOfWeek) % 7;
				while( dt < endDate )
				{
					if( (dt.DayOfWeek == DayOfWeek.Saturday) || 
						(dt.DayOfWeek == DayOfWeek.Sunday) )
					{
						days[ index, month ] = 
							new YearDay( YearDayType.Weekend, dt.Day.ToString() );
						countWeekends++;
					}
					else
					{
						days[ index, month ] = 
							new YearDay( YearDayType.Weekday, dt.Day.ToString() );
						countWeekdays++;
					}

					dt = dt.AddDays( 1 );
					if( dt.Day == 1 )
					{
						month++;
						index = 1 + (7 - (int) firstDay + (int) dt.DayOfWeek) % 7;
					}
					else
					{
						index++;
                    
					}
				}

				Debug.WriteLine( "Weekdays " + countWeekdays + ", Weekends " + countWeekends );

				//  Fill in the Headings.
				for( int row = 1; row <= numDayRows; row++ )
				{
					DayOfWeek dow = (DayOfWeek) ((int) ((row - 1) + firstDay) % 7);
					days[ row, 0 ] = new YearDay( YearDayType.Heading, dow.ToString() );
				}

				int nExtra = 0;
				for( int row = numDayRows + 1; row < numRows; row++ )
				{
					days[ row, 0 ] = new YearDay( YearDayType.Heading, extra[ nExtra++ ] );

					for( int col = 1; col < numColumns; col++ )
					{
						days[ row, col ] = new YearDay( YearDayType.Weekday, "" );
					}
				}

				int m = startDate.Month;
				for( int col = 1; col < numColumns; col++ )
				{
					days[ 0, col ] = new YearDay( YearDayType.Heading, months[ (m + col - 2) % 12 ] );
				}
			}
		}
	}
}
