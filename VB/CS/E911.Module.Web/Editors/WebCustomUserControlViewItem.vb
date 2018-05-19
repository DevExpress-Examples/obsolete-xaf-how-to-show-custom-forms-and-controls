Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Editors
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors

Namespace E911.Module.Web.Editors
	Public Interface IModelWebCustomUserControlViewItem
	Inherits IModelCustomUserControlViewItem
		<Category("Data")> _
		Property UserControlPath() As String
	End Interface
	<ViewItem(GetType(IModelCustomUserControlViewItem))> _
	Public Class WebCustomUserControlViewItem
		Inherits CustomUserControlViewItem
		Protected model As IModelWebCustomUserControlViewItem
		Public Sub New(ByVal model As IModelViewItem, ByVal objectType As Type)
			MyBase.New(model, objectType)
			Me.model = TryCast(model, IModelWebCustomUserControlViewItem)
			If Me.model Is Nothing Then
				Throw New ArgumentNullException("IModelWebCustomUserControlViewItem must extend IModelCustomUserControlViewItem in the ExtendModelInterfaces method of your Web ModuleBase descendant.")
			End If
		End Sub
		Protected Overrides Function CreateControlCore() As Object
			'You can access the View and other properties here to additionally initialize your control.
			Return WebWindow.CurrentRequestPage.LoadControl(model.UserControlPath)
		End Function
	End Class
End Namespace