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
 * Date: 10/01/2009
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace YearChart
{
	partial class YearChartOptionsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelWeekStartDay;
		private System.Windows.Forms.GroupBox groupExtraRows;
		private System.Windows.Forms.TextBox textTitle;
		private System.Windows.Forms.ComboBox comboWeekStartDay;
		private System.Windows.Forms.NumericUpDown numericYear;
		private System.Windows.Forms.ListBox listExtraRows;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearChartOptionsForm));
			this.numericYear = new System.Windows.Forms.NumericUpDown();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textTitle = new System.Windows.Forms.TextBox();
			this.labelWeekStartDay = new System.Windows.Forms.Label();
			this.comboWeekStartDay = new System.Windows.Forms.ComboBox();
			this.groupExtraRows = new System.Windows.Forms.GroupBox();
			this.buttonModifyRow = new System.Windows.Forms.Button();
			this.buttonMoveRowDown = new System.Windows.Forms.Button();
			this.buttonMoveRowUp = new System.Windows.Forms.Button();
			this.textExtraRow = new System.Windows.Forms.TextBox();
			this.buttonRemoveRow = new System.Windows.Forms.Button();
			this.buttonAddRow = new System.Windows.Forms.Button();
			this.listExtraRows = new System.Windows.Forms.ListBox();
			this.labelExtraRow = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.radioWholeYear = new System.Windows.Forms.RadioButton();
			this.radioDateRange = new System.Windows.Forms.RadioButton();
			this.groupDateSelection = new System.Windows.Forms.GroupBox();
			this.dateTo = new System.Windows.Forms.DateTimePicker();
			this.dateFrom = new System.Windows.Forms.DateTimePicker();
			this.labelSelectYear = new System.Windows.Forms.Label();
			this.labelFrom = new System.Windows.Forms.Label();
			this.labelTo = new System.Windows.Forms.Label();
			this.groupChartSettings = new System.Windows.Forms.GroupBox();
			this.checkAbbreviate = new System.Windows.Forms.CheckBox();
			this.groupExtraColumns = new System.Windows.Forms.GroupBox();
			this.buttonModifyColumn = new System.Windows.Forms.Button();
			this.buttonMoveColumnDown = new System.Windows.Forms.Button();
			this.buttonMoveColumnUp = new System.Windows.Forms.Button();
			this.textExtraColumn = new System.Windows.Forms.TextBox();
			this.buttonRemoveColumn = new System.Windows.Forms.Button();
			this.buttonAddColumn = new System.Windows.Forms.Button();
			this.listExtraColumns = new System.Windows.Forms.ListBox();
			this.labelExtraColumn = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
			this.groupExtraRows.SuspendLayout();
			this.groupDateSelection.SuspendLayout();
			this.groupChartSettings.SuspendLayout();
			this.groupExtraColumns.SuspendLayout();
			this.SuspendLayout();
			// 
			// numericYear
			// 
			this.numericYear.Location = new System.Drawing.Point(6, 62);
			this.numericYear.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									0});
			this.numericYear.Name = "numericYear";
			this.numericYear.Size = new System.Drawing.Size(120, 20);
			this.numericYear.TabIndex = 2;
			this.numericYear.ValueChanged += new System.EventHandler(this.NumericYearValueChanged);
			// 
			// labelTitle
			// 
			this.labelTitle.Location = new System.Drawing.Point(6, 16);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(100, 23);
			this.labelTitle.TabIndex = 2;
			this.labelTitle.Text = "Title";
			// 
			// textTitle
			// 
			this.textTitle.Location = new System.Drawing.Point(6, 32);
			this.textTitle.MaxLength = 100;
			this.textTitle.Name = "textTitle";
			this.textTitle.Size = new System.Drawing.Size(337, 20);
			this.textTitle.TabIndex = 3;
			// 
			// labelWeekStartDay
			// 
			this.labelWeekStartDay.Location = new System.Drawing.Point(6, 61);
			this.labelWeekStartDay.Name = "labelWeekStartDay";
			this.labelWeekStartDay.Size = new System.Drawing.Size(100, 23);
			this.labelWeekStartDay.TabIndex = 4;
			this.labelWeekStartDay.Text = "Week Starts On";
			// 
			// comboWeekStartDay
			// 
			this.comboWeekStartDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboWeekStartDay.FormattingEnabled = true;
			this.comboWeekStartDay.Items.AddRange(new object[] {
									"Sunday",
									"Monday",
									"Tuesday",
									"Wednesday",
									"Thursday",
									"Friday",
									"Saturday"});
			this.comboWeekStartDay.Location = new System.Drawing.Point(6, 76);
			this.comboWeekStartDay.Name = "comboWeekStartDay";
			this.comboWeekStartDay.Size = new System.Drawing.Size(121, 21);
			this.comboWeekStartDay.TabIndex = 5;
			// 
			// groupExtraRows
			// 
			this.groupExtraRows.Controls.Add(this.buttonModifyRow);
			this.groupExtraRows.Controls.Add(this.buttonMoveRowDown);
			this.groupExtraRows.Controls.Add(this.buttonMoveRowUp);
			this.groupExtraRows.Controls.Add(this.textExtraRow);
			this.groupExtraRows.Controls.Add(this.buttonRemoveRow);
			this.groupExtraRows.Controls.Add(this.buttonAddRow);
			this.groupExtraRows.Controls.Add(this.listExtraRows);
			this.groupExtraRows.Controls.Add(this.labelExtraRow);
			this.groupExtraRows.Location = new System.Drawing.Point(12, 155);
			this.groupExtraRows.Name = "groupExtraRows";
			this.groupExtraRows.Size = new System.Drawing.Size(350, 185);
			this.groupExtraRows.TabIndex = 3;
			this.groupExtraRows.TabStop = false;
			this.groupExtraRows.Text = "Extra Rows";
			// 
			// buttonModifyRow
			// 
			this.buttonModifyRow.Enabled = false;
			this.buttonModifyRow.Location = new System.Drawing.Point(269, 48);
			this.buttonModifyRow.Name = "buttonModifyRow";
			this.buttonModifyRow.Size = new System.Drawing.Size(75, 23);
			this.buttonModifyRow.TabIndex = 7;
			this.buttonModifyRow.Text = "Modify";
			this.buttonModifyRow.UseVisualStyleBackColor = true;
			this.buttonModifyRow.Click += new System.EventHandler(this.ButtonModifyRowClick);
			// 
			// buttonMoveRowDown
			// 
			this.buttonMoveRowDown.Enabled = false;
			this.buttonMoveRowDown.Location = new System.Drawing.Point(269, 135);
			this.buttonMoveRowDown.Name = "buttonMoveRowDown";
			this.buttonMoveRowDown.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveRowDown.TabIndex = 6;
			this.buttonMoveRowDown.Text = "Move Down";
			this.buttonMoveRowDown.UseVisualStyleBackColor = true;
			this.buttonMoveRowDown.Click += new System.EventHandler(this.ButtonMoveRowDownClick);
			// 
			// buttonMoveRowUp
			// 
			this.buttonMoveRowUp.Enabled = false;
			this.buttonMoveRowUp.Location = new System.Drawing.Point(269, 106);
			this.buttonMoveRowUp.Name = "buttonMoveRowUp";
			this.buttonMoveRowUp.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveRowUp.TabIndex = 5;
			this.buttonMoveRowUp.Text = "Move Up";
			this.buttonMoveRowUp.UseVisualStyleBackColor = true;
			this.buttonMoveRowUp.Click += new System.EventHandler(this.ButtonMoveRowUpClick);
			// 
			// textExtraRow
			// 
			this.textExtraRow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.textExtraRow.Location = new System.Drawing.Point(133, 36);
			this.textExtraRow.MaxLength = 30;
			this.textExtraRow.Name = "textExtraRow";
			this.textExtraRow.Size = new System.Drawing.Size(129, 20);
			this.textExtraRow.TabIndex = 2;
			// 
			// buttonRemoveRow
			// 
			this.buttonRemoveRow.Enabled = false;
			this.buttonRemoveRow.Location = new System.Drawing.Point(269, 77);
			this.buttonRemoveRow.Name = "buttonRemoveRow";
			this.buttonRemoveRow.Size = new System.Drawing.Size(75, 23);
			this.buttonRemoveRow.TabIndex = 4;
			this.buttonRemoveRow.Text = "Remove";
			this.buttonRemoveRow.UseVisualStyleBackColor = true;
			this.buttonRemoveRow.Click += new System.EventHandler(this.ButtonRemoveRowClick);
			// 
			// buttonAddRow
			// 
			this.buttonAddRow.Location = new System.Drawing.Point(268, 19);
			this.buttonAddRow.Name = "buttonAddRow";
			this.buttonAddRow.Size = new System.Drawing.Size(75, 23);
			this.buttonAddRow.TabIndex = 3;
			this.buttonAddRow.Text = "Add";
			this.buttonAddRow.UseVisualStyleBackColor = true;
			this.buttonAddRow.Click += new System.EventHandler(this.ButtonAddRowClick);
			// 
			// listExtraRows
			// 
			this.listExtraRows.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.listExtraRows.FormattingEnabled = true;
			this.listExtraRows.Location = new System.Drawing.Point(7, 19);
			this.listExtraRows.Name = "listExtraRows";
			this.listExtraRows.Size = new System.Drawing.Size(120, 160);
			this.listExtraRows.TabIndex = 0;
			this.listExtraRows.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListExtraRowsDrawItem);
			this.listExtraRows.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListExtraRowsMeasureItem);
			this.listExtraRows.SelectedIndexChanged += new System.EventHandler(this.ListExtraRowsSelectedIndexChanged);
			// 
			// labelExtraRow
			// 
			this.labelExtraRow.Location = new System.Drawing.Point(133, 21);
			this.labelExtraRow.Name = "labelExtraRow";
			this.labelExtraRow.Size = new System.Drawing.Size(100, 23);
			this.labelExtraRow.TabIndex = 1;
			this.labelExtraRow.Text = "Row Heading";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(724, 12);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(724, 44);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// radioWholeYear
			// 
			this.radioWholeYear.Location = new System.Drawing.Point(6, 19);
			this.radioWholeYear.Name = "radioWholeYear";
			this.radioWholeYear.Size = new System.Drawing.Size(104, 24);
			this.radioWholeYear.TabIndex = 0;
			this.radioWholeYear.TabStop = true;
			this.radioWholeYear.Text = "Whole Year";
			this.radioWholeYear.UseVisualStyleBackColor = true;
			this.radioWholeYear.CheckedChanged += new System.EventHandler(this.RadioWholeYearCheckedChanged);
			// 
			// radioDateRange
			// 
			this.radioDateRange.Location = new System.Drawing.Point(143, 19);
			this.radioDateRange.Name = "radioDateRange";
			this.radioDateRange.Size = new System.Drawing.Size(104, 24);
			this.radioDateRange.TabIndex = 3;
			this.radioDateRange.TabStop = true;
			this.radioDateRange.Text = "Date Range";
			this.radioDateRange.UseVisualStyleBackColor = true;
			this.radioDateRange.CheckedChanged += new System.EventHandler(this.RadioDateRangeCheckedChanged);
			// 
			// groupDateSelection
			// 
			this.groupDateSelection.Controls.Add(this.dateTo);
			this.groupDateSelection.Controls.Add(this.dateFrom);
			this.groupDateSelection.Controls.Add(this.radioWholeYear);
			this.groupDateSelection.Controls.Add(this.radioDateRange);
			this.groupDateSelection.Controls.Add(this.numericYear);
			this.groupDateSelection.Controls.Add(this.labelSelectYear);
			this.groupDateSelection.Controls.Add(this.labelFrom);
			this.groupDateSelection.Controls.Add(this.labelTo);
			this.groupDateSelection.Location = new System.Drawing.Point(368, 12);
			this.groupDateSelection.Name = "groupDateSelection";
			this.groupDateSelection.Size = new System.Drawing.Size(350, 137);
			this.groupDateSelection.TabIndex = 2;
			this.groupDateSelection.TabStop = false;
			this.groupDateSelection.Text = "Date Selection";
			// 
			// dateTo
			// 
			this.dateTo.Location = new System.Drawing.Point(143, 106);
			this.dateTo.Name = "dateTo";
			this.dateTo.Size = new System.Drawing.Size(200, 20);
			this.dateTo.TabIndex = 7;
			this.dateTo.ValueChanged += new System.EventHandler(this.DateToValueChanged);
			// 
			// dateFrom
			// 
			this.dateFrom.Location = new System.Drawing.Point(143, 62);
			this.dateFrom.Name = "dateFrom";
			this.dateFrom.Size = new System.Drawing.Size(200, 20);
			this.dateFrom.TabIndex = 5;
			this.dateFrom.ValueChanged += new System.EventHandler(this.DateFromValueChanged);
			// 
			// labelSelectYear
			// 
			this.labelSelectYear.Location = new System.Drawing.Point(6, 46);
			this.labelSelectYear.Name = "labelSelectYear";
			this.labelSelectYear.Size = new System.Drawing.Size(100, 23);
			this.labelSelectYear.TabIndex = 1;
			this.labelSelectYear.Text = "Select Year";
			// 
			// labelFrom
			// 
			this.labelFrom.Location = new System.Drawing.Point(143, 46);
			this.labelFrom.Name = "labelFrom";
			this.labelFrom.Size = new System.Drawing.Size(100, 23);
			this.labelFrom.TabIndex = 4;
			this.labelFrom.Text = "From";
			// 
			// labelTo
			// 
			this.labelTo.Location = new System.Drawing.Point(143, 89);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(100, 23);
			this.labelTo.TabIndex = 6;
			this.labelTo.Text = "To";
			// 
			// groupChartSettings
			// 
			this.groupChartSettings.Controls.Add(this.checkAbbreviate);
			this.groupChartSettings.Controls.Add(this.textTitle);
			this.groupChartSettings.Controls.Add(this.labelTitle);
			this.groupChartSettings.Controls.Add(this.comboWeekStartDay);
			this.groupChartSettings.Controls.Add(this.labelWeekStartDay);
			this.groupChartSettings.Location = new System.Drawing.Point(12, 12);
			this.groupChartSettings.Name = "groupChartSettings";
			this.groupChartSettings.Size = new System.Drawing.Size(350, 137);
			this.groupChartSettings.TabIndex = 1;
			this.groupChartSettings.TabStop = false;
			this.groupChartSettings.Text = "Chart Settings";
			// 
			// checkAbbreviate
			// 
			this.checkAbbreviate.Location = new System.Drawing.Point(7, 106);
			this.checkAbbreviate.Name = "checkAbbreviate";
			this.checkAbbreviate.Size = new System.Drawing.Size(104, 24);
			this.checkAbbreviate.TabIndex = 6;
			this.checkAbbreviate.Text = "Short Headings";
			this.checkAbbreviate.UseVisualStyleBackColor = true;
			// 
			// groupExtraColumns
			// 
			this.groupExtraColumns.Controls.Add(this.buttonModifyColumn);
			this.groupExtraColumns.Controls.Add(this.buttonMoveColumnDown);
			this.groupExtraColumns.Controls.Add(this.buttonMoveColumnUp);
			this.groupExtraColumns.Controls.Add(this.textExtraColumn);
			this.groupExtraColumns.Controls.Add(this.buttonRemoveColumn);
			this.groupExtraColumns.Controls.Add(this.buttonAddColumn);
			this.groupExtraColumns.Controls.Add(this.listExtraColumns);
			this.groupExtraColumns.Controls.Add(this.labelExtraColumn);
			this.groupExtraColumns.Location = new System.Drawing.Point(368, 155);
			this.groupExtraColumns.Name = "groupExtraColumns";
			this.groupExtraColumns.Size = new System.Drawing.Size(350, 185);
			this.groupExtraColumns.TabIndex = 4;
			this.groupExtraColumns.TabStop = false;
			this.groupExtraColumns.Text = "Extra Columns";
			// 
			// buttonModifyColumn
			// 
			this.buttonModifyColumn.Enabled = false;
			this.buttonModifyColumn.Location = new System.Drawing.Point(269, 48);
			this.buttonModifyColumn.Name = "buttonModifyColumn";
			this.buttonModifyColumn.Size = new System.Drawing.Size(75, 23);
			this.buttonModifyColumn.TabIndex = 7;
			this.buttonModifyColumn.Text = "Modify";
			this.buttonModifyColumn.UseVisualStyleBackColor = true;
			this.buttonModifyColumn.Click += new System.EventHandler(this.ButtonModifyColumnClick);
			// 
			// buttonMoveColumnDown
			// 
			this.buttonMoveColumnDown.Enabled = false;
			this.buttonMoveColumnDown.Location = new System.Drawing.Point(269, 135);
			this.buttonMoveColumnDown.Name = "buttonMoveColumnDown";
			this.buttonMoveColumnDown.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveColumnDown.TabIndex = 6;
			this.buttonMoveColumnDown.Text = "Move Down";
			this.buttonMoveColumnDown.UseVisualStyleBackColor = true;
			this.buttonMoveColumnDown.Click += new System.EventHandler(this.ButtonMoveColumnDownClick);
			// 
			// buttonMoveColumnUp
			// 
			this.buttonMoveColumnUp.Enabled = false;
			this.buttonMoveColumnUp.Location = new System.Drawing.Point(269, 106);
			this.buttonMoveColumnUp.Name = "buttonMoveColumnUp";
			this.buttonMoveColumnUp.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveColumnUp.TabIndex = 5;
			this.buttonMoveColumnUp.Text = "Move Up";
			this.buttonMoveColumnUp.UseVisualStyleBackColor = true;
			this.buttonMoveColumnUp.Click += new System.EventHandler(this.ButtonMoveColumnUpClick);
			// 
			// textExtraColumn
			// 
			this.textExtraColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.textExtraColumn.Location = new System.Drawing.Point(133, 36);
			this.textExtraColumn.MaxLength = 30;
			this.textExtraColumn.Name = "textExtraColumn";
			this.textExtraColumn.Size = new System.Drawing.Size(129, 20);
			this.textExtraColumn.TabIndex = 2;
			// 
			// buttonRemoveColumn
			// 
			this.buttonRemoveColumn.Enabled = false;
			this.buttonRemoveColumn.Location = new System.Drawing.Point(269, 77);
			this.buttonRemoveColumn.Name = "buttonRemoveColumn";
			this.buttonRemoveColumn.Size = new System.Drawing.Size(75, 23);
			this.buttonRemoveColumn.TabIndex = 4;
			this.buttonRemoveColumn.Text = "Remove";
			this.buttonRemoveColumn.UseVisualStyleBackColor = true;
			this.buttonRemoveColumn.Click += new System.EventHandler(this.ButtonRemoveColumnClick);
			// 
			// buttonAddColumn
			// 
			this.buttonAddColumn.Location = new System.Drawing.Point(268, 19);
			this.buttonAddColumn.Name = "buttonAddColumn";
			this.buttonAddColumn.Size = new System.Drawing.Size(75, 23);
			this.buttonAddColumn.TabIndex = 3;
			this.buttonAddColumn.Text = "Add";
			this.buttonAddColumn.UseVisualStyleBackColor = true;
			this.buttonAddColumn.Click += new System.EventHandler(this.ButtonAddColumnClick);
			// 
			// listExtraColumns
			// 
			this.listExtraColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.listExtraColumns.FormattingEnabled = true;
			this.listExtraColumns.Location = new System.Drawing.Point(7, 19);
			this.listExtraColumns.Name = "listExtraColumns";
			this.listExtraColumns.Size = new System.Drawing.Size(120, 160);
			this.listExtraColumns.TabIndex = 0;
			this.listExtraColumns.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListExtraColumnsDrawItem);
			this.listExtraColumns.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListExtraColumnsMeasureItem);
			this.listExtraColumns.SelectedIndexChanged += new System.EventHandler(this.ListExtraColumnsSelectedIndexChanged);
			// 
			// labelExtraColumn
			// 
			this.labelExtraColumn.Location = new System.Drawing.Point(133, 21);
			this.labelExtraColumn.Name = "labelExtraColumn";
			this.labelExtraColumn.Size = new System.Drawing.Size(100, 23);
			this.labelExtraColumn.TabIndex = 1;
			this.labelExtraColumn.Text = "Column Heading";
			// 
			// YearChartOptionsForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(809, 354);
			this.Controls.Add(this.groupChartSettings);
			this.Controls.Add(this.groupDateSelection);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupExtraColumns);
			this.Controls.Add(this.groupExtraRows);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "YearChartOptionsForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Year Chart Options";
			((System.ComponentModel.ISupportInitialize)(this.numericYear)).EndInit();
			this.groupExtraRows.ResumeLayout(false);
			this.groupExtraRows.PerformLayout();
			this.groupDateSelection.ResumeLayout(false);
			this.groupChartSettings.ResumeLayout(false);
			this.groupChartSettings.PerformLayout();
			this.groupExtraColumns.ResumeLayout(false);
			this.groupExtraColumns.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonModifyColumn;
		private System.Windows.Forms.Button buttonModifyRow;
		private System.Windows.Forms.Button buttonMoveColumnDown;
		private System.Windows.Forms.Button buttonMoveColumnUp;
		private System.Windows.Forms.Button buttonRemoveColumn;
		private System.Windows.Forms.Button buttonAddColumn;
		private System.Windows.Forms.Button buttonMoveRowDown;
		private System.Windows.Forms.RadioButton radioWholeYear;
		private System.Windows.Forms.RadioButton radioDateRange;
		private System.Windows.Forms.GroupBox groupDateSelection;
		private System.Windows.Forms.DateTimePicker dateTo;
		private System.Windows.Forms.DateTimePicker dateFrom;
		private System.Windows.Forms.Label labelSelectYear;
		private System.Windows.Forms.Label labelFrom;
		private System.Windows.Forms.Label labelTo;
		private System.Windows.Forms.Button buttonMoveRowUp;
		private System.Windows.Forms.GroupBox groupChartSettings;
		private System.Windows.Forms.CheckBox checkAbbreviate;
		private System.Windows.Forms.GroupBox groupExtraColumns;
		private System.Windows.Forms.Button buttonRemoveRow;
		private System.Windows.Forms.Button buttonAddRow;
		private System.Windows.Forms.Label labelExtraColumn;
		private System.Windows.Forms.ListBox listExtraColumns;
		private System.Windows.Forms.TextBox textExtraColumn;
		private System.Windows.Forms.Label labelExtraRow;
		private System.Windows.Forms.TextBox textExtraRow;

		// ---------------------------------------------------------------------

		void ButtonAddRowClick(object sender, System.EventArgs e)
		{
			extraRows.Add( textExtraRow.Text );
			int index = listExtraRows.Items.Add( textExtraRow.Text );

			listExtraRows.SelectedIndex = index;
		}

		void ButtonModifyRowClick(object sender, EventArgs e)
		{
			int index = listExtraRows.SelectedIndex;
			if( index >= 0 )
			{
				string text = textExtraRow.Text;
				extraRows[ index ] = text;
				listExtraRows.Items[ index ] = text;
			}
		}

		void ButtonRemoveRowClick(object sender, System.EventArgs e)
		{
			if( listExtraRows.SelectedIndex >= 0 )
			{
				extraRows.RemoveAt( listExtraRows.SelectedIndex );
				listExtraRows.Items.RemoveAt( listExtraRows.SelectedIndex );
			}
		}

		void ButtonMoveRowUpClick(object sender, EventArgs e)
		{
			if( listExtraRows.SelectedIndex > 0 )
			{
				int index = listExtraRows.SelectedIndex;
				string text = extraRows[ index ].ToString();

				extraRows.RemoveAt( index );
				listExtraRows.Items.RemoveAt( index );

				index--;

				extraRows.Insert( index, text );
				listExtraRows.Items.Insert( index, text );

				listExtraRows.SelectedIndex = index;
			}
		}
		
		void ButtonMoveRowDownClick( object sender, EventArgs e )
		{
			int index = listExtraRows.SelectedIndex;
			if( index >= 0 && index < listExtraRows.Items.Count - 1 )
			{
				string text = extraRows[ index ].ToString();

				extraRows.RemoveAt( index );
				listExtraRows.Items.RemoveAt( index );

				index++;

				extraRows.Insert( index, text );
				listExtraRows.Items.Insert( index, text );

				listExtraRows.SelectedIndex = index;
			}
		}

		void ListExtraRowsSelectedIndexChanged(object sender, EventArgs e)
		{
			enableExtraRowButtons();
		}

		private void enableExtraRowButtons()
		{
			buttonAddRow.Enabled = listExtraRows.Items.Count < 10;

			if( listExtraRows.SelectedIndex == -1 )
			{
				buttonModifyRow.Enabled = false;
				buttonRemoveRow.Enabled = false;
				buttonMoveRowUp.Enabled = false;
				buttonMoveRowDown.Enabled = false;

				textExtraRow.Clear();
			}
			else
			{
				buttonModifyRow.Enabled = true;
				buttonRemoveRow.Enabled = true;
				buttonMoveRowUp.Enabled = listExtraRows.SelectedIndex > 0;
				buttonMoveRowDown.Enabled = listExtraRows.SelectedIndex < listExtraRows.Items.Count - 1;

				textExtraRow.Text = extraRows[ listExtraRows.SelectedIndex ].ToString();
			}
		}

		void ListExtraRowsDrawItem( object sender, DrawItemEventArgs e )
		{
			if( e.Index >= 0 )
			{
				//e.DrawBackground();
				Brush brushHeading  = new SolidBrush( m_colorHeading );
				Rectangle rectItem = Rectangle.FromLTRB( e.Bounds.Left, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom- 1 );
				e.Graphics.FillRectangle( brushHeading, rectItem );

				Font fontHeading = new Font( this.Font.FontFamily, this.Font.Size, FontStyle.Bold );
				Brush brushFore     = new SolidBrush( ForeColor );

				e.Graphics.DrawString( listExtraRows.Items[ e.Index ].ToString(), fontHeading, brushFore, e.Bounds );

//				e.DrawFocusRectangle();
				Brush brushFocus;
				if( (e.State & DrawItemState.Selected) > 0 )
				{
					brushFocus = new SolidBrush( Color.Gray );
				}
				else
				{
					brushFocus = new SolidBrush( Color.White );
				}

				Pen penFocus = new Pen( brushFocus );
				e.Graphics.DrawRectangle( penFocus, rectItem );
			}
		}
		
		void ListExtraRowsMeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = listExtraRows.Font.Height + 3;
		}

		// ---------------------------------------------------------------------

		void ButtonAddColumnClick(object sender, System.EventArgs e)
		{
			extraColumns.Add( textExtraColumn.Text );
			int index = listExtraColumns.Items.Add( textExtraColumn.Text );

			listExtraColumns.SelectedIndex = index;
		}

		void ButtonModifyColumnClick(object sender, EventArgs e)
		{
			int index = listExtraColumns.SelectedIndex;
			if( index >= 0 )
			{
				string text = textExtraColumn.Text;
				extraColumns[ index ] = text;
				listExtraColumns.Items[ index ] = text;
			}
		}

		void ButtonRemoveColumnClick(object sender, System.EventArgs e)
		{
			if( listExtraColumns.SelectedIndex >= 0 )
			{
				extraColumns.RemoveAt( listExtraColumns.SelectedIndex );
				listExtraColumns.Items.RemoveAt( listExtraColumns.SelectedIndex );
			}
		}

		void ButtonMoveColumnUpClick(object sender, EventArgs e)
		{
			if( listExtraColumns.SelectedIndex > 0 )
			{
				int index = listExtraColumns.SelectedIndex;
				string text = extraColumns[ index ].ToString();

				extraColumns.RemoveAt( index );
				listExtraColumns.Items.RemoveAt( index );

				index--;

				extraColumns.Insert( index, text );
				listExtraColumns.Items.Insert( index, text );

				listExtraColumns.SelectedIndex = index;
			}
		}
		
		void ButtonMoveColumnDownClick( object sender, EventArgs e )
		{
			int index = listExtraColumns.SelectedIndex;
			if( index >= 0 && index < listExtraColumns.Items.Count - 1 )
			{
				string text = extraColumns[ index ].ToString();

				extraColumns.RemoveAt( index );
				listExtraColumns.Items.RemoveAt( index );

				index++;

				extraColumns.Insert( index, text );
				listExtraColumns.Items.Insert( index, text );

				listExtraColumns.SelectedIndex = index;
			}
		}

		void ListExtraColumnsSelectedIndexChanged(object sender, EventArgs e)
		{
			enableExtraColumnButtons();
		}

		private void enableExtraColumnButtons()
		{
			buttonAddColumn.Enabled = listExtraColumns.Items.Count < 10;

			if( listExtraColumns.SelectedIndex == -1 )
			{
				buttonModifyColumn.Enabled = false;
				buttonRemoveColumn.Enabled = false;
				buttonMoveColumnUp.Enabled = false;
				buttonMoveColumnDown.Enabled = false;

				textExtraColumn.Clear();
			}
			else
			{
				buttonModifyColumn.Enabled = true;
				buttonRemoveColumn.Enabled = true;
				buttonMoveColumnUp.Enabled = listExtraColumns.SelectedIndex > 0;
				buttonMoveColumnDown.Enabled = listExtraColumns.SelectedIndex < listExtraColumns.Items.Count - 1;

				textExtraColumn.Text = extraColumns[ listExtraColumns.SelectedIndex ].ToString();
			}
		}
		
		void ListExtraColumnsDrawItem( object sender, DrawItemEventArgs e )
		{
			if( e.Index >= 0 )
			{
				//e.DrawBackground();
				Brush brushHeading  = new SolidBrush( m_colorHeading );
				Rectangle rectItem = Rectangle.FromLTRB( e.Bounds.Left, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom- 1 );
				e.Graphics.FillRectangle( brushHeading, rectItem );

				Font fontHeading = new Font( this.Font.FontFamily, this.Font.Size, FontStyle.Bold );
				Brush brushFore     = new SolidBrush( ForeColor );

				e.Graphics.DrawString( listExtraColumns.Items[ e.Index ].ToString(), fontHeading, brushFore, rectItem );

				//e.DrawFocusRectangle();
				Brush brushFocus;
				if( (e.State & DrawItemState.Selected) > 0 )
				{
					brushFocus = new SolidBrush( Color.Gray );
				}
				else
				{
					brushFocus = new SolidBrush( Color.White );
				}

				Pen penFocus = new Pen( brushFocus );
				e.Graphics.DrawRectangle( penFocus, rectItem );
			}
		}
		
		void ListExtraColumnsMeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = listExtraColumns.Font.Height + 3;
		}

		// ---------------------------------------------------------------------

		void RadioWholeYearCheckedChanged(object sender, EventArgs e)
		{
			dateRadioChanged();
		}

		void RadioDateRangeCheckedChanged(object sender, EventArgs e)
		{
			dateRadioChanged();
		}
		
		/// <summary>
		/// When changed, set the controls editable in the Date Selection box.
		/// </summary>
		void dateRadioChanged()
		{
			if( radioWholeYear.Checked )
			{
				numericYear.Enabled = true;
				dateFrom.Enabled = false;
				dateTo.Enabled = false;
			}
			else
			{
				numericYear.Enabled = false;
				dateFrom.Enabled = true;
				dateTo.Enabled = true;
			}
		}
		
		/// <summary>
		/// Set to true when changing one control to avoid rebounded affect from other controls.
		/// </summary>
		private bool ignoreChanges = false;
		
		void NumericYearValueChanged(object sender, EventArgs e)
		{
			if( !ignoreChanges )
			{
				ignoreChanges = true;
				int year = (int) numericYear.Value;

				dateFrom.Value = new DateTime( year, 1, 1 );
				dateTo.Value = new DateTime( year, 12, 31 );
				ignoreChanges = false;
			}
		}

		void DateFromValueChanged(object sender, EventArgs e)
		{
			if( !ignoreChanges )
			{
				ignoreChanges = true;
				if( dateTo.Value < dateFrom.Value )
				{
					dateTo.Value = dateFrom.Value;
				}
				else
				{
					// Check for maximum date range.
					DateTime dateToMax = dateFrom.Value.AddYears( 5 ).AddDays( -1 );
					if( dateTo.Value > dateToMax )
					{
						dateTo.Value = dateToMax;
					}
				}

				numericYear.Value = dateFrom.Value.Year;
				ignoreChanges = false;
			}
		}

		void DateToValueChanged(object sender, EventArgs e)
		{
			if( !ignoreChanges )
			{
				ignoreChanges = true;
				if( dateTo.Value < dateFrom.Value )
				{
					dateFrom.Value = dateTo.Value;
				}
				else
				{
					// Check for maximum date range.
					DateTime dateFromMin = dateTo.Value.AddYears( -5 ).AddDays( 1 );
					if( dateFrom.Value < dateFromMin )
					{
						dateFrom.Value = dateFromMin;
					}
				}

				numericYear.Value = dateFrom.Value.Year;
				ignoreChanges = false;
			}
		}

		// ---------------------------------------------------------------------

	}
}
