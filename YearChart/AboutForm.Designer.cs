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
 * Date: 11/01/2009
 */
namespace YearChart
{
	partial class AboutForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.LinkLabel linkWebsite;
		private System.Windows.Forms.Button buttonOK;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.buttonOK = new System.Windows.Forms.Button();
			this.linkWebsite = new System.Windows.Forms.LinkLabel();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelNetVersion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(101, 344);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// linkWebsite
			// 
			this.linkWebsite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkWebsite.Location = new System.Drawing.Point(12, 315);
			this.linkWebsite.Name = "linkWebsite";
			this.linkWebsite.Size = new System.Drawing.Size(245, 19);
			this.linkWebsite.TabIndex = 1;
			this.linkWebsite.TabStop = true;
			this.linkWebsite.Text = "http://www.kajabity.com/";
			this.linkWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkWebsiteLinkClicked);
			// 
			// labelVersion
			// 
			this.labelVersion.Location = new System.Drawing.Point(12, 271);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(245, 23);
			this.labelVersion.TabIndex = 2;
			this.labelVersion.Text = "Kajabity Year Chart vX.X.X.X";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNetVersion
			// 
			this.labelNetVersion.Location = new System.Drawing.Point(12, 292);
			this.labelNetVersion.Name = "labelNetVersion";
			this.labelNetVersion.Size = new System.Drawing.Size(245, 23);
			this.labelNetVersion.TabIndex = 3;
			this.labelNetVersion.Text = ".NET Framework vX.X.X.X";
			this.labelNetVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(269, 379);
			this.Controls.Add(this.labelNetVersion);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.linkWebsite);
			this.Controls.Add(this.buttonOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "About Kajabity Year Chart";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label labelNetVersion;
	}
}
