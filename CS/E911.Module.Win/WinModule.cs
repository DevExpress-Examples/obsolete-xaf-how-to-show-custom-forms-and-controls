using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;

namespace E911.Module.Win {
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class E911WindowsFormsModule : ModuleBase {
        public E911WindowsFormsModule() {
            InitializeComponent();
        }
        public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<E911.Module.Editors.IModelCustomUserControlViewItem, E911.Module.Win.Editors.IModelWinCustomUserControlViewItem>();
        }
    }
}
