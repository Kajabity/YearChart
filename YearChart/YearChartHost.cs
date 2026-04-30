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
    public sealed class YearChartHost : UserControl
    {
        private const int PageWorkspacePadding = 24;
        private const int PageShadowOffset = 5;
        private const float MinimumZoom = 0.10f;
        private const float MaximumZoom = 4.00f;

        private ChartViewMode viewMode = ChartViewMode.Stretch;
        private PageSettings pageSettings;
        private SizeF pageSize;
        private float pageLayoutZoom = 1.0f;
        private bool pageLayoutZoomExplicit;

        public YearChartHost()
        {
            ChartPanel = new YearChartPanel();
            ChartPanel.Dock = DockStyle.Fill;
            ChartPanel.DoubleClick += YearChartPanelDoubleClick;

            AutoScroll = true;
            BackColor = Color.FromArgb(240, 240, 240);
            pageSettings = new PageSettings();
            pageSize = CalculatePageSize(pageSettings);
            TabStop = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

            Controls.Add(ChartPanel);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public YearChartPanel ChartPanel { get; }

        [DefaultValue(ChartViewMode.Stretch)]
        public ChartViewMode ViewMode
        {
            get => viewMode;
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
            get => pageSettings;
            set
            {
                pageSettings = value == null ? new PageSettings() : (PageSettings)value.Clone();
                pageSize = CalculatePageSize(pageSettings);
                pageLayoutZoomExplicit = false;
                ApplyPageLayoutSize();
                Invalidate();
            }
        }

        public event EventHandler ChartDoubleClick;

        public YearChartLayout Draw(Graphics graphics, Rectangle bounds)
        {
            return ChartPanel.Draw(graphics, bounds);
        }

        public void ZoomPageLayoutToFit()
        {
            pageLayoutZoomExplicit = false;
            ApplyPageLayoutSize();
            Invalidate();
        }

        public void InvalidateChart()
        {
            ChartPanel.Invalidate();
            Invalidate();
        }

        private void ApplyViewMode()
        {
            if (viewMode == ChartViewMode.Stretch)
            {
                AutoScrollMinSize = Size.Empty;
                BackColor = Color.White;
                ChartPanel.Visible = true;
                ChartPanel.Dock = DockStyle.Fill;
            }
            else
            {
                BackColor = Color.FromArgb(240, 240, 240);
                ChartPanel.Dock = DockStyle.None;
                ChartPanel.Visible = false;
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

            if (!pageLayoutZoomExplicit)
            {
                pageLayoutZoom = CalculateFitZoom(pageSize);
            }

            var displaySize = ScaleSize(pageSize, pageLayoutZoom);
            AutoScrollMinSize = new Size(
                displaySize.Width + (PageWorkspacePadding * 2) + PageShadowOffset,
                displaySize.Height + (PageWorkspacePadding * 2) + PageShadowOffset);
        }

        private float CalculateFitZoom(SizeF pageSize)
        {
            var availableWidth = Math.Max(1, ClientSize.Width - (PageWorkspacePadding * 2) - PageShadowOffset);
            var availableHeight = Math.Max(1, ClientSize.Height - (PageWorkspacePadding * 2) - PageShadowOffset);
            var zoom = Math.Min(availableWidth / pageSize.Width, availableHeight / pageSize.Height);

            return Math.Max(MinimumZoom, Math.Min(MaximumZoom, zoom));
        }

        private static SizeF CalculatePageSize(PageSettings settings)
        {
            var width = settings.PaperSize.Width;
            var height = settings.PaperSize.Height;

            if (settings.Landscape && width < height || !settings.Landscape && width > height)
            {
                return new SizeF(height, width);
            }

            return new SizeF(width, height);
        }

        private RectangleF GetMarginBounds(SizeF pageSize)
        {
            var margins = pageSettings.Margins;
            var left = Math.Min(margins.Left, pageSize.Width);
            var top = Math.Min(margins.Top, pageSize.Height);
            var right = Math.Min(margins.Right, pageSize.Width - left);
            var bottom = Math.Min(margins.Bottom, pageSize.Height - top);

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
#if DEBUG
            var start = YearChartDiagnostics.StartTimer();
#endif
            base.OnPaint(e);

            if (viewMode != ChartViewMode.PageLayout)
            {
#if DEBUG
                YearChartDiagnostics.WriteElapsed("host paint (stretch)", start);
#endif
                return;
            }

            DrawPageLayout(e.Graphics);
#if DEBUG
            YearChartDiagnostics.WriteElapsed("host paint (page layout)", start);
#endif
        }

        private void DrawPageLayout(Graphics graphics)
        {
#if DEBUG
            var start = YearChartDiagnostics.StartTimer();
            var backgroundStart = YearChartDiagnostics.StartTimer();
#endif
            graphics.Clear(BackColor);
            graphics.SmoothingMode = SmoothingMode.None;
#if DEBUG
            var backgroundMilliseconds = YearChartDiagnostics.GetElapsedMilliseconds(backgroundStart);

            var setupStart = YearChartDiagnostics.StartTimer();
#endif
            var displaySize = ScaleSize(pageSize, pageLayoutZoom);
            var scrollOffset = AutoScrollPosition;
            var x = PageWorkspacePadding + scrollOffset.X;
            var y = PageWorkspacePadding + scrollOffset.Y;

            if (displaySize.Width < ClientSize.Width - (PageWorkspacePadding * 2))
            {
                x = (ClientSize.Width - displaySize.Width) / 2;
            }

            if (displaySize.Height < ClientSize.Height - (PageWorkspacePadding * 2))
            {
                y = (ClientSize.Height - displaySize.Height) / 2;
            }

            var shadowBounds = new Rectangle(
                x + PageShadowOffset,
                y + PageShadowOffset,
                displaySize.Width,
                displaySize.Height);
            var pageBounds = new Rectangle(x, y, displaySize.Width, displaySize.Height);
#if DEBUG
            var setupMilliseconds = YearChartDiagnostics.GetElapsedMilliseconds(setupStart);

            var resourceStart = YearChartDiagnostics.StartTimer();
            var decorationStart = YearChartDiagnostics.StartTimer();
#endif
            using Brush shadowBrush = new SolidBrush(Color.FromArgb(190, 190, 190));
            using Brush pageBrush = new SolidBrush(Color.White);
            using var pageBorderPen = new Pen(Color.FromArgb(160, 160, 160));
#if DEBUG
            var resourceMilliseconds = YearChartDiagnostics.GetElapsedMilliseconds(resourceStart);
#endif
            graphics.FillRectangle(shadowBrush, shadowBounds);
            graphics.FillRectangle(pageBrush, pageBounds);
#if DEBUG
            var decorationMilliseconds = YearChartDiagnostics.GetElapsedMilliseconds(decorationStart);

            var chartMilliseconds = DrawScaledChart(graphics, pageBounds, pageSize);
#else
            DrawScaledChart(graphics, pageBounds, pageSize);
#endif

#if DEBUG
            var borderStart = YearChartDiagnostics.StartTimer();
#endif
            graphics.DrawRectangle(pageBorderPen, pageBounds);
#if DEBUG
            var borderMilliseconds = YearChartDiagnostics.GetElapsedMilliseconds(borderStart);

            var totalMilliseconds = YearChartDiagnostics.GetElapsedMilliseconds(start);

            YearChartDiagnostics.WriteLine(
                $"page layout draw ({displaySize.Width}x{displaySize.Height}) took {totalMilliseconds:0.###} ms " +
                $"[clear {backgroundMilliseconds:0.###}, setup {setupMilliseconds:0.###}, " +
                $"resources {resourceMilliseconds:0.###}, fill {decorationMilliseconds:0.###}, " +
                $"chart {chartMilliseconds:0.###}, border {borderMilliseconds:0.###}]");
#endif
        }

#if DEBUG
        private double DrawScaledChart(Graphics graphics, Rectangle pageBounds, SizeF pageSize)
#else
        private void DrawScaledChart(Graphics graphics, Rectangle pageBounds, SizeF pageSize)
#endif
        {
#if DEBUG
            var start = YearChartDiagnostics.StartTimer();
#endif
            var state = graphics.Save();
            var chartBounds = Rectangle.Round(GetMarginBounds(pageSize));

            try
            {
                graphics.TranslateTransform(pageBounds.Left, pageBounds.Top);
                graphics.ScaleTransform(pageLayoutZoom, pageLayoutZoom);

                ChartPanel.Draw(graphics, chartBounds);

                using var marginPen = new Pen(Color.FromArgb(140, 170, 170, 170));
                marginPen.DashStyle = DashStyle.Dash;
                graphics.DrawRectangle(marginPen, chartBounds.X, chartBounds.Y, chartBounds.Width, chartBounds.Height);
            }
            finally
            {
                graphics.Restore(state);
            }

#if DEBUG
            return YearChartDiagnostics.GetElapsedMilliseconds(start);
#endif
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
                var zoomChange = e.Delta > 0 ? 1.10f : 1 / 1.10f;
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

    }
}
