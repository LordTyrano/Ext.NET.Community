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
    ///<summary>
    ///</summary>
    public partial class ComponentLoaderDirectEvents : ComponentDirectEvents
    {
        public ComponentLoaderDirectEvents() { }

        public ComponentLoaderDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeLoad;

        /// <summary>
        /// Fires before a load request is made to the server. Returning false from an event listener can prevent the load from occurring.
        /// Parameters
        ///   item : Ext.ComponentLoader
        ///   
        ///   options : Object
        ///   The options passed to the request
        /// </summary>
        [ListenerArgument(0, "item", typeof(ComponentLoader), "this")]
        [ListenerArgument(1, "options", typeof(object), "The options passed to the request")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a load request is made to the server. Returning false from an event listener can prevent the load from occurring.")]
        public virtual ComponentDirectEvent BeforeLoad
        {
            get
            {
                return this.beforeLoad ?? (this.beforeLoad = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent exception;

        /// <summary>
        /// Fires after an unsuccessful load.
        /// Parameters
        ///   item : Ext.ComponentLoader
        ///   
        ///   response : Object
        ///   The response from the server
        /// 
        ///   options : Object
        ///   The options passed to the request
        /// </summary>
        [ListenerArgument(0, "item", typeof(ComponentLoader), "this")]
        [ListenerArgument(1, "response", typeof(object), "The response from the server")]
        [ListenerArgument(2, "options", typeof(object), "The options passed to the request")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("exception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an unsuccessful load.")]
        public virtual ComponentDirectEvent Exception
        {
            get
            {
                return this.exception ?? (this.exception = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent load;

        /// <summary>
        /// Fires after a successful load.
        /// Parameters
        ///   item : Ext.ComponentLoader
        ///   
        ///   response : Object
        ///   The response from the server
        /// 
        ///   options : Object
        ///   The options passed to the request
        /// </summary>
        [ListenerArgument(0, "item", typeof(ComponentLoader), "this")]
        [ListenerArgument(1, "response", typeof(object), "The response from the server")]
        [ListenerArgument(2, "options", typeof(object), "The options passed to the request")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a successful load.")]
        public virtual ComponentDirectEvent Load
        {
            get
            {
                return this.load ?? (this.load = new ComponentDirectEvent(this));
            }
        }
    }
}
