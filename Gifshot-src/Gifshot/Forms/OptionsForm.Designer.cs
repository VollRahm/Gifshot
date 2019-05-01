namespace Gifshot
{
    partial class OptionsForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.notifIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autostartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitGifshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.notifContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifIcon
            // 
            this.notifIcon.ContextMenuStrip = this.notifContextMenu;
            this.notifIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifIcon.Icon")));
            this.notifIcon.Text = "Gifshot";
            this.notifIcon.Visible = true;
            // 
            // notifContextMenu
            // 
            this.notifContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autostartToolStripMenuItem,
            this.showWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitGifshotToolStripMenuItem});
            this.notifContextMenu.Name = "notifContextMenu";
            this.notifContextMenu.Size = new System.Drawing.Size(181, 98);
            // 
            // autostartToolStripMenuItem
            // 
            this.autostartToolStripMenuItem.Checked = true;
            this.autostartToolStripMenuItem.CheckOnClick = true;
            this.autostartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autostartToolStripMenuItem.Name = "autostartToolStripMenuItem";
            this.autostartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autostartToolStripMenuItem.Text = "Autostart";
            this.autostartToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autostartToolStripMenuItem_CheckedChanged);
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showWindowToolStripMenuItem.Text = "Settings...";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitGifshotToolStripMenuItem
            // 
            this.exitGifshotToolStripMenuItem.Name = "exitGifshotToolStripMenuItem";
            this.exitGifshotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitGifshotToolStripMenuItem.Text = "Exit Gifshot";
            this.exitGifshotToolStripMenuItem.Click += new System.EventHandler(this.exitGifshotToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "(Icon designed by Freepik from www.flaticon.com)";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 68);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Gifshot";
            this.Shown += new System.EventHandler(this.OptionsForm_Shown);
            this.notifContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifIcon;
        private System.Windows.Forms.ContextMenuStrip notifContextMenu;
        private System.Windows.Forms.ToolStripMenuItem autostartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitGifshotToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

