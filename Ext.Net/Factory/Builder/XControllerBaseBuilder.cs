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
    public abstract partial class XControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TXControllerBase, TBuilder> : Observable.Builder<TXControllerBase, TBuilder>
            where TXControllerBase : XControllerBase
            where TBuilder : Builder<TXControllerBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TXControllerBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Array of models to require from AppName.model namespace.
			/// </summary>
            public virtual TBuilder Models(string[] models)
            {
                this.ToComponent().Models = models;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Array of stores to require from AppName.store namespacee.
			/// </summary>
            public virtual TBuilder Stores(string[] stores)
            {
                this.ToComponent().Stores = stores;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Array of stores to require from AppName.store namespacee.
			/// </summary>
            public virtual TBuilder Views(string[] views)
            {
                this.ToComponent().Views = views;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The controller name. Required
			/// </summary>
            public virtual TBuilder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}