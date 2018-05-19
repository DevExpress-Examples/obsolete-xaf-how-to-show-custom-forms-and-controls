Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.Xpo
Imports E911.Module.Editors

''' <summary>
''' This is a custom WinForms user form that displays persistent data received from XPO.
''' You do not need to implement the IXpoSessionAwareControl interface if your form gets data from other sources or does not require data at all.
''' </summary>
Partial Public Class WebCustomForm
	Inherits Page
	Implements IXpoSessionAwareControl
	''' <summary>
	''' You can also pass parameters into your custom form or read them via the query string or ASP.NET session or other standard ASP.NET means. Refer to ASP.NET documentation for more details on this.
	''' See Also:
	''' http://stackoverflow.com/questions/14956027/
	''' http://forums.asp.net/t/579631.aspx/1
	''' </summary>
	Protected Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		' Initializing a form when it is invoked from a controller.
		XpoSessionAwareControlInitializer.Initialize(TryCast(Me, IXpoSessionAwareControl), DevExpress.ExpressApp.Web.WebApplication.Instance)
	End Sub
	#Region "IXpoSessionAwareControl Members"
	Public Sub UpdateDataSource(ByVal session As Session) Implements IXpoSessionAwareControl.UpdateDataSource
		' Initializing a child control when it is not created by XAF (as part of a custom form).
		CType(Me.CustomUserControl, IXpoSessionAwareControl).UpdateDataSource(session)
	End Sub
	#End Region
End Class
