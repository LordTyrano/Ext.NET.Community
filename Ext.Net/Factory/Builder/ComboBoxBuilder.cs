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
    public partial class ComboBox
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TComboBox, TBuilder> : ComboBoxBase.Builder<TComboBox, TBuilder>
            where TComboBox : ComboBox
            where TBuilder : Builder<TComboBox, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TComboBox component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ComboBoxListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ComboBoxDirectEvents> action)
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
        public partial class Builder : ComboBox.Builder<ComboBox, ComboBox.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ComboBox()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComboBox component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComboBox.Config config) : base(new ComboBox(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ComboBox component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ComboBox.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ComboBox(this);
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
        public ComboBox.Builder ComboBox()
        {
#if MVC
			return this.ComboBox(new ComboBox { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ComboBox(new ComboBox());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ComboBox.Builder ComboBox(ComboBox component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ComboBox.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ComboBox.Builder ComboBox(ComboBox.Config config)
        {
#if MVC
			return new ComboBox.Builder(new ComboBox(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ComboBox.Builder(new ComboBox(config));
#endif			
        }
    }
}