Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Editors
Imports System.Windows.Forms
Imports System.ComponentModel
Imports E911.Module.Controllers
Imports DevExpress.ExpressApp.SystemModule

Namespace E911.Module.Win.Controllers
	''' <summary>
	''' A custom Application Model element extension for the Navigation Item node to be able to specify custom Win Forms via the Model Editor.
	''' </summary>
	Public Interface IModelWinCustomFormPathNavigationItem
		<Category("Data")> _
		Property CustomFormTypeName() As String
	End Interface
	Public Class WinShowCustomFormWindowController
		Inherits ShowCustomFormWindowController
		Protected Overrides Sub ShowCustomForm(ByVal model As IModelNavigationItem)
			Dim customFormTypeName As String = (CType(model, IModelWinCustomFormPathNavigationItem)).CustomFormTypeName
			Dim form As Form = TryCast(DevExpress.Persistent.Base.ReflectionHelper.CreateObject(customFormTypeName), Form)
			' Initializing a form when it is invoked from a controller.
			XpoSessionAwareControlInitializer.Initialize(TryCast(form, IXpoSessionAwareControl), Application)
			form.Show()
		End Sub
	End Class
End Namespace