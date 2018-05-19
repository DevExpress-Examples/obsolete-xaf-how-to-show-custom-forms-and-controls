using System;
using System.Web.UI;

public partial class WebCustomUserControl : UserControl {
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        grid.DataSource = Demo.DataHelper.GetData();
        grid.DataBind();
    }
}
