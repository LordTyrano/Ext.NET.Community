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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class MenuItemListeners : AbstractComponentListeners
    {
        private ComponentListener click;

        /// <summary>
        /// Fires when this item is clicked
        /// Parameters
        /// item : Ext.menu.Item
        ///     The item that was clicked
        /// e : Ext.EventObject
        ///     The underyling Ext.EventObject.
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this item is clicked")]
        public virtual ComponentListener Click
        {
            get
            {
                return this.click ?? (this.click = new ComponentListener());
            }
        }

        private ComponentListener activate;

        /// <summary>
        /// Fires when this item is activated
        /// Parameters
        /// item : Ext.menu.Item
        ///     The item that was clicked
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("activate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this item is activated")]
        public override ComponentListener Activate
        {
            get
            {
                return this.activate ?? (this.activate = new ComponentListener());
            }
        }

        private ComponentListener deactivate;

        /// <summary>
        /// Fires when this item is deactivated
        /// Parameters
        /// item : Ext.menu.Item
        ///     The item that was clicked
        /// </summary>
        [ListenerArgument(0, "item")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("deactivate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this item is deactivated")]
        public override ComponentListener Deactivate
        {
            get
            {
                return this.deactivate ?? (this.deactivate = new ComponentListener());
            }
        }

        private ComponentListener textchange;

        /// <summary>
        /// Fired when the item's text is changed by the setText} method.
        /// Parameters
        /// item : Ext.button.Button
        /// oldText : String
        /// newText : String
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "oldText")]
        [ListenerArgument(2, "newText")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("textchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when the item's text is changed by the setText} method.")]
        public virtual ComponentListener TextChange
        {
            get
            {
                return this.textchange ?? (this.textchange = new ComponentListener());
            }
        }

        private ComponentListener iconchange;

        /// <summary>
        /// Fired when the item's icon is changed by the setIcon or setIconCls methods.
        /// Parameters
        /// item : Ext.button.Button
        /// oldIcon : String
        /// newIcon : String
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "oldIcon")]
        [ListenerArgument(2, "newIcon")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iconchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when the item's icon is changed by the setIcon or setIconCls methods.")]
        public virtual ComponentListener IconChange
        {
            get
            {
                return this.iconchange ?? (this.iconchange = new ComponentListener());
            }
        }
    }
}