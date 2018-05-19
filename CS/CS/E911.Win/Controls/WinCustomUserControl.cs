using System;
using DevExpress.Xpo;
using DevExpress.Utils;
using E911.Module.Editors;
using System.Collections.Generic;

namespace E911.Module.Win.Controls {
    public partial class WinCustomUserControl : DevExpress.XtraEditors.XtraUserControl, IXpoSessionAwareControl {
        public WinCustomUserControl() {
            InitializeComponent();
        }
        void IXpoSessionAwareControl.UpdateDataSource(Session session) {
            Guard.ArgumentNotNull(session, "session");
            gridControl1.DataSource = new XPCollection<DevExpress.Persistent.BaseImpl.Task>(session);
            gridControl1.ForceInitialize();
        }
    }
}
