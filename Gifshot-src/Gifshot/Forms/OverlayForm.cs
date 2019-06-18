using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gifshot.Forms;

namespace Gifshot.Forms
{
    public partial class OverlayForm : Form
    {
        //Graphics formG;

        public Bitmap screenshot; //passed in screenshot
        public Image darkenedScreenshot;

        public OverlayForm(Bitmap _screenshot)
        {
            InitializeComponent();
            screenshot = _screenshot;
            this.BackgroundImage = darkenedScreenshot;
          /*  this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);*/

        }

        private void OverlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                MainForm.inst.DisableAllOverlays();
            }
            if(e.Alt)
            {
                MainForm.inst.DisableAllOverlays();
            }

            if (selectionRect != Rectangle.Empty && isMouseDown == false)
            {
                if (e.KeyCode == Keys.C && e.Control)
                {
                    MainForm.inst.Func_copyToClipBoardBtn_Click(this, null);
                }
                if (e.KeyCode == Keys.S && e.Control)
                {
                    MainForm.inst.Func_saveImageBtn_Click(this, null);
                }
            }
        }


        private void OverlayForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                MainForm.inst.Hide();
                isMouseDown = true; //set bool true if mouse holding
                upperleftSelection = e.Location; //sets start location
                selectionRect = Rectangle.Empty;
                GlobalVariables.isMakingScreenshot = this;
               
            }
        }



        private void OverlayForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && GlobalVariables.isMakingScreenshot == this)
            {
                this.TopMost = false;
                isMouseDown = false;
                if (selectionRect.Width < 1) selectionRect.Width = 1;
                if (selectionRect.Height < 1) selectionRect.Height = 1;
                Bitmap croppedScreen = CropImage(screenshot, selectionRect);
                MainForm.inst.currentScreenshot = croppedScreen;
                MainForm.inst.Location = new Point(Cursor.Position.X - 300, Cursor.Position.Y - 30);
                MainForm.inst.Show();
                MainForm.inst.Focus();
            }
        }

        private bool isMouseDown = false; //bool to tell if user is holding the mouse
        Point upperleftSelection;
        Pen pen = new Pen(Color.Red, 3);

        Point lastPosition = new Point(0, 0);
        Rectangle selectionRect = Rectangle.Empty;

        private void OverlayForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && e.Location != lastPosition) //check if user is holding mouse and moved it
            {
                
                
                selectionRect = new Rectangle(upperleftSelection.X, upperleftSelection.Y, e.X - upperleftSelection.X, e.Y - upperleftSelection.Y);
                if(selectionRect.Width < 0 && selectionRect.Height < 0)
                {
                    selectionRect = new Rectangle(e.X, e.Y, upperleftSelection.X - e.X, upperleftSelection.Y - e.Y);
                }else if(selectionRect.Width < 0)
                {
                    selectionRect = new Rectangle(e.X, upperleftSelection.Y, upperleftSelection.X - e.X, e.Y - upperleftSelection.Y);
                }else if(selectionRect.Height < 0){
                    selectionRect = new Rectangle(upperleftSelection.X, e.Y, e.X - upperleftSelection.X, upperleftSelection.Y - e.Y);
                }

                
                this.Refresh(); //delete old rectangle
                lastPosition = e.Location; //sets the same location to check next time
               
                selectAreaInfo.Show(selectionRect.Width + "x" + selectionRect.Height+ " px", this, new Point(Cursor.Position.X, Cursor.Position.Y + 17));
            }
            if (!isMouseDown && selectionRect == Rectangle.Empty && GlobalVariables.isMakingScreenshot == null)
            {
                selectAreaInfo.Show("Please select your area by dragging", this, new Point(Cursor.Position.X, Cursor.Position.Y + 17));
                this.Focus();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.  
            if (isMouseDown && Cursor.Position != lastPosition) //check if user is holding mouse and moved it
            {
                e.Graphics.DrawImage(CropImage(screenshot, selectionRect), selectionRect.Location);
                e.Graphics.DrawRectangle(pen, selectionRect); // draw new one form start point to current location
            }
        }

        public Bitmap CropImage(Bitmap source, Rectangle section) //image crop method from https://stackoverflow.com/questions/9484935/how-to-cut-a-part-of-image-in-c-sharp
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width +1 , section.Height +1);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        private Bitmap DarkenImage(Bitmap originalImage, float contrast)
        {
            Bitmap adjustedImage = new Bitmap(originalImage.Width, originalImage.Height);
            float brightness = 1.0f;

            float gamma = 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;

            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
        new float[] {contrast, 0, 0, 0, 0}, // scale red
        new float[] {0, contrast, 0, 0, 0}, // scale green
        new float[] {0, 0, contrast, 0, 0}, // scale blue
        new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
        new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            using (Graphics g = Graphics.FromImage(adjustedImage))
            {
                g.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                    , 0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel, imageAttributes);
            }
            return adjustedImage;
        }


    }
}
