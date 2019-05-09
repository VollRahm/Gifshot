using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImgurSharp;
using Gifshot.Forms;

namespace Gifshot.Forms
{
    public partial class OverlayForm : Form
    {
        Graphics formG;

        public Bitmap screenshot; //passed in screenshot

        public OverlayForm(Bitmap _screenshot)
        {
            InitializeComponent();
            screenshot = _screenshot;
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

        private void OverlayForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                formG = this.CreateGraphics();
                isMouseDown = true; //set bool true if mouse holding
                upperleftSelection = e.Location; //sets start location
                
            }
        }



        private void OverlayForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
                //todo show form
            }
        }

        private bool isMouseDown = false; //bool to tell if user is holding the mouse
        Point upperleftSelection;
        Pen pen = new Pen(Color.Red, 3);

        Point lastPosition = new Point(0, 0);
        Rectangle selectionRect;

        private void OverlayForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && e.Location != lastPosition) //check if user is holding mouse and moved it
            {
                selectionRect = new Rectangle(upperleftSelection, new Size(e.X - upperleftSelection.X, e.Y - upperleftSelection.Y));
                this.Refresh(); //delete old rectangle
                formG.DrawRectangle(pen, selectionRect); // draw new one form start point to current location
                lastPosition = e.Location; //sets the same location to check next time
            }
        }

        public Bitmap CropImage(Bitmap source, Rectangle section) //image crop method from https://stackoverflow.com/questions/9484935/how-to-cut-a-part-of-image-in-c-sharp
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

      

        
    }
}
