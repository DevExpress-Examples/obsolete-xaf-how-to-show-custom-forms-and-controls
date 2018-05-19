Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Utils
Imports E911.Module.Editors
Imports System.Collections.Generic

Namespace E911.Module.Win.Controls
	Partial Public Class WinCustomUserControl
		Inherits DevExpress.XtraEditors.XtraUserControl
		Implements IXpoSessionAwareControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)
			If (Not DesignMode) Then
				UpdateDataSource()
			End If
		End Sub
		Private Sub UpdateDataSource()
			Dim session As Session = (CType(Me, IXpoSessionAwareControl)).Session
			Guard.ArgumentNotNull(session, "session")
			gridControl1.DataSource = New XPCollection(Of DevExpress.Persistent.BaseImpl.Task)(session)
			gridControl1.ForceInitialize()
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
