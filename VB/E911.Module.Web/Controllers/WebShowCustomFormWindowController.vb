Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Controllers

Namespace E911.Module.Web.Controllers
	Public Class WebShowCustomFormWindowController
		Inherits ShowCustomFormWindowController
		Protected Overrides Sub ShowCustomForm()
			DevExpress.ExpressApp.Web.WebWindow.CurrentRequestWindow.RegisterStartupScript("ShowCustomFormScript", "window.open('Controls/WebCustomForm.aspx');")
		End Sub
	End Class
End Namespace