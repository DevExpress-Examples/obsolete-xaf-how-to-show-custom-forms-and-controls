using System;
using System.Linq;
using System.Collections.Generic;

namespace E911.Module.Win {
    public sealed partial class E911WindowsFormsModule {
        // Extends the Application Model elements for View and Navigation Items to be able to specify custom controls via the Model Editor.
        // Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument3169 help article for more information.
        public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<E911.Module.Editors.IModelCustomUserControlViewItem, E911.Module.Win.Editors.IModelWinCustomUserControlViewItem>();
            extenders.Add<DevExpress.ExpressApp.SystemModule.IModelNavigationItem, E911.Module.Win.Controllers.IModelWinCustomFormPathNavigationItem>();
        }
    }
}
