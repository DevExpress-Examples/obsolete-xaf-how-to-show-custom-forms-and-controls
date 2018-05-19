using System;
using E911.Module.Controllers;
using System.Windows.Forms;
using E911.Module.Editors;

namespace E911.Module.Win.Controllers {
    public class WinShowCustomFormWindowController : ShowCustomFormWindowController {
        protected override void ShowCustomForm() {
            Form form = DevExpress.Persistent.Base.ReflectionHelper.CreateObject(
                    "E911.Module.Win.Controls.WinCustomForm") as Form;
            //Initializing a form when it is invoked from a controller.
            new XpoSessionAwareControlInitializer(form as IXpoSessionAwareControl, Application);
            form.Show();
        }
    }
}