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
        private MainWindowSettings mainWindowSettings;

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            yearChartHost.PageSettings = printDocument.DefaultPageSettings;

            RestoreMainWindowSettings();
        }

        protected override void OnResize(EventArgs ev)
        {
            base.OnResize(ev);
            this.toolStripContainer.ContentPanel.Invalidate(ClientRectangle);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveMainWindowSettings();
            base.OnFormClosing(e);
        }

        private void RestoreMainWindowSettings()
        {
            mainWindowSettings = MainWindowSettings.Load();

            if (!mainWindowSettings.HasBounds)
            {
                return;
            }

            Rectangle bounds = EnsureVisibleBounds(mainWindowSettings.Bounds);

            StartPosition = FormStartPosition.Manual;
            Bounds = bounds;

            if (mainWindowSettings.WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void SaveMainWindowSettings()
        {
            if (mainWindowSettings == null)
            {
                mainWindowSettings = new MainWindowSettings();
            }

            mainWindowSettings.Bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
            mainWindowSettings.WindowState = WindowState == FormWindowState.Minimized ? FormWindowState.Normal : WindowState;
            mainWindowSettings.Save();
        }

        private static Rectangle EnsureVisibleBounds(Rectangle bounds)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(bounds))
                {
                    return bounds;
                }
            }

            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            Size size = new Size(
                Math.Min(bounds.Width, workingArea.Width),
                Math.Min(bounds.Height, workingArea.Height));

            return new Rectangle(workingArea.Location, size);
        }

        private void doOptionsDialog()
        {
            using (YearChartOptionsForm dialog = new YearChartOptionsForm())
            {
                YearChartPanel yearChartPanel = yearChartHost.ChartPanel;

                dialog.ChartTitle = yearChartPanel.Title;
                dialog.IsWholeYear = yearChartPanel.IsWholeYear;
                if (yearChartPanel.IsWholeYear)
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

                DialogResult result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    yearChartPanel.Title = dialog.ChartTitle;
                    printDocument.DocumentName = dialog.ChartTitle;

                    if (dialog.IsWholeYear)
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
                    yearChartHost.InvalidateChart();
                    statusLabel.Text = "Ready";
                }
            }
        }

        private void PageSetupToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                yearChartHost.PageSettings = printDocument.DefaultPageSettings;
            }
        }

        private void PrintPreviewToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to print YearChart:\n" + ex.Message, "YearChart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Debug.WriteLine("PageBounds    " + ev.PageBounds);
            Debug.WriteLine("PrintableArea " + ev.PageSettings.PrintableArea);
            Debug.WriteLine("MarginBounds  " + ev.MarginBounds);
            Debug.WriteLine("Hard Margin   " + ev.PageSettings.HardMarginX + ", " + ev.PageSettings.HardMarginY + " Landscape? " + ev.PageSettings.Landscape);
            Debug.WriteLine("");

            Rectangle marginBounds = ev.MarginBounds;

            bool preview = printDocument.PrintController.IsPreview;
            if (!preview)
            {
                marginBounds.Offset(-(int)ev.PageSettings.HardMarginX, -(int)ev.PageSettings.HardMarginY);
            }

            Debug.WriteLine("MarginBounds (2) " + marginBounds + ": Preview? " + preview);
            Debug.WriteLine("");

            yearChartHost.Draw(ev.Graphics, marginBounds);

            //			Pen penMargin = new Pen( Color.Red );
            //			ev.Graphics.DrawRectangle( penMargin, MarginBounds );
            //			Rectangle printableRect = new Rectangle( MinLeft, MinTop, (MaxRight - MinLeft), (MaxBottom - MinTop) );
            //			ev.Graphics.DrawRectangle( penMargin, printableRect );

            ev.HasMorePages = false;
        }

        private void PrintToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to print YearChart:\n" + ex.Message, "YearChart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExitToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void OptionsToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            doOptionsDialog();
        }

        private void ContentsToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Help.ShowHelp(this, "YearChart.chm", HelpNavigator.TableOfContents);
        }

        private void IndexToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Help.ShowHelpIndex(this, "YearChart.chm");
        }

        private void SearchToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Help.ShowHelp(this, "YearChart.chm", HelpNavigator.Find);
        }

        private void AboutToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            AboutForm dialog = new AboutForm();

            DialogResult result = dialog.ShowDialog(this);
        }

        private void YearChartHostChartDoubleClick(object sender, EventArgs e)
        {
            doOptionsDialog();
        }

        private void StretchViewButtonClick(object sender, EventArgs e)
        {
            SelectView(ChartViewMode.Stretch);
        }

        private void PageLayoutViewButtonClick(object sender, EventArgs e)
        {
            SelectView(ChartViewMode.PageLayout);
        }

        private void FitWindowToolStripMenuItemClick(object sender, EventArgs e)
        {
            SelectView(ChartViewMode.Stretch);
        }

        private void PrintLayoutToolStripMenuItemClick(object sender, EventArgs e)
        {
            SelectView(ChartViewMode.PageLayout);
        }

        private void SelectView(ChartViewMode viewMode)
        {
            if (viewMode == ChartViewMode.PageLayout)
            {
                yearChartHost.PageSettings = printDocument.DefaultPageSettings;
            }

            yearChartHost.ViewMode = viewMode;
            stretchViewButton.Checked = viewMode == ChartViewMode.Stretch;
            pageLayoutViewButton.Checked = viewMode == ChartViewMode.PageLayout;
            fitWindowToolStripMenuItem.Checked = viewMode == ChartViewMode.Stretch;
            printLayoutToolStripMenuItem.Checked = viewMode == ChartViewMode.PageLayout;
            statusLabel.Text = viewMode == ChartViewMode.Stretch ? "View: Stretch to Fit" : "View: Page Layout";
        }

        /// <summary>
        /// Handles Save As (Export) HTML file command - select a filename (default "YearChart.html") and write
        /// the current chart into it as an HTML table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.DefaultExt = "html";
                dialog.Filter = "HTML files (*.html, *.htm)|*.html;*.htm|All files (*.*)|*.*";
                dialog.FileName = "YearChart.html";

                DialogResult result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    Debug.WriteLine("Export as HTML to file: " + dialog.FileName);

                    SaveAsHtml(dialog.FileName);
                }
            }
        }

        /// <summary>
        /// Saves a copy of the YearChart in HTML format file.
        /// </summary>
        /// <param name="filename">The name and path of the HTML file to be written.</param>
        private void SaveAsHtml(string filename)
        {
            using (FileStream outStream = File.OpenWrite(filename))
            {
                outStream.SetLength(0L);

                YearChartHtmlWriter writer = new YearChartHtmlWriter(yearChartHost.ChartPanel.Model);
                writer.Write(outStream);
            }
        }
    }
}
