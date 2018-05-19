using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl;

namespace E911.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            for (int i = 0; i < 10; i++) {
                Task theObject = ObjectSpace.CreateObject<Task>();
                theObject.Subject = String.Format("Task{0}", i);
            }
            ObjectSpace.CommitChanges();
        }
    }
}
