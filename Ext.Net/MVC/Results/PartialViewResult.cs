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
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class PartialViewResult : ViewResultBase
    {
        private RenderMode renderMode = RenderMode.RenderTo;
        private IDMode idMode = IDMode.Static;
        private bool wrapByScriptTag=true;

        /// <summary>
        /// 
        /// </summary>
        public string ContainerId
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDMode IDMode
        {
            get { return idMode; }
            set { idMode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Namespace
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public RenderMode RenderMode
        {
            get { return renderMode; }
            set { renderMode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ControlId
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool WrapByScriptTag
        {
            get { return wrapByScriptTag; }
            set { wrapByScriptTag = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SingleControl
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Items
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ClearContainer
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ControlToRender
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Container.Config ContainerConfig
        {
            get;
            set;
        }

        public object Model
        {
            get;
            set;
        }

        internal bool Config
        {
            get;
            set;
        }

        internal bool WriteToString
        {
            get;
            set;
        }

        internal string Output
        {
            get;
            set;
        }

        private string beforeScript;
        private string afterScript;

        /// <summary>
        /// 
        /// </summary>
        public PartialViewResult()
        {
            var instanceScript = HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT];

            if (instanceScript != null)
            {
                this.beforeScript = instanceScript.ToString();
                HttpContext.Current.Items.Remove(ResourceManager.INSTANCESCRIPT);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        public PartialViewResult(string containerId) : this()
        {
            this.ContainerId = containerId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <param name="renderMode"></param>
        public PartialViewResult(string containerId, RenderMode renderMode) : this()
        {
            this.ContainerId = containerId;
            this.RenderMode = renderMode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <param name="renderMode"></param>
        /// <param name="controlId"></param>
        public PartialViewResult(string containerId, RenderMode renderMode, string controlId) : this()
        {
            this.ContainerId = containerId;
            this.RenderMode = renderMode;
            this.ControlId = controlId;
        }

        private static Regex ItemsContainer_RE = new Regex("<ext\\.net\\.container>.+?items:\\[(.*)\\].+</ext\\.net\\.container>", RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex ItemsAddToContainer_RE = new Regex("Ext\\.getCmp\\(\"Ext_Net_Partial_Items\"\\)\\.add\\((\\w*.Ext_Net_Temp_Container|Ext_Net_Temp_Container)\\);", RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex ItemsDestroyCmpContainer_RE = new Regex("Ext\\.net\\.ResourceMgr\\.destroyCmp\\(\"(\\w*.Ext_Net_Temp_Container|Ext_Net_Temp_Container)\"\\);", RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex TempIDRemove_RE = new Regex("id=\\\\\"Ext_Net_Temp_Container_Content\\\\\"", RegexOptions.Compiled | RegexOptions.Singleline);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var instanceScript = HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT];

            if (instanceScript != null)
            {
                this.afterScript = instanceScript.ToString();
                HttpContext.Current.Items.Remove(ResourceManager.INSTANCESCRIPT);
            }

            if (String.IsNullOrEmpty(this.ViewName))
            {
                this.ViewName = context.RouteData.GetRequiredString("action");
            }
            
            string id = this.ControlId ?? BaseControl.GenerateID();
            string ct = this.ContainerId ?? "Ext.getBody()";

            if (this.Model != null)
            {
                this.ViewData.Model = this.Model;
            }

            ViewDataDictionary dict = new ViewDataDictionary(this.ViewData);
            ViewEngineResult result = null;

            if (this.View == null)
            {
                result = this.ViewEngineCollection.FindPartialView(context, this.ViewName);
                this.View = result != null ? result.View : null;
            }

            if (this.View == null)
            {
                throw new Exception("View with name '{0}' is not found".FormatWith(this.ViewName));
            }

            if (this.View is RazorView)
            {
                if (this.SingleControl)
                {
                    throw new Exception("Razor view doesn't support SingleControl option");
                }

                if (this.ControlToRender.IsNotEmpty())
                {
                    throw new Exception("Razor view doesn't support ControlToRender option");
                }

                if (this.Items)
                {
                    throw new Exception("Razor view doesn't support Items option");
                }
                
                this.RenderRazorView(context, (RazorView)this.View);

                if (result != null)
                {
                    result.ViewEngine.ReleaseView(context, this.View);
                }

                return;
            }

            if (this.Items && this.RenderMode != Ext.Net.RenderMode.AddTo && this.RenderMode != Ext.Net.RenderMode.InsertTo)
            {
                throw new Exception("Items mode can be used with AddTo/InsertTo only");
            }

            if (this.Items && this.SingleControl)
            {
                throw new Exception("Items and SingleControl cannot be used at one time");
            }

            if (this.Items && this.ControlToRender.IsNotEmpty())
            {
                throw new Exception("Items and ControlToRender cannot be used at one time");
            }

            if (this.SingleControl && this.ControlToRender.IsNotEmpty())
            {
                throw new Exception("SingleControl and ControlToRender cannot be used at one time");
            }

            string path = ((WebFormView)this.View).ViewPath;

            ViewContext viewContext = new ViewContext(context, this.View, this.ViewData, this.TempData, context.HttpContext.Response.Output);

            PartialViewPage pageHolder = new PartialViewPage
            {
                ViewData = dict,
                ViewContext = viewContext
            };
			
			var curRM = HttpContext.Current.Items[typeof(ResourceManager)];
			HttpContext.Current.Items[typeof(ResourceManager)] = null;

            ResourceManager rm = new ResourceManager();
            rm.RenderScripts = ResourceLocationType.None;
            rm.RenderStyles = ResourceLocationType.None;
            rm.IDMode = this.IDMode;
            pageHolder.Controls.Add(rm);
            
            ViewUserControl uc = (ViewUserControl)pageHolder.LoadControl(path);
            uc.ID = id + "_UC";
            uc.ViewData = ViewData;

            if (uc is IDynamicUserControl)
            {
                ((IDynamicUserControl)uc).BeforeRender();
            }

            BaseControl controlToRender = null;

            if (this.ControlToRender.IsEmpty() && !this.SingleControl)
            {
                Container p;

                if (this.ContainerConfig != null)
                {
                    p = new Container(this.ContainerConfig);
                    p.ID = id;
                    p.IDMode = this.IDMode;                    
                }
                else
                {
                    p = new Container { ID = id, IDMode = this.IDMode, Border = false };
                }

                if (this.Namespace != null)
                {
                    p.Namespace = this.Namespace;
                }

                if (this.Items || this.Config)
                {
                    p.Layout = "auto";
                    p.AddBeforeClientInitScript("<ext.net.container>");
                    p.AddAfterClientInitScript("</ext.net.container>");
                    p.ID = "Ext_Net_Temp_Container";                    
                    p.IDMode = Ext.Net.IDMode.Static;
                }
                
                pageHolder.Controls.Add(p);
                p.ContentControls.Add(uc);
                controlToRender = p;
            }
            else
            {
                pageHolder.Controls.Add(uc);
                BaseControl c = null;

                if (this.SingleControl)
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<BaseControl>(uc);
                }
                else
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<BaseControl>(pageHolder, this.ControlToRender);
                }

                if (c == null)
                {
                    if (this.SingleControl)
                    {
                        throw new Exception("Cannot find the Ext.Net control in the view");
                    }
                    else
                    {
                        throw new Exception("Cannot find the control with ID=" + this.ControlToRender);
                    }
                }

                controlToRender = c;

                if (!controlToRender.HasOwnIDMode)
                {
                    controlToRender.IDMode = this.IDMode;
                }
            }

            pageHolder.InitHelpers();

            StringBuilder sb = new StringBuilder();

            string script;
            if (this.Items || this.Config)
            {
                script = controlToRender.ToScript(Ext.Net.RenderMode.AddTo, "Ext_Net_Partial_Items", true);

                script = ItemsAddToContainer_RE.Replace(script, delegate
                {                    
                    return "";
                }, 1);

                script = ItemsDestroyCmpContainer_RE.Replace(script, delegate
                {
                    return "";
                }, 1);

                script = TempIDRemove_RE.Replace(script, delegate
                {
                    return "";
                }, 1);

                if (this.Config)
                {
                    Match match = ItemsContainer_RE.Match(script);
                    if (match != null && match.Success)
                    {
                        this.Output = "[" + match.Groups[1].Value + "]";
                    }
                    else
                    {
                        this.Output = "[]";
                    }
                    
                    IDisposable disposable = this.View as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }

                    if (result != null)
                    {
                        result.ViewEngine.ReleaseView(context, this.View);
                    }

                    return;
                }
                
                script = ItemsContainer_RE.Replace(script, delegate(Match m)
                {
                    string elementGet = ct.Contains(".") ? ct : "Ext.getCmp({0})".FormatWith(JSON.Serialize(ct));
                    string methodTemplate = string.Concat(".", "add","([");

                    if (this.RenderMode == RenderMode.InsertTo)
                    {
                        methodTemplate = string.Concat(".", "insert", "(", this.Index, ",[");
                    }

                    string replace = elementGet.ConcatWith(methodTemplate, m.Groups[1].Value, "]);");

                    return this.ClearContainer ? (elementGet + ".removeAll();" + replace) : replace;
                }, 1);
            }
            else
            {
                if(this.RenderMode == Ext.Net.RenderMode.InsertTo)
                {
                    script = controlToRender.ToScript(mode:this.RenderMode, element:ct, index:this.Index, selfRendering:true, clearContainer:this.ClearContainer);
                }
                else
                {
                    script = controlToRender.ToScript(mode: this.RenderMode, element: ct, selfRendering: true, clearContainer: this.ClearContainer);
                }
            }

            HttpContext.Current.Items[typeof(ResourceManager)] = curRM;

            if (this.RenderMode == Ext.Net.RenderMode.AddTo || this.RenderMode == Ext.Net.RenderMode.InsertTo || this.RenderMode == Ext.Net.RenderMode.Replace)
            {
                string cmpId = this.ContainerId.Contains(".") ? this.ContainerId.RightOfRightmostOf(".") : this.ContainerId;
                sb.AppendFormat("Ext.ComponentManager.onAvailable(\"{0}\",function(){{{1}{2}{3}}});", cmpId, this.beforeScript ?? "", script, this.afterScript ?? "");
            }
            else
            {
                sb.AppendFormat("Ext.onReady(function(){{{0}{1}{2}}});", this.beforeScript ?? "", script, this.afterScript ?? "");
            }           

            this.RenderScript(context, sb.ToString());

            if (result != null)
            {
                result.ViewEngine.ReleaseView(context, this.View);
            }
        }

        private void RenderScript(ControllerContext context, string script)
        {
            if (X.IsAjaxRequest)
            {
                script = "{script:"+JSON.Serialize(script)+"}";
                context.HttpContext.Response.ContentType = "application/json";
            }
            else if (this.WrapByScriptTag)
            {
                script = "<script type=\"text/javascript\">" + script + "</script>";
                context.HttpContext.Response.ContentType = "text/html";
            }

            IDisposable disposable = this.View as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            if (this.WriteToString)
            {
                this.Output = script;
            }
            else
            {
                context.HttpContext.Response.Write(script);
            }
        }

        

        private static Regex RazorItems_RE = new Regex("<Ext.Net.RazorItems>(.*?)</Ext.Net.RazorItems>", RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex RazorRenderToItems_RE = new Regex("<Ext.Net.RazorRenderToItems>(.*?)</Ext.Net.RazorRenderToItems>", RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex RazorBeforeScript_RE = new Regex("<Ext.Net.RazorBeforeScript>(.*?)</Ext.Net.RazorBeforeScript>", RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex RazorAfterScript_RE = new Regex("<Ext.Net.RazorAfterScript>(.*?)</Ext.Net.RazorAfterScript>", RegexOptions.Compiled | RegexOptions.Singleline);
        private void RenderRazorView(ControllerContext context, RazorView razorView)
        {
            using (StringWriter sw = new StringWriter())
            {
                if (this.RenderMode != Ext.Net.RenderMode.RenderTo)
                {
                    BaseControl.SectionsStack.Push(new List<string>());
                }

                ViewContext viewContext = new ViewContext(context, razorView, this.ViewData, this.TempData, sw);

                RequestManager.SuppressAjaxRequestMarker();

                razorView.Render(viewContext, sw);
                string result = sw.GetStringBuilder().ToString();

                RequestManager.ResumeAjaxRequestMarker();
                
                StringBuilder sb = new StringBuilder();

                if (this.RenderMode != Ext.Net.RenderMode.RenderTo)
                {
                    List<string> idsToRender = BaseControl.SectionsStack.Pop();

                    sb.Append("<Ext.Net.RazorItems>[");
                    foreach (string item in idsToRender)
                    {
                        sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                               {"id", item}         
                            }));
                        sb.Append(",");
                    }
                    if (idsToRender.Count > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append("]</Ext.Net.RazorItems>");
                }

                sb.Append("<Ext.Net.RazorBeforeScript>");
                sb.Append("<#:anchor id='ext.net.global.script.before' />");                
                sb.Append("</Ext.Net.RazorBeforeScript>");

                sb.Append("<Ext.Net.RazorRenderToItems>");                
                sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                    {"id", "init_script"}         
                }));                
                sb.Append("</Ext.Net.RazorRenderToItems>");

                sb.Append("<Ext.Net.RazorAfterScript>");
                sb.Append("<#:anchor id='ext.net.global.script.after' />");
                sb.Append("</Ext.Net.RazorAfterScript>");

                MvcResourceManagerConfig config = MVC.MvcResourceManager.SharedConfig;
                config.RenderScripts = ResourceLocationType.None;
                config.RenderStyles = ResourceLocationType.None;
                MVC.MvcResourceManager.SharedConfig = config;

                List<ResourceItem> resources = null;

                if (HttpContext.Current.Items[Ext.Net.ResourceManager.GLOBAL_RESOURCES] != null)
                {
                    resources = (List<ResourceItem>)HttpContext.Current.Items[Ext.Net.ResourceManager.GLOBAL_RESOURCES];
                }                

                sb.Insert(0, result);                

                result = Ext.Net.ExtNetTransformer.Transform(sb.ToString());

                string items = "";
                
                string html = RazorItems_RE.Replace(result, delegate(Match m){
                    items = m.Groups[1].Value;
                    return "";
                });

                if (this.Config)
                {
                    this.Output = !string.IsNullOrWhiteSpace(items) ? items : "[]";
                    
                    IDisposable disposable = this.View as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }

                    return;
                }

                string renderToItems = "";
                
                html = RazorRenderToItems_RE.Replace(html, delegate(Match m)
                {
                    renderToItems = m.Groups[1].Value;
                    return "";
                });

                string beforeScript = "";
                
                html = RazorBeforeScript_RE.Replace(html, delegate(Match m)
                {
                    beforeScript = m.Groups[1].Value;
                    return "";
                });

                string afterScript = "";

                html = RazorAfterScript_RE.Replace(html, delegate(Match m)
                {
                    afterScript = m.Groups[1].Value;
                    return "";
                });

                sb.Length = 0;

                if (this.ClearContainer && this.RenderMode == Ext.Net.RenderMode.RenderTo)
                {
                    sb.AppendFormat("Ext.net.getEl(\"{0}\").update();", this.ContainerId);
                }

                if (!string.IsNullOrWhiteSpace(html))
                {
                    string[] lines = html.Split(new string[] { "\r\n", "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                    if (lines.Length > 0)
                    {
                        html = JSON.Serialize(lines).ConcatWith(".join('')");
                        html = html.Replace("</script>", "<\\/script>");
                        sb.AppendFormat("Ext.net.append({0},{1});", this.RenderMode == Ext.Net.RenderMode.RenderTo ? string.Concat("Ext.net.getEl('", this.ContainerId, "')") : "Ext.getBody()", html);
                    }
                }

                if (beforeScript.IsNotEmpty())
                {
                    sb.Append(beforeScript);
                }

                if (!string.IsNullOrWhiteSpace(items))
                {
                    if (this.RenderMode == Ext.Net.RenderMode.AddTo || this.RenderMode == Ext.Net.RenderMode.InsertTo)
                    {
                        sb.AppendFormat("Ext.net.addTo({0}, {1}, {2});", JSON.Serialize(this.ContainerId), items, JSON.Serialize(this.ClearContainer));
                    }
                    else if (this.RenderMode == RenderMode.Replace)
                    {
                        sb.Append("Ext.net._renderTo(arguments[0]," + items + ");");
                    }
                    else
                    {
                        sb.AppendFormat("Ext.net.renderTo({0}, {1});", JSON.Serialize(this.ContainerId), items);
                    }
                }

                if (renderToItems.IsNotEmpty())
                {
                    sb.Append(renderToItems);
                }

                if (afterScript.IsNotEmpty())
                {
                    sb.Append(afterScript);
                }

                if (this.RenderMode == RenderMode.Replace)
                {
                    string elementGet = this.ContainerId.Contains(".") ? this.ContainerId : "Ext.getCmp({0})".FormatWith(JSON.Serialize(this.ContainerId));
                    
                    sb.Insert(0, elementGet + ".replace(function(){");
                    sb.Append("});");
                }

                string script = sb.ToString();
                
                if (this.RenderMode == Ext.Net.RenderMode.AddTo || this.RenderMode == Ext.Net.RenderMode.InsertTo || this.RenderMode == Ext.Net.RenderMode.Replace)
                {
                    string cmpId = this.ContainerId.Contains(".") ? this.ContainerId.RightOfRightmostOf(".") : this.ContainerId;
                    
                    script = string.Format("Ext.ComponentManager.onAvailable(\"{0}\",function(){{{1}{2}{3}}});", cmpId, this.beforeScript ?? "", script, this.afterScript ?? "");
                }
                else
                {
                    script = string.Format("Ext.onReady(function(){{{0}{1}{2}}});", this.beforeScript ?? "", script, this.afterScript ?? "");
                }

                this.RenderScript(context, this.RegisterRazorResources(script, resources));
            }
        }

        protected virtual string RegisterRazorResources(string script, List<ResourceItem> resources)
        {
            StringBuilder sb = new StringBuilder();

            List<Icon> icons = ResourceManager.GlobalIcons;
            HttpContext.Current.Items.Remove("Ext.Net.GlobalIcons");
            if (icons.Count > 0)
            {
                string[] arr = new string[icons.Count];
                for (int i = 0; i < icons.Count; i++)
                {
                    arr[i] = icons[i].ToString();
                }

                sb.Append("Ext.net.ResourceMgr.registerIcon(");
                sb.Append(JSON.Serialize(arr));
                sb.Append(");");
            }

            if (resources != null && resources.Count > 0 || ResourceManager.GlobalClientResources.Count > 0)
            {
                MvcResourceManagerConfig config = MVC.MvcResourceManager.SharedConfig;

                sb.Append("Ext.net.ResourceMgr.load([");
                bool comma = false;
                string url;

                List<ClientResourceItem> gbScripts = ResourceManager.GlobalClientResources;
                HttpContext.Current.Items.Remove(ResourceManager.GLOBAL_CLIENT_RESOURCES);

                if (gbScripts.Count > 0)
                {
                    foreach (ClientResourceItem item in gbScripts)
                    {
                        if (item.Path.IsNotEmpty())
                        {
                            sb.AppendFormat("{{url:{0}{1}}}", JSON.Serialize(item.Path.StartsWith("~") ? ExtNetTransformer.ResolveUrl(item.Path) : item.Path), item.IsCss ? ",mode:\"css\"" : "");
                        }
                        else if (item.PathEmbedded.IsNotEmpty())
                        {
                            sb.AppendFormat("{{url:{0}{1}}{1}}", JSON.Serialize(HttpUtility.HtmlAttributeEncode(ExtNetTransformer.GetWebResourceUrl(item.Type, item.PathEmbedded))), item.IsCss ? ",mode:\"css\"" : "");
                        }
                    }
                }

                if(resources != null)
                {
                    foreach (ResourceItem item in resources)
                    {
                        if (comma)
                        {
                            sb.Append(",");
                        }

                        comma = true;

                        if (item is ClientStyleItem)
                        {
                            ClientStyleItem styleItem = (ClientStyleItem)item;

                            if (styleItem.IgnoreResourceMode)
                            {
                                if (styleItem.PathEmbedded.IsNotEmpty())
                                {
                                    url = ExtNetTransformer.GetWebResourceUrl(styleItem.Type, styleItem.PathEmbedded);
                                }
                                else
                                {
                                    url = styleItem.Path.StartsWith("~") ? ExtNetTransformer.ResolveUrl(styleItem.Path) : styleItem.Path;
                                }
                            }
                            else
                            {
                                url = config.RenderStyles == ResourceLocationType.File ? config.ResourcePath.ConcatWith(styleItem.Path) : ExtNetTransformer.GetWebResourceUrl(styleItem.Type, styleItem.PathEmbedded);
                            }

                            sb.Append("{mode:\"css\",url:").Append(JSON.Serialize(url)).Append("}");
                        }
                        else if (item is ClientScriptItem)
                        {
                            ClientScriptItem scriptItem = (ClientScriptItem)item;                            

                            if(scriptItem.IgnoreResourceMode)
                            {
                                if (scriptItem.PathEmbedded.IsNotEmpty())
                                {
                                    url = (config.ScriptMode == ScriptMode.Release || scriptItem.PathEmbeddedDebug.IsEmpty()) ? scriptItem.PathEmbedded : scriptItem.PathEmbeddedDebug;
                                }
                                else
                                {
                                    bool isDebug = !(config.ScriptMode == ScriptMode.Release || scriptItem.PathEmbeddedDebug.IsEmpty());
                                    url = (isDebug ? scriptItem.PathDebug : scriptItem.Path).StartsWith("~") ? ExtNetTransformer.ResolveUrl(isDebug ? scriptItem.PathDebug : scriptItem.Path) : (isDebug ? scriptItem.PathDebug : scriptItem.Path);
                                }
                            }
                            else if (config.RenderScripts == ResourceLocationType.File)
                            {
                                if (config.ScriptMode == ScriptMode.Release || scriptItem.PathDebug.IsEmpty())
                                {
                                    url = config.ResourcePath.ConcatWith(scriptItem.Path);
                                }
                                else
                                {
                                    url = config.ResourcePath.ConcatWith(scriptItem.PathDebug);
                                }
                            }
                            else
                            {
                                if (config.ScriptMode == ScriptMode.Release || scriptItem.PathEmbeddedDebug.IsEmpty())
                                {
                                    url = ExtNetTransformer.GetWebResourceUrl(scriptItem.Type, scriptItem.PathEmbedded);
                                }
                                else
                                {
                                    url = ExtNetTransformer.GetWebResourceUrl(scriptItem.Type, scriptItem.PathEmbeddedDebug);
                                }
                            }
                            // CDN is not supported by loading via Ext.net.ResourceMgr.load (another domain)

                            sb.Append("{url:").Append(JSON.Serialize(url)).Append("}");
                        }
                    }
                }

                sb.Append("], function(){");
                sb.Append(script);
                sb.Append("});");
            }
            else
            {
                sb.Append(script);
            }            

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override ViewEngineResult FindView(ControllerContext context)
        {
            ViewEngineResult result = ViewEngineCollection.FindPartialView(context, ViewName);
            if (result.View != null)
            {
                return result;
            }

            // we need to generate an exception containing all the locations we searched
            StringBuilder locationsText = new StringBuilder();
            foreach (string location in result.SearchedLocations)
            {
                locationsText.AppendLine();
                locationsText.Append(location);
            }
            throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                "The partial view '{0}' could not be found. The following locations were searched:{1}", ViewName, locationsText));
        }
    }
}
