namespace WinCustomUserControlLibrary {
    partial class WinCustomForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.winCustomUserControl1 = new WinCustomUserControlLibrary.WinCustomUserControl();
            this.SuspendLayout();
            // 
            // winCustomUserControl1
            // 
            this.winCustomUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winCustomUserControl1.Location = new System.Drawing.Point(0, 0);
            this.winCustomUserControl1.Name = "winCustomUserControl1";
            this.winCustomUserControl1.Size = new System.Drawing.Size(499, 440);
            this.winCustomUserControl1.TabIndex = 0;
            // 
            // WinCustomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 440);
            this.Controls.Add(this.winCustomUserControl1);
            this.Name = "WinCustomForm";
            this.Text = "WinCustomForm";
            this.ResumeLayout(false);

        }

        #endregion

        private WinCustomUserControlLibrary.WinCustomUserControl winCustomUserControl1;

    }
}