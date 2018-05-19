Imports System.ComponentModel
Imports DevExpress.ExpressApp

Namespace E911.Module.Win
	<ToolboxItemFilter("Xaf.Platform.Win")> _
	Public NotInheritable Partial Class E911WindowsFormsModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of E911.Module.Editors.IModelCustomUserControlViewItem, E911.Module.Win.Editors.IModelWinCustomUserControlViewItem)()
		End Sub
	End Class
End Namespace
