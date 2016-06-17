/**
 * Copyright 2009-14 Williams Technologies Limited.
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

using System.IO;
using System.Windows.Forms;
using YearChart.Model;

namespace YearChart
{
    class YearChartHtmlWriter
    {
        private YearChartModel model;

        /// <summary>
        /// Construct a writer for a specified YearChart model instance.
        /// </summary>
        /// <param name="model">The YearChart model instance that is to be written as HTML.</param>
        public YearChartHtmlWriter( YearChartModel model )
        {
            this.model = model;
        }

        /// <summary>
        /// Write the model as HTML to the output stream.
        /// </summary>
        /// <param name="stream">The output stream where the HTML will be written.</param>
        public void Write( Stream stream )
        {
            //  28592              iso-8859-2                   Central European (ISO)
            //  28591              iso-8859-1                   Western European (ISO)
            //  65001              utf-8                        Unicode (UTF-8)
            //  from http://msdn.microsoft.com/en-us/library/system.text.encodinginfo.getencoding.aspx

            //  Create a writer to output to a UTF-8 encoding (code page 65001).
            using( StreamWriter writer = new StreamWriter( stream, System.Text.Encoding.GetEncoding( 65001 ) ) )
            {
                //TODO: Internationalise this part.
                writer.WriteLine( "<html lang=\"en-GB\">" );
                writer.WriteLine( "<head>" );
                writer.WriteLine( "	<meta charset=\"UTF-8\">" );
                writer.WriteLine( "	<title>" + model.Title + " | www.kajabity.com</title>" );
                writer.WriteLine( "	<meta name=\"generator\" content=\"Kajabity " + Application.ProductName + " version " + Application.ProductVersion + "\">" );
                writer.WriteLine( "	<style type=\"text/css\">" );
                writer.WriteLine( "	body { font-family: Arial, Helvetica, sans-serif; }" );
                writer.WriteLine( "	#header { height: 40px; }" );
                writer.WriteLine( "	#link { float: left; vertical-align:bottom; }" );
                writer.WriteLine( "	#year { float: right;  clear:none;}" );
                writer.WriteLine( "	#title { text-align:center; clear:none; width: 50%; }" );
                writer.WriteLine( "	table { background-color:black; border: 2px solid; width: 100%; }" );
                int cellWidthPercent = 100 / model.NumberOfColumns;
                //TODO: correct for rounding errors - for left headings, calculate by subtracting width of n-1 columns.
                writer.WriteLine( "	th { text-align:left; background-color:yellow; padding: 0; width: " + cellWidthPercent + "%; }" );
                writer.WriteLine( "	.thick-left { border-left:2px solid; }" );
                writer.WriteLine( "	.thick-right { border-right: 2px solid; }" );
                writer.WriteLine( "	.thick-top { border-top:2px solid; }" );
                writer.WriteLine( "	.thick-bottom { border-bottom: 2px solid; }" );
                writer.WriteLine( "	td { background-color:white; padding: 1; width: " + cellWidthPercent + "%; }" );
                writer.WriteLine( "	.empty { background-color:silver; }" );
                writer.WriteLine( "	.weekend { background-color:orange; }" );
                writer.WriteLine( "	</style>" );
                writer.WriteLine( "</head>" );

                writer.WriteLine( "<body>" );

                writer.WriteLine( "<div id=\"header\">" );
                writer.WriteLine( "	<div id=\"link\"><a href=\"http://www.kajabity.com\">www.kajabity.com</a></div>" );
                writer.WriteLine( "	<div id=\"title\"><h1>" + model.Title + "</h1></div>" );

                //TODO: This is common code - need to extract into a shared class.
                string year = model.Year.ToString();
                if( model.EndDate.Year > model.StartDate.Year )
                {
                    year = year + "-" + model.EndDate.Year;
                }

                writer.WriteLine( "	<div id=\"year\">" + year + "</div>" );
                writer.WriteLine( "</div>" );
                writer.WriteLine( "<table>" );

                //	Fill in the Cells
                for( int row = 0; row < model.NumberOfRows; row++ )
                {
                    writer.WriteLine( "	<tr>" );
                    for( int col = 0; col < model.NumberOfColumns; col++ )
                    {
                        YearChartCell day = model.Cells[ col, row ];
                        //TODO: Internationalise this part.
                        //TODO: Calculate day text with excaped HTML syntax.
                        //TODO: Calculate cell style - perhaps use Table level style instead.  Or row/column level style...  Specifically the border thicknesses.
                        if( day == null || day.type == CellType.Blank )
                        {
                            writer.WriteLine( "		<td class=\"empty\"></td>" );
                        }
                        else if( day.type == CellType.Heading )
                        {
                            writer.WriteLine( "		<th class=\"\">" + day.text + "</th>" );
                        }
                        else if( day.type == CellType.Weekday )
                        {
                            writer.WriteLine( "		<td class=\"\">" + day.text + "</td>" );
                        }
                        else if( day.type == CellType.Weekend )
                        {
                            writer.WriteLine( "		<td class=\"weekend\">" + day.text + "</td>" );
                        }
                        else if( day.type == CellType.Extra )
                        {
                            writer.WriteLine( "		<td class=\"\">" + day.text + "</td>" );
                        }
                    }

                    writer.WriteLine( "	</tr>" );
                }

                writer.WriteLine( "</table>" );
                writer.WriteLine( "</body>" );

                writer.WriteLine( "</html>" );
                writer.Close();
            }
        }
    }

}
