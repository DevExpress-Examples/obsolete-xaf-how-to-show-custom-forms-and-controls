using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;

namespace E911.Module.Editors {
    public interface IModelCustomUserControlViewItem : IModelViewItem { }
    [ViewItem(typeof(IModelCustomUserControlViewItem))]
    public abstract class CustomUserControlViewItem : ViewItem, IComplexPropertyEditor {
        public CustomUserControlViewItem(IModelViewItem model, Type objectType)
            : base(objectType, model != null ? model.Id : string.Empty) {
        }
        private IObjectSpace theObjectSpace;
        private XafApplication theApplication;
        public IObjectSpace ObjectSpace {
            get { return theObjectSpace; }
        }
        public XafApplication Application {
            get { return theApplication; }
        }
        public void Setup(IObjectSpace objectSpace, XafApplication application) {
            theObjectSpace = objectSpace;
            theApplication = application;
        }
        protected override void OnControlCreated() {
            base.OnControlCreated();
            //Initializing a control when it is created by XAF (as part of a ViewItem).
            new XpoSessionAwareControlInitializer(Control as IXpoSessionAwareControl, theObjectSpace);
        }
    }
    public interface IXpoSessionAwareControl {
        void UpdateDataSource(Session session);
    }
    public class XpoSessionAwareControlInitializer {
        public XpoSessionAwareControlInitializer(IXpoSessionAwareControl control, IObjectSpace objectSpace) {
            //The IXpoSessionAwareControl interface is needed to pass a Session into a custom control that is supposed to implement this interface.
           
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(objectSpace, "objectSpace");
            //If a custom control is XAF-aware, then use the ObjectSpace to query data.
            // You can pass an XafApplication into your custom control in a similar manner, if necessary.
            DevExpress.ExpressApp.Xpo.XPObjectSpace xpObjectSpace = ((DevExpress.ExpressApp.Xpo.XPObjectSpace)objectSpace);
            // Session is required to query data when a custom control is XPO-aware only.
            control.UpdateDataSource(xpObjectSpace.Session);
            //It is required to update the session when ObjectSpace is reloaded.
            objectSpace.Reloaded += delegate(object sender, EventArgs args) {
                control.UpdateDataSource(xpObjectSpace.Session);
            };
        }
        public XpoSessionAwareControlInitializer(IXpoSessionAwareControl sessionAwareControl, XafApplication theApplication)
            : this(sessionAwareControl, theApplication != null ? theApplication.CreateObjectSpace() : null) {
        }
    }
}