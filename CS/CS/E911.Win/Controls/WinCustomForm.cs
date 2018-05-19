using System;
using E911.Module.Editors;
using DevExpress.Xpo;

namespace E911.Module.Win.Controls {
    public partial class WinCustomForm : DevExpress.XtraEditors.XtraForm, IXpoSessionAwareControl {
        public WinCustomForm() {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            //Initializing a child control in a scenario when it is placed on a form and is not created by XAF.
            if(!DesignMode) {
                ((IXpoSessionAwareControl)this.CustomUserControl).Session = ((IXpoSessionAwareControl)this).Session;
            }
        }
        Session IXpoSessionAwareControl.Session { get; set; }
    }
}