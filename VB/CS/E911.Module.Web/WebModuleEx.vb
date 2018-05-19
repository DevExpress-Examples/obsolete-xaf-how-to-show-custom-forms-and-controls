Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Collections.Generic

Namespace E911.Module.Web
	Public NotInheritable Partial Class E911AspNetModule
		' Registers custom extensions for Application Model elements.
		' Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument3169 help article for more information.
		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of E911.Module.Editors.IModelCustomUserControlViewItem, E911.Module.Web.Editors.IModelWebCustomUserControlViewItem)()
			extenders.Add(Of DevExpress.ExpressApp.SystemModule.IModelNavigationItem, E911.Module.Web.Controllers.IModelWebCustomFormPathNavigationItem)()
		End Sub
	End Class
End Namespace
