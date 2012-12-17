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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ValidationStatus), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:CapsLockDetector runat=\"server\" />")]
    [Description("")]
    public partial class CapsLockDetector : Plugin, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CapsLockDetector() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(CapsLockDetector), "Ext.Net.Build.Ext.Net.ux.capslockdetector.capslockdetector.js", "/ux/capslockdetector/capslockdetector.js"));

                return baseList;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.CapsLockDetector";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool PreventCapsLockChar
        {
            get
            {
                return this.State.Get<bool>("PreventCapsLockChar", false);
            }
            set
            {
                this.State.Set("PreventCapsLockChar", value);
            }
        }

        /// <summary>
        /// The error icon
        /// </summary>
        [Meta]
        [Category("3. CapsLockDetector")]
        [DefaultValue(Icon.None)]
        [Description("The error icon")]
        public virtual Icon CapsLockIndicatorIcon
        {
            get
            {
                return this.State.Get<Icon>("CapsLockIndicatorIcon", Icon.None);
            }
            set
            {
                this.State.Set("CapsLockIndicatorIcon", value);
            }
        }

        /// <summary>
        /// The error icon css class
        /// </summary>
        [Meta]
        [Category("3. CapsLockDetector")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CapsLockIndicatorIconCls
        {
            get
            {
                return this.State.Get<string>("CapsLockIndicatorIconCls", "");
            }
            set
            {
                this.State.Set("CapsLockIndicatorIconCls", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("capsLockIndicatorIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CapsLockIndicatorIconClsProxy
        {
            get
            {
                if (this.CapsLockIndicatorIcon != Icon.None)
                {
                    return ResourceManager.GetIconRequester(this.CapsLockIndicatorIcon);
                }

                return this.CapsLockIndicatorIconCls;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CapsLockDetector")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CapsLockIndicatorText
        {
            get
            {
                return this.State.Get<string>("CapsLockIndicatorText", "");
            }
            set
            {
                this.State.Set("CapsLockIndicatorText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CapsLockDetector")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CapsLockIndicatorTip
        {
            get
            {
                return this.State.Get<string>("CapsLockIndicatorTip", "");
            }
            set
            {
                this.State.Set("CapsLockIndicatorTip", value);
            }
        }

        private CapsLockDetectorListeners listeners;

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
        public CapsLockDetectorListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CapsLockDetectorListeners();
                }

                return this.listeners;
            }
        }


        private CapsLockDetectorDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side DirectEventHandlers")]
        public CapsLockDetectorDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CapsLockDetectorDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.CapsLockIndicatorIcon);
                return icons;
            }
        }
    }
}