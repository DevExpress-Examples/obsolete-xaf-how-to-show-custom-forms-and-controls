using System;
using System.Web.UI;
using DevExpress.Xpo;
using E911.Module.Editors;

public partial class WebCustomForm : Page, IXpoSessionAwareControl {
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        //Initializing a form when it is invoked from a controller.
        new XpoSessionAwareControlInitializer(this as IXpoSessionAwareControl, DevExpress.ExpressApp.Web.WebApplication.Instance);
        if(!DesignMode) {
            //Initializing a child control in a scenario when it is placed on a form and is not created by XAF.
            ((IXpoSessionAwareControl)this.CustomUserControl).Session = ((IXpoSessionAwareControl)this).Session;
        }
    }
    Session IXpoSessionAwareControl.Session { get; set; }
}
