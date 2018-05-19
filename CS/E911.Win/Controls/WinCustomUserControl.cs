using System;
using DevExpress.Xpo;
using DevExpress.Utils;
using System.Collections;
using E911.Module.Editors;
using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace E911.Module.Win.Controls {
    /// <summary>
    /// This is a custom WinForms user control that displays persistent data received from XPO.
    /// You do not need to implement the IXpoSessionAwareControl interface if your control gets data from other sources or does not require data at all.
    /// </summary>
    public partial class WinCustomUserControl : DevExpress.XtraEditors.XtraUserControl, IXpoSessionAwareControl {
        public WinCustomUserControl() {
            InitializeComponent();
        }
        void IXpoSessionAwareControl.UpdateDataSource(Session session) {
            Guard.ArgumentNotNull(session, "session");
            Type persistentDataType = typeof(DevExpress.Persistent.BaseImpl.Task);
            IList persistentData = new XPCollection(session, persistentDataType, CriteriaOperator.Parse("Status = 'NotStarted'"));
            gridControl1.DataSource = persistentData;
            gridControl1.ForceInitialize();
        }
    }
}
