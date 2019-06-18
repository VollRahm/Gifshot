using Gifshot.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gifshot
{
    public static class Variables
    {
        public static string ConfigFilepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gifshot\\config.json"); 

        public static List<OverlayForm> runningOverlayForms = new List<OverlayForm>();

    }
}
