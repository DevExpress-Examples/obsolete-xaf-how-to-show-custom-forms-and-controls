using System;
using DevExpress.Xpo;
using E911.Module.Editors;

namespace E911.Module.Win.Controls {
    public partial class WinCustomForm : DevExpress.XtraEditors.XtraForm, IXpoSessionAwareControl {
        public WinCustomForm() {
            InitializeComponent();
        }
        #region IXpoSessionAwareControl Members
        public void UpdateDataSource(Session session) {
            //Initializing a child control when it is not created by XAF (placed on a custom form).
            ((IXpoSessionAwareControl)this.CustomUserControl).UpdateDataSource(session);
        }
        #endregion
    }
}