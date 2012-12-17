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
using System;

namespace Ext.Net
{
    /// <summary>
    /// A Column subclass which renders a checkbox in each column cell which toggles the truthiness of the associated data field on click.
    /// </summary>
    [Meta]
    [Description("")]
    public partial class CheckColumn : ColumnBase, INoneEditable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CheckColumn() { }

		/// <summary>
		/// 
		/// </summary>        
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "checkcolumn";
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.Editor.Primary != null && !this.IsRowEditing)
            {
                throw new Exception("CheckColumn doesn't support Editor as cell editor. Please use Editable property");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CheckColumn")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool Editable
        {
            get
            {
                return this.State.Get<bool>("Editable", false);
            }
            set
            {
                this.State.Set("Editable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CheckColumn")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool SingleSelect
        {
            get
            {
                return this.State.Get<bool>("SingleSelect", false);
            }
            set
            {
                this.State.Set("SingleSelect", value);
            }
        }

        /// <summary>
        /// Prevent grid selection upon mousedown.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CheckColumn")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool StopSelection
        {
            get
            {
                return this.State.Get<bool>("SingleSelect", true);
            }
            set
            {
                this.State.Set("SingleSelect", value);
            }
        }

        private CheckColumnListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public CheckColumnListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CheckColumnListeners();
                }

                return this.listeners;
            }
        }

        private CheckColumnDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public CheckColumnDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CheckColumnDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}
