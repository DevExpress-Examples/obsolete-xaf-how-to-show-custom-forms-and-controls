using System;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace E911.Module.Web {
    [ToolboxItemFilter("Xaf.Platform.Web")]
    public sealed partial class E911AspNetModule : ModuleBase {
        public E911AspNetModule() {
            InitializeComponent();
        }
        public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<E911.Module.Editors.IModelCustomUserControlViewItem, E911.Module.Web.Editors.IModelWebCustomUserControlViewItem>();
        }
    }
}
