Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Editors
Imports System.ComponentModel
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors

Namespace E911.Module.Win.Editors
	Public Interface IModelWinCustomUserControlViewItem
		<Category("Data")> _
		Property ControlTypeName() As String
	End Interface
	<ViewItem(GetType(IModelCustomUserControlViewItem))> _
	Public Class WinCustomUserControlViewItem
		Inherits CustomUserControlViewItem
		Protected model As IModelWinCustomUserControlViewItem
		Public Sub New(ByVal model As IModelViewItem, ByVal objectType As Type)
			MyBase.New(model, objectType)
			Me.model = TryCast(model, IModelWinCustomUserControlViewItem)
			If Me.model Is Nothing Then
				Throw New ArgumentNullException("IModelWinCustomUserControlViewItem must extend IModelCustomUserControlViewItem in the ExtendModelInterfaces method of your Win ModuleBase descendant.")
			End If
		End Sub
		Protected Overrides Function CreateControlCore() As Object
			'You can access the View and other properties here to additionally initialize your control.
			Return DevExpress.Persistent.Base.ReflectionHelper.CreateObject(model.ControlTypeName)
		End Function
	End Class
End Namespace