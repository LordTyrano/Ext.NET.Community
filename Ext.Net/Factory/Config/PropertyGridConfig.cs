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
    public partial class PropertyGrid
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit PropertyGrid.Config Conversion to PropertyGrid
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator PropertyGrid(PropertyGrid.Config config)
        {
            return new PropertyGrid(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridPanelBase.Config 
        { 
			/*  Implicit PropertyGrid.Config Conversion to PropertyGrid.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator PropertyGrid.Builder(PropertyGrid.Config config)
			{
				return new PropertyGrid.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private PropertyGridParameterCollection source = null;

			/// <summary>
			/// A data object to use as the data source of the grid.
			/// </summary>
			public PropertyGridParameterCollection Source
			{
				get
				{
					if (this.source == null)
					{
						this.source = new PropertyGridParameterCollection();
					}
			
					return this.source;
				}
			}
			
			private bool editable = true;

			/// <summary>
			/// If false then all cells will be read only
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Editable 
			{ 
				get
				{
					return this.editable;
				}
				set
				{
					this.editable = value;
				}
			}

			private bool inferTypes = true;

			/// <summary>
			/// True to automatically infer the type based on the initial value passed for each field. This ensures the editor remains the correct type even if the value is blanked and becomes empty. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool InferTypes 
			{ 
				get
				{
					return this.inferTypes;
				}
				set
				{
					this.inferTypes = value;
				}
			}

			private int nameColumnWidth = 115;

			/// <summary>
			/// Optional. Specify the width for the name column. The value column will take any remaining space. Defaults to 115.
			/// </summary>
			[DefaultValue(115)]
			public virtual int NameColumnWidth 
			{ 
				get
				{
					return this.nameColumnWidth;
				}
				set
				{
					this.nameColumnWidth = value;
				}
			}
        
			private PropertyGridListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public PropertyGridListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new PropertyGridListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private PropertyGridDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public PropertyGridDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new PropertyGridDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}