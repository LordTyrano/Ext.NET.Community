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
    /// A generic Plugin.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxData("<{0}:GenericPlugin runat=\"server\" />")]
    [Description("A generic Plugin.")]
    public partial class GenericPlugin : Plugin
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GenericPlugin() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GenericPlugin(string instanceName, string path)
        {
            this.InstanceName = instanceName;
            this.Path = path;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return this.InstanceName;
            }
        }

        /// <summary>
        /// The JavaScript class name. Used to create a 'new' instance of the object.
        /// </summary>
        [Meta]
        [Category("3. GenericPlugin")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The JavaScript class name. Used to create a 'new' instance of the object.")]
        public virtual string InstanceName
        {
            get
            {
                return this.State.Get<string>("InstanceName", "");
            }
            set
            {
                this.State.Set("InstanceName", value);
            }
        }

        /// <summary>
        /// The file path to the required JavaScript file.
        /// </summary>
        [Meta]
        [Category("3. GenericPlugin")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The file path to the required JavaScript file.")]
        public virtual string Path
        {
            get
            {
                return this.State.Get<string>("Path", "");
            }
            set
            {
                this.State.Set("Path", value);
            }
        }
    }
}