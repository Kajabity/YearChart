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

/*
 * Created by SharpDevelop.
 * User: simon
 * Date: 31/07/2009
 * Time: 23:29
 * 
 */
using System;

namespace YearChart.Model
{
    public enum CellType { Blank, Heading, Weekday, Weekend, Extra };
    
	/// <summary>
	/// Description of ModelCell.
	/// </summary>
	public abstract class YearChartCell
	{
        public CellType type = CellType.Blank;
        public string text = "";

		protected YearChartCell( CellType type, string text )
		{
            this.type = type;
            this.text = text;
		}
		
		protected YearChartCell()
		{
		}
	}
}
