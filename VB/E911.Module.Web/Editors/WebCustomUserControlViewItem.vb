Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Editors
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors

Namespace E911.Module.Web.Editors
	''' <summary>
	''' A custom Application Model element extension for the View Item node to be able to specify custom ASP.NET controls via the Model Editor.
	''' </summary>
	Public Interface IModelWebCustomUserControlViewItem
	Inherits IModelCustomUserControlViewItem
		<Category("Data")> _
		Property CustomControlPath() As String
	End Interface
	''' <summary>
	''' An custom View Item that hosts a custom ASP.NET user control (http://documentation.devexpress.com/#Xaf/CustomDocument2612) to show it in the XAF View.
	''' </summary>
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
			' You can access the View and other properties here to additionally initialize your control.
			Dim userControl As System.Web.UI.Control = WebWindow.CurrentRequestPage.LoadControl(model.CustomControlPath)
			userControl.ID = Me.GetType().Name
			Return userControl
		End Function
	End Class
End Namespace