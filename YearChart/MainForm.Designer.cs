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
 */


namespace YearChart
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		private YearChart.YearChartHost yearChartHost;
		
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;
		private System.Drawing.Printing.PrintDocument printDocument;
		
		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fitWindowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printLayoutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private YearChart.ChartViewToolStripButton stretchViewButton;
        private YearChart.ChartViewToolStripButton pageLayoutViewButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            exportToHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fitWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printDocument = new System.Drawing.Printing.PrintDocument();
            toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            stretchViewButton = new ChartViewToolStripButton();
            pageLayoutViewButton = new ChartViewToolStripButton();
            yearChartHost = new YearChartHost();
            helpProvider = new System.Windows.Forms.HelpProvider();
            pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            printDialog = new System.Windows.Forms.PrintDialog();
            menuStrip.SuspendLayout();
            toolStripContainer.BottomToolStripPanel.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            menuStrip.Size = new System.Drawing.Size(1248, 38);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { pageSetupToolStripMenuItem, printPreviewToolStripMenuItem, printToolStripMenuItem, toolStripSeparator1, exportToHTMLToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(62, 34);
            fileToolStripMenuItem.Text = "&File";
            // 
            // pageSetupToolStripMenuItem
            // 
            pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            pageSetupToolStripMenuItem.Size = new System.Drawing.Size(276, 40);
            pageSetupToolStripMenuItem.Text = "Page Set&up...";
            pageSetupToolStripMenuItem.ToolTipText = "Change the layout of the printed page - margins and orientation.";
            pageSetupToolStripMenuItem.Click += PageSetupToolStripMenuItemClick;
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new System.Drawing.Size(276, 40);
            printPreviewToolStripMenuItem.Text = "Print Pre&view";
            printPreviewToolStripMenuItem.ToolTipText = "Shows how the chart will look when printed.";
            printPreviewToolStripMenuItem.Click += PrintPreviewToolStripMenuItemClick;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            printToolStripMenuItem.Size = new System.Drawing.Size(276, 40);
            printToolStripMenuItem.Text = "&Print...";
            printToolStripMenuItem.ToolTipText = "Print the YearChart to your selected printer.";
            printToolStripMenuItem.Click += PrintToolStripMenuItemClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(273, 6);
            // 
            // exportToHTMLToolStripMenuItem
            // 
            exportToHTMLToolStripMenuItem.Name = "exportToHTMLToolStripMenuItem";
            exportToHTMLToolStripMenuItem.Size = new System.Drawing.Size(276, 40);
            exportToHTMLToolStripMenuItem.Text = "Export to HTML";
            exportToHTMLToolStripMenuItem.Click += exportToHTMLToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(273, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(276, 40);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.ToolTipText = "Closes the appliction.";
            exitToolStripMenuItem.Click += ExitToolStripMenuItemClick;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { fitWindowToolStripMenuItem, printLayoutToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(75, 34);
            viewToolStripMenuItem.Text = "&View";
            // 
            // fitWindowToolStripMenuItem
            // 
            fitWindowToolStripMenuItem.Checked = true;
            fitWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            fitWindowToolStripMenuItem.Name = "fitWindowToolStripMenuItem";
            fitWindowToolStripMenuItem.Size = new System.Drawing.Size(242, 40);
            fitWindowToolStripMenuItem.Text = "&Fit Window";
            fitWindowToolStripMenuItem.Click += FitWindowToolStripMenuItemClick;
            // 
            // printLayoutToolStripMenuItem
            // 
            printLayoutToolStripMenuItem.Name = "printLayoutToolStripMenuItem";
            printLayoutToolStripMenuItem.Size = new System.Drawing.Size(242, 40);
            printLayoutToolStripMenuItem.Text = "&Print Layout";
            printLayoutToolStripMenuItem.Click += PrintLayoutToolStripMenuItemClick;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(78, 34);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(219, 40);
            optionsToolStripMenuItem.Text = "&Options...";
            optionsToolStripMenuItem.ToolTipText = "Change the settings for the chart including year and title.";
            optionsToolStripMenuItem.Click += OptionsToolStripMenuItemClick;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { contentsToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(74, 34);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            contentsToolStripMenuItem.Text = "&Contents";
            contentsToolStripMenuItem.ToolTipText = "Open the Help window on the Contents page.";
            contentsToolStripMenuItem.Click += ContentsToolStripMenuItemClick;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(312, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItemClick;
            // 
            // printDocument
            // 
            printDocument.DocumentName = "YearChart document";
            printDocument.PrintPage += printDocument_PrintPage;
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            toolStripContainer.BottomToolStripPanel.Controls.Add(statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            toolStripContainer.ContentPanel.Controls.Add(yearChartHost);
            toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1248, 868);
            toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            toolStripContainer.Location = new System.Drawing.Point(0, 0);
            toolStripContainer.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            toolStripContainer.Name = "toolStripContainer";
            toolStripContainer.Size = new System.Drawing.Size(1248, 946);
            toolStripContainer.TabIndex = 1;
            toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            toolStripContainer.TopToolStripPanel.Controls.Add(menuStrip);
            // 
            // statusStrip
            // 
            statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            statusStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel, stretchViewButton, pageLayoutViewButton });
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(1248, 40);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(1169, 31);
            statusLabel.Spring = true;
            statusLabel.Text = "Ready";
            statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stretchViewButton
            // 
            stretchViewButton.AutoSize = false;
            stretchViewButton.Checked = true;
            stretchViewButton.CheckState = System.Windows.Forms.CheckState.Checked;
            stretchViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            stretchViewButton.Name = "stretchViewButton";
            stretchViewButton.Size = new System.Drawing.Size(32, 36);
            stretchViewButton.Text = "Stretch to Fit";
            stretchViewButton.ToolTipText = "Stretch to Fit";
            stretchViewButton.Click += StretchViewButtonClick;
            // 
            // pageLayoutViewButton
            // 
            pageLayoutViewButton.AutoSize = false;
            pageLayoutViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            pageLayoutViewButton.Icon = ChartViewButtonIcon.PageLayout;
            pageLayoutViewButton.Name = "pageLayoutViewButton";
            pageLayoutViewButton.Size = new System.Drawing.Size(32, 36);
            pageLayoutViewButton.Text = "Page Layout";
            pageLayoutViewButton.ToolTipText = "Page Layout";
            pageLayoutViewButton.Click += PageLayoutViewButtonClick;
            // 
            // yearChartHost
            // 
            yearChartHost.AutoScroll = true;
            yearChartHost.BackColor = System.Drawing.Color.White;
            yearChartHost.Dock = System.Windows.Forms.DockStyle.Fill;
            yearChartHost.Location = new System.Drawing.Point(0, 0);
            yearChartHost.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            yearChartHost.Name = "yearChartHost";
            helpProvider.SetShowHelp(yearChartHost, true);
            yearChartHost.Size = new System.Drawing.Size(1248, 868);
            yearChartHost.TabIndex = 0;
            yearChartHost.ChartDoubleClick += YearChartHostChartDoubleClick;
            // 
            // helpProvider
            // 
            helpProvider.HelpNamespace = "YearChart.chm";
            // 
            // pageSetupDialog
            // 
            pageSetupDialog.Document = printDocument;
            pageSetupDialog.EnableMetric = true;
            // 
            // printPreviewDialog
            // 
            printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Enabled = true;
            printPreviewDialog.Icon = (System.Drawing.Icon)resources.GetObject("printPreviewDialog.Icon");
            printPreviewDialog.Name = "printPreviewDialog";
            printPreviewDialog.ShowIcon = false;
            printPreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            printDialog.Document = printDocument;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1248, 946);
            Controls.Add(toolStripContainer);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            Name = "MainForm";
            Text = "Kajabity YearChart";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer.BottomToolStripPanel.PerformLayout();
            toolStripContainer.ContentPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.PerformLayout();
            toolStripContainer.ResumeLayout(false);
            toolStripContainer.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToHTMLToolStripMenuItem;
	}
}
