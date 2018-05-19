Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.SystemModule

Namespace WinWebSolution.Module
	Public MustInherit Class ShowCustomFormWindowController
		Inherits WindowController
		Private navigationController As ShowNavigationItemController
		Private showCustomFormActionCore As SingleChoiceAction
		Private currentWindowCaption As String = String.Empty
		Private Shared nonPersistentObjectType As Type = GetType(UIContainerObject)
		Public Sub New()
			TargetWindowType = WindowType.Main
			showCustomFormActionCore = New SingleChoiceAction(Me, "Show Form", PredefinedCategory.View)
			showCustomFormActionCore.ImageName = "Attention"
			showCustomFormActionCore.PaintStyle = ActionItemPaintStyle.CaptionAndImage
			showCustomFormActionCore.ItemType = SingleChoiceActionItemType.ItemIsOperation
			AddHandler showCustomFormActionCore.Execute, AddressOf showCustomFormActionCore_Execute
		End Sub
		Public ReadOnly Property ShowCustomFormAction() As SingleChoiceAction
			Get
				Return showCustomFormActionCore
			End Get
		End Property
		Private Sub PopulateSingleChoiceActionItemsFrom(ByVal sourceSingleChoiceAction As SingleChoiceAction)
			showCustomFormActionCore.BeginUpdate()
			showCustomFormActionCore.Items.Clear()
			If sourceSingleChoiceAction.Items.Count > 0 Then
				For Each sourceItem As ChoiceActionItem In sourceSingleChoiceAction.Items(0).Items
					If (CType(sourceItem.Data, ViewShortcut)).ViewId = nonPersistentObjectType.Name & "_DetailView" Then
						Dim destinationItem As New ChoiceActionItem(sourceItem.Id, sourceItem.Caption, sourceItem.Data)
						destinationItem.ImageName = sourceItem.ImageName
						showCustomFormActionCore.Items.Add(destinationItem)
					End If
				Next sourceItem
			End If
			showCustomFormActionCore.EndUpdate()
		End Sub
		Protected Overrides Sub OnFrameAssigned()
			MyBase.OnFrameAssigned()
			AddHandler Application.CustomProcessShortcut, AddressOf Application_CustomProcessShortcut
			navigationController = Frame.GetController(Of ShowNavigationItemController)()
			If navigationController IsNot Nothing Then
				AddHandler navigationController.ItemsInitialized, AddressOf navigationController_ItemsInitialized
				AddHandler navigationController.CustomShowNavigationItem, AddressOf navigationController_CustomShowNavigationItem
			End If
		End Sub
		Private Sub navigationController_CustomShowNavigationItem(ByVal sender As Object, ByVal e As CustomShowNavigationItemEventArgs)
			e.Handled = ShowFormCore(e.ActionArguments)
		End Sub
		Protected Overrides Sub OnDeactivated()
			MyBase.OnDeactivated()
			RemoveHandler Application.CustomProcessShortcut, AddressOf Application_CustomProcessShortcut
			If navigationController IsNot Nothing Then
				RemoveHandler navigationController.CustomShowNavigationItem, AddressOf navigationController_CustomShowNavigationItem
				RemoveHandler navigationController.ItemsInitialized, AddressOf navigationController_ItemsInitialized
			End If
		End Sub
		Private Sub Application_CustomProcessShortcut(ByVal sender As Object, ByVal e As CustomProcessShortcutEventArgs)
			Dim app As XafApplication = CType(sender, XafApplication)
			If e.Shortcut IsNot Nothing AndAlso (Not String.IsNullOrEmpty(e.Shortcut.ViewId)) Then
				Dim modelView As IModelDetailView = TryCast(app.FindModelView(e.Shortcut.ViewId), IModelDetailView)
				If modelView IsNot Nothing Then
					Dim type As Type = ReflectionHelper.FindType(modelView.ModelClass.Name)
					If type Is nonPersistentObjectType Then
						e.View = CreateDetailViewCore(app)
						e.Handled = True
					End If
				End If
			End If
		End Sub
		Private Sub navigationController_ItemsInitialized(ByVal sender As Object, ByVal e As EventArgs)
			PopulateSingleChoiceActionItemsFrom(navigationController.ShowNavigationItemAction)
		End Sub
		Private Sub showCustomFormActionCore_Execute(ByVal sender As Object, ByVal e As SingleChoiceActionExecuteEventArgs)
			ShowFormCore(e)
		End Sub
		Private Function ShowFormCore(ByVal args As SingleChoiceActionExecuteEventArgs) As Boolean
			Dim id As String = args.SelectedChoiceActionItem.Id
			Dim handled As Boolean = False
			If (Not String.IsNullOrEmpty(id)) Then
				currentWindowCaption = args.SelectedChoiceActionItem.Caption
				Dim svp As ShowViewParameters = args.ShowViewParameters
				Select Case id
					Case "StandardNonModalFormWithCustomControl"
						ShowStandardNonModalFormWithCustomControl(svp)
						handled = True
					Case "StandardModalFormWithCustomControl"
						ShowStandardModalFormWithCustomControl(svp)
						handled = True
					Case "StandardEmbeddedFormWithCustomControl"
						ShowStandardEmbeddedFormWithCustomControl(svp)
						handled = True
					Case "CustomNonModalForm"
						ShowCustomNonModalForm()
						handled = True
					Case "CustomModalForm"
						ShowCustomModalForm()
						handled = True
				End Select
			End If
			Return handled
		End Function
		Private Function CreateDetailViewCore(ByVal app As XafApplication) As DetailView
			Dim os As IObjectSpace = app.CreateObjectSpace()
			Dim obj As Object = CreateNonPersistentObject(nonPersistentObjectType, os)
			Dim dv As DetailView = app.CreateDetailView(os, obj, True)
			dv.ViewEditMode = ViewEditMode.View
			dv.Caption = GetWindowCaption()
			Return dv
		End Function
		Protected Function GetWindowCaption() As String
			Return currentWindowCaption
		End Function
		Private Shared Function CreateNonPersistentObject(ByVal type As Type, ByVal os As IObjectSpace) As Object
			Dim obj As Object = Nothing
			Dim typeInfo As ITypeInfo = XafTypesInfo.Instance.FindTypeInfo(type)
			Dim dcAttribute As DomainComponentAttribute = typeInfo.FindAttribute(Of DomainComponentAttribute)(False)
			Dim npAttribute As NonPersistentAttribute = typeInfo.FindAttribute(Of NonPersistentAttribute)(False)
			If GetType(PersistentBase).IsAssignableFrom(type) Then
				If npAttribute IsNot Nothing Then
					obj = os.CreateObject(type)
				End If
			Else
				If dcAttribute IsNot Nothing OrElse npAttribute IsNot Nothing Then
					obj = Activator.CreateInstance(type)
				End If
			End If
			If obj Is Nothing Then
				Throw New InvalidOperationException("Cannot create an object of a non-persistent type.")
			End If
			Return obj
		End Function
		Protected Overridable Sub ShowStandardNonModalFormWithCustomControl(ByVal svp As ShowViewParameters)
			svp.CreatedView = CreateDetailViewCore(Application)
			svp.Context = TemplateContext.View
			svp.TargetWindow = TargetWindow.NewWindow
		End Sub
		Protected Overridable Sub ShowStandardModalFormWithCustomControl(ByVal svp As ShowViewParameters)
			svp.CreatedView = CreateDetailViewCore(Application)
			svp.Context = TemplateContext.PopupWindow
			svp.Controllers.Add(Application.CreateController(Of DialogController)())
			svp.TargetWindow = TargetWindow.NewModalWindow
		End Sub
		Protected Overridable Sub ShowStandardEmbeddedFormWithCustomControl(ByVal svp As ShowViewParameters)
			svp.CreatedView = CreateDetailViewCore(Application)
			svp.Context = TemplateContext.View
			svp.TargetWindow = TargetWindow.Current
		End Sub
		Protected MustOverride Sub ShowCustomNonModalForm()
		Protected MustOverride Sub ShowCustomModalForm()
	End Class
End Namespace