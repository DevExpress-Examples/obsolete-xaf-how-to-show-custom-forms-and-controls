using System;
using System.Web.UI;
using DevExpress.Xpo;
using E911.Module.Editors;

public partial class WebCustomForm : Page, IXpoSessionAwareControl {
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        //Initializing a form when it is invoked from a controller.
        new XpoSessionAwareControlInitializer(this as IXpoSessionAwareControl, DevExpress.ExpressApp.Web.WebApplication.Instance);
    }
    #region IXpoSessionAwareControl Members
    public void UpdateDataSource(Session session) {
        //Initializing a child control when it is not created by XAF (as part of a custom form).
        ((IXpoSessionAwareControl)this.CustomUserControl).UpdateDataSource(session);
    }
    #endregion
}
