Imports Microsoft.VisualBasic
Imports System
Imports WinCustomUserControlLibrary

Namespace WinWebSolution.Module.Win
	Public Class WinShowCustomFormWindowController
		Inherits ShowCustomFormWindowController
		Protected Overrides Sub ShowCustomNonModalForm()
			Dim form As New WinCustomForm()
			form.Text = GetWindowCaption()
			form.Show()
		End Sub
		Protected Overrides Sub ShowCustomModalForm()
			Using form As New WinCustomForm()
				form.Text = GetWindowCaption()
				form.ShowDialog()
			End Using
		End Sub
	End Class
End Namespace
