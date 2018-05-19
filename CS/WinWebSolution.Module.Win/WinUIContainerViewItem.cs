using System;
using WinCustomUserControlLibrary;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;

namespace WinWebSolution.Module.Win {
    public interface IWinUIContainerViewItem: IModelViewItem { }
    [DetailViewItemAttribute(typeof(IWinUIContainerViewItem))]
    public class WinUIContainerViewItem : ViewItem {
        public WinUIContainerViewItem(Type objectType, string id) : base(objectType, id) { }
        public WinUIContainerViewItem(IWinUIContainerViewItem model, Type objectType) : base(objectType, model.Id) { }
        protected override object CreateControlCore() { 
            return new WinCustomUserControl(); 
        }
    }
}