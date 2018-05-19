using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WinCustomUserControlLibrary {
    public partial class WinCustomUserControl : DevExpress.XtraEditors.XtraUserControl {
        public WinCustomUserControl() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            gridControl1.DataSource = Demo.DataHelper.GetData();
        }
    }
}
