/**
 * Copyright 2009-14 Williams Technologies Limited.
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

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

            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.Margins = new Margins( 50, 50, 50, 50 );
        }

        protected override void OnResize( EventArgs ev )
        {
            base.OnResize( ev );
            this.toolStripContainer.ContentPanel.Invalidate( ClientRectangle );
        }

        private void doOptionsDialog()
        {
            using( YearChartOptionsForm dialog = new YearChartOptionsForm() )
            {
                dialog.ChartTitle = yearChartPanel.Title;
                dialog.IsWholeYear = yearChartPanel.IsWholeYear;
                if( yearChartPanel.IsWholeYear )
                {
                    dialog.Year = yearChartPanel.Year;
                }
                else
                {
                    dialog.StartDate = yearChartPanel.StartDate;
                    dialog.EndDate = yearChartPanel.EndDate;
                }

                dialog.ExtraRows = yearChartPanel.ExtraRows;
                dialog.ExtraColumns = yearChartPanel.ExtraColumns;
                dialog.WeekStartDay = yearChartPanel.WeekStartDay;
                dialog.Abbreviate = yearChartPanel.Abbreviate;
                dialog.HeadingColor = yearChartPanel.HeadingColor;

                DialogResult result = dialog.ShowDialog( this );
                if( result == DialogResult.OK )
                {
                    yearChartPanel.Title = dialog.ChartTitle;
                    printDocument.DocumentName = dialog.ChartTitle;

                    if( dialog.IsWholeYear )
                    {
                        yearChartPanel.Year = dialog.Year;
                    }
                    else
                    {
                        yearChartPanel.StartDate = dialog.StartDate;
                        yearChartPanel.EndDate = dialog.EndDate;
                    }

                    yearChartPanel.ExtraRows = dialog.ExtraRows;
                    yearChartPanel.ExtraColumns = dialog.ExtraColumns;
                    yearChartPanel.WeekStartDay = dialog.WeekStartDay;
                    yearChartPanel.Abbreviate = dialog.Abbreviate;

                    yearChartPanel.Calculate();
                    this.Invalidate();
                }
            }
        }

        void PageSetupToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            pageSetupDialog.ShowDialog();
        }

        void PrintPreviewToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Failed to print Year Chart:\n" + ex.Message, "Year Chart", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void printDocument_PrintPage( object sender, PrintPageEventArgs ev )
        {
            Debug.WriteLine( "PageBounds    " + ev.PageBounds );
            Debug.WriteLine( "PrintableArea " + ev.PageSettings.PrintableArea );
            Debug.WriteLine( "MarginBounds  " + ev.MarginBounds );
            Debug.WriteLine( "Hard Margin   " + ev.PageSettings.HardMarginX + ", " + ev.PageSettings.HardMarginY + " Landscape? " + ev.PageSettings.Landscape );
            Debug.WriteLine( "" );

            bool changedMargins = false;

            int Left = ev.MarginBounds.Left;
            int Top = ev.MarginBounds.Top;
            int Right = ev.MarginBounds.Right;
            int Bottom = ev.MarginBounds.Bottom;

            int MinLeft;
            int MinTop;
            int MaxRight;
            int MaxBottom;

            if( ev.PageSettings.Landscape )
            {
                MinLeft = (int) ( ev.PageSettings.PrintableArea.Top + 0.5 );
                MinTop = (int) ( ev.PageSettings.PrintableArea.Left + 0.5 );
                MaxRight = (int) ( ev.PageSettings.PrintableArea.Bottom - 0.5 );
                MaxBottom = (int) ( ev.PageSettings.PrintableArea.Right - 0.5 );
            }
            else
            {
                MinLeft = (int) ( ev.PageSettings.PrintableArea.Left + 0.5 );
                MinTop = (int) ( ev.PageSettings.PrintableArea.Top + 0.5 );
                MaxRight = (int) ( ev.PageSettings.PrintableArea.Right - 0.5 );
                MaxBottom = (int) ( ev.PageSettings.PrintableArea.Bottom - 0.5 );
            }

            Debug.WriteLine( "Min Margins: Left " + MinLeft + ", Top " + MinTop + ", Right " + ( ev.PageBounds.Right - MaxRight ) + ", Bottom " + ( ev.PageBounds.Bottom - MaxBottom ) );

            if( Left < MinLeft )
            {
                changedMargins = true;
                Left = MinLeft;
            }

            if( Top < MinTop )
            {
                changedMargins = true;
                Top = MinTop;
            }

            if( Right > MaxRight )
            {
                changedMargins = true;
                Right = MaxRight;
            }

            if( Bottom > MaxBottom )
            {
                changedMargins = true;
                Bottom = MaxBottom;
            }

            if( changedMargins )
            {
                printDocument.DefaultPageSettings.Margins = new Margins( Left, ( ev.PageBounds.Right - Right ), Top, ( ev.PageBounds.Bottom - Bottom ) );
                Debug.WriteLine( "Adjusted Margins " + printDocument.DefaultPageSettings.Margins );
                MessageBox.Show( "Page Margins set outside printable area - adjusted to fit.", "Kajabity Year Chart" );
            }

            Rectangle MarginBounds = new Rectangle( Left, Top, ( Right - Left ), ( Bottom - Top ) );

            bool preview = printDocument.PrintController.IsPreview;
            if( !preview )
            {
                MarginBounds.Offset( -(int) ev.PageSettings.HardMarginX, -(int) ev.PageSettings.HardMarginY );
            }

            Debug.WriteLine( "MarginBounds (2) " + MarginBounds + ": Changed? " + changedMargins + ": Preview? " + preview );
            Debug.WriteLine( "" );

            yearChartPanel.Draw( ev.Graphics, MarginBounds );

            //			Pen penMargin = new Pen( Color.Red );
            //			ev.Graphics.DrawRectangle( penMargin, MarginBounds );
            //			Rectangle printableRect = new Rectangle( MinLeft, MinTop, (MaxRight - MinLeft), (MaxBottom - MinTop) );
            //			ev.Graphics.DrawRectangle( penMargin, printableRect );

            ev.HasMorePages = false;
        }

        void PrintToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            if( printDialog.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    printDocument.Print();
                }
                catch( Exception ex )
                {
                    MessageBox.Show( "Failed to print Year Chart:\n" + ex.Message, "Year Chart", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        void ExitToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            Close();
        }

        void OptionsToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            doOptionsDialog();
        }

        void ContentsToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            Help.ShowHelp( this, "YearChart.chm", HelpNavigator.TableOfContents );
        }

        void IndexToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            Help.ShowHelpIndex( this, "YearChart.chm" );
        }

        void SearchToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            Help.ShowHelp( this, "YearChart.chm", HelpNavigator.Find );
        }

        void AboutToolStripMenuItemClick( object sender, System.EventArgs e )
        {
            AboutForm dialog = new AboutForm();

            DialogResult result = dialog.ShowDialog( this );
        }

        void YearChartPanelDoubleClick( object sender, EventArgs e )
        {
            doOptionsDialog();
        }

        /// <summary>
        /// Handles Save As (Export) HTML file command - select a filename (default "YearChart.html") and write
        /// the current chart into it as an HTML table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToHTMLToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using( SaveFileDialog dialog = new SaveFileDialog() )
            {
                dialog.DefaultExt = "html";
                dialog.Filter = "HTML files (*.html, *.htm)|*.html;*.htm|All files (*.*)|*.*";
                dialog.FileName = "YearChart.html";

                DialogResult result = dialog.ShowDialog( this );
                if( result == DialogResult.OK )
                {
                    Debug.WriteLine( "Export as HTML to file: " + dialog.FileName );

                    SaveAsHtml( dialog.FileName );
                }
            }
        }

        /// <summary>
        /// Saves a copy of the Year Chart in HTML format file.
        /// </summary>
        /// <param name="filename">The name and path of the HTML file to be written.</param>
        private void SaveAsHtml( string filename )
        {
            using( FileStream outStream = File.OpenWrite( filename ) )
            {
                outStream.SetLength( 0L );

                YearChartHtmlWriter writer = new YearChartHtmlWriter( yearChartPanel.Model );
                writer.Write( outStream );
            }
        }
    }
}
