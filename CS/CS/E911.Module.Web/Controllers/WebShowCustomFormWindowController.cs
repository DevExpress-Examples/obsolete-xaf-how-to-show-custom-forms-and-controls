using System;
using E911.Module.Controllers;
using System.ComponentModel;
using DevExpress.ExpressApp.SystemModule;

namespace E911.Module.Web.Controllers {
    /// <summary>
    /// A custom Application Model element extension for the Navigation Item node to be able to specify custom Web Forms via the Model Editor.
    /// </summary>
    public interface IModelWebCustomFormPathNavigationItem : IModelNavigationItem {
        [Category("Data")]
        string CustomFormPath { get; set; }
    }
    public class WebShowCustomFormWindowController : ShowCustomFormWindowController {
        /// <summary>
        /// You can also pass parameters into your custom form or read them via the query string or ASP.NET session or other standard ASP.NET means. Refer to ASP.NET documentation for more details on this.
        /// See Also:
        /// http://stackoverflow.com/questions/14956027/
        /// http://forums.asp.net/t/579631.aspx/1
        /// </summary>
        protected override void ShowCustomForm(IModelNavigationItem model) {
            string customFormPath = ((IModelWebCustomFormPathNavigationItem)model).CustomFormPath;
            DevExpress.ExpressApp.Web.WebWindow.CurrentRequestWindow.RegisterStartupScript(
                "ShowCustomFormScriptKey",
                string.Format("window.open('{0}');", customFormPath)
            );
        }
    }
}