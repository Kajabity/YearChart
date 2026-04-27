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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YearChart
{
    public class YearChartHost : UserControl
    {
        private readonly YearChartPanel yearChartPanel;
        private ChartViewMode viewMode = ChartViewMode.Stretch;

        public YearChartHost()
        {
            yearChartPanel = new YearChartPanel();
            yearChartPanel.Dock = DockStyle.Fill;
            yearChartPanel.DoubleClick += YearChartPanelDoubleClick;

            BackColor = Color.White;
            Controls.Add(yearChartPanel);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public YearChartPanel ChartPanel
        {
            get { return yearChartPanel; }
        }

        [DefaultValue(ChartViewMode.Stretch)]
        public ChartViewMode ViewMode
        {
            get { return viewMode; }
            set
            {
                if (viewMode == value)
                {
                    return;
                }

                viewMode = value;
                ApplyViewMode();
            }
        }

        public event EventHandler ChartDoubleClick;

        public YearChartLayout Draw(Graphics graphics, Rectangle bounds)
        {
            return yearChartPanel.Draw(graphics, bounds);
        }

        private void ApplyViewMode()
        {
            if (viewMode == ChartViewMode.Stretch)
            {
                yearChartPanel.Dock = DockStyle.Fill;
            }

            Invalidate(true);
        }

        private void YearChartPanelDoubleClick(object sender, EventArgs e)
        {
            ChartDoubleClick?.Invoke(this, e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(true);
        }
    }
}
