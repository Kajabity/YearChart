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
    public class YearChartPanel : System.Windows.Forms.Panel
    {
        private readonly YearChartRenderer renderer = new YearChartRenderer();

        /// <summary>
        /// Defines the width of an extra padding margin used only when drawing on screen.
        /// </summary>
        private int padding = 5;

        /// <summary>
        /// A private model - aggregated through this class so that changes can trigger updating the display.
        /// </summary>
        private YearChartModel model = new YearChartModel();

        public YearChartModel Model
        {
            get
            {
                return model;
            }
        }


        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public DayOfWeek WeekStartDay
        {
            get
            {
                return model.StartOfWeek;
            }
            set
            {
                model.StartOfWeek = value;
            }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public int Year
        {
            get { return model.Year; }
            set { model.Year = value; Invalidate(); }
        }

        public bool IsWholeYear
        {
            get
            {
                return model.IsWholeYear;
            }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public DateTime StartDate
        {
            get
            {
                return model.StartDate;
            }
            set
            {
                model.StartDate = value;
            }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public DateTime EndDate
        {
            get
            {
                return model.EndDate;
            }
            set
            {
                model.EndDate = value;
            }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public bool Abbreviate
        {
            get
            {
                return model.Abbreviate;
            }
            set
            {
                model.Abbreviate = value;
            }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public string Title
        {
            get { return model.Title; }
            set { model.Title = value; Invalidate(); }
        }

        private Color m_colorHeading = Color.Yellow;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Color HeadingColor
        {
            get { return m_colorHeading; }
            set { m_colorHeading = value; Invalidate(); }
        }

        private Color m_colorWeekend = Color.Orange;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Color WeekendColor
        {
            get { return m_colorWeekend; }
            set { m_colorWeekend = value; Invalidate(); }
        }

        private Color m_colorBlank = Color.LightGray;

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Color BlankColor
        {
            get { return m_colorBlank; }
            set { m_colorBlank = value; Invalidate(); }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public YearChartCell[] ExtraRows
        {
            get
            {
                return model.ExtraRows;
            }
            set
            {
                model.ExtraRows = value;
                Invalidate();
            }
        }

        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public YearChartCell[] ExtraColumns
        {
            get
            {
                return model.ExtraColumns;
            }
            set
            {
                model.ExtraColumns = value;
                Invalidate();
            }
        }

        public YearChartPanel()
        {
            model.Update();
            this.BackColor = Color.White;
        }

        public void Calculate()
        {
            model.Update();
        }

        protected override void OnPaint( PaintEventArgs ev )
        {
            base.OnPaint( ev );

            //			Brush brushBack     = new SolidBrush( Color.Aqua );
            //			ev.Graphics.FillRectangle( brushBack, ClientRectangle );

            // Add a blank padded border around the displayed chart.
            Draw( ev.Graphics, Rectangle.Inflate( ClientRectangle, -padding, -padding ) );
        }

        public YearChartLayout Draw( Graphics g, Rectangle rectClient )
        {
            return renderer.Draw( g, model, CreateRenderStyle(), rectClient );
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
            this.Invalidate( ClientRectangle );
        }
    }
}
