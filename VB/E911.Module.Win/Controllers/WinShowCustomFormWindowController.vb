Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Controllers
Imports System.Windows.Forms
Imports E911.Module.Editors

Namespace E911.Module.Win.Controllers
	Public Class WinShowCustomFormWindowController
		Inherits ShowCustomFormWindowController
		Protected Overrides Sub ShowCustomForm()
			Dim form As Form = TryCast(DevExpress.Persistent.Base.ReflectionHelper.CreateObject("E911.Module.Win.Controls.WinCustomForm"), Form)
			'Initializing a form when it is invoked from a controller.
			Dim TempXpoSessionAwareControlInitializer As XpoSessionAwareControlInitializer = New XpoSessionAwareControlInitializer(TryCast(form, IXpoSessionAwareControl), Application)
			form.Show()
		End Sub
	End Class
End Namespace