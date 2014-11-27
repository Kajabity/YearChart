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
 * Date: 09/01/2009
 * Time: 15:19
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.Diagnostics;

namespace YearChart
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            printDocument.DefaultPageSettings.Landscape = true;
			printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
			printDocument.DefaultPageSettings.Margins = new Margins( 50, 50, 50, 50 );
		}

		private void InitialisePrintSettings()
		{
			//System.Threading.Thread.CurrentThread.CurrentCulture
		}
        protected override void OnResize( EventArgs ev ) 
        {
            base.OnResize( ev );
            this.toolStripContainer.ContentPanel.Invalidate( ClientRectangle );
        }

        private void doOptionsDialog()
        {
			YearChartOptionsForm dialog = new YearChartOptionsForm();
			dialog.ChartTitle = yearChartPanel.Title;
			dialog.Year = yearChartPanel.Year;
			dialog.ExtraRows = yearChartPanel.ExtraRows;
			dialog.WeekStartDay  = yearChartPanel.WeekStartDay;

			DialogResult result = dialog.ShowDialog( this );
			if( result == DialogResult.OK )
			{
				yearChartPanel.Title		= dialog.ChartTitle;
				printDocument.DocumentName = dialog.ChartTitle;
				
				yearChartPanel.Year			= dialog.Year;
				yearChartPanel.ExtraRows	= dialog.ExtraRows;
				yearChartPanel.WeekStartDay	= dialog.WeekStartDay;

				yearChartPanel.Calculate();
				this.Invalidate();
			}
        }
	}
}
