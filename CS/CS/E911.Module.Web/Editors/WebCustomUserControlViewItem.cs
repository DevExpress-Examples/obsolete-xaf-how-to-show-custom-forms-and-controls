using System;
using E911.Module.Editors;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;

namespace E911.Module.Web.Editors {
    public interface IModelWebCustomUserControlViewItem : IModelCustomUserControlViewItem {
        [Category("Data")]
        string UserControlPath { get; set; }
    }
    [ViewItem(typeof(IModelCustomUserControlViewItem))]
    public class WebCustomUserControlViewItem : CustomUserControlViewItem {
        protected IModelWebCustomUserControlViewItem model;
        public WebCustomUserControlViewItem(IModelViewItem model, Type objectType)
            : base(model, objectType) {
            this.model = model as IModelWebCustomUserControlViewItem;
            if (this.model == null)
                throw new ArgumentNullException("IModelWebCustomUserControlViewItem must extend IModelCustomUserControlViewItem in the ExtendModelInterfaces method of your Web ModuleBase descendant.");
        }
        protected override object CreateControlCore() {
            //You can access the View and other properties here to additionally initialize your control.
            return WebWindow.CurrentRequestPage.LoadControl(model.UserControlPath);
        }
    }
}