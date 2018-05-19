using System;
using System.Web.UI;
using DevExpress.Xpo;
using DevExpress.Utils;
using E911.Module.Editors;

public partial class WebCustomUserControl : UserControl, IXpoSessionAwareControl {
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if(!DesignMode) {
            UpdateDataSource();
        }
    }
    private void UpdateDataSource() {
        Session session = ((IXpoSessionAwareControl)this).Session;
        Guard.ArgumentNotNull(session, "session");
        XpoDataSource dataSource = new XpoDataSource();
        dataSource.TypeName = typeof(DevExpress.Persistent.BaseImpl.Task).FullName;
        dataSource.Session = session;
        grid.DataSource = dataSource;
        grid.DataBind();
    }
    Session IXpoSessionAwareControl.Session { get; set; }
}