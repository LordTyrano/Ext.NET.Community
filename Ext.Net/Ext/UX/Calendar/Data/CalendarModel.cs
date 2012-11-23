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
 ********/using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ext.Net
{
    /// <summary>
    /// This is the Record specification for calendar items used by the
    /// CalendarPanel's calendar store. If your model fields 
    /// are named differently you should update the mapping configs accordingly.
    /// The only required fields when creating a new calendar record instance are CalendarId and
    /// Title.  All other fields are either optional or will be defaulted if blank.
    /// </summary>
    public partial class CalendarModel
    {        
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual int? CalendarId 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Newtonsoft.Json.JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Title 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Newtonsoft.Json.JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual bool? IsHidden
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CalendarMappingsContractResolver : DefaultContractResolver
    {
        Dictionary<string, string> mappings = new Dictionary<string, string>(5);

        public CalendarMappingsContractResolver()
        {            
            mappings["CalendarId"] = "id";            
            mappings["Title"] = "title";
            mappings["Description"] = "desc";
            mappings["IsHidden"] = "hidden";
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            return this.mappings.ContainsKey(propertyName) ? this.mappings[propertyName] : propertyName;
        }        
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CalendarModelCollection : List<CalendarModel> 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Serialize(bool mapping)
        {
            return JSON.Serialize(this, mapping ? new CalendarMappingsContractResolver() : null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static CalendarModelCollection Deserialize(string json)
        {
            return CalendarModelCollection.Deserialize(json, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        public static CalendarModelCollection Deserialize(string json, bool mapping)
        {
            return JSON.Deserialize<CalendarModelCollection>(json, mapping ? new CalendarMappingsContractResolver() : null);
        }
    }
}