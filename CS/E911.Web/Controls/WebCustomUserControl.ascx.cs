using System;
using System.Web.UI;
using DevExpress.Xpo;
using DevExpress.Utils;
using E911.Module.Editors;

public partial class WebCustomUserControl : UserControl, IXpoSessionAwareControl {
    void IXpoSessionAwareControl.UpdateDataSource(Session session) {
        Guard.ArgumentNotNull(session, "session");
        XpoDataSource dataSource = new XpoDataSource();
        dataSource.TypeName = typeof(DevExpress.Persistent.BaseImpl.Task).FullName;
        dataSource.Session = session;
        grid.DataSource = dataSource;
        grid.DataBind();
    }
}