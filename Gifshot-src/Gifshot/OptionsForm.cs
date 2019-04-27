using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gifshot
{
    public partial class OptionsForm : Form
    {
        public bool firstStartup;

        public OptionsForm()
        {
            HideFormOnStartup();
            InitializeComponent();
            LoadConfigFile();
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

            await Task.Delay(2000); //wait until Form is hidden
            this.Location = new Point(
                new Random().Next(Screen.PrimaryScreen.Bounds.Left + 100, Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.Bounds.Width / 2),
                new Random().Next(Screen.PrimaryScreen.Bounds.Top + 100, Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.Bounds.Height / 2));  //reset location to random point on 
        }

        #endregion

        #region Notification Context Menu Handlers

        private void exitGifshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //self explanatory
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //to-do: Add the "Make Screenshot" Method
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.Show();
        }

        private void autostartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //to-do: Add the Autostart switcher
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

                        if (currentLine.Contains("autostart="))// if its the autostart line
                        {
                            Config.isAutostart = int.Parse(currentLine.Split('=')[1]) == 1; //read the number after 1 and convert it to bool
                            autostartToolStripMenuItem.Checked = Config.isAutostart;
                        }

                        else if (currentLine.Contains("hotkey="))// if its the hotkey line
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
            }
        }
    }
}
