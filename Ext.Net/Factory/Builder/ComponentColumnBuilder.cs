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
    public partial class ComponentColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TComponentColumn, TBuilder> : ColumnBase.Builder<TComponentColumn, TBuilder>
            where TComponentColumn : ComponentColumn
            where TBuilder : Builder<TComponentColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TComponentColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Component(Action<ItemsCollection<AbstractComponent>> action)
            {
                action(this.ToComponent().Component);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to show toolbar for over row only
			/// </summary>
            public virtual TBuilder OverOnly(bool overOnly)
            {
                this.ToComponent().OverOnly = overOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Delay before showing over toolbar
			/// </summary>
            public virtual TBuilder ShowDelay(int showDelay)
            {
                this.ToComponent().ShowDelay = showDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Delay before hide over toolbar
			/// </summary>
            public virtual TBuilder HideDelay(int hideDelay)
            {
                this.ToComponent().HideDelay = hideDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use component as cell editor
			/// </summary>
            public virtual TBuilder Editor(bool editor)
            {
                this.ToComponent().Editor = editor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to fit component's width
			/// </summary>
            public virtual TBuilder AutoWidthComponent(bool autoWidthComponent)
            {
                this.ToComponent().AutoWidthComponent = autoWidthComponent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to stop selection after click on the column
			/// </summary>
            public virtual TBuilder StopSelection(bool stopSelection)
            {
                this.ToComponent().StopSelection = stopSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Index of initial pinned row (component will be shown at this row)
			/// </summary>
            public virtual TBuilder PinIndex(int pinIndex)
            {
                this.ToComponent().PinIndex = pinIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to pin the component initially (you can show it manually)
			/// </summary>
            public virtual TBuilder Pin(bool pin)
            {
                this.ToComponent().Pin = pin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to pin all column if this column is pinned
			/// </summary>
            public virtual TBuilder PinAllColumns(bool pinAllColumns)
            {
                this.ToComponent().PinAllColumns = pinAllColumns;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Use Enter key for vertical navigation (can be used with shift key for up moving)
			/// </summary>
            public virtual TBuilder MoveEditorOnEnter(bool moveEditorOnEnter)
            {
                this.ToComponent().MoveEditorOnEnter = moveEditorOnEnter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Use Tab key for horizontal navigation (can be used with shift key for left moving)
			/// </summary>
            public virtual TBuilder MoveEditorOnTab(bool moveEditorOnTab)
            {
                this.ToComponent().MoveEditorOnTab = moveEditorOnTab;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide component immediately after unpin
			/// </summary>
            public virtual TBuilder HideOnUnpin(bool hideOnUnpin)
            {
                this.ToComponent().HideOnUnpin = hideOnUnpin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable key navigation of selection model
			/// </summary>
            public virtual TBuilder DisableKeyNavigation(bool disableKeyNavigation)
            {
                this.ToComponent().DisableKeyNavigation = disableKeyNavigation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to bubble key events from the component
			/// </summary>
            public virtual TBuilder SwallowKeyEvents(bool swallowKeyEvents)
            {
                this.ToComponent().SwallowKeyEvents = swallowKeyEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of events to pin the component in a row (uses with OverOnly=true)
			/// </summary>
            public virtual TBuilder PinEvents(string[] pinEvents)
            {
                this.ToComponent().PinEvents = pinEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of events to unpin the component in a row (uses with OverOnly=true)
			/// </summary>
            public virtual TBuilder UnpinEvents(string[] unpinEvents)
            {
                this.ToComponent().UnpinEvents = unpinEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ComponentColumnListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ComponentColumnDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentColumn.Builder<ComponentColumn, ComponentColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ComponentColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentColumn.Config config) : base(new ComponentColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ComponentColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ComponentColumn(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ComponentColumn.Builder ComponentColumn()
        {
#if MVC
			return this.ComponentColumn(new ComponentColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ComponentColumn(new ComponentColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentColumn.Builder ComponentColumn(ComponentColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ComponentColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentColumn.Builder ComponentColumn(ComponentColumn.Config config)
        {
#if MVC
			return new ComponentColumn.Builder(new ComponentColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ComponentColumn.Builder(new ComponentColumn(config));
#endif			
        }
    }
}