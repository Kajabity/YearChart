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

/*
 * Created by SharpDevelop.
 * User: simon
 * Date: 10/01/2009
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using YearChart.Model;

namespace YearChart
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public sealed class YearChartPanel : Panel
    {
        private readonly YearChartRenderer renderer = new();

        /// <summary>
        /// Defines the width of an extra padding margin used only when drawing on screen.
        /// </summary>
        private const int padding = 5;

        /// <summary>
        /// A private model - aggregated through this class so that changes can trigger updating the display.
        /// </summary>
        public YearChartModel Model { get; } = new();


        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public DayOfWeek WeekStartDay
        {
            get => Model.StartOfWeek;
            set => Model.StartOfWeek = value;
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public int Year
        {
            get => Model.Year;
            set { Model.Year = value; Invalidate(); }
        }

        public bool IsWholeYear => Model.IsWholeYear;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public DateTime StartDate
        {
            get => Model.StartDate;
            set => Model.StartDate = value;
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public DateTime EndDate
        {
            get => Model.EndDate;
            set => Model.EndDate = value;
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public bool Abbreviate
        {
            get => Model.Abbreviate;
            set => Model.Abbreviate = value;
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public string Title
        {
            get => Model.Title;
            set { Model.Title = value; Invalidate(); }
        }

        private Color m_colorHeading = Color.Yellow;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Color HeadingColor
        {
            get => m_colorHeading;
            set { m_colorHeading = value; Invalidate(); }
        }

        private Color m_colorWeekend = Color.Orange;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Color WeekendColor
        {
            get => m_colorWeekend;
            set { m_colorWeekend = value; Invalidate(); }
        }

        private Color m_colorBlank = Color.LightGray;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Color BlankColor
        {
            get => m_colorBlank;
            set { m_colorBlank = value; Invalidate(); }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public YearChartCell[] ExtraRows
        {
            get => Model.ExtraRows;
            set
            {
                Model.ExtraRows = value;
                Invalidate();
            }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public YearChartCell[] ExtraColumns
        {
            get => Model.ExtraColumns;
            set
            {
                Model.ExtraColumns = value;
                Invalidate();
            }
        }

        public YearChartPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Model.Update();
            BackColor = Color.White;
        }

        public void Calculate()
        {
            Model.Update();
        }

        protected override void OnPaint( PaintEventArgs ev )
        {
#if DEBUG
            var start = YearChartDiagnostics.StartTimer();
#endif
            base.OnPaint( ev );

            // Add a blank padded border around the displayed chart.
            Draw( ev.Graphics, Rectangle.Inflate( ClientRectangle, -padding, -padding ) );
#if DEBUG
            YearChartDiagnostics.WriteElapsed(
                $"panel paint ({ClientSize.Width}x{ClientSize.Height})",
                start);
#endif
        }

        public YearChartLayout Draw( Graphics g, Rectangle rectClient )
        {
            return renderer.Draw( g, Model, CreateRenderStyle(), rectClient );
        }

        private YearChartRenderStyle CreateRenderStyle()
        {
            return new YearChartRenderStyle
            {
                Font = Font,
                BackColor = BackColor,
                ForeColor = ForeColor,
                HeadingColor = m_colorHeading,
                WeekendColor = m_colorWeekend,
                BlankColor = m_colorBlank
            };
        }

        protected override void OnResize( EventArgs ev )
        {
            base.OnResize( ev );
            Invalidate( ClientRectangle );
        }
    }
}
