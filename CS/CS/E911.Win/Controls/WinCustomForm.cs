using System;
using DevExpress.Xpo;
using E911.Module.Editors;

namespace E911.Module.Win.Controls {
    /// <summary>
    /// This is a custom WinForms form that displays persistent data received from XPO.
    /// You do not need to implement the IXpoSessionAwareControl interface if your form gets data from other sources or does not require data at all.
    /// </summary>
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