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
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace YearChart
{
    public class YearChartHost : UserControl
    {
        private const int PageWorkspacePadding = 24;
        private const int PageShadowOffset = 5;
        private const float MinimumZoom = 0.10f;
        private const float MaximumZoom = 4.00f;

        private readonly YearChartPanel yearChartPanel;
        private ChartViewMode viewMode = ChartViewMode.Stretch;
        private PageSettings pageSettings;
        private float pageLayoutZoom = 1.0f;
        private bool pageLayoutZoomExplicit;
        private Bitmap pageLayoutImage;
        private Size pageLayoutImagePageSize;
        private Margins pageLayoutImageMargins;

        public YearChartHost()
        {
            yearChartPanel = new YearChartPanel();
            yearChartPanel.Dock = DockStyle.Fill;
            yearChartPanel.DoubleClick += YearChartPanelDoubleClick;

            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 240);
            pageSettings = new PageSettings();
            TabStop = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PageSettings PageSettings
        {
            get { return pageSettings; }
            set
            {
                pageSettings = value == null ? new PageSettings() : (PageSettings)value.Clone();
                pageLayoutZoomExplicit = false;
                ClearPageLayoutImage();
                ApplyPageLayoutSize();
                Invalidate();
            }
        }

        public event EventHandler ChartDoubleClick;

        public YearChartLayout Draw(Graphics graphics, Rectangle bounds)
        {
            return yearChartPanel.Draw(graphics, bounds);
        }

        public void ZoomPageLayoutToFit()
        {
            pageLayoutZoomExplicit = false;
            ApplyPageLayoutSize();
            Invalidate();
        }

        public void InvalidateChart()
        {
            ClearPageLayoutImage();
            yearChartPanel.Invalidate();
            Invalidate();
        }

        private void ApplyViewMode()
        {
            if (viewMode == ChartViewMode.Stretch)
            {
                AutoScrollMinSize = Size.Empty;
                BackColor = Color.White;
                yearChartPanel.Visible = true;
                yearChartPanel.Dock = DockStyle.Fill;
            }
            else
            {
                BackColor = Color.FromArgb(240, 240, 240);
                yearChartPanel.Dock = DockStyle.None;
                yearChartPanel.Visible = false;
                ClearPageLayoutImage();
                ApplyPageLayoutSize();
            }

            Invalidate(true);
        }

        private void ApplyPageLayoutSize()
        {
            if (viewMode != ChartViewMode.PageLayout)
            {
                return;
            }

            SizeF pageSize = GetPageSize();

            if (!pageLayoutZoomExplicit)
            {
                pageLayoutZoom = CalculateFitZoom(pageSize);
            }

            Size displaySize = ScaleSize(pageSize, pageLayoutZoom);
            AutoScrollMinSize = new Size(
                displaySize.Width + (PageWorkspacePadding * 2) + PageShadowOffset,
                displaySize.Height + (PageWorkspacePadding * 2) + PageShadowOffset);
        }

        private float CalculateFitZoom(SizeF pageSize)
        {
            int availableWidth = Math.Max(1, ClientSize.Width - (PageWorkspacePadding * 2) - PageShadowOffset);
            int availableHeight = Math.Max(1, ClientSize.Height - (PageWorkspacePadding * 2) - PageShadowOffset);
            float zoom = Math.Min(availableWidth / pageSize.Width, availableHeight / pageSize.Height);

            return Math.Max(MinimumZoom, Math.Min(MaximumZoom, zoom));
        }

        private SizeF GetPageSize()
        {
            int width = pageSettings.PaperSize.Width;
            int height = pageSettings.PaperSize.Height;

            if (pageSettings.Landscape && width < height)
            {
                return new SizeF(height, width);
            }

            if (!pageSettings.Landscape && width > height)
            {
                return new SizeF(height, width);
            }

            return new SizeF(width, height);
        }

        private Size GetPagePixelSize()
        {
            SizeF pageSize = GetPageSize();

            return new Size(
                Math.Max(1, (int)Math.Round(pageSize.Width)),
                Math.Max(1, (int)Math.Round(pageSize.Height)));
        }

        private RectangleF GetMarginBounds(SizeF pageSize)
        {
            Margins margins = pageSettings.Margins;
            float left = Math.Min(margins.Left, pageSize.Width);
            float top = Math.Min(margins.Top, pageSize.Height);
            float right = Math.Min(margins.Right, pageSize.Width - left);
            float bottom = Math.Min(margins.Bottom, pageSize.Height - top);

            return new RectangleF(
                left,
                top,
                Math.Max(1, pageSize.Width - left - right),
                Math.Max(1, pageSize.Height - top - bottom));
        }

        private static Size ScaleSize(SizeF size, float scale)
        {
            return new Size(
                Math.Max(1, (int)Math.Ceiling(size.Width * scale)),
                Math.Max(1, (int)Math.Ceiling(size.Height * scale)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (viewMode != ChartViewMode.PageLayout)
            {
                return;
            }

            DrawPageLayout(e.Graphics);
        }

        private void DrawPageLayout(Graphics graphics)
        {
            graphics.Clear(BackColor);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            SizeF pageSize = GetPageSize();
            Bitmap pageImage = GetPageLayoutImage();
            Size displaySize = ScaleSize(pageSize, pageLayoutZoom);
            Point scrollOffset = AutoScrollPosition;
            int x = PageWorkspacePadding + scrollOffset.X;
            int y = PageWorkspacePadding + scrollOffset.Y;

            if (displaySize.Width < ClientSize.Width - (PageWorkspacePadding * 2))
            {
                x = (ClientSize.Width - displaySize.Width) / 2;
            }

            if (displaySize.Height < ClientSize.Height - (PageWorkspacePadding * 2))
            {
                y = (ClientSize.Height - displaySize.Height) / 2;
            }

            Rectangle shadowBounds = new Rectangle(
                x + PageShadowOffset,
                y + PageShadowOffset,
                displaySize.Width,
                displaySize.Height);
            Rectangle pageBounds = new Rectangle(x, y, displaySize.Width, displaySize.Height);

            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
            using (Pen pageBorderPen = new Pen(Color.FromArgb(160, 160, 160)))
            {
                graphics.FillRectangle(shadowBrush, shadowBounds);
                graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graphics.PixelOffsetMode = PixelOffsetMode.Half;
                graphics.DrawImage(pageImage, pageBounds);
                graphics.DrawRectangle(pageBorderPen, pageBounds);
            }
        }

        private Bitmap GetPageLayoutImage()
        {
            Size pagePixelSize = GetPagePixelSize();

            if (pageLayoutImage != null &&
                pageLayoutImagePageSize == pagePixelSize &&
                MarginsEqual(pageLayoutImageMargins, pageSettings.Margins))
            {
                return pageLayoutImage;
            }

            ClearPageLayoutImage();

            pageLayoutImage = new Bitmap(pagePixelSize.Width, pagePixelSize.Height);
            pageLayoutImagePageSize = pagePixelSize;
            pageLayoutImageMargins = (Margins)pageSettings.Margins.Clone();

            using (Graphics pageGraphics = Graphics.FromImage(pageLayoutImage))
            {
                pageGraphics.Clear(Color.White);
                pageGraphics.SmoothingMode = SmoothingMode.None;
                pageGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

                RectangleF marginBounds = GetMarginBounds(pagePixelSize);
                Rectangle chartBounds = Rectangle.Round(marginBounds);

                yearChartPanel.Draw(pageGraphics, chartBounds);

                using (Pen marginPen = new Pen(Color.FromArgb(140, 170, 170, 170)))
                {
                    marginPen.DashStyle = DashStyle.Dash;
                    pageGraphics.DrawRectangle(marginPen, chartBounds.X, chartBounds.Y, chartBounds.Width, chartBounds.Height);
                }
            }

            return pageLayoutImage;
        }

        private void ClearPageLayoutImage()
        {
            if (pageLayoutImage != null)
            {
                pageLayoutImage.Dispose();
                pageLayoutImage = null;
            }
        }

        private static bool MarginsEqual(Margins left, Margins right)
        {
            return left != null &&
                right != null &&
                left.Left == right.Left &&
                left.Top == right.Top &&
                left.Right == right.Right &&
                left.Bottom == right.Bottom;
        }

        private void YearChartPanelDoubleClick(object sender, EventArgs e)
        {
            ChartDoubleClick?.Invoke(this, e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            ChartDoubleClick?.Invoke(this, e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (viewMode == ChartViewMode.PageLayout && ModifierKeys == Keys.Control)
            {
                float zoomChange = e.Delta > 0 ? 1.10f : 1 / 1.10f;
                pageLayoutZoom = Math.Max(MinimumZoom, Math.Min(MaximumZoom, pageLayoutZoom * zoomChange));
                pageLayoutZoomExplicit = true;
                ApplyPageLayoutSize();
                Invalidate();
                return;
            }

            base.OnMouseWheel(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Focus();
            base.OnMouseEnter(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyPageLayoutSize();
            Invalidate(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ClearPageLayoutImage();
            }

            base.Dispose(disposing);
        }
    }
}
