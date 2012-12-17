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
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;

namespace Ext.Net
{
    /// <summary>
    /// Adds custom behavior for left/right keyboard navigation for use with a tree.
    /// Depends on the view having an expand and collapse method which accepts a record. 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class TreeSelectionModel : RowSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreeSelectionModel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.selection.TreeModel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        [DefaultValue("")]
        [ConfigOption]
        public override string SelType
        {
            get
            {
                return "treemodel";
            }
        }

        /// <summary>
        /// Prune records when they are removed from the store from the selection. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Prune records when they are removed from the store from the selection.")]
        public override bool PruneRemoved
        {
            get
            {
                return this.State.Get<bool>("PruneRemoved", false);
            }
            set
            {
                this.State.Set("PruneRemoved", value);
            }
        }

        private List<SubmittedNode> selectedNodes;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual List<SubmittedNode> SelectedNodes
        {
            get
            {
                return this.selectedNodes;
            }
            protected internal set
            {
                this.selectedNodes = value;
            }
        }

        private SelectedRowCollection selectedRows;
        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("selectedData", JsonMode.AlwaysArray)]
        [Description("")]
        public override SelectedRowCollection SelectedRows
        {
            get
            {
                if (this.selectedRows == null)
                {
                    this.selectedRows = new SelectedRowCollection();

                    if (this.SelectedNodes != null && this.SelectedNodes.Count > 0)
                    {
                        this.selectedRows.AddRange(this.SelectedNodes.ConvertAll<SelectedRow>(n => new SelectedRow(n.NodeID)));
                    }
                }

                return this.selectedRows;
            }
        }
    }
}
