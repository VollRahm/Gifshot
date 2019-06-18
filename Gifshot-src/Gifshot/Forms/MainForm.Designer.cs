namespace Gifshot.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autostartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitGifshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.func_saveImageBtn = new System.Windows.Forms.Button();
            this.func_copyToClipBoardBtn = new System.Windows.Forms.Button();
            this.notifContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifIcon
            // 
            this.notifIcon.ContextMenuStrip = this.notifContextMenu;
            this.notifIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifIcon.Icon")));
            this.notifIcon.Text = "Gifshot";
            this.notifIcon.Visible = true;
            this.notifIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifIcon_MouseClick);
            // 
            // notifContextMenu
            // 
            this.notifContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autostartToolStripMenuItem,
            this.showWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitGifshotToolStripMenuItem});
            this.notifContextMenu.Name = "notifContextMenu";
            this.notifContextMenu.Size = new System.Drawing.Size(134, 76);
            // 
            // autostartToolStripMenuItem
            // 
            this.autostartToolStripMenuItem.Checked = true;
            this.autostartToolStripMenuItem.CheckOnClick = true;
            this.autostartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autostartToolStripMenuItem.Name = "autostartToolStripMenuItem";
            this.autostartToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.autostartToolStripMenuItem.Text = "Autostart";
            this.autostartToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autostartToolStripMenuItem_CheckedChanged);
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.showWindowToolStripMenuItem.Text = "Settings...";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // exitGifshotToolStripMenuItem
            // 
            this.exitGifshotToolStripMenuItem.Name = "exitGifshotToolStripMenuItem";
            this.exitGifshotToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitGifshotToolStripMenuItem.Text = "Exit Gifshot";
            this.exitGifshotToolStripMenuItem.Click += new System.EventHandler(this.exitGifshotToolStripMenuItem_Click);
            // 
            // func_saveImageBtn
            // 
            this.func_saveImageBtn.BackColor = System.Drawing.Color.Transparent;
            this.func_saveImageBtn.BackgroundImage = global::Gifshot.Properties.Resources.save_file_button;
            this.func_saveImageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.func_saveImageBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.func_saveImageBtn.FlatAppearance.BorderSize = 0;
            this.func_saveImageBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.func_saveImageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.func_saveImageBtn.ForeColor = System.Drawing.Color.Transparent;
            this.func_saveImageBtn.Location = new System.Drawing.Point(1, 1);
            this.func_saveImageBtn.Name = "func_saveImageBtn";
            this.func_saveImageBtn.Size = new System.Drawing.Size(35, 35);
            this.func_saveImageBtn.TabIndex = 2;
            this.func_saveImageBtn.UseVisualStyleBackColor = false;
            this.func_saveImageBtn.Click += new System.EventHandler(this.Func_saveImageBtn_Click);
            // 
            // func_copyToClipBoardBtn
            // 
            this.func_copyToClipBoardBtn.BackColor = System.Drawing.Color.Transparent;
            this.func_copyToClipBoardBtn.BackgroundImage = global::Gifshot.Properties.Resources.copy_to_clipboard;
            this.func_copyToClipBoardBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.func_copyToClipBoardBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.func_copyToClipBoardBtn.FlatAppearance.BorderSize = 0;
            this.func_copyToClipBoardBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.func_copyToClipBoardBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.func_copyToClipBoardBtn.ForeColor = System.Drawing.Color.Transparent;
            this.func_copyToClipBoardBtn.Location = new System.Drawing.Point(35, 1);
            this.func_copyToClipBoardBtn.Name = "func_copyToClipBoardBtn";
            this.func_copyToClipBoardBtn.Size = new System.Drawing.Size(35, 35);
            this.func_copyToClipBoardBtn.TabIndex = 2;
            this.func_copyToClipBoardBtn.UseVisualStyleBackColor = false;
            this.func_copyToClipBoardBtn.Click += new System.EventHandler(this.Func_copyToClipBoardBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 37);
            this.Controls.Add(this.func_copyToClipBoardBtn);
            this.Controls.Add(this.func_saveImageBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Gifshot";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.OptionsForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.notifContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifIcon;
        private System.Windows.Forms.ContextMenuStrip notifContextMenu;
        private System.Windows.Forms.ToolStripMenuItem autostartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitGifshotToolStripMenuItem;
        private System.Windows.Forms.Button func_saveImageBtn;
        private System.Windows.Forms.Button func_copyToClipBoardBtn;
    }
}

