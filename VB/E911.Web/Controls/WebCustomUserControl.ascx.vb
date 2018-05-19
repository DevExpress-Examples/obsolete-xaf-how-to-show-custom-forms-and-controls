Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Xpo
Imports DevExpress.Utils
Imports E911.Module.Editors

''' <summary>
''' This is a custom WinForms user control that displays persistent data received from XPO.
''' You do not need to implement the IXpoSessionAwareControl interface if your control gets data from other sources or does not require data at all.
''' </summary>
Partial Public Class WebCustomUserControl
	Inherits UserControl
	Implements IXpoSessionAwareControl
	Private Sub UpdateDataSource(ByVal session As Session) Implements IXpoSessionAwareControl.UpdateDataSource
		Guard.ArgumentNotNull(session, "session")
		Dim dataSource As New XpoDataSource()
                            dataSource.Criteria = "Status = 'NotStarted'"
		dataSource.TypeName = GetType(DevExpress.Persistent.BaseImpl.Task).FullName
		dataSource.Session = session
		grid.DataSource = dataSource
		grid.DataBind()
	End Sub
End Class