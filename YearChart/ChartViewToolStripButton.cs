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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YearChart
{
    public enum ChartViewButtonIcon
    {
        StretchToFit,
        PageLayout
    }

    public class ChartViewToolStripButton : ToolStripButton
    {
        private ChartViewButtonIcon icon = ChartViewButtonIcon.StretchToFit;

        public ChartViewToolStripButton()
        {
            AutoSize = false;
            DisplayStyle = ToolStripItemDisplayStyle.None;
            Size = new Size(32, 24);
        }

        [DefaultValue(ChartViewButtonIcon.StretchToFit)]
        public ChartViewButtonIcon Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new Rectangle(
                ContentRectangle.X + ((ContentRectangle.Width - 20) / 2),
                ContentRectangle.Y + ((ContentRectangle.Height - 20) / 2),
                20,
                20);

            Color outlineColor = Enabled ? Color.FromArgb(45, 45, 45) : SystemColors.GrayText;
            Color accentColor = Enabled ? Color.FromArgb(0, 120, 215) : SystemColors.GrayText;

            if (icon == ChartViewButtonIcon.PageLayout)
            {
                DrawPageLayoutIcon(e.Graphics, bounds, outlineColor, accentColor);
            }
            else
            {
                DrawStretchIcon(e.Graphics, bounds, outlineColor, accentColor);
            }
        }

        private static void DrawStretchIcon(Graphics graphics, Rectangle bounds, Color outlineColor, Color accentColor)
        {
            using (Pen outlinePen = new Pen(outlineColor, 1.6f))
            using (Pen arrowPen = new Pen(accentColor, 1.8f))
            {
                arrowPen.StartCap = LineCap.Round;
                arrowPen.EndCap = LineCap.Round;

                graphics.DrawRectangle(outlinePen, bounds.X + 2, bounds.Y + 2, bounds.Width - 5, bounds.Height - 5);

                Point center = new Point(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
                DrawArrow(graphics, arrowPen, center, new Point(bounds.Left + 5, bounds.Top + 5));
                DrawArrow(graphics, arrowPen, center, new Point(bounds.Right - 5, bounds.Top + 5));
                DrawArrow(graphics, arrowPen, center, new Point(bounds.Left + 5, bounds.Bottom - 5));
                DrawArrow(graphics, arrowPen, center, new Point(bounds.Right - 5, bounds.Bottom - 5));
            }
        }

        private static void DrawArrow(Graphics graphics, Pen pen, Point start, Point end)
        {
            graphics.DrawLine(pen, start, end);

            int horizontal = end.X < start.X ? 1 : -1;
            int vertical = end.Y < start.Y ? 1 : -1;
            graphics.DrawLine(pen, end, new Point(end.X + (horizontal * 4), end.Y));
            graphics.DrawLine(pen, end, new Point(end.X, end.Y + (vertical * 4)));
        }

        private static void DrawPageLayoutIcon(Graphics graphics, Rectangle bounds, Color outlineColor, Color accentColor)
        {
            Rectangle shadowBounds = new Rectangle(bounds.X + 7, bounds.Y + 3, 10, 15);
            Rectangle pageBounds = new Rectangle(bounds.X + 4, bounds.Y + 1, 12, 16);
            Rectangle marginBounds = new Rectangle(bounds.X + 7, bounds.Y + 5, 6, 8);

            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
            using (Brush pageBrush = new SolidBrush(Color.White))
            using (Pen pagePen = new Pen(outlineColor, 1.6f))
            using (Pen marginPen = new Pen(accentColor, 1.2f))
            {
                graphics.FillRectangle(shadowBrush, shadowBounds);
                graphics.FillRectangle(pageBrush, pageBounds);
                graphics.DrawRectangle(pagePen, pageBounds);
                graphics.DrawRectangle(marginPen, marginBounds);
            }
        }
    }
}
