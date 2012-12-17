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
    public partial class DataViewDraggable
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DataViewDraggable(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DataViewDraggable.Config Conversion to DataViewDraggable
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DataViewDraggable(DataViewDraggable.Config config)
        {
            return new DataViewDraggable(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit DataViewDraggable.Config Conversion to DataViewDraggable.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DataViewDraggable.Builder(DataViewDraggable.Config config)
			{
				return new DataViewDraggable.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string ghostCls = "";

			/// <summary>
			/// The CSS class added to the outermost element of the created ghost proxy
			/// </summary>
			[DefaultValue("")]
			public virtual string GhostCls 
			{ 
				get
				{
					return this.ghostCls;
				}
				set
				{
					this.ghostCls = value;
				}
			}

			private XTemplate ghostTpl = null;

			/// <summary>
			/// The template used in the ghost DataView
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate GhostTpl 
			{ 
				get
				{
					return this.ghostTpl;
				}
				set
				{
					this.ghostTpl = value;
				}
			}

			private DragZone dDConfig = null;

			/// <summary>
			/// Config object that is applied to the internally created DragZone
			/// </summary>
			[DefaultValue(null)]
			public virtual DragZone DDConfig 
			{ 
				get
				{
					return this.dDConfig;
				}
				set
				{
					this.dDConfig = value;
				}
			}

        }
    }
}