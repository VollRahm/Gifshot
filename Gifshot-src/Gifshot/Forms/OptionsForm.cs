using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MouseKeyboardLibrary;


namespace Gifshot
{
    public partial class OptionsForm : Form
    {
        public bool firstStartup;
        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        SettingsForm settingsFrm = new SettingsForm();

        KeyboardHook keyboardHook = new KeyboardHook();

        public OptionsForm()
        {
            HideFormOnStartup();
            InitializeComponent();
            LoadConfigFile();
        }

        private void SetupKBHook()
        {
            keyboardHook.KeyUp += new KeyEventHandler(KeyPressedGlobally);
            keyboardHook.Start();
        }


        #region Form Hiders

        private void HideFormOnStartup()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(-100000, -100000); //changing position to something far away so it  doesn't flash on the screen at startup
            this.ShowInTaskbar = false;
          
        }

        private async void OptionsForm_Shown(object sender, EventArgs e)
        {
            this.Hide(); //this.Hide() only works after OptionsForm_Shown()
            this.Visible = false;   //instantly hide the form after its shown
            if(firstStartup)//only show notification if its the first startup
            notifIcon.ShowBalloonTip(1500, "Gifshot", "Gifshot running. Click the icon to set Autostart", ToolTipIcon.Info); //show notification

            #region Check Autostart Status

            if (rk.GetValue(this.Text) == null)
            {
                Config.isAutostart = false; //if theres no value theres no autostart
                autostartToolStripMenuItem.Checked = Config.isAutostart;
            }
            else
            {
                Config.isAutostart = true;
                autostartToolStripMenuItem.Checked = Config.isAutostart;
            }
            
            #endregion //This needs to go here otherwise Windows Defender randomly throws an error

            await Task.Delay(500); //wait until Form is hidden
            this.Location = new Point(
                new Random().Next(Screen.PrimaryScreen.Bounds.Left + 100, Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.Bounds.Width / 2),
                new Random().Next(Screen.PrimaryScreen.Bounds.Top + 100, Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.Bounds.Height / 2));  //reset location to random point on 
            SetupKBHook(); //Start Keyboard hook after windows is initialized
            
        }

        #endregion

        #region Notification Context Menu Handlers

        private void exitGifshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //self explanatory
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsFrm.Show();
        }

        private void autostartToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if(!autostartToolStripMenuItem.Checked && Config.isAutostart)
            {
                   rk.DeleteValue(this.Text); //delete Key if autostart is enabled and it was disabled
            }
            else
            {
                    rk.SetValue(this.Text, Application.ExecutablePath); //add autostart
            }
        }

        #endregion

        private void LoadConfigFile()
        {
            if (File.Exists(Variables.ConfigFilepath)) //check if config file exists
            {
                firstStartup = false;

                using (StreamReader reader = new StreamReader(Variables.ConfigFilepath)) //read config
                {
                    while (!reader.EndOfStream) //read every line
                    {
                        string currentLine = reader.ReadLine(); // get one line of the config
                        if (currentLine[0] == '#') continue; //skip line if the first character is '#' (commented)


                        if (currentLine.Contains("hotkey="))// if its the hotkey line
                        {
                            Config.hotkey = (Keys)int.Parse(currentLine.Split('=')[1]); //Parse the number and cast it to a WinForms Key
                        }
                    }
                }
                
               
            }
            else
            {
                firstStartup = true; //no config = first startup

                using (StreamWriter writer = new StreamWriter(Variables.ConfigFilepath))//create new config
                {
                    writer.WriteLine(Variables.standardConfigFile); //write new config
                }

                    rk.SetValue(this.Text, Application.ExecutablePath); //set autostart on first startup
                
            }
        }

        private void KeyPressedGlobally(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Config.hotkey)
            {
                ShowOverlaysOnScreens();
            }
        }

        private void ShowOverlaysOnScreens()
        {
            List<OverlayForm> overlayForms = new List<OverlayForm>(); //Create a Dictionary for multiple monitors with monitor name
            List<Image> screenshots = new List<Image>(); //Dictionary for the images on the screens

            int screenIndex = 0;
            foreach(Screen screen in Screen.AllScreens)
            {
                overlayForms.Add(new OverlayForm()); //create new form for screen
                Variables.runningOverlayForms.Add(overlayForms[screenIndex]); //add form to global list
                overlayForms[screenIndex].StartPosition = FormStartPosition.Manual;
                overlayForms[screenIndex].SetBounds(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height); //set the form to screen position
                screenshots.Add(TakeScreenshot(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height, 0.62f)); //take screenshot of current screen, decrease contrast
                overlayForms[screenIndex].BackgroundImage = screenshots[screenIndex]; //set it to the right form
                overlayForms[screenIndex].BackgroundImageLayout = ImageLayout.Zoom;
                overlayForms[screenIndex].Show();  // show the form
                screenIndex++; //next *clap* screen *clap*
            }
        }

        private Image TakeScreenshot(int x, int y, int width, int height, float contrast = 1f)
        {
            Bitmap screenshot = new Bitmap(width, height, PixelFormat.Format32bppArgb); // create the Bitmap
            Graphics g = Graphics.FromImage(screenshot); //take bitmap

            g.CopyFromScreen(x, y,0,0, new Size(width, height), CopyPixelOperation.SourceCopy); //make screenshot of region

            return DarkenImage(screenshot, contrast);
            
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
            Graphics g = Graphics.FromImage(adjustedImage);
            g.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                , 0, 0, originalImage.Width, originalImage.Height,
                GraphicsUnit.Pixel, imageAttributes);
            return adjustedImage;
        }



    }
}
