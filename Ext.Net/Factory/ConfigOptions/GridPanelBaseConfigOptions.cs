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
    public abstract partial class GridPanelBase
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
                
                list.Add("selectionSubmit", new ConfigOption("selectionSubmit", null, true, this.SelectionSubmit ));
                list.Add("selectionMemory", new ConfigOption("selectionMemory", null, true, this.SelectionMemory ));
                list.Add("selectionMemoryEvents", new ConfigOption("selectionMemoryEvents", null, true, this.SelectionMemoryEvents ));
                list.Add("syncRowHeight", new ConfigOption("syncRowHeight", null, true, this.SyncRowHeight ));
                list.Add("lockText", new ConfigOption("lockText", null, "Lock", this.LockText ));
                list.Add("unlockText", new ConfigOption("unlockText", null, "Unlock", this.UnlockText ));
                list.Add("lockedView", new ConfigOption("lockedView", new SerializationOptions("lockedViewConfig>View"), null, this.LockedView ));
                list.Add("normalView", new ConfigOption("normalView", new SerializationOptions("normalViewConfig>View"), null, this.NormalView ));
                list.Add("view", new ConfigOption("view", new SerializationOptions("viewConfig>View"), null, this.View ));
                list.Add("verticalScroller", new ConfigOption("verticalScroller", new SerializationOptions("verticalScroller>Scroller"), null, this.VerticalScroller ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary", 1), null, this.Store ));
                list.Add("features", new ConfigOption("features", new SerializationOptions(typeof(ItemCollectionJsonConverter)), null, this.Features ));

                return list;
            }
        }
    }
}