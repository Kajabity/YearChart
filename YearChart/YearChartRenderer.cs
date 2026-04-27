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
            using (Font headingFont = new Font(style.Font.FontFamily, style.Font.Size, FontStyle.Bold))
            using (Font titleFont = new Font(style.Font.FontFamily, style.Font.Size + 5, FontStyle.Bold))
            {
                YearChartLayout layout = YearChartLayout.Calculate(graphics, model, bounds, titleFont, headingFont);

                using (Brush backBrush = new SolidBrush(style.BackColor))
                {
                    graphics.FillRectangle(backBrush, bounds);
                }

                if (!layout.CanRender)
                {
                    graphics.Flush();
                    return layout;
                }

                DrawTitleArea(graphics, model, style, layout, titleFont);
                DrawCells(graphics, model, style, layout, headingFont);
                DrawGrid(graphics, model, layout);

                graphics.Flush();
                return layout;
            }
        }

        private static void DrawCells(
            Graphics graphics,
            YearChartModel model,
            YearChartRenderStyle style,
            YearChartLayout layout,
            Font headingFont)
        {
            using (Brush foreBrush = new SolidBrush(style.ForeColor))
            using (Brush headingBrush = new SolidBrush(style.HeadingColor))
            using (Brush weekendBrush = new SolidBrush(style.WeekendColor))
            using (Brush blankBrush = new SolidBrush(style.BlankColor))
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;

                for (int row = 0; row < model.NumberOfRows; row++)
                {
                    for (int col = 0; col < model.NumberOfColumns; col++)
                    {
                        Rectangle rect = layout.GetCellBounds(col, row);
                        YearChartCell cell = model.Cells[col, row];

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
        }

        private static void DrawTitleArea(
            Graphics graphics,
            YearChartModel model,
            YearChartRenderStyle style,
            YearChartLayout layout,
            Font titleFont)
        {
            using (Font footerFont = new Font(style.Font.FontFamily, 8))
            using (Brush foreBrush = new SolidBrush(style.ForeColor))
            using (Brush footerBrush = new SolidBrush(Color.Silver))
            using (StringFormat footerFormat = new StringFormat(StringFormatFlags.NoWrap))
            using (StringFormat titleFormat = new StringFormat(StringFormatFlags.NoWrap))
            using (StringFormat yearFormat = new StringFormat(StringFormatFlags.NoWrap))
            {
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
        }

        private static void DrawGrid(Graphics graphics, YearChartModel model, YearChartLayout layout)
        {
            using (Pen thickPen = new Pen(Color.Black, 2))
            using (Pen thinPen = new Pen(Color.Black))
            {
                Rectangle border = layout.GetGridBounds();
                border.Inflate(1, 1);
                graphics.DrawRectangle(thickPen, border);

                int row = 1;
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

                int col = 1;
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
}
