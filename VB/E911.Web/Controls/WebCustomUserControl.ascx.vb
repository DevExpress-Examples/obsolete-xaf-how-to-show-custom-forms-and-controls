Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Xpo
Imports DevExpress.Utils
Imports E911.Module.Editors

Partial Public Class WebCustomUserControl
	Inherits UserControl
	Implements IXpoSessionAwareControl
	Private Sub UpdateDataSource(ByVal session As Session) Implements IXpoSessionAwareControl.UpdateDataSource
		Guard.ArgumentNotNull(session, "session")
		Dim dataSource As New XpoDataSource()
		dataSource.TypeName = GetType(DevExpress.Persistent.BaseImpl.Task).FullName
		dataSource.Session = session
		grid.DataSource = dataSource
		grid.DataBind()
	End Sub
End Class