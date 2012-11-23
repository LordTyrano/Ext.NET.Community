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
    [ToolboxBitmap(typeof(PortalColumn), "Build.ToolboxIcons.PortalColumn.bmp")]
    [ToolboxData("<{0}:PortalColumn runat=\"server\" StyleSpec=\"padding:10px 0 10px 10px\"><Items><{0}:AnchorLayout ID=\"AnchorLayout1\" runat=\"server\"><{0}:Anchor Horizontal=\"100%\"><{0}:Portlet Title=\"Portlet\" runat=\"server\" /></{0}:Anchor></{0}:AnchorLayout></Items></{0}:PortalColumn>")]
    [Description("")]
    public partial class PortalColumn : Panel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PortalColumn() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "portalcolumn";
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
                return "Ext.app.PortalColumn";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string DefaultLayout
        {
            get
            {
                return "anchor";
            }
        }

        /// <summary>
        /// The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.
        /// </summary>        
        [ConfigOption]
        [Category("4. AbstractContainer")]
        [DefaultValue("portlet")]
        [NotifyParentProperty(true)]
        [Description("The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.")]
        public override string DefaultType
        {
            get
            {
                return this.State.Get<string>("DefaultType", "portlet");
            }
            set
            {
                this.State.Set("DefaultType", value);
            }
        }
    }
}