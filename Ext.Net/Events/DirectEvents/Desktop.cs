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
    public partial class DesktopDirectEvents : ComponentDirectEvents
    {
        public DesktopDirectEvents() { }

        public DesktopDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent shortcutmove;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "module")]
        [ListenerArgument(2, "record")]
        [ListenerArgument(3, "xy")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("shortcutmove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent ShortcutMove
        {
            get
            {
                return this.shortcutmove ?? (this.shortcutmove = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent shortcutnameedit;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "module")]
        [ListenerArgument(2, "value")]
        [ListenerArgument(3, "oldValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("shortcutnameedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent ShortcutNameEdit
        {
            get
            {
                return this.shortcutnameedit ?? (this.shortcutnameedit = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent ready;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "el")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("ready", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Ready
        {
            get
            {
                return this.ready ?? (this.ready = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeUnload;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "el")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeunload", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeUnload
        {
            get
            {
                return this.beforeUnload ?? (this.beforeUnload = new ComponentDirectEvent(this));
            }
        }
    }
}