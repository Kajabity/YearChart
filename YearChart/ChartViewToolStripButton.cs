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

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YearChart
{
    public enum ChartViewButtonIcon
    {
        StretchToFit,
        PageLayout
    }

    public sealed class ChartViewToolStripButton : ToolStripButton
    {
        private ChartViewButtonIcon icon = ChartViewButtonIcon.StretchToFit;

        public ChartViewToolStripButton()
        {
            AutoSize = false;
            DisplayStyle = ToolStripItemDisplayStyle.Image;
            UpdateImage();
            Size = new Size(32, 24);
        }

        [DefaultValue(ChartViewButtonIcon.StretchToFit)]
        public ChartViewButtonIcon Icon
        {
            get => icon;
            set
            {
                icon = value;
                UpdateImage();
            }
        }

        private void UpdateImage()
        {
            var oldImage = Image;
            Image = ChartViewIconImages.Load(icon);
            oldImage?.Dispose();
        }
    }
}
