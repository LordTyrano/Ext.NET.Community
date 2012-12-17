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

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class BaseListener : BaseItem
    {
        /// <summary>
        /// The scope in which to execute the handler function. The handler function's 'this' context.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("this")]
        [NotifyParentProperty(true)]
        [Description("The scope in which to execute the handler function. The handler function's 'this' context.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "this");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// A simple selector to filter the target or look for a descendant of the target
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A simple selector to filter the target or look for a descendant of the target")]
        public virtual string Delegate
        {
            get
            {
                return this.State.Get<string>("Delegate", "");
            }
            set
            {
                this.State.Set("Delegate", value);
            }
        }

        /// <summary>
        /// True to stop the event. That is stop propagation, and prevent the default action.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to stop the event. That is stop propagation, and prevent the default action.")]
        public virtual bool StopEvent
        {
            get
            {
                return this.State.Get<bool>("StopEvent", false);
            }
            set
            {
                this.State.Set("StopEvent", value);
            }
        }

        /// <summary>
        /// True to prevent the default action.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prevent the default action.")]
        public virtual bool PreventDefault
        {
            get
            {
                return this.State.Get<bool>("PreventDefault", false);
            }
            set
            {
                this.State.Set("PreventDefault", value);
            }
        }

        /// <summary>
        /// True to prevent event propagation.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prevent event propagation.")]
        public virtual bool StopPropagation
        {
            get
            {
                return this.State.Get<bool>("StopPropagation", false);
            }
            set
            {
                this.State.Set("StopPropagation", value);
            }
        }

        /// <summary>
        /// False to pass a browser event to the handler function instead of an Ext.EventObject.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to pass a browser event to the handler function instead of an Ext.EventObject.")]
        public virtual bool Normalized
        {
            get
            {
                return this.State.Get<bool>("Normalized", false);
            }
            set
            {
                this.State.Set("Normalized", value);
            }
        }

        /// <summary>
        /// The number of milliseconds to delay the invocation of the handler after the event fires.
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds to delay the invocation of the handler after the event fires.")]
        public virtual int Delay
        {
            get
            {
                return this.State.Get<int>("Delay", 0);
            }
            set
            {
                this.State.Set("Delay", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool HasOwnDelay
        {
            get
            {
                return this.State.Get<int>("Delay", int.MinValue) != int.MinValue;
            }
        }

        /// <summary>
        /// True to add a handler to handle just the next firing of the event, and then remove itself.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to add a handler to handle just the next firing of the event, and then remove itself.")]
        public virtual bool Single
        {
            get
            {
                return this.State.Get<bool>("Single", false);
            }
            set
            {
                this.State.Set("Single", value);
            }
        }

        /// <summary>
        /// Causes the handler to be scheduled to run in an Ext.util.DelayedTask delayed by the specified number of milliseconds. If the event fires again within that time, the original handler is not invoked, but the new handler is scheduled in its place.
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Causes the handler to be scheduled to run in an Ext.util.DelayedTask delayed by the specified number of milliseconds. If the event fires again within that time, the original handler is not invoked, but the new handler is scheduled in its place.")]
        public virtual int Buffer
        {
            get
            {
                return this.State.Get<int>("Buffer", 0);
            }
            set
            {
                this.State.Set("Buffer", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public HandlerConfig GetListenerConfig()
        {
            HandlerConfig cfg = new HandlerConfig();
            cfg.Scope = this.Scope == "this" ? null : this.Scope;
            cfg.Buffer = this.Buffer;
            cfg.Delay = this.Delay;
            cfg.Single = this.Single;
            cfg.Delegate = this.Delegate == "" ? null : this.Delegate;
            cfg.Normalized = this.Normalized;
            cfg.PreventDefault = this.PreventDefault;
            cfg.StopEvent = this.StopEvent;
            cfg.StopPropagation = this.StopPropagation;

            return cfg;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public void ClearListenerConfig()
        {
            this.State.Set("Scope", null);
            this.State.Set("Buffer", null);
            this.State.Set("Delay", null);
            this.State.Set("Single", null);
            this.State.Set("Delegate", null);
            this.State.Set("Normalized", null);
            this.State.Set("PreventDefault", null);
            this.State.Set("StopEvent", null);
            this.State.Set("StopPropagation", null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public partial class ListenerArgumentAttributeComparer : IComparer<ListenerArgumentAttribute>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj1"></param>
            /// <param name="obj2"></param>
            /// <returns></returns>
            [Description("")]
            public int Compare(ListenerArgumentAttribute obj1, ListenerArgumentAttribute obj2)
            {
                return obj1.Index.CompareTo(obj2.Index);
            }
        }

        internal void SetArgumentList(PropertyInfo property)
        {
            List<ListenerArgumentAttribute> attrs = new List<ListenerArgumentAttribute>();

            foreach (ListenerArgumentAttribute a in property.GetCustomAttributes(typeof(ListenerArgumentAttribute), false))
            {
                attrs.Add(a);
            }

            attrs.Sort(new ListenerArgumentAttributeComparer());

            List<string> args = new List<string>();

            foreach (ListenerArgumentAttribute a in attrs)
            {
                args.Add(a.Name);
            }

            this.argumentList = args;
        }

        List<string> argumentList;

        [Description("List of Arguments passed to event handler.")]
        internal List<string> ArgumentList
        {
            get
            {
                if (this.argumentList == null)
                {
                    this.argumentList = new List<string>();
                }

                return this.argumentList;
            }
        }
    }
}