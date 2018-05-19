Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace WinCustomUserControlLibrary
	Partial Public Class WinCustomUserControl
		Inherits DevExpress.XtraEditors.XtraUserControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)
			gridControl1.DataSource = Demo.DataHelper.GetData()
		End Sub
	End Class
End Namespace
