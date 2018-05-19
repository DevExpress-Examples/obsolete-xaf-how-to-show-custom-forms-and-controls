Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Xpo
Imports DevExpress.Utils
Imports E911.Module.Editors

Partial Public Class WebCustomUserControl
	Inherits UserControl
	Implements IXpoSessionAwareControl
	Protected Overrides Sub OnLoad(ByVal e As EventArgs)
		MyBase.OnLoad(e)
		If (Not DesignMode) Then
			UpdateDataSource()
		End If
	End Sub
	Private Sub UpdateDataSource()
		Dim session As Session = (CType(Me, IXpoSessionAwareControl)).Session
		Guard.ArgumentNotNull(session, "session")
		Dim dataSource As New XpoDataSource()
		dataSource.TypeName = GetType(DevExpress.Persistent.BaseImpl.Task).FullName
		dataSource.Session = session
		grid.DataSource = dataSource
		grid.DataBind()
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