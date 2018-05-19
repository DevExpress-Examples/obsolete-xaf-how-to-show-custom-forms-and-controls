using System;
using System.Linq;
using System.Collections.Generic;

namespace E911.Module.Web {
    public sealed partial class E911AspNetModule {
        // Registers custom extensions for Application Model elements.
        // Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument3169 help article for more information.
        public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<E911.Module.Editors.IModelCustomUserControlViewItem, E911.Module.Web.Editors.IModelWebCustomUserControlViewItem>();
            extenders.Add<DevExpress.ExpressApp.SystemModule.IModelNavigationItem, E911.Module.Web.Controllers.IModelWebCustomFormPathNavigationItem>();
        }
    }
}
