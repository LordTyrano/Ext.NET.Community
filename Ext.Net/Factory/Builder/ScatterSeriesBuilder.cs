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
    public partial class ScatterSeries
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TScatterSeries, TBuilder> : CartesianSeries.Builder<TScatterSeries, TBuilder>
            where TScatterSeries : ScatterSeries
            where TBuilder : Builder<TScatterSeries, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TScatterSeries component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkerConfig(SpriteAttributes markerConfig)
            {
                this.ToComponent().MarkerConfig = markerConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Style(SpriteAttributes style)
            {
                this.ToComponent().Style = style;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ScatterSeries.Builder<ScatterSeries, ScatterSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ScatterSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ScatterSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ScatterSeries.Config config) : base(new ScatterSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ScatterSeries component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ScatterSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ScatterSeries(this);
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
        public ScatterSeries.Builder ScatterSeries()
        {
#if MVC
			return this.ScatterSeries(new ScatterSeries { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ScatterSeries(new ScatterSeries());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ScatterSeries.Builder ScatterSeries(ScatterSeries component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ScatterSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ScatterSeries.Builder ScatterSeries(ScatterSeries.Config config)
        {
#if MVC
			return new ScatterSeries.Builder(new ScatterSeries(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ScatterSeries.Builder(new ScatterSeries(config));
#endif			
        }
    }
}