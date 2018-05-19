Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils

Namespace E911.Module.Editors
	Public Interface IModelCustomUserControlViewItem
	Inherits IModelViewItem
	End Interface
	<ViewItem(GetType(IModelCustomUserControlViewItem))> _
	Public MustInherit Class CustomUserControlViewItem
		Inherits ViewItem
		Implements IComplexPropertyEditor
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
		Public Sub Setup(ByVal objectSpace As IObjectSpace, ByVal application As XafApplication) Implements IComplexPropertyEditor.Setup
			theObjectSpace = objectSpace
			theApplication = application
		End Sub
		Protected Overrides Sub OnControlCreated()
			MyBase.OnControlCreated()
			'Initializing a control when it is placed on a XAF View.
			Dim TempXpoSessionAwareControlInitializer As XpoSessionAwareControlInitializer = New XpoSessionAwareControlInitializer(TryCast(Control, IXpoSessionAwareControl), theObjectSpace)
		End Sub
	End Class
	Public Interface IXpoSessionAwareControl
		Property Session() As Session
	End Interface
	Public Class XpoSessionAwareControlInitializer
		Public Sub New(ByVal sessionAwareControl As IXpoSessionAwareControl, ByVal theObjectSpace As IObjectSpace)
			'The IXpoSessionAwareControl interface is needed to pass a Session into a custom user control that is supposed to implement this interface.
			' Session is required to query data when a custom user control is XPO-aware only.
			Guard.ArgumentNotNull(sessionAwareControl, "sessionAwareControl")
			' If a custom user control is XAF-aware, then use the ObjectSpace to query data.
			' You can pass an XafApplication into your custom control in a similar manner, if necessary.
			sessionAwareControl.Session = (CType(theObjectSpace, ObjectSpace)).Session
		End Sub
		Public Sub New(ByVal sessionAwareControl As IXpoSessionAwareControl, ByVal theApplication As XafApplication)
			Me.New(sessionAwareControl,If(theApplication IsNot Nothing, theApplication.CreateObjectSpace(), Nothing))
		End Sub
	End Class
End Namespace