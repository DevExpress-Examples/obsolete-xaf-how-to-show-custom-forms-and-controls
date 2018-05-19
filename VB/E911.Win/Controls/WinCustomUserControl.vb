Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Utils
Imports System.Collections
Imports E911.Module.Editors
Imports System.Collections.Generic
Imports DevExpress.Data.Filtering

Namespace E911.Module.Win.Controls
	''' <summary>
	''' This is a custom WinForms user control that displays persistent data received from XPO.
	''' You do not need to implement the IXpoSessionAwareControl interface if your control gets data from other sources or does not require data at all.
	''' </summary>
	Partial Public Class WinCustomUserControl
		Inherits DevExpress.XtraEditors.XtraUserControl
		Implements IXpoSessionAwareControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub UpdateDataSource(ByVal session As Session) Implements IXpoSessionAwareControl.UpdateDataSource
			Guard.ArgumentNotNull(session, "session")
			Dim persistentDataType As Type = GetType(DevExpress.Persistent.BaseImpl.Task)
			Dim persistentData As IList = New XPCollection(session, persistentDataType, CriteriaOperator.Parse("Status = 'NotStarted'"))
			gridControl1.DataSource = persistentData
			gridControl1.ForceInitialize()
		End Sub
	End Class
End Namespace
