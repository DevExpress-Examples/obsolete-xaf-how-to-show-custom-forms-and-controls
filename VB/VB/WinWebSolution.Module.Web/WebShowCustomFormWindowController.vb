Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports DevExpress.ExpressApp

Namespace WinWebSolution.Module.Web
	Public Class WebShowCustomFormWindowController
		Inherits ShowCustomFormWindowController
		Private customFormPath As String = "CustomUserControls/WebCustomForm.aspx"
		Protected Overrides Sub ShowCustomNonModalForm()
			Dim page As Page = CType(Frame.Template, Page)

			Dim script As String = "<script>" & ControlChars.CrLf & "                                var openedWindow = window.open(""" & customFormPath & """,""test"", ""toolbar=no,menubar=no,width=600,height=600,resizable=no, center=yes"");" & ControlChars.CrLf & "                            </script>"
			page.ClientScript.RegisterStartupScript(Me.GetType(), "clientScriptForNonModalWindow", script)
		End Sub
		Protected Overrides Sub ShowCustomModalForm()
			Dim page As Page = CType(Frame.Template, Page)

			Dim script As String = "<script>" & ControlChars.CrLf & "                                window.showModalDialog(""" & customFormPath & """,""#1"",""dialogHeight: 600px; dialogWidth: 600px;dialogTop: 190px;  dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;"");" & ControlChars.CrLf & "                            </script>"
			page.ClientScript.RegisterStartupScript(Me.GetType(), "clientScriptForModalWindow", script)
		End Sub
	End Class
End Namespace