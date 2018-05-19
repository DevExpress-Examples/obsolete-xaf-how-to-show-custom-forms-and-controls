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
		If (Not DesignMode) Then
			'Initializing a child control in a scenario when it is placed on a form and is not created by XAF.
			CType(Me.CustomUserControl, IXpoSessionAwareControl).Session = (CType(Me, IXpoSessionAwareControl)).Session
		End If
	End Sub
	Private privateSession As Session
	Private Property Session() As Session Implements IXpoSessionAwareControl.Session
		Get
			Return privateSession
		End Get
		Set(ByVal value As Session)
			privateSession = value
		End Set
	End Property
End Class
