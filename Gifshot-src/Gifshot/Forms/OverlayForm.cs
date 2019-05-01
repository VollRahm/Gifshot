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
    public partial class OverlayForm : Form
    {
        public OverlayForm()
        {
            InitializeComponent();
        }

        private void OverlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                DisableAllOverlays();
            }
            if(e.Alt)
            {
                DisableAllOverlays();
            }
        }

        private void DisableAllOverlays()
        {
            foreach (OverlayForm form in Variables.runningOverlayForms)
            {
                if (form == this) continue; //skip if its the current one
                form.Hide();
                form.Dispose();
            }
            Variables.runningOverlayForms.Clear();
            this.Hide();
            this.Dispose();
        }
    }
}
