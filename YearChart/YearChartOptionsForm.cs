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

/*
 * Created by SharpDevelop.
 * User: simon
 * Date: 10/01/2009
 */
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using YearChart.Model;

namespace YearChart
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class YearChartOptionsForm : Form
	{
		
		public string ChartTitle
		{
			get
			{
				return textTitle.Text;
			}
			set
			{
				textTitle.Text = value;
			}
		}
		
		public int Year
		{
			get
			{
				return (int) numericYear.Value;
			}
			set
			{
				numericYear.Value = value;
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
				return radioWholeYear.Checked;
			}
			set
			{
				radioWholeYear.Checked = value;
				radioDateRange.Checked = !value;
			}
		}

		public DateTime StartDate
		{
			get
			{
				return dateFrom.Value;
			}
			set
			{
				dateFrom.Value = value;
			}
		}

		public DateTime EndDate
		{
			get
			{
				return dateTo.Value;
			}
			set
			{
				dateTo.Value = value;
			}
		}

		public bool Abbreviate
		{
			get
			{
				return checkAbbreviate.Checked;
			}
			set
			{
				checkAbbreviate.Checked = value;
			}
		}

		public ArrayList extraRows = new ArrayList();

		public YearChartCell[] ExtraRows
		{
			get
			{
				YearChartCell []extra = new YearChartCell[ listExtraRows.Items.Count ];
				for( int i = 0; i < extra.Length; i++ )
				{
					extra[ i ] = new HeadingCell( (string) listExtraRows.Items[ i ] ) ;
				}

				return extra;
			}
			set
			{
				listExtraRows.Items.Clear();
				
				if( value != null )
				{
					for( int i = 0; i < value.Length; i++ )
					{
						extraRows.Add( value[ i ].text );
						listExtraRows.Items.Add( value[ i ].text );
					}
				}

				enableExtraRowButtons();
			}
		}

		public ArrayList extraColumns = new ArrayList();

		public YearChartCell[] ExtraColumns
		{
			get
			{
				YearChartCell []extra = new YearChartCell[ listExtraColumns.Items.Count ];
				for( int i = 0; i < extra.Length; i++ )
				{
					extra[ i ] = new HeadingCell( (string) listExtraColumns.Items[ i ] ) ;
				}

				return extra;
			}
			set
			{
				listExtraColumns.Items.Clear();
				
				if( value != null )
				{
					for( int i = 0; i < value.Length; i++ )
					{
						extraColumns.Add( value[ i ].text );
						listExtraColumns.Items.Add( value[ i ].text );
					}
				}
				
				enableExtraColumnButtons();
			}
		}
		
		private Color m_colorHeading = Color.Yellow;
		
		public Color HeadingColor
		{
			get { return m_colorHeading; }
			set { m_colorHeading = value; Invalidate(); }
		}

		public DayOfWeek WeekStartDay
		{
			get
			{
				return (DayOfWeek) comboWeekStartDay.SelectedIndex;
			}
			set
			{
				comboWeekStartDay.SelectedIndex = (int) value;
			}
		}

		
		public YearChartOptionsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
	}
}
