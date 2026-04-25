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
 * Date: 10/01/2009
 */
using System;
using System.Collections;
using System.ComponentModel;
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

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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
		
		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public Color HeadingColor
		{
			get { return m_colorHeading; }
			set { m_colorHeading = value; Invalidate(); }
		}

		[DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
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
