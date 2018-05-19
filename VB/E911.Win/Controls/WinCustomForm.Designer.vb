Imports Microsoft.VisualBasic
Imports System
Namespace E911.Module.Win.Controls
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
			Me.CustomUserControl = New E911.Module.Win.Controls.WinCustomUserControl()
			Me.SuspendLayout()
			' 
			' CustomUserControl
			' 
			Me.CustomUserControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.CustomUserControl.Location = New System.Drawing.Point(0, 0)
			Me.CustomUserControl.Name = "CustomUserControl"
			Me.CustomUserControl.Size = New System.Drawing.Size(499, 440)
			Me.CustomUserControl.TabIndex = 0
			' 
			' WinCustomForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(499, 440)
			Me.Controls.Add(Me.CustomUserControl)
			Me.Name = "WinCustomForm"
			Me.Text = "WinCustomForm"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public CustomUserControl As WinCustomUserControl


	End Class
End Namespace