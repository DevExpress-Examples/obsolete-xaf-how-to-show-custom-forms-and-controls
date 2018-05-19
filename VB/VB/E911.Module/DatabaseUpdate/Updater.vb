Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Persistent.BaseImpl

Namespace E911.Module.DatabaseUpdate
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			For i As Integer = 0 To 9
				Dim theObject As Task = ObjectSpace.CreateObject(Of Task)()
				theObject.Subject = String.Format("Task{0}", i)
			Next i
			ObjectSpace.CommitChanges()
		End Sub
	End Class
End Namespace
