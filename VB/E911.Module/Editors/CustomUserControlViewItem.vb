Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.Data.Filtering
Imports System.Collections

Namespace E911.Module.Editors
	''' <summary>
	''' A base custom Application Model element extension for the View Item node.
	''' </summary>
	Public Interface IModelCustomUserControlViewItem
	Inherits IModelViewItem
	End Interface

	''' <summary>
	''' A base custom View Item that hosts a custom user control (http://documentation.devexpress.com/#Xaf/CustomDocument2612) to show it in the XAF View.
	''' </summary>
	<ViewItem(GetType(IModelCustomUserControlViewItem))> _
	Public MustInherit Class CustomUserControlViewItem
		Inherits ViewItem
		Implements IComplexViewItem
		Public Sub New(ByVal model As IModelViewItem, ByVal objectType As Type)
			MyBase.New(objectType,If(model IsNot Nothing, model.Id, String.Empty))
		End Sub
		Private theObjectSpace As IObjectSpace
		Private theApplication As XafApplication
		Public ReadOnly Property ObjectSpace() As IObjectSpace
			Get
				Return theObjectSpace
			End Get
		End Property
		Public ReadOnly Property Application() As XafApplication
			Get
				Return theApplication
			End Get
		End Property
		Public Sub Setup(ByVal objectSpace As IObjectSpace, ByVal application As XafApplication) Implements IComplexViewItem.Setup
			theObjectSpace = objectSpace
			theApplication = application
		End Sub
		Protected Overrides Sub OnControlCreated()
			MyBase.OnControlCreated()
			' Initializing a control when it is created by XAF (as part of a ViewItem).
			' If you do not need to query data via 
			XpoSessionAwareControlInitializer.Initialize(TryCast(Control, IXpoSessionAwareControl), theObjectSpace)
		End Sub
	End Class
	''' <summary>
	''' This interface is designed to provide persistent data from the XAF application to custom user controls or forms (the interface should be implemented by them).
	''' </summary>
	Public Interface IXpoSessionAwareControl
		Sub UpdateDataSource(ByVal session As Session)
	End Interface
	Public NotInheritable Class XpoSessionAwareControlInitializer
		Private Sub New()
		End Sub
		Public Shared Sub Initialize(ByVal control As IXpoSessionAwareControl, ByVal objectSpace As IObjectSpace)
			' The IXpoSessionAwareControl interface is needed to pass a Session into a custom control that is supposed to implement this interface.
			Guard.ArgumentNotNull(control, "control")
			Guard.ArgumentNotNull(objectSpace, "objectSpace")

			' If a custom control is XAF-aware, then use the IObjectSpace to query data and bind it to your custom control (http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppBaseObjectSpacetopic). 
			' See some examples below:
			Dim persistentDataType As Type = GetType(DevExpress.Persistent.BaseImpl.Task)
			Dim persistentData As IList = objectSpace.GetObjects(persistentDataType, CriteriaOperator.Parse("Status = 'InProgress'"))

			' Session is required to query data when a custom control is XPO-aware only. 
			' You can pass an XafApplication into your custom control in a similar manner, if necessary.
			Dim xpObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = (CType(objectSpace, DevExpress.ExpressApp.Xpo.XPObjectSpace))
			control.UpdateDataSource(xpObjectSpace.Session)

			' It is required to update the session when ObjectSpace is reloaded.
			AddHandler objectSpace.Reloaded, Function(sender, args) AnonymousMethod1(sender, args, control, xpObjectSpace)
		End Sub
		
		Private Shared Function AnonymousMethod1(ByVal sender As Object, ByVal args As EventArgs, ByVal control As IXpoSessionAwareControl, ByVal xpObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace) As Boolean
			control.UpdateDataSource(xpObjectSpace.Session)
			Return True
		End Function
		Public Shared Sub Initialize(ByVal sessionAwareControl As IXpoSessionAwareControl, ByVal theApplication As XafApplication)
			Initialize(sessionAwareControl,If(theApplication IsNot Nothing, theApplication.CreateObjectSpace(), Nothing))
		End Sub
	End Class
End Namespace