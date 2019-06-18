using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gifshot
{
    public class Config
    {
        private string NOTE = "Please don't change anything inside here. If you did and the program breaks, delete this file.";
        public Keys hotkey = Keys.PrintScreen; //the hotkey to make a screenshot
        
        public void Save()
        {
            string jsonConfig = JsonConvert.SerializeObject(this);
            using (StreamWriter writer = new StreamWriter(Variables.ConfigFilepath))//open config.json
            {
                writer.Write(jsonConfig); //store config
            }
        }
    }
}
