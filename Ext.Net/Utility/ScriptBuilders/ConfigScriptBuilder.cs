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
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public class ConfigScriptBuilder : BaseScriptBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Description("")]
        public ConfigScriptBuilder(BaseControl control) : base(control) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string Build()
        {
            return this.Build(LazyMode.Config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public override string Build(bool selfRendering)
        {
            return this.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string Build(LazyMode mode)
        {            
            if (this.script == null)
            {
                AbstractComponent cmp = this.Control as AbstractComponent;
                
                if (cmp != null)
                {
                    cmp.PreventRenderTo = true;
                }
                
                this.Control.IsDynamicLazy = true;
                this.Control.TopDynamicControl = true;

                StringBuilder sb = new StringBuilder();

                List<BaseControl> childControls = this.FindControls(this.Control, false, null, null, null);
                childControls.Insert(0, this.Control);                

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (c.AutoDataBind)
                        {
                            c.DataBind();
                        }
                    }
                }

                SelfRenderingPage pageHolder = new SelfRenderingPage();
                ResourceManager newMgr = new ResourceManager(true);
                newMgr.RenderScripts = ResourceLocationType.None;
                newMgr.RenderStyles = ResourceLocationType.None;
                newMgr.IDMode = IDMode.Explicit;
                newMgr.IsDynamic = true;
                pageHolder.Controls.Add(newMgr);
                pageHolder.Controls.Add(this.Control);
                pageHolder.Items["Ext.Net.DeferInitScriptGeneration"] = new object();

                string html = this.Control is INoneContentable ? null : BaseScriptBuilder.RenderControl(this.Control, pageHolder);
                pageHolder.Items["Ext.Net.DeferInitScriptGeneration"] = null;

                List<BaseControl> newChildControls = this.FindControls(this.Control, false, sb, null, null);
                newChildControls.Insert(0, this.Control);

                foreach (BaseControl c in newChildControls)
                {
                    if (!childControls.Contains(c) && (c.Visible || Object.ReferenceEquals(c, this.Control)))
                    {
                        if (c.AutoDataBind)
                        {
                            c.DataBind();
                        }
                    }
                }

                childControls = newChildControls;

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        c.OnClientInit(true);
                        c.RegisterBeforeAfterScript();
                    }
                }

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (Object.ReferenceEquals(c, this.Control))
                        {
                            string initScript;

                            if (this.Control is ICustomConfigSerialization)
                            {
                                initScript = ((ICustomConfigSerialization)c).ToScript(c);
                            }
                            else
                            {
                                initScript = mode == LazyMode.Instance ? "new {0}({1})".FormatWith(c.InstanceOf, c.InitialConfig) : c.InitialConfig;
                            }
                            
                            this.ScriptClientInitBag.Add(c.ClientInitID, initScript);
                        }
                        else
                        {
                            string script = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                                                {"ref", c.IsLazy ? c.ClientInitID : "init_script"},
                                                {"index", ResourceManager.ScriptOrderNumber.ToString()}
                                            }, c.BuildInitScript());

                            this.ScriptClientInitBag.Add(c.ClientInitID, script);
                        }
                        
                        c.AlreadyRendered = true;
                    }
                }

                if (this.ScriptClientInitBag.Count > 0)
                {
                    foreach (KeyValuePair<string, string> item in this.ScriptClientInitBag)
                    {
                        sb.Append(this.ScriptClientInitBag[item.Key]);
                    }
                }                
                
                string  initToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                    {"id", "init_script"}                            
                });

                if (html.IsNotEmpty())
                {
                    sb.Insert(sb.ToString().IndexOf('{') + 1, "contentHtml:function(){{{0}{1}}},".FormatWith(html, initToken));
                }
                else
                {
                    sb.Append(initToken);
                }

                this.script = sb.ToString();
            }

            string config = Transformer.NET.Html.HtmlTransformer.Transform(this.script);                        

            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        protected override void CheckResources(BaseControl control, ResourceManager manager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="icons"></param>
        protected override void CheckIcon(BaseControl control, List<Icon> icons)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="ns"></param>
        protected override void RegisterNS(StringBuilder sb, List<string> ns)
        {
        }

        protected override void RegisterControlResourcesInManager(ResourceManager manager, BaseControl ctrl)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        [Description("")]
        public static ConfigScriptBuilder Create(BaseControl control)
        {
            return new ConfigScriptBuilder(control);
        }
    }
}
