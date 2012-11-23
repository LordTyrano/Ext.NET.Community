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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class FlashComponentListeners : AbstractComponentListeners
    {
        private ComponentListener failure;

        /// <summary>
        /// Fired when the Flash movie embedding fails
        /// Parameters
        ///     item : Ext.flash.Component
        /// </summary>
        [ListenerArgument(0, "item", typeof(FlashComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("failure", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when the Flash movie embedding fails")]
        public virtual ComponentListener Failure
        {
            get
            {
                return this.failure ?? (this.failure = new ComponentListener());
            }
        }

        private ComponentListener success;

        /// <summary>
        /// Fired when the Flash movie has been successfully embedded
        /// Parameters
        ///     item : Ext.flash.Component
        /// </summary>
        [ListenerArgument(0, "item", typeof(FlashComponent), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("success", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when the Flash movie has been successfully embedded")]
        public virtual ComponentListener Success
        {
            get
            {
                return this.success ?? (this.success = new ComponentListener());
            }
        }
    }
}