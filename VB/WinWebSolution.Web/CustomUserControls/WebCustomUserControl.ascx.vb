Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI

Partial Public Class WebCustomUserControl
	Inherits UserControl
	Protected Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		grid.DataSource = Demo.DataHelper.GetData()
		grid.DataBind()
	End Sub
End Class
