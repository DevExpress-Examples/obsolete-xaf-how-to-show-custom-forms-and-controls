Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model

Namespace WinSolution.Module.Web
	Public Interface IWebUIContainerViewItem
	Inherits IModelViewItem
	End Interface
	<DetailViewItemAttribute(GetType(IWebUIContainerViewItem))> _
	Public Class WebUIContainerViewItem
		Inherits ViewItem
		Public Sub New(ByVal objectType As Type, ByVal id As String)
			MyBase.New(objectType, id)
		End Sub
		Public Sub New(ByVal model As IWebUIContainerViewItem, ByVal objectType As Type)
			MyBase.New(objectType, model.Id)
		End Sub
		Protected Overrides Function CreateControlCore() As Object
			Return WebWindow.CurrentRequestPage.LoadControl("CustomUserControls/WebCustomUserControl.ascx")
		End Function
	End Class
End Namespace