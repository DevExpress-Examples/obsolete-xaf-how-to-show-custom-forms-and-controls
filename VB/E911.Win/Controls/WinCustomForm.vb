Imports Microsoft.VisualBasic
Imports System
Imports E911.Module.Editors
Imports DevExpress.Xpo

Namespace E911.Module.Win.Controls
	Partial Public Class WinCustomForm
		Inherits DevExpress.XtraEditors.XtraForm
		Implements IXpoSessionAwareControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
			MyBase.OnHandleCreated(e)
			'Initializing a child control in a scenario when it is placed on a form and is not created by XAF.
			If (Not DesignMode) Then
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
End Namespace