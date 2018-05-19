using System;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace E911.Module.Web {
    [ToolboxItemFilter("Xaf.Platform.Web")]
    public sealed partial class E911AspNetModule : ModuleBase {
        public E911AspNetModule() {
            InitializeComponent();
        }
    }
}
