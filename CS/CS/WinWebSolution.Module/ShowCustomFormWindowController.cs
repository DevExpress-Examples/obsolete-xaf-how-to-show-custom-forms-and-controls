using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.SystemModule;

namespace WinWebSolution.Module {
    public abstract class ShowCustomFormWindowController : WindowController {
        private ShowNavigationItemController navigationController;
        private SingleChoiceAction showCustomFormActionCore;
        private string currentWindowCaption = string.Empty;
        private static Type nonPersistentObjectType = typeof(UIContainerObject);
        public ShowCustomFormWindowController() {
            TargetWindowType = WindowType.Main;
            showCustomFormActionCore = new SingleChoiceAction(this, "Show Form", PredefinedCategory.View);
            showCustomFormActionCore.ImageName = "Attention";
            showCustomFormActionCore.PaintStyle = ActionItemPaintStyle.CaptionAndImage;
            showCustomFormActionCore.ItemType = SingleChoiceActionItemType.ItemIsOperation;
            showCustomFormActionCore.Execute += showCustomFormActionCore_Execute;
        }
        public SingleChoiceAction ShowCustomFormAction { get { return showCustomFormActionCore; } }
        private void PopulateSingleChoiceActionItemsFrom(SingleChoiceAction sourceSingleChoiceAction) {
            showCustomFormActionCore.BeginUpdate();
            showCustomFormActionCore.Items.Clear();
            if (sourceSingleChoiceAction.Items.Count > 0) {
                foreach (ChoiceActionItem sourceItem in sourceSingleChoiceAction.Items[0].Items) {
                    if (((ViewShortcut)sourceItem.Data).ViewId == nonPersistentObjectType.Name + "_DetailView") {
                        ChoiceActionItem destinationItem = new ChoiceActionItem(sourceItem.Id, sourceItem.Caption, sourceItem.Data);
                        destinationItem.ImageName = sourceItem.ImageName;
                        showCustomFormActionCore.Items.Add(destinationItem);
                    }
                }
            }
            showCustomFormActionCore.EndUpdate();
        }
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            Application.CustomProcessShortcut += Application_CustomProcessShortcut;
            navigationController = Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null) {
                navigationController.ItemsInitialized += navigationController_ItemsInitialized;
                navigationController.CustomShowNavigationItem += navigationController_CustomShowNavigationItem;
            }
        }
        private void navigationController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e) {
            e.Handled = ShowFormCore(e.ActionArguments);
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            Application.CustomProcessShortcut -= Application_CustomProcessShortcut;
            if (navigationController != null) {
                navigationController.CustomShowNavigationItem -= navigationController_CustomShowNavigationItem;
                navigationController.ItemsInitialized -= navigationController_ItemsInitialized;
            }
        }
        private void Application_CustomProcessShortcut(object sender, CustomProcessShortcutEventArgs e) {
            XafApplication app = (XafApplication)sender;
            if (e.Shortcut != null && !string.IsNullOrEmpty(e.Shortcut.ViewId)) {
                IModelDetailView modelView = app.FindModelView(e.Shortcut.ViewId) as IModelDetailView;
                if (modelView != null) {
                    Type type = ReflectionHelper.FindType(modelView.ModelClass.Name);
                    if (type == nonPersistentObjectType) {
                        e.View = CreateDetailViewCore(app);
                        e.Handled = true;
                    }
                }
            }
        }
        private void navigationController_ItemsInitialized(object sender, EventArgs e) {
            PopulateSingleChoiceActionItemsFrom(navigationController.ShowNavigationItemAction);
        }
        private void showCustomFormActionCore_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            ShowFormCore(e);
        }
        private bool ShowFormCore(SingleChoiceActionExecuteEventArgs args) {
            string id = args.SelectedChoiceActionItem.Id;
            bool handled = false;
            if (!string.IsNullOrEmpty(id)) {
                currentWindowCaption = args.SelectedChoiceActionItem.Caption;
                ShowViewParameters svp = args.ShowViewParameters;
                switch (id) {
                    case "StandardNonModalFormWithCustomControl":
                        ShowStandardNonModalFormWithCustomControl(svp);
                        handled = true;
                        break;
                    case "StandardModalFormWithCustomControl":
                        ShowStandardModalFormWithCustomControl(svp);
                        handled = true;
                        break;
                    case "StandardEmbeddedFormWithCustomControl":
                        ShowStandardEmbeddedFormWithCustomControl(svp);
                        handled = true;
                        break;
                    case "CustomNonModalForm":
                        ShowCustomNonModalForm();
                        handled = true;
                        break;
                    case "CustomModalForm":
                        ShowCustomModalForm();
                        handled = true;
                        break;
                }
            }
            return handled;
        }
        private DetailView CreateDetailViewCore(XafApplication app) {
            IObjectSpace os = app.CreateObjectSpace();
            object obj = CreateNonPersistentObject(nonPersistentObjectType, os);
            DetailView dv = app.CreateDetailView(os, obj, true);
            dv.ViewEditMode = ViewEditMode.View;
            dv.Caption = GetWindowCaption();
            return dv;
        }
        protected string GetWindowCaption() {
            return currentWindowCaption;
        }
        private static object CreateNonPersistentObject(Type type, IObjectSpace os) {
            object obj = null;
            ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(type);
            DomainComponentAttribute dcAttribute = typeInfo.FindAttribute<DomainComponentAttribute>(false);
            NonPersistentAttribute npAttribute = typeInfo.FindAttribute<NonPersistentAttribute>(false);
            if (typeof(PersistentBase).IsAssignableFrom(type)) {
                if (npAttribute != null)
                    obj = os.CreateObject(type);
            }
            else {
                if (dcAttribute != null || npAttribute != null)
                    obj = Activator.CreateInstance(type);
            }
            if (obj == null)
                throw new InvalidOperationException("Cannot create an object of a non-persistent type.");
            return obj;
        }
        protected virtual void ShowStandardNonModalFormWithCustomControl(ShowViewParameters svp) {
            svp.CreatedView = CreateDetailViewCore(Application);
            svp.Context = TemplateContext.View;
            svp.TargetWindow = TargetWindow.NewWindow;
        }
        protected virtual void ShowStandardModalFormWithCustomControl(ShowViewParameters svp) {
            svp.CreatedView = CreateDetailViewCore(Application);
            svp.Context = TemplateContext.PopupWindow;
            svp.Controllers.Add(Application.CreateController<DialogController>());
            svp.TargetWindow = TargetWindow.NewModalWindow;
        }
        protected virtual void ShowStandardEmbeddedFormWithCustomControl(ShowViewParameters svp) {
            svp.CreatedView = CreateDetailViewCore(Application);
            svp.Context = TemplateContext.View;
            svp.TargetWindow = TargetWindow.Current;
        }
        protected abstract void ShowCustomNonModalForm();
        protected abstract void ShowCustomModalForm();
    }
}