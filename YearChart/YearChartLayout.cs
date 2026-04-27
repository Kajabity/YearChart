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
    public class YearChartLayout
    {
        private const int TitlePadding = 3;

        private YearChartLayout()
        {
        }

        public Rectangle Bounds { get; private set; }

        public Rectangle TitleBounds { get; private set; }

        public int[] XCoordinates { get; private set; }

        public int[] YCoordinates { get; private set; }

        public int ColumnCount { get; private set; }

        public int RowCount { get; private set; }

        public bool CanRender { get; private set; }

        public SizeF TitleSize { get; private set; }

        public SizeF DayHeadingSize { get; private set; }

        public static YearChartLayout Calculate(
            Graphics graphics,
            YearChartModel model,
            Rectangle bounds,
            Font titleFont,
            Font headingFont)
        {
            YearChartLayout layout = new YearChartLayout();
            layout.Bounds = bounds;
            layout.ColumnCount = model.NumberOfColumns;
            layout.RowCount = model.NumberOfRows;

            layout.TitleSize = graphics.MeasureString(model.Title, titleFont);
            layout.DayHeadingSize = MeasureDayHeadings(graphics, model, headingFont);

            layout.CanRender =
                layout.TitleSize.Height < bounds.Height &&
                layout.TitleSize.Width < bounds.Width &&
                layout.DayHeadingSize.Width < bounds.Width;

            if (!layout.CanRender)
            {
                layout.XCoordinates = new int[0];
                layout.YCoordinates = new int[0];
                layout.TitleBounds = Rectangle.Empty;
                return layout;
            }

            layout.CalculateGrid();
            layout.TitleBounds = Rectangle.FromLTRB(
                bounds.Left,
                bounds.Top,
                bounds.Right,
                (int)(bounds.Top + layout.TitleSize.Height));

            return layout;
        }

        public Rectangle GetCellBounds(int column, int row)
        {
            return Rectangle.FromLTRB(
                XCoordinates[column],
                YCoordinates[row],
                XCoordinates[column + 1],
                YCoordinates[row + 1]);
        }

        public Rectangle GetGridBounds()
        {
            return Rectangle.FromLTRB(
                XCoordinates[0],
                YCoordinates[0],
                XCoordinates[ColumnCount],
                YCoordinates[RowCount]);
        }

        private static SizeF MeasureDayHeadings(Graphics graphics, YearChartModel model, Font headingFont)
        {
            SizeF dayHeadingSize = new SizeF(1, 1);

            for (int row = 0; row < model.NumberOfRows; row++)
            {
                YearChartCell cell = model.Cells[0, row];
                if (cell == null)
                {
                    continue;
                }

                SizeF measured = graphics.MeasureString(cell.text, headingFont);

                if (measured.Width > dayHeadingSize.Width)
                {
                    dayHeadingSize = measured;
                }
            }

            return dayHeadingSize;
        }

        private void CalculateGrid()
        {
            XCoordinates = new int[ColumnCount + 1];
            XCoordinates[0] = Bounds.X;
            XCoordinates[1] = Bounds.X + (int)DayHeadingSize.Width + 3;
            XCoordinates[ColumnCount] = Bounds.Right - 1;

            float width = XCoordinates[ColumnCount] - XCoordinates[1];
            for (int column = 2; column <= ColumnCount; column++)
            {
                XCoordinates[column] = (int)(XCoordinates[1] + (column - 1) * (width / (ColumnCount - 1)));
            }

            YCoordinates = new int[RowCount + 1];
            YCoordinates[0] = Bounds.Y + (int)TitleSize.Height + TitlePadding;
            YCoordinates[RowCount] = Bounds.Bottom - 1;

            float height = YCoordinates[RowCount] - YCoordinates[0];
            for (int row = 1; row <= RowCount; row++)
            {
                YCoordinates[row] = (int)(YCoordinates[0] + row * (height / RowCount));
            }
        }
    }
}
