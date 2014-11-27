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

		private System.Windows.Forms.TextBox textExtra;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelWeekStartDay;
		private System.Windows.Forms.GroupBox groupExtraRows;
		private System.Windows.Forms.Label labelLabel;
		private System.Windows.Forms.TextBox textTitle;
		private System.Windows.Forms.ComboBox comboWeekStartDay;
		private System.Windows.Forms.NumericUpDown numericYear;
		private System.Windows.Forms.Label labelYear;
		private System.Windows.Forms.ListBox listExtraRows;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonRemove;
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
			this.labelYear = new System.Windows.Forms.Label();
			this.numericYear = new System.Windows.Forms.NumericUpDown();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textTitle = new System.Windows.Forms.TextBox();
			this.labelWeekStartDay = new System.Windows.Forms.Label();
			this.comboWeekStartDay = new System.Windows.Forms.ComboBox();
			this.groupExtraRows = new System.Windows.Forms.GroupBox();
			this.textExtra = new System.Windows.Forms.TextBox();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.listExtraRows = new System.Windows.Forms.ListBox();
			this.labelLabel = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
			this.groupExtraRows.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelYear
			// 
			this.labelYear.Location = new System.Drawing.Point(13, 9);
			this.labelYear.Name = "labelYear";
			this.labelYear.Size = new System.Drawing.Size(100, 23);
			this.labelYear.TabIndex = 0;
			this.labelYear.Text = "Year";
			// 
			// numericYear
			// 
			this.numericYear.Location = new System.Drawing.Point(12, 25);
			this.numericYear.Maximum = new decimal(new int[] {
									9999,
									0,
									0,
									0});
			this.numericYear.Name = "numericYear";
			this.numericYear.Size = new System.Drawing.Size(120, 20);
			this.numericYear.TabIndex = 1;
			// 
			// labelTitle
			// 
			this.labelTitle.Location = new System.Drawing.Point(12, 49);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(100, 23);
			this.labelTitle.TabIndex = 2;
			this.labelTitle.Text = "Title";
			// 
			// textTitle
			// 
			this.textTitle.Location = new System.Drawing.Point(12, 65);
			this.textTitle.MaxLength = 100;
			this.textTitle.Name = "textTitle";
			this.textTitle.Size = new System.Drawing.Size(241, 20);
			this.textTitle.TabIndex = 3;
			// 
			// labelWeekStartDay
			// 
			this.labelWeekStartDay.Location = new System.Drawing.Point(13, 91);
			this.labelWeekStartDay.Name = "labelWeekStartDay";
			this.labelWeekStartDay.Size = new System.Drawing.Size(100, 23);
			this.labelWeekStartDay.TabIndex = 4;
			this.labelWeekStartDay.Text = "Week Start Day";
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
			this.comboWeekStartDay.Location = new System.Drawing.Point(13, 106);
			this.comboWeekStartDay.Name = "comboWeekStartDay";
			this.comboWeekStartDay.Size = new System.Drawing.Size(121, 21);
			this.comboWeekStartDay.TabIndex = 5;
			// 
			// groupExtraRows
			// 
			this.groupExtraRows.Controls.Add(this.textExtra);
			this.groupExtraRows.Controls.Add(this.buttonRemove);
			this.groupExtraRows.Controls.Add(this.buttonAdd);
			this.groupExtraRows.Controls.Add(this.listExtraRows);
			this.groupExtraRows.Controls.Add(this.labelLabel);
			this.groupExtraRows.Location = new System.Drawing.Point(13, 133);
			this.groupExtraRows.Name = "groupExtraRows";
			this.groupExtraRows.Size = new System.Drawing.Size(240, 123);
			this.groupExtraRows.TabIndex = 6;
			this.groupExtraRows.TabStop = false;
			this.groupExtraRows.Text = "Extra Rows";
			// 
			// textExtra
			// 
			this.textExtra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.textExtra.Location = new System.Drawing.Point(133, 30);
			this.textExtra.MaxLength = 30;
			this.textExtra.Name = "textExtra";
			this.textExtra.Size = new System.Drawing.Size(100, 20);
			this.textExtra.TabIndex = 2;
			this.textExtra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextExtraKeyPress);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Location = new System.Drawing.Point(133, 90);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(75, 23);
			this.buttonRemove.TabIndex = 4;
			this.buttonRemove.Text = "Remove";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.ButtonRemoveClick);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(133, 61);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 3;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// listExtraRows
			// 
			this.listExtraRows.FormattingEnabled = true;
			this.listExtraRows.Location = new System.Drawing.Point(6, 19);
			this.listExtraRows.Name = "listExtraRows";
			this.listExtraRows.Size = new System.Drawing.Size(120, 95);
			this.listExtraRows.TabIndex = 0;
			// 
			// labelLabel
			// 
			this.labelLabel.Location = new System.Drawing.Point(133, 16);
			this.labelLabel.Name = "labelLabel";
			this.labelLabel.Size = new System.Drawing.Size(100, 23);
			this.labelLabel.TabIndex = 1;
			this.labelLabel.Text = "Label";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(265, 12);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 7;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(265, 44);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// YearChartOptionsForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(352, 270);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupExtraRows);
			this.Controls.Add(this.comboWeekStartDay);
			this.Controls.Add(this.labelWeekStartDay);
			this.Controls.Add(this.textTitle);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.numericYear);
			this.Controls.Add(this.labelYear);
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
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		
		void ButtonAddClick(object sender, System.EventArgs e)
		{
			addLabel(textExtra.Text);
		}
		
		void ButtonRemoveClick(object sender, System.EventArgs e)
		{
			if( listExtraRows.SelectedIndex >= 0 )
			{
				removeLabel( listExtraRows.SelectedIndex );
			}
		}
		
		/// <summary>
		/// Provide special handling for characters typed in the 'Label' box - specifically
		/// to handle the 'Return' or 'Enter' key and treat this as if the user pressed the 'Add' button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextExtraKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if( e.KeyChar == '\r' )
			{
				addLabel(textExtra.Text);
			}
		}
		
		void addLabel( string text )
		{
			extraRowStrings.Add( text );
			listExtraRows.Items.Add( "[" + text + "]" );

			textExtra.Text = "";
		}
		
		void removeLabel( int index )
		{
			extraRowStrings.RemoveAt( index );
			listExtraRows.Items.RemoveAt( index );
		}
		
	}
}
