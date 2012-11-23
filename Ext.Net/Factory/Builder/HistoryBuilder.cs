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
    public partial class History
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<THistory, TBuilder> : Observable.Builder<THistory, TBuilder>
            where THistory : History
            where TBuilder : Builder<THistory, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(THistory component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<HistoryListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<HistoryDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CallHistory(string name, params object[] args)
            {
                this.ToComponent().CallHistory(name, args);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add a new token to the history stack. This can be any arbitrary value, although it would commonly be the concatenation of a component id and another id marking the specifc history state of that component.
			/// </summary>
            public virtual TBuilder Add(string token, bool preventDuplicate)
            {
                this.ToComponent().Add(token, preventDuplicate);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add a new token to the history stack. This can be any arbitrary value, although it would commonly be the concatenation of a component id and another id marking the specifc history state of that component.
			/// </summary>
            public virtual TBuilder Add(string token)
            {
                this.ToComponent().Add(token);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Programmatically steps back one step in browser history (equivalent to the user pressing the Back button).
			/// </summary>
            public virtual TBuilder Back()
            {
                this.ToComponent().Back();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Programmatically steps forward one step in browser history (equivalent to the user pressing the Forward button).
			/// </summary>
            public virtual TBuilder Forward()
            {
                this.ToComponent().Forward();
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : History.Builder<History, History.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new History()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(History component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(History.Config config) : base(new History(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(History component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public History.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.History(this);
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
        public History.Builder History()
        {
#if MVC
			return this.History(new History { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.History(new History());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public History.Builder History(History component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new History.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public History.Builder History(History.Config config)
        {
#if MVC
			return new History.Builder(new History(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new History.Builder(new History(config));
#endif			
        }
    }
}