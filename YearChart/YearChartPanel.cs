/**
 * Copyright 2009 Williams Technologies Limtied.
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
 * Kajbity is a trademark of Williams Technologies Limited.
 * 
 * http://www.kajabity.com
 */

/*
 * Created by SharpDevelop.
 * User: simon
 * Date: 10/01/2009
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.Diagnostics;

namespace YearChart
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class YearChartPanel : System.Windows.Forms.Panel
	{
		/// <summary>
		/// Defines the width of an extra padding margin used only when drawing on screen.
		/// </summary>
		private int padding = 10;
		
        private YearData yd = new YearData();
        
        public int Year
        {
        	get { return yd.Year; }
        	set { yd.Year = value; Invalidate(); }
        }

        public string Title
        {
        	get { return yd.Title; }
        	set { yd.Title = value; Invalidate(); }
        }

        private Color m_colorHeading = Color.Yellow;
        
        public Color HeadingColor
        {
        	get { return m_colorHeading; }
        	set { m_colorHeading = value; Invalidate(); }
        }

        private Color m_colorWeekend = Color.Orange;
        
        public Color WeekendColor
        {
        	get { return m_colorWeekend; }
        	set { m_colorWeekend = value; Invalidate(); }
        }

        private Color m_colorBlank = Color.LightGray;
        
        public Color BlankColor
        {
        	get { return m_colorBlank; }
        	set { m_colorBlank = value; Invalidate(); }
        }

		public string[] ExtraRows
		{
			get
			{
				return yd.ExtraRows;
			}
			set
			{
				yd.ExtraRows = value;
			}
		}

		public DayOfWeek WeekStartDay
		{
			get
			{
				return yd.WeekStartDay;
			}
			set
			{
				yd.WeekStartDay = value;
			}
		}

		public void Calculate()
		{
			yd.Calculate();
		}

		public YearChartPanel()
		{
			yd.Calculate();
			this.BackColor = Color.White;
		}

        protected override void OnPaint( PaintEventArgs ev ) 
        {
            base.OnPaint( ev );

            Draw( ev.Graphics, Rectangle.Inflate( ClientRectangle, -padding, -padding ) );
        }

        public void Draw( Graphics g, Rectangle rectClient )
        {
            Brush brushBack     = new SolidBrush( BackColor );
            Brush brushFore     = new SolidBrush( ForeColor );

            Brush brushHeading  = new SolidBrush( m_colorHeading );
            Brush brushWeekend  = new SolidBrush( m_colorWeekend );
            Brush brushBlank    = new SolidBrush( m_colorBlank );

            Font TitleFont = new Font( Font.FontFamily, Font.Size + 5, FontStyle.Bold );
            Font HeadingFont = new Font( Font.FontFamily, Font.Size, FontStyle.Bold );


            //  Wipe the whole background.
            g.FillRectangle( brushBack, rectClient );

            //  Get the size of the Title.
            SizeF sizeTitle = g.MeasureString( yd.Title, Font );
            SizeF sizeDOW = g.MeasureString( DayOfWeek.Wednesday.ToString(), HeadingFont );

            //  Don't do anything more if the title won't fit!
            if( (sizeTitle.Height < rectClient.Height) &&
                (sizeTitle.Width  < rectClient.Width) &&
                (sizeDOW.Width    < rectClient.Width) )
            {
                //  Calculate the Column offsets.
                int nCols = yd.numColumns;
                int []xCoords = new int[ nCols + 1 ];

                xCoords[ 0 ] = rectClient.X;
                xCoords[ 1 ] = rectClient.X + (int) sizeDOW.Width + 3;
                xCoords[ nCols ] = rectClient.X + rectClient.Width - 1;

                int w = xCoords[ nCols ] - xCoords[ 1 ];
                for( int col = 2; col < nCols; col++ )
                {
                    xCoords[ col ] = xCoords[ 1 ] + (col - 1) * w / (nCols - 1);
                }

                //Calculate the Row offsets.
                int nRows = 1 + yd.numRows;
                int []yCoords = new int[ 1 + nRows ];

                yCoords[ 0 ] = rectClient.Y;
                yCoords[ 1 ] = rectClient.Y + (int) sizeTitle.Height * 2;
                yCoords[ nRows ] = rectClient.Y + rectClient.Height - 1;

                int h = yCoords[ nRows ] - yCoords[ 1 ];
                for( int row = 2; row < nRows; row++ )
                {
                    yCoords[ row ] = yCoords[ 1 ] + (row - 1) * h / (nRows - 1);
                }


                //  Draw the Title.
                StringFormat format = new StringFormat( StringFormatFlags.NoWrap );
                format.Alignment = StringAlignment.Center;

                Rectangle rectTitle = Rectangle.FromLTRB( xCoords[ 0 ], yCoords[ 0 ],
                    xCoords[ nCols ], yCoords[ 1 ] );

                g.DrawString( yd.Title, TitleFont, new SolidBrush( ForeColor ), 
                    rectTitle, format );

                //	Attempt to load and draw the icon on the chart.
//                try
//                {
//	                Icon appIcon = new Icon("App.ico");
//	                g.DrawIcon( appIcon, rectClient.Left, rectClient.Top );
//                }
//                catch(Exception ex)
//                {
//	                Debug.WriteLine( "Failed to load Icon: App.ico" );
//                }
                

                Debug.WriteLine( "nRows " + nRows + ", nCols " + nCols );
                //StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                
                for( int row = 1; row < nRows; row ++ )
                {
                    for( int col = 0; col < nCols; col ++ )
                    {
                        Rectangle rect = Rectangle.FromLTRB( xCoords[ col ], yCoords[ row ],
                            xCoords[ col + 1 ], yCoords[ row + 1 ] );
                        YearDay day = yd.days[ row - 1, col ];
                        if( day == null || day.type == YearDayType.Blank )
                        {
                            g.FillRectangle( brushBlank, rect );
                        }
                        else if( day.type == YearDayType.Heading )
                        {
                            g.FillRectangle( brushHeading, rect );
                            g.DrawString( day.text, HeadingFont, brushFore, rect, format );
                        }
                        else if( day.type == YearDayType.Weekday )
                        {
                            //e.Graphics.FillRectangle( brushBack, rect );
                            g.DrawString( day.text, Font, brushFore, rect, format );
                        } 
                        else if( day.type == YearDayType.Weekend )
                        {
                            g.FillRectangle( brushWeekend, rect );
                            g.DrawString( day.text, Font, brushFore, rect, format );
                        }
                    }
                }

                Pen penLine = new Pen( Color.Black );

                for( int row = 1; row <= nRows; row ++ )
                {
                    g.DrawLine( penLine, xCoords[ 0 ], yCoords[ row ],
                        xCoords[ nCols ], yCoords[ row ] );
                }

                for( int col = 0; col <= nCols; col ++ )
                {
                    g.DrawLine( penLine, xCoords[ col ], yCoords[ 1 ],
                        xCoords[ col ], yCoords[ nRows ] );
                }

                Debug.WriteLine( "" );
            }

            g.Flush();
        }

        protected override void OnResize( EventArgs ev ) 
        {
            base.OnResize( ev );
            this.Invalidate( ClientRectangle );
        }
	}
}
