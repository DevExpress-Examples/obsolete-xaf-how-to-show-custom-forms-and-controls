Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Controllers
Imports System.ComponentModel
Imports DevExpress.ExpressApp.SystemModule

Namespace E911.Module.Web.Controllers
	''' <summary>
	''' A custom Application Model element extension for the Navigation Item node to be able to specify custom Web Forms via the Model Editor.
	''' </summary>
	Public Interface IModelWebCustomFormPathNavigationItem
	Inherits IModelNavigationItem
		<Category("Data")> _
		Property CustomFormPath() As String
	End Interface
	Public Class WebShowCustomFormWindowController
		Inherits ShowCustomFormWindowController
		''' <summary>
		''' You can also pass parameters into your custom form or read them via the query string or ASP.NET session or other standard ASP.NET means. Refer to ASP.NET documentation for more details on this.
		''' See Also:
		''' http://stackoverflow.com/questions/14956027/
		''' http://forums.asp.net/t/579631.aspx/1
		''' </summary>
		Protected Overrides Sub ShowCustomForm(ByVal model As IModelNavigationItem)
			Dim customFormPath As String = (CType(model, IModelWebCustomFormPathNavigationItem)).CustomFormPath
			DevExpress.ExpressApp.Web.WebWindow.CurrentRequestWindow.RegisterStartupScript("ShowCustomFormScriptKey", String.Format("window.open('{0}');", customFormPath))
		End Sub
	End Class
End Namespace