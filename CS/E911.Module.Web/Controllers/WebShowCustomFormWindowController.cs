using System;
using E911.Module.Controllers;

namespace E911.Module.Web.Controllers {
    public class WebShowCustomFormWindowController : ShowCustomFormWindowController {
        protected override void ShowCustomForm() {
            DevExpress.ExpressApp.Web.WebWindow.CurrentRequestWindow.RegisterStartupScript(
                "ShowCustomFormScript", "window.open('Controls/WebCustomForm.aspx');");
        }
    }
}