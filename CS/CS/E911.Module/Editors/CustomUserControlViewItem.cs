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
            //Initializing a control when it is placed on a XAF View.
            new XpoSessionAwareControlInitializer(Control as IXpoSessionAwareControl, theObjectSpace);
        }
    }
    public interface IXpoSessionAwareControl {
        Session Session { get; set; }
    }
    public class XpoSessionAwareControlInitializer {
        public XpoSessionAwareControlInitializer(IXpoSessionAwareControl sessionAwareControl, IObjectSpace theObjectSpace) {
            //The IXpoSessionAwareControl interface is needed to pass a Session into a custom user control that is supposed to implement this interface.
            // Session is required to query data when a custom user control is XPO-aware only.
            Guard.ArgumentNotNull(sessionAwareControl, "sessionAwareControl");
            // If a custom user control is XAF-aware, then use the ObjectSpace to query data.
            // You can pass an XafApplication into your custom control in a similar manner, if necessary.
            sessionAwareControl.Session = ((ObjectSpace)theObjectSpace).Session;
        }
        public XpoSessionAwareControlInitializer(IXpoSessionAwareControl sessionAwareControl, XafApplication theApplication)
            : this(sessionAwareControl, theApplication != null ? theApplication.CreateObjectSpace() : null) {
        }
    }
}