Imports Microsoft.VisualBasic
Imports System
Namespace WinCustomUserControlLibrary
	Partial Public Class WinCustomUserControl
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.textEdit1 = New DevExpress.XtraEditors.TextEdit()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.buttonEdit1 = New DevExpress.XtraEditors.ButtonEdit()
			Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
			Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
			Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
			Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.buttonEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.layoutControl1.SuspendLayout()
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Location = New System.Drawing.Point(105, 38)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(388, 367)
			Me.gridControl1.TabIndex = 7
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' textEdit1
			' 
			Me.textEdit1.Location = New System.Drawing.Point(353, 7)
			Me.textEdit1.Name = "textEdit1"
			Me.textEdit1.Size = New System.Drawing.Size(140, 20)
			Me.textEdit1.StyleController = Me.layoutControl1
			Me.textEdit1.TabIndex = 6
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(7, 416)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(486, 22)
			Me.simpleButton1.StyleController = Me.layoutControl1
			Me.simpleButton1.TabIndex = 5
			Me.simpleButton1.Text = "simpleButton1"
			' 
			' buttonEdit1
			' 
			Me.buttonEdit1.Location = New System.Drawing.Point(105, 7)
			Me.buttonEdit1.Name = "buttonEdit1"
			Me.buttonEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.buttonEdit1.Size = New System.Drawing.Size(139, 20)
			Me.buttonEdit1.StyleController = Me.layoutControl1
			Me.buttonEdit1.TabIndex = 4
			' 
			' layoutControl1
			' 
			Me.layoutControl1.Controls.Add(Me.gridControl1)
			Me.layoutControl1.Controls.Add(Me.textEdit1)
			Me.layoutControl1.Controls.Add(Me.buttonEdit1)
			Me.layoutControl1.Controls.Add(Me.simpleButton1)
			Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControl1.Name = "layoutControl1"
			Me.layoutControl1.Root = Me.layoutControlGroup1
			Me.layoutControl1.Size = New System.Drawing.Size(499, 444)
			Me.layoutControl1.TabIndex = 8
			Me.layoutControl1.Text = "layoutControl1"
			' 
			' layoutControlGroup1
			' 
			Me.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1"
			Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() { Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem3, Me.layoutControlItem4})
			Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlGroup1.Name = "layoutControlGroup1"
			Me.layoutControlGroup1.Size = New System.Drawing.Size(499, 444)
			Me.layoutControlGroup1.Spacing = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
			Me.layoutControlGroup1.Text = "layoutControlGroup1"
			Me.layoutControlGroup1.TextVisible = False
			' 
			' layoutControlItem1
			' 
			Me.layoutControlItem1.Control = Me.gridControl1
			Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
			Me.layoutControlItem1.Location = New System.Drawing.Point(0, 31)
			Me.layoutControlItem1.Name = "layoutControlItem1"
			Me.layoutControlItem1.Size = New System.Drawing.Size(497, 378)
			Me.layoutControlItem1.Text = "layoutControlItem1"
			Me.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left
			Me.layoutControlItem1.TextSize = New System.Drawing.Size(93, 20)
			' 
			' layoutControlItem2
			' 
			Me.layoutControlItem2.Control = Me.buttonEdit1
			Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
			Me.layoutControlItem2.Location = New System.Drawing.Point(0, 0)
			Me.layoutControlItem2.Name = "layoutControlItem2"
			Me.layoutControlItem2.Size = New System.Drawing.Size(248, 31)
			Me.layoutControlItem2.Text = "layoutControlItem2"
			Me.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left
			Me.layoutControlItem2.TextSize = New System.Drawing.Size(93, 20)
			' 
			' layoutControlItem3
			' 
			Me.layoutControlItem3.Control = Me.simpleButton1
			Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
			Me.layoutControlItem3.Location = New System.Drawing.Point(0, 409)
			Me.layoutControlItem3.Name = "layoutControlItem3"
			Me.layoutControlItem3.Size = New System.Drawing.Size(497, 33)
			Me.layoutControlItem3.Text = "layoutControlItem3"
			Me.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left
			Me.layoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
			Me.layoutControlItem3.TextToControlDistance = 0
			Me.layoutControlItem3.TextVisible = False
			' 
			' layoutControlItem4
			' 
			Me.layoutControlItem4.Control = Me.textEdit1
			Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
			Me.layoutControlItem4.Location = New System.Drawing.Point(248, 0)
			Me.layoutControlItem4.Name = "layoutControlItem4"
			Me.layoutControlItem4.Size = New System.Drawing.Size(249, 31)
			Me.layoutControlItem4.Text = "layoutControlItem4"
			Me.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left
			Me.layoutControlItem4.TextSize = New System.Drawing.Size(93, 20)
			' 
			' WinCustomUserControl
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.layoutControl1)
			Me.Name = "WinCustomUserControl"
			Me.Size = New System.Drawing.Size(499, 444)
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.buttonEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.layoutControl1.ResumeLayout(False)
			CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private textEdit1 As DevExpress.XtraEditors.TextEdit
		Private simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private buttonEdit1 As DevExpress.XtraEditors.ButtonEdit
		Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
		Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
		Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
		Private layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
	End Class
End Namespace
