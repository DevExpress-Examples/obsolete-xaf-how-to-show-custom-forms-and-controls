using System;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;

namespace WinSolution.Module.Web {
    public interface IWebUIContainerViewItem : IModelViewItem { }
    [DetailViewItemAttribute(typeof(IWebUIContainerViewItem))]
    public class WebUIContainerViewItem : ViewItem {
        public WebUIContainerViewItem(Type objectType, string id) : base(objectType, id) { }
        public WebUIContainerViewItem(IWebUIContainerViewItem model, Type objectType) : base(objectType, model.Id) { }
        protected override object CreateControlCore() {
            return WebWindow.CurrentRequestPage.LoadControl("CustomUserControls/WebCustomUserControl.ascx");
        }
    }
}