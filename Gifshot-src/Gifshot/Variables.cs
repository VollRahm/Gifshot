using Gifshot.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gifshot
{
    public static class Variables
    {
        public const string ConfigFilepath = "gifshot.conf";

        public static List<OverlayForm> runningOverlayForms = new List<OverlayForm>();

        public static string standardConfigFile =
            "#Please don't change anything inside here, it could break the program." + Environment.NewLine+
            $"hotkey={((int)Config.hotkey).ToString()}";
    }
}
