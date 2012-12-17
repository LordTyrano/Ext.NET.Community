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
using System.IO;
using System.Text;
using Newtonsoft.Json;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    [Meta]
    [Description("")]
    public partial class NumericFilter : GridFilter
    {
        public NumericFilter() { }
        
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. NumericFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.Numeric;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. NumericFilter")]
        [DefaultValue("Enter Number...")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public string EmptyText
        {
            get
            {
                return this.State.Get<string>("EmptyText", "Enter Number...");
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
        [Category("3. NumericFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual float? GreaterThanValue
        {
            get
            {
                return this.State.Get<float?>("GreaterThanValue", null);
            }
            set
            {
                this.State.Set("GreaterThanValue", value);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Meta]
        [Category("3. NumericFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual float? LessThanValue
        {
            get
            {
                return this.State.Get<float?>("LessThanValue", null);
            }
            set
            {
                this.State.Set("LessThanValue", value);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Meta]
        [Category("3. NumericFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual float? EqualValue
        {
            get
            {
                return this.State.Get<float?>("EqualValue", null);
            }
            set
            {
                this.State.Set("EqualValue", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>      
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string ValueProxy
        {
            get
            {
                if (this.GreaterThanValue.HasValue || this.LessThanValue.HasValue || this.EqualValue.HasValue)
                {
                    StringWriter sw = new StringWriter(new StringBuilder());
                    JsonTextWriter jw = new JsonTextWriter(sw);
                    jw.WriteStartObject();

                    if (this.GreaterThanValue.HasValue)
                    {
                        jw.WritePropertyName("gt");
                        jw.WriteValue(this.GreaterThanValue);
                    }

                    if (this.LessThanValue.HasValue)
                    {
                        jw.WritePropertyName("lt");
                        jw.WriteValue(this.LessThanValue);
                    }

                    if (this.EqualValue.HasValue)
                    {
                        jw.WritePropertyName("eq");
                        jw.WriteValue(this.EqualValue);
                    }
                    
                    jw.WriteEndObject();

                    return sw.GetStringBuilder().ToString();
                }

                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(float? greaterThanValue, float? lessThanValue)
        {
            RequestManager.EnsureDirectEvent();

            string value = "{gt:".ConcatWith(greaterThanValue.HasValue ? JSON.Serialize(greaterThanValue.Value) : "undefined",
                    ",lt:", lessThanValue.HasValue ? JSON.Serialize(lessThanValue.Value) : "undefined", "}");

            this.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), value);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(float? eqValue)
        {
            RequestManager.EnsureDirectEvent();

            string value = "{eq:".ConcatWith(eqValue.HasValue ? JSON.Serialize(eqValue.Value) : "undefined", "}");
            this.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), value);
        }
    }
}
