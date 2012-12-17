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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractTabPanel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAbstractTabPanel"></typeparam>
        /// <typeparam name="TBuilder"></typeparam>
        new public abstract partial class Builder<TAbstractTabPanel, TBuilder> : AbstractPanel.Builder<TAbstractTabPanel, TBuilder>
            where TAbstractTabPanel : AbstractTabPanel
            where TBuilder : Builder<TAbstractTabPanel, TBuilder>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>
            public virtual TBuilder DefaultTabMenuBuilder(Action<DefaultTabMenuCollectionBuilder<TAbstractTabPanel, TBuilder>> action)
            {
                action(new DefaultTabMenuCollectionBuilder<TAbstractTabPanel, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            /// <summary>
            /// TabBar collection
            /// </summary>
            [Description("TabBar collection")]
            public virtual TBuilder TabBar(AbstractComponent item)
            {
                this.ToComponent().TabBar.Add(item);
                return this as TBuilder;
            }

            /// <summary>
            /// TabBar collection
            /// </summary>
            [Description("TabBar collection")]
            public virtual TBuilder TabBar(IEnumerable<AbstractComponent> items)
            {
                this.ToComponent().TabBar.AddRange(items);
                return this as TBuilder;
            }

            /// <summary>
            /// TabBar collection
            /// </summary>
            [Description("TabBar collection")]
            public virtual TBuilder TabBar(params AbstractComponent[] items)
            {
                this.ToComponent().TabBar.AddRange(items);
                return this as TBuilder;
            }
        }
    }
}