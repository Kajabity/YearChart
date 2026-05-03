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

using System.Drawing;
using YearChart.Model;

namespace YearChart
{
    public class YearChartRenderer
    {
        private const string KajabityUrl = "www.kajabity.com";

        public YearChartLayout Draw(
            Graphics graphics,
            YearChartModel model,
            YearChartRenderStyle style,
            Rectangle bounds)
        {
#if DEBUG
            var drawStart = YearChartDiagnostics.StartTimer();
#endif
            using var headingFont = new Font(style.Font.FontFamily, style.Font.Size, FontStyle.Bold);
            using var titleFont = new Font(style.Font.FontFamily, style.Font.Size + 5, FontStyle.Bold);
#if DEBUG
            var layoutStart = YearChartDiagnostics.StartTimer();
#endif
            var layout = YearChartLayout.Calculate(graphics, model, bounds, titleFont, headingFont);
#if DEBUG
            YearChartDiagnostics.WriteElapsed("layout calculation", layoutStart);
#endif

            using (Brush backBrush = new SolidBrush(style.BackColor))
            {
                graphics.FillRectangle(backBrush, bounds);
            }

            if (!layout.CanRender)
            {
#if DEBUG
                YearChartDiagnostics.WriteElapsed("renderer draw skipped", drawStart);
#endif
                return layout;
            }

#if DEBUG
            var titleStart = YearChartDiagnostics.StartTimer();
#endif
            DrawTitleArea(graphics, model, style, layout, titleFont);
#if DEBUG
            YearChartDiagnostics.WriteElapsed("title drawing", titleStart);
#endif

#if DEBUG
            var cellsStart = YearChartDiagnostics.StartTimer();
#endif
            DrawCells(graphics, model, style, layout, headingFont);
#if DEBUG
            YearChartDiagnostics.WriteElapsed("cell drawing", cellsStart);
#endif

#if DEBUG
            var gridStart = YearChartDiagnostics.StartTimer();
#endif
            DrawGrid(graphics, model, layout);
#if DEBUG
            YearChartDiagnostics.WriteElapsed("grid drawing", gridStart);

            YearChartDiagnostics.WriteElapsed(
                $"renderer draw ({model.NumberOfColumns} columns, {model.NumberOfRows} rows)",
                drawStart);
#endif
            return layout;
        }

        private static void DrawCells(
            Graphics graphics,
            YearChartModel model,
            YearChartRenderStyle style,
            YearChartLayout layout,
            Font headingFont)
        {
            using Brush foreBrush = new SolidBrush(style.ForeColor);
            using Brush headingBrush = new SolidBrush(style.HeadingColor);
            using Brush weekendBrush = new SolidBrush(style.WeekendColor);
            using Brush blankBrush = new SolidBrush(style.BlankColor);
            using var format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;

            for (var row = 0; row < model.NumberOfRows; row++)
            {
                for (var col = 0; col < model.NumberOfColumns; col++)
                {
                    var rect = layout.GetCellBounds(col, row);
                    var cell = model.Cells[col, row];

                    if (cell == null || cell.type == CellType.Blank)
                    {
                        graphics.FillRectangle(blankBrush, rect);
                    }
                    else if (cell.type == CellType.Heading)
                    {
                        graphics.FillRectangle(headingBrush, rect);
                        graphics.DrawString(cell.text, headingFont, foreBrush, rect, format);
                    }
                    else if (cell.type == CellType.Weekday)
                    {
                        graphics.DrawString(cell.text, style.Font, foreBrush, rect, format);
                    }
                    else if (cell.type == CellType.Weekend)
                    {
                        graphics.FillRectangle(weekendBrush, rect);
                        graphics.DrawString(cell.text, style.Font, foreBrush, rect, format);
                    }
                }
            }
        }

        private static void DrawTitleArea(
            Graphics graphics,
            YearChartModel model,
            YearChartRenderStyle style,
            YearChartLayout layout,
            Font titleFont)
        {
            using var footerFont = new Font(style.Font.FontFamily, 8);
            using Brush foreBrush = new SolidBrush(style.ForeColor);
            using Brush footerBrush = new SolidBrush(Color.Silver);
            using var footerFormat = new StringFormat(StringFormatFlags.NoWrap);
            using var titleFormat = new StringFormat(StringFormatFlags.NoWrap);
            using var yearFormat = new StringFormat(StringFormatFlags.NoWrap);
            footerFormat.Alignment = StringAlignment.Near;
            footerFormat.LineAlignment = StringAlignment.Far;
            graphics.DrawString(KajabityUrl, footerFont, footerBrush, layout.TitleBounds, footerFormat);

            titleFormat.Alignment = StringAlignment.Center;
            titleFormat.LineAlignment = StringAlignment.Near;
            graphics.DrawString(model.Title, titleFont, foreBrush, layout.TitleBounds, titleFormat);

            yearFormat.Alignment = StringAlignment.Far;
            yearFormat.LineAlignment = StringAlignment.Near;
            graphics.DrawString(YearChartDisplayText.GetYearText(model), titleFont, foreBrush, layout.TitleBounds, yearFormat);
        }

        private static void DrawGrid(Graphics graphics, YearChartModel model, YearChartLayout layout)
        {
            using var thickPen = new Pen(Color.Black, 2);
            using var thinPen = new Pen(Color.Black);
            var border = layout.GetGridBounds();
            border.Inflate(1, 1);
            graphics.DrawRectangle(thickPen, border);

            var row = 1;
            graphics.DrawLine(thickPen, layout.XCoordinates[0], layout.YCoordinates[row],
                layout.XCoordinates[layout.ColumnCount], layout.YCoordinates[row]);

            for (row++; row <= model.NumberOfDays; row++)
            {
                graphics.DrawLine(thinPen, layout.XCoordinates[0], layout.YCoordinates[row],
                    layout.XCoordinates[layout.ColumnCount], layout.YCoordinates[row]);
            }

            if (model.ExtraRows.Length > 0)
            {
                graphics.DrawLine(thickPen, layout.XCoordinates[0], layout.YCoordinates[row],
                    layout.XCoordinates[layout.ColumnCount], layout.YCoordinates[row]);

                for (row++; row < layout.RowCount; row++)
                {
                    graphics.DrawLine(thinPen, layout.XCoordinates[0], layout.YCoordinates[row],
                        layout.XCoordinates[layout.ColumnCount], layout.YCoordinates[row]);
                }
            }

            var col = 1;
            graphics.DrawLine(thickPen, layout.XCoordinates[col], layout.YCoordinates[0],
                layout.XCoordinates[col], layout.YCoordinates[layout.RowCount]);

            for (col++; col <= model.NumberOfMonths; col++)
            {
                graphics.DrawLine(thinPen, layout.XCoordinates[col], layout.YCoordinates[0],
                    layout.XCoordinates[col], layout.YCoordinates[layout.RowCount]);
            }

            if (model.ExtraColumns.Length > 0)
            {
                graphics.DrawLine(thickPen, layout.XCoordinates[col], layout.YCoordinates[0],
                    layout.XCoordinates[col], layout.YCoordinates[layout.RowCount]);

                for (col++; col < layout.ColumnCount; col++)
                {
                    graphics.DrawLine(thinPen, layout.XCoordinates[col], layout.YCoordinates[0],
                        layout.XCoordinates[col], layout.YCoordinates[layout.RowCount]);
                }
            }
        }

    }
}
