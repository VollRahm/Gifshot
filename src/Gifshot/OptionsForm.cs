using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gifshot
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            HideFormOnStartup();
            InitializeComponent();
        }

        private void HideFormOnStartup()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(-100000, -100000); //changing position to not flash on the screen at startup
            this.ShowInTaskbar = false;
        }

        private void OptionsForm_Shown(object sender, EventArgs e)
        {
            this.Hide(); //this.Hide() only works after OptionsForm_Shown()
            this.Visible = false;   //instantly hide the form after its shown
        }
    }
}
