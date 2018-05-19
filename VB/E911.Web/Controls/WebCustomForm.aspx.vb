Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Xpo
Imports E911.Module.Editors

Partial Public Class WebCustomForm
	Inherits Page
	Implements IXpoSessionAwareControl
	Protected Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		'Initializing a form when it is invoked from a controller.
		Dim TempXpoSessionAwareControlInitializer As XpoSessionAwareControlInitializer = New XpoSessionAwareControlInitializer(TryCast(Me, IXpoSessionAwareControl), DevExpress.ExpressApp.Web.WebApplication.Instance)
	End Sub
	#Region "IXpoSessionAwareControl Members"
	Public Sub UpdateDataSource(ByVal session As Session) Implements IXpoSessionAwareControl.UpdateDataSource
		'Initializing a child control when it is not created by XAF (as part of a custom form).
		CType(Me.CustomUserControl, IXpoSessionAwareControl).UpdateDataSource(session)
	End Sub
	#End Region
End Class
