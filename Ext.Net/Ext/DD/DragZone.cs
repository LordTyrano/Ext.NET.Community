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

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This class provides a container DD instance that allows dragging of multiple child source nodes.
    /// This class does not move the drag target nodes, but a proxy element which may contain any DOM structure you wish. The DOM element to show in the proxy is provided by either a provided implementation of getDragData, or by registered draggables registered with Ext.dd.Registry
    /// If you wish to provide draggability for an arbitrary number of DOM nodes, each of which represent some application object (For example nodes in a DataView) then use of this class is the most efficient way to "activate" those nodes.
    /// By default, this class requires that draggable child nodes are registered with Ext.dd.Registry. However a simpler way to allow a DragZone to manage any number of draggable elements is to configure the DragZone with an implementation of the getDragData method which interrogates the passed mouse event to see if it has taken place within an element, or class of elements. This is easily done by using the event's getTarget method to identify a node based on a Ext.DomQuery selector.
    /// </summary>
    [Meta]
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:DragZone runat=\"server\"></{0}:DragZone>")]
    [ToolboxBitmap(typeof(DragZone), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("This class provides a container DD instance that allows dragging of multiple child source nodes.")]
    public partial class DragZone : DragSource
    {
        /// <summary>
        /// 
        /// </summary>
        public DragZone()
        {
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
                return "Ext.dd.DragZone";
            }
        }

        /// <summary>
        /// True to register this container with the Scrollmanager for auto scrolling during drag operations.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. DragZone")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to register this container with the Scrollmanager for auto scrolling during drag operations.")]
        public virtual bool ContainerScroll
        {
            get
            {
                return this.State.Get<bool>("ContainerScroll", false);
            }
            set
            {
                this.State.Set("ContainerScroll", value);
            }
        }
        
        private JFunction afterRepair;

        /// <summary>
        /// Called after a repair of an invalid drop. By default, highlights this.dragData.ddel
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("7. DragSource")]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called after a repair of an invalid drop. By default, highlights this.dragData.ddel")]
        public virtual JFunction AfterRepair
        {
            get
            {
                if (this.afterRepair == null)
                {
                    this.afterRepair = new JFunction();
                }

                return this.afterRepair;
            }
        }


        private JFunction getRepairXY;

        /// <summary>
        /// Called before a repair of an invalid drop to get the XY to animate to. By default returns the XY of this.dragData.ddel
        /// Parameters:
        ///    e : The mouse up event
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("7. DragSource")]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called before a repair of an invalid drop to get the XY to animate to. By default returns the XY of this.dragData.ddel")]
        public virtual JFunction GetRepairXY
        {
            get
            {
                if (this.getRepairXY == null)
                {
                    this.getRepairXY = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.getRepairXY.Args = new string[] {"e"};
                    }
                }

                return this.getRepairXY;
            }
        }

        private JFunction onInitDrag;

        /// <summary>
        /// Called once drag threshold has been reached to initialize the proxy element. By default, it clones the this.dragData.ddel
        /// Parameters:
        ///    x : The x position of the click on the dragged object
        ///    y : The y position of the click on the dragged object
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("7. DragSource")]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called once drag threshold has been reached to initialize the proxy element. By default, it clones the this.dragData.ddel")]
        public virtual JFunction OnInitDrag
        {
            get
            {
                if (this.onInitDrag == null)
                {
                    this.onInitDrag = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.onInitDrag.Args = new string[] {"x", "y"};
                    }
                }

                return this.onInitDrag;
            }
        }
    }
}