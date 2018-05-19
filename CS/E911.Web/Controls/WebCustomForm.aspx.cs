using System;
using System.Web.UI;
using DevExpress.Xpo;
using E911.Module.Editors;

/// <summary>
/// This is a custom WinForms user form that displays persistent data received from XPO.
/// You do not need to implement the IXpoSessionAwareControl interface if your form gets data from other sources or does not require data at all.
/// </summary>
public partial class WebCustomForm : Page, IXpoSessionAwareControl {
    /// <summary>
    /// You can also pass parameters into your custom form or read them via the query string or ASP.NET session or other standard ASP.NET means. Refer to ASP.NET documentation for more details on this.
    /// See Also:
    /// http://stackoverflow.com/questions/14956027/
    /// http://forums.asp.net/t/579631.aspx/1
    /// </summary>
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        // Initializing a form when it is invoked from a controller.
        XpoSessionAwareControlInitializer.Initialize(this as IXpoSessionAwareControl, DevExpress.ExpressApp.Web.WebApplication.Instance);
    }
    #region IXpoSessionAwareControl Members
    public void UpdateDataSource(Session session) {
        // Initializing a child control when it is not created by XAF (as part of a custom form).
        ((IXpoSessionAwareControl)this.CustomUserControl).UpdateDataSource(session);
    }
    #endregion
}
