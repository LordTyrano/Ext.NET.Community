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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class FormPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("pollInterval", new ConfigOption("pollInterval", null, 500, this.PollInterval ));
                list.Add("pollForChanges", new ConfigOption("pollForChanges", null, false, this.PollForChanges ));
                list.Add("errorReader", new ConfigOption("errorReader", new SerializationOptions("errorReader>PrimaryProxy"), null, this.ErrorReader ));
                list.Add("method", new ConfigOption("method", new SerializationOptions("method"), HttpMethod.Default, this.Method ));
                list.Add("reader", new ConfigOption("reader", new SerializationOptions("reader>PrimaryProxy"), null, this.Reader ));
                list.Add("standardSubmit", new ConfigOption("standardSubmit", null, false, this.StandardSubmit ));
                list.Add("timeout", new ConfigOption("timeout", null, 30, this.Timeout ));
                list.Add("trackResetOnLoad", new ConfigOption("trackResetOnLoad", null, false, this.TrackResetOnLoad ));
                list.Add("urlProxy", new ConfigOption("urlProxy", new SerializationOptions("url"), "", this.UrlProxy ));
                list.Add("waitMsgTarget", new ConfigOption("waitMsgTarget", null, "", this.WaitMsgTarget ));
                list.Add("waitTitle", new ConfigOption("waitTitle", null, "Please Wait...", this.WaitTitle ));
                list.Add("jsonSubmit", new ConfigOption("jsonSubmit", null, false, this.JsonSubmit ));
                list.Add("fieldDefaults", new ConfigOption("fieldDefaults", new SerializationOptions(JsonMode.Object), null, this.FieldDefaults ));

                return list;
            }
        }
    }
}