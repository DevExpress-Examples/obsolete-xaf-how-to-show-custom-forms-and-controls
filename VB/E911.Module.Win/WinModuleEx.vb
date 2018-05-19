Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Collections.Generic

Namespace E911.Module.Win
	Public NotInheritable Partial Class E911WindowsFormsModule
		' Extends the Application Model elements for View and Navigation Items to be able to specify custom controls via the Model Editor.
		' Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument3169 help article for more information.
		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of E911.Module.Editors.IModelCustomUserControlViewItem, E911.Module.Win.Editors.IModelWinCustomUserControlViewItem)()
			extenders.Add(Of DevExpress.ExpressApp.SystemModule.IModelNavigationItem, E911.Module.Win.Controllers.IModelWinCustomFormPathNavigationItem)()
		End Sub
	End Class
End Namespace
