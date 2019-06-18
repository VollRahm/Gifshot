namespace Gifshot.Forms
{
    partial class OverlayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverlayForm));
            this.selectAreaInfo = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // selectAreaInfo
            // 
            this.selectAreaInfo.AutoPopDelay = 5000;
            this.selectAreaInfo.InitialDelay = 0;
            this.selectAreaInfo.ReshowDelay = 0;
            this.selectAreaInfo.UseAnimation = false;
            this.selectAreaInfo.UseFading = false;
            // 
            // OverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OverlayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OverlayForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip selectAreaInfo;
    }
}