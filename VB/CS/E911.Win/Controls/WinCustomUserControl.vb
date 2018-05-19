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
		Private Sub UpdateDataSource(ByVal session As Session) Implements IXpoSessionAwareControl.UpdateDataSource
			Guard.ArgumentNotNull(session, "session")
			gridControl1.DataSource = New XPCollection(Of DevExpress.Persistent.BaseImpl.Task)(session)
			gridControl1.ForceInitialize()
		End Sub
	End Class
End Namespace
