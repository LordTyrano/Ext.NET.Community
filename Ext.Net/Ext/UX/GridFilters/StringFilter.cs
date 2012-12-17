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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    [Meta]
	[Description("")]
    public partial class StringFilter : GridFilter
    {
        public StringFilter() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. StringFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.String;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. StringFilter")]
        [DefaultValue("Enter Filter Text...")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string EmptyText
        {
            get
            {
                return this.State.Get<string>("EmptyText", "Enter Filter Text...");
            }
            set
            {
                this.State.Set("EmptyText", value);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. StringFilter")]
        [DefaultValue("")]
        [Description("Predefined filter value")]
        public virtual string Value
        {
            get
            {
                return this.State.Get<string>("Value", "");
            }
            set
            {
                this.State.Set("Value", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(string value)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(value));
        }
    }
}
