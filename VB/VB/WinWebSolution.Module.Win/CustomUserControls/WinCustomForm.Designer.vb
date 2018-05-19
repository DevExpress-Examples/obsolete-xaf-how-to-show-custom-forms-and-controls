Imports Microsoft.VisualBasic
Imports System
Namespace WinCustomUserControlLibrary
	Partial Public Class WinCustomForm
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.winCustomUserControl1 = New WinCustomUserControlLibrary.WinCustomUserControl()
			Me.SuspendLayout()
			' 
			' winCustomUserControl1
			' 
			Me.winCustomUserControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.winCustomUserControl1.Location = New System.Drawing.Point(0, 0)
			Me.winCustomUserControl1.Name = "winCustomUserControl1"
			Me.winCustomUserControl1.Size = New System.Drawing.Size(499, 440)
			Me.winCustomUserControl1.TabIndex = 0
			' 
			' WinCustomForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(499, 440)
			Me.Controls.Add(Me.winCustomUserControl1)
			Me.Name = "WinCustomForm"
			Me.Text = "WinCustomForm"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private winCustomUserControl1 As WinCustomUserControlLibrary.WinCustomUserControl

	End Class
End Namespace