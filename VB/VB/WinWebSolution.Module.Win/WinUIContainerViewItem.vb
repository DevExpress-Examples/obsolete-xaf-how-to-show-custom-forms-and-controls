Imports Microsoft.VisualBasic
Imports System
Imports WinCustomUserControlLibrary
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model

Namespace WinWebSolution.Module.Win
	Public Interface IWinUIContainerViewItem
	Inherits IModelViewItem
	End Interface
	<DetailViewItemAttribute(GetType(IWinUIContainerViewItem))> _
	Public Class WinUIContainerViewItem
		Inherits ViewItem
		Public Sub New(ByVal objectType As Type, ByVal id As String)
			MyBase.New(objectType, id)
		End Sub
		Public Sub New(ByVal model As IWinUIContainerViewItem, ByVal objectType As Type)
			MyBase.New(objectType, model.Id)
		End Sub
		Protected Overrides Function CreateControlCore() As Object
			Return New WinCustomUserControl()
		End Function
	End Class
End Namespace