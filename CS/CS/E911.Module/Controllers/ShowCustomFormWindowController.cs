using System;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using DevExpress.ExpressApp.SystemModule;

namespace E911.Module.Controllers {
    public abstract class ShowCustomFormWindowController : WindowController {
        private ShowNavigationItemController navigationController;
        public ShowCustomFormWindowController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            navigationController = Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null)
                navigationController.CustomShowNavigationItem += navigationController_CustomShowNavigationItem;
        }
        protected override void OnDeactivated() {
            if (navigationController != null)
                navigationController.CustomShowNavigationItem -= navigationController_CustomShowNavigationItem;
            base.OnDeactivated();
        }
        private void navigationController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e) {
            if (e.ActionArguments.SelectedChoiceActionItem.Id == "CustomForm") {
                ShowCustomForm();
                e.Handled = true;
            }
        }
        protected abstract void ShowCustomForm();
    }
}
