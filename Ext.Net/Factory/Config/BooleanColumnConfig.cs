/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.1.1 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BooleanColumn
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public BooleanColumn(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit BooleanColumn.Config Conversion to BooleanColumn
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator BooleanColumn(BooleanColumn.Config config)
        {
            return new BooleanColumn(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : CellCommandColumn.Config 
        { 
			/*  Implicit BooleanColumn.Config Conversion to BooleanColumn.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator BooleanColumn.Builder(BooleanColumn.Config config)
			{
				return new BooleanColumn.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string falseText = "false";

			/// <summary>
			/// The string returned by the renderer when the column value is falsey (but not undefined) (defaults to 'false').
			/// </summary>
			[DefaultValue("false")]
			public virtual string FalseText 
			{ 
				get
				{
					return this.falseText;
				}
				set
				{
					this.falseText = value;
				}
			}

			private string trueText = "true";

			/// <summary>
			/// The string returned by the renderer when the column value is not falsey (defaults to 'true').
			/// </summary>
			[DefaultValue("true")]
			public virtual string TrueText 
			{ 
				get
				{
					return this.trueText;
				}
				set
				{
					this.trueText = value;
				}
			}

			private string undefinedText = "&#160;";

			/// <summary>
			/// The string returned by the renderer when the column value is undefined (defaults to ' ').
			/// </summary>
			[DefaultValue("&#160;")]
			public virtual string UndefinedText 
			{ 
				get
				{
					return this.undefinedText;
				}
				set
				{
					this.undefinedText = value;
				}
			}

        }
    }
}