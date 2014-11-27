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

		public ArrayList extraRowStrings = new ArrayList();
		
		public string[] ExtraRows
		{
			get
			{
				return (string []) extraRowStrings.ToArray( typeof (string) );
					
//				string []extra = new String[ listExtraRows.Items.Count ];
//				for( int i = 0; i < extra.Length; i++ )
//				{
//					extra[ i ] = (string) listExtraRows.Items[ i ];
//				}
//
//				return extra;
			}
			set
			{
				listExtraRows.Items.Clear();
				
				for( int i = 0; i < value.Length; i++ )
				{
					addLabel( value[ i ] );
				}
			}
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
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
