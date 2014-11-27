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

using YearChart.Model;

namespace YearChart
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class YearChartPanel : System.Windows.Forms.Panel
	{
		private const string KAJABITY_URL = "www.kajabity.com";

		private SizeF sizeTitle;
		private SizeF sizeDOW;
		private SizeF sizeKajabityUrl;
		private int nCols;
		private int []xCoords;
		private int nRows;
		private int []yCoords;

		/// <summary>
		/// Defines the width of an extra padding margin used only when drawing on screen.
		/// </summary>
		private int padding = 10;
		
		/// <summary>
		/// A private model - aggregated through this class so that changes can trigger updating the display.
		/// </summary>
		private YearChartModel model = new YearChartModel();

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
		
		public bool Abbreviate
		{
			get
			{
				return  model.Abbreviate;
			}
			set
			{
				model.Abbreviate = value;
			}
		}

		public string Title
		{
			get { return model.Title; }
			set { model.Title = value; Invalidate(); }
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

		public void Draw( Graphics g, Rectangle rectClient )
		{
			Brush brushBack     = new SolidBrush( BackColor );
			Brush brushFore     = new SolidBrush( ForeColor );

			Brush brushHeading  = new SolidBrush( m_colorHeading );
			Brush brushWeekend  = new SolidBrush( m_colorWeekend );
			Brush brushBlank    = new SolidBrush( m_colorBlank );

			Font fontTitle = new Font( this.Font.FontFamily, this.Font.Size + 5, FontStyle.Bold );
			Font fontHeading = new Font( this.Font.FontFamily, this.Font.Size, FontStyle.Bold );

			Font fontFooter = new Font( this.Font.FontFamily, 8 );
			sizeKajabityUrl = g.MeasureString( KAJABITY_URL, fontFooter );

			//  Wipe the whole background.
			g.FillRectangle( brushBack, rectClient );

			//  Get the size of the Title and headings.
			sizeTitle = g.MeasureString( model.Title, fontTitle );
			sizeDOW = new SizeF( 1, 1 );
			for( int i = 0; i < model.NumberOfRows; i++ )
			{
				SizeF s = g.MeasureString( model.Cells[ 0, i ].text, fontHeading );
				
				if( sizeDOW == null || s.Width > sizeDOW.Width )
				{
					sizeDOW = s;
				}
			}

			//  Don't do anything more if the title won't fit!
			if( (sizeTitle.Height < rectClient.Height) &&
			   (sizeTitle.Width  < rectClient.Width) &&
			   (sizeDOW.Width    < rectClient.Width) )
			{
				calculateGrid( rectClient );

				//  Draw the Title.
				drawTitle( g, rectClient, fontTitle );

				//drawIcon( g );
				
				//  Draw the Footer.
				drawKajabityUrl( g, rectClient, fontFooter );


				StringFormat format = new StringFormat();
				format.Alignment = StringAlignment.Near;
				format.LineAlignment = StringAlignment.Center;

				//	Fill in the Cells
				for( int row = 0; row < model.NumberOfRows; row ++ )
				{
					for( int col = 0; col < model.NumberOfColumns; col ++ )
					{
						Rectangle rect = Rectangle.FromLTRB( xCoords[ col ], yCoords[ row ],
						                                    xCoords[ col + 1 ], yCoords[ row + 1 ] );

						YearChartCell day = model.Cells[ col, row ];
						if( day == null || day.type == CellType.Blank )
						{
							g.FillRectangle( brushBlank, rect );
						}
						else if( day.type == CellType.Heading )
						{
							g.FillRectangle( brushHeading, rect );
							g.DrawString( day.text, fontHeading, brushFore, rect, format );
						}
						else if( day.type == CellType.Weekday )
						{
							//e.Graphics.FillRectangle( brushBack, rect );
							g.DrawString( day.text, Font, brushFore, rect, format );
						}
						else if( day.type == CellType.Weekend )
						{
							g.FillRectangle( brushWeekend, rect );
							g.DrawString( day.text, Font, brushFore, rect, format );
						}
					}
				}

				drawGrid( g );

				Debug.WriteLine( "" );
			}

			g.Flush();
		}

		/// <summary>
		/// Draw the program Icon on the chart.
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rectClient"></param>
		private void drawIcon( Graphics g, Rectangle rectClient )
		{
			//	Attempt to load and draw the icon on the chart.
			try
			{
				Icon appIcon = new Icon("App.ico");
				g.DrawIcon( appIcon, rectClient.Left, rectClient.Top );
			}
			catch( Exception /*ex*/ )
			{
				Debug.WriteLine( "Failed to load Icon: App.ico" );
			}
		}
		
		/// <summary>
		/// Calculate all of the display sizes and positions.
		/// </summary>
		/// <param name="rectClient"></param>
		private void calculateGrid( Rectangle rectClient )
		{
			//  Calculate the Column offsets.
			nCols = model.NumberOfColumns;
			xCoords = new int[ nCols + 1 ];

			xCoords[ 0 ] = rectClient.X;
			xCoords[ 1 ] = rectClient.X + (int) sizeDOW.Width + 3;
			xCoords[ nCols ] = rectClient.Right - 1;

			float w = xCoords[ nCols ] - xCoords[ 1 ];
			for( int col = 2; col <= nCols; col++ )
			{
				xCoords[ col ] = (int) (xCoords[ 1 ] + (col - 1) * (w / (nCols - 1)));
			}

			//	Calculate the Row offsets.
			nRows = model.NumberOfRows;
			yCoords = new int[ nRows + 1 ];

			yCoords[ 0 ] = rectClient.Y + (int) sizeTitle.Height /*+ padding*/;
			yCoords[ nRows ] = (int) (rectClient.Bottom - 1);

			Debug.WriteLine( "rectClient.Y " + rectClient.Y + ", sizeTitle.Height " + sizeTitle.Height );
			Debug.WriteLine( "yCoords[ 0 ] " + yCoords[ 0 ] + ", yCoords[ nRows ] " + yCoords[ nRows ] );
			
			float h = yCoords[ nRows ] - yCoords[ 0 ];
			for( int row = 1; row <= nRows; row++ )
			{
				yCoords[ row ] = (int) (yCoords[ 0 ] + row * (h / nRows));
			}

			Debug.WriteLine( "nRows " + nRows + ", nCols " + nCols );
		}

		private void drawTitle( Graphics g, Rectangle rectClient, Font fontTitle )
		{
			StringFormat format = new StringFormat( StringFormatFlags.NoWrap );
			format.Alignment = StringAlignment.Center;

			Rectangle rectTitle = Rectangle.FromLTRB( rectClient.Left, rectClient.Top,
			                                         rectClient.Right, (int) (rectClient.Top + sizeTitle.Height) );
			
//			Brush brushBack     = new SolidBrush( Color.Beige );
//			g.FillRectangle( brushBack, rectTitle );

			g.DrawString( model.Title, fontTitle, new SolidBrush( ForeColor ),
			             rectTitle, format );
		}

		private void drawKajabityUrl( Graphics g, Rectangle rectClient, Font fontFooter )
		{
			StringFormat format = new StringFormat( StringFormatFlags.NoWrap );
			format.Alignment = StringAlignment.Far; // Right
			format.LineAlignment = StringAlignment.Near; // Top

			//Rectangle rectFooter = Rectangle.FromLTRB( rectClient.Left, (int) (rectClient.Bottom - sizeKajabityUrl.Height),rectClient.Right, rectClient.Bottom );
			
//			Brush brushBack     = new SolidBrush( Color.Beige );
//			g.FillRectangle( brushBack, rectFooter );

			g.DrawString( KAJABITY_URL, fontFooter, new SolidBrush( Color.Silver ),
			             rectClient, format );
		}

		private void drawGrid( Graphics g )
		{
			//	Use a thin Pen to draw the grid lines and a thick one for the borders.
			Pen penThick = new Pen( Color.Black, 2 );
			Pen penThin = new Pen( Color.Black );
			
			//	Outside border
			Rectangle rectBorder = Rectangle.FromLTRB( xCoords[ 0 ], yCoords[ 0 ], xCoords[ nCols ], yCoords[ nRows ] );
			rectBorder.Inflate( 1, 1 );
			g.DrawRectangle( penThick, rectBorder );

			//	Thick line under column headings.
			int row = 1;
			g.DrawLine( penThick, xCoords[ 0 ], yCoords[ row ],
			           xCoords[ nCols ], yCoords[ row ] );

			// Horizontal lines...
			for( row++; row <= model.NumberOfDays; row++ )
			{
				g.DrawLine( penThin, xCoords[ 0 ], yCoords[ row ],
				           xCoords[ nCols ], yCoords[ row ] );
			}

			//	Now handle extra rows...
			if( model.ExtraRows.Length > 0 )
			{
				//	First a thick separator line.
				g.DrawLine( penThick, xCoords[ 0 ], yCoords[ row ],
				           xCoords[ nCols ], yCoords[ row ] );

				// Then remaining horizontal lines...
				for( row++; row < nRows; row++ )
				{
					g.DrawLine( penThin, xCoords[ 0 ], yCoords[ row ],
					           xCoords[ nCols ], yCoords[ row ] );
				}
			}
			
			//	Thick line after row headings.
			int col = 1;
			g.DrawLine( penThick, xCoords[ col ], yCoords[ 0 ],
			           xCoords[ col ], yCoords[ nRows ] );

			// Vertical lines...
			for( col++; col <= model.NumberOfMonths; col++ )
			{
				g.DrawLine( penThin, xCoords[ col ], yCoords[ 0 ],
				           xCoords[ col ], yCoords[ nRows ] );
			}
			
			//	Now handle extra columns...
			if( model.ExtraColumns.Length > 0 )
			{
				//	First a thick separator line.
				g.DrawLine( penThick, xCoords[ col ], yCoords[ 0 ],
				           xCoords[ col ], yCoords[ nRows ] );

				// Then remaining verticle lines...
				for( col++; col < nCols; col++ )
				{
					g.DrawLine( penThin, xCoords[ col ], yCoords[ 0 ],
					           xCoords[ col ], yCoords[ nRows ] );
				}
			}
		}
		
		protected override void OnResize( EventArgs ev )
		{
			base.OnResize( ev );
			this.Invalidate( ClientRectangle );
		}
	}
}
