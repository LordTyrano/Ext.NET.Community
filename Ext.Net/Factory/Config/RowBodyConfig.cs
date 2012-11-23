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
 * @version   : 2.1.0 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public partial class RowBody
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RowBody(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RowBody.Config Conversion to RowBody
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RowBody(RowBody.Config config)
        {
            return new RowBody(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridFeature.Config 
        { 
			/*  Implicit RowBody.Config Conversion to RowBody.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RowBody.Builder(RowBody.Config config)
			{
				return new RowBody.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string rowBodyHiddenCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string RowBodyHiddenCls 
			{ 
				get
				{
					return this.rowBodyHiddenCls;
				}
				set
				{
					this.rowBodyHiddenCls = value;
				}
			}

			private string rowBodyTrCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string RowBodyTrCls 
			{ 
				get
				{
					return this.rowBodyTrCls;
				}
				set
				{
					this.rowBodyTrCls = value;
				}
			}

			private string rowBodyTdCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string RowBodyTdCls 
			{ 
				get
				{
					return this.rowBodyTdCls;
				}
				set
				{
					this.rowBodyTdCls = value;
				}
			}

			private string rowBodyDivCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string RowBodyDivCls 
			{ 
				get
				{
					return this.rowBodyDivCls;
				}
				set
				{
					this.rowBodyDivCls = value;
				}
			}
        
			private JFunction getAdditionalData = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction GetAdditionalData
			{
				get
				{
					if (this.getAdditionalData == null)
					{
						this.getAdditionalData = new JFunction();
					}
			
					return this.getAdditionalData;
				}
			}
			
        }
    }
}