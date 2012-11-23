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
    public abstract partial class GridPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : TablePanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool selectionSubmit = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SelectionSubmit 
			{ 
				get
				{
					return this.selectionSubmit;
				}
				set
				{
					this.selectionSubmit = value;
				}
			}

			private bool selectionMemory = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SelectionMemory 
			{ 
				get
				{
					return this.selectionMemory;
				}
				set
				{
					this.selectionMemory = value;
				}
			}

			private bool selectionMemoryEvents = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SelectionMemoryEvents 
			{ 
				get
				{
					return this.selectionMemoryEvents;
				}
				set
				{
					this.selectionMemoryEvents = value;
				}
			}

			private bool syncRowHeight = true;

			/// <summary>
			/// Synchronize rowHeight between the normal and locked grid view. This is turned on by default. If your grid is guaranteed to have rows of all the same height, you should set this to false to optimize performance. 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SyncRowHeight 
			{ 
				get
				{
					return this.syncRowHeight;
				}
				set
				{
					this.syncRowHeight = value;
				}
			}

			private string lockText = "Lock";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Lock")]
			public virtual string LockText 
			{ 
				get
				{
					return this.lockText;
				}
				set
				{
					this.lockText = value;
				}
			}

			private string unlockText = "Unlock";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Unlock")]
			public virtual string UnlockText 
			{ 
				get
				{
					return this.unlockText;
				}
				set
				{
					this.unlockText = value;
				}
			}
        
			private ViewCollection<GridView> lockedView = null;

			/// <summary>
			/// A view configuration to be applied to the locked side of the grid. Any conflicting configurations between lockedViewConfig and viewConfig will be overwritten by the lockedViewConfig.
			/// </summary>
			public ViewCollection<GridView> LockedView
			{
				get
				{
					if (this.lockedView == null)
					{
						this.lockedView = new ViewCollection<GridView>();
					}
			
					return this.lockedView;
				}
			}
			        
			private ViewCollection<GridView> normalView = null;

			/// <summary>
			/// A view configuration to be applied to the normal/unlocked side of the grid. Any conflicting configurations between normalViewConfig and viewConfig will be overwritten by the normalViewConfig. 
			/// </summary>
			public ViewCollection<GridView> NormalView
			{
				get
				{
					if (this.normalView == null)
					{
						this.normalView = new ViewCollection<GridView>();
					}
			
					return this.normalView;
				}
			}
			        
			private ViewCollection<GridView> view = null;

			/// <summary>
			/// The Ext.grid.View used by the grid. This can be set before a call to render().
			/// </summary>
			public ViewCollection<GridView> View
			{
				get
				{
					if (this.view == null)
					{
						this.view = new ViewCollection<GridView>();
					}
			
					return this.view;
				}
			}
			        
			private GridScrollerCollection verticalScroller = null;

			/// <summary>
			/// 
			/// </summary>
			public GridScrollerCollection VerticalScroller
			{
				get
				{
					if (this.verticalScroller == null)
					{
						this.verticalScroller = new GridScrollerCollection();
					}
			
					return this.verticalScroller;
				}
			}
			        
			private StoreCollection<Store> store = null;

			/// <summary>
			/// The Ext.Net.Store the grid should use as its data source (required).
			/// </summary>
			public StoreCollection<Store> Store
			{
				get
				{
					if (this.store == null)
					{
						this.store = new StoreCollection<Store>();
					}
			
					return this.store;
				}
			}
			        
			private ItemsCollection<GridFeature> features = null;

			/// <summary>
			/// An array of grid features
			/// </summary>
			public ItemsCollection<GridFeature> Features
			{
				get
				{
					if (this.features == null)
					{
						this.features = new ItemsCollection<GridFeature>();
					}
			
					return this.features;
				}
			}
			
        }
    }
}