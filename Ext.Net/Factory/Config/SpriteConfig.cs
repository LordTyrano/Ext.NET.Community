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
    public partial class Sprite
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Sprite(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Sprite.Config Conversion to Sprite
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Sprite(Sprite.Config config)
        {
            return new Sprite(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : SpriteAttributes.Config 
        { 
			/*  Implicit Sprite.Config Conversion to Sprite.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Sprite.Builder(Sprite.Config config)
			{
				return new Sprite.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string spriteID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string SpriteID 
			{ 
				get
				{
					return this.spriteID;
				}
				set
				{
					this.spriteID = value;
				}
			}

			private bool draggable = false;

			/// <summary>
			/// True to make the sprite draggable.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Draggable 
			{ 
				get
				{
					return this.draggable;
				}
				set
				{
					this.draggable = value;
				}
			}

			private DragSource draggableConfig = null;

			/// <summary>
			/// Drag config object.
			/// </summary>
			[DefaultValue(null)]
			public virtual DragSource DraggableConfig 
			{ 
				get
				{
					return this.draggableConfig;
				}
				set
				{
					this.draggableConfig = value;
				}
			}

			private string[] group = null;

			/// <summary>
			/// The group that this sprite belongs to, or an array of groups. Only relevant when added to a Ext.draw.Surface
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Group 
			{ 
				get
				{
					return this.group;
				}
				set
				{
					this.group = value;
				}
			}
        
			private SpriteListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public SpriteListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new SpriteListeners();
					}
			
					return this.listeners;
				}
			}
			
        }
    }
}