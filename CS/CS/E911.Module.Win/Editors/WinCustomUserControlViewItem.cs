using System;
using E911.Module.Editors;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;

namespace E911.Module.Win.Editors {
    public interface IModelWinCustomUserControlViewItem {
        [Category("Data")]
        string ControlTypeName { get; set; }
    }
    [ViewItem(typeof(IModelCustomUserControlViewItem))]
    public class WinCustomUserControlViewItem : CustomUserControlViewItem {
        protected IModelWinCustomUserControlViewItem model;
        public WinCustomUserControlViewItem(IModelViewItem model, Type objectType)
            : base(model, objectType) {
            this.model = model as IModelWinCustomUserControlViewItem;
            if (this.model == null)
                throw new ArgumentNullException("IModelWinCustomUserControlViewItem must extend IModelCustomUserControlViewItem in the ExtendModelInterfaces method of your Win ModuleBase descendant.");
        }
        protected override object CreateControlCore() {
            //You can access the View and other properties here to additionally initialize your control.
            return DevExpress.Persistent.Base.ReflectionHelper.CreateObject(model.ControlTypeName);
        }
    }
}