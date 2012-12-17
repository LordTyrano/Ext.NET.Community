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

using System;
using System.ComponentModel;

using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public class RemoteActionEventArgs : EventArgs
    {
        private readonly ParameterCollection extraParams;
        private JObject serviceParams;
        private bool accept;
        private string refusalMessage;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RemoteActionEventArgs(string serviceParams, ParameterCollection extraParams)
        {
            this.serviceParams = JObject.Parse(serviceParams);
            this.extraParams = extraParams;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Accept
        {
            get
            {
                return this.accept;
            }
            set
            {
                this.accept = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string RefusalMessage
        {
            get
            {
                return this.refusalMessage;
            }
            set
            {
                this.refusalMessage = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ParameterCollection ExtraParams
        {
            get
            {
                return this.extraParams;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected JObject ServiceParams
        {
            get
            {
                return this.serviceParams;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected T GetValue<T>(string name)
        {
            if (this.ServiceParams == null)
            {
                return default(T);
            }
            
            JProperty p = this.ServiceParams.Property(name);

            if (p == null || p.Value == null)
            {
                return default(T);
            }
            return p.Value.Value<T>();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string NodeID
        {
            get
            {
                return this.GetValue<string>("id");
            }
        }

        private object attributes;

        /// <summary>
        /// 
        /// </summary>
        public object Attributes
        {
            get
            {
                return this.attributes;
            }
            set
            {
                this.attributes = value;

                var p = ResourceManager.ExtraParamsResponse.GetParameter("ra_applyObject");
                if (p == null)
                {
                    p = new Parameter("ra_applyObject", "{}", ParameterMode.Raw);
                    ResourceManager.ExtraParamsResponse.Add(p);
                }            

                if (value == null)
                {
                    ResourceManager.ExtraParamsResponse.Remove(p);
                    return;
                }
                
                ResourceManager.ExtraParamsResponse["ra_applyObject"] = value is string ? value.ToString() : JSON.Serialize(value, JSON.ScriptConvertersInternal);
            }
        }
    }
}