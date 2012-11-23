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

namespace Ext.Net
{
    /// <summary>
    /// The type of content that is to be loaded into a component, which can be one of 4 types
    /// </summary>
    public enum LoadMode
    {
        /// <summary>
        /// Loads raw html content, see Ext.AbstractComponent-html
        /// </summary>
        Html,
        /// <summary>
        /// Loads raw html content, see Ext.AbstractComponent-data
        /// </summary>
        Data,
        /// <summary>
        /// Loads child {Ext.AbstractComponent} instances. This option is only valid when used with a Container.
        /// </summary>
        Component,
        /// <summary>
        /// Loads a page inside generated iframe element. This option is only valid when used with a Container.
        /// </summary>
        Frame,
        /// <summary>
        /// Execute script
        /// </summary>
        Script
    }
}
