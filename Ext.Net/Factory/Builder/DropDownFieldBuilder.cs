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
    public partial class DropDownField
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDropDownField, TBuilder> : DropDownFieldBase.Builder<TDropDownField, TBuilder>
            where TDropDownField : DropDownField
            where TBuilder : Builder<TDropDownField, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDropDownField component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<PickerFieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<PickerFieldDirectEvents> action)
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
        public partial class Builder : DropDownField.Builder<DropDownField, DropDownField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DropDownField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DropDownField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DropDownField.Config config) : base(new DropDownField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DropDownField component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DropDownField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DropDownField(this);
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
        public DropDownField.Builder DropDownField()
        {
#if MVC
			return this.DropDownField(new DropDownField { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DropDownField(new DropDownField());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DropDownField.Builder DropDownField(DropDownField component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DropDownField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DropDownField.Builder DropDownField(DropDownField.Config config)
        {
#if MVC
			return new DropDownField.Builder(new DropDownField(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DropDownField.Builder(new DropDownField(config));
#endif			
        }
    }
}