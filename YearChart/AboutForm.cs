/*
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
 * Date: 11/01/2009
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace YearChart
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			string version = Application.ProductName + " v" + Application.ProductVersion.ToString();
			Debug.WriteLine( "App. Version: " + version );
			labelVersion.Text = version;
			
			version = ".NET Framework v" + Environment.Version.ToString();
			Debug.WriteLine( ".NET Version: " + version );
			labelNetVersion.Text = version;
		}

		void LinkWebsiteLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//TODO: Use the Link from 'e'.
			string target = linkWebsite.Text;
			System.Diagnostics.Process.Start( target );
		}
	}
}
