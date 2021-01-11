using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FIFA_Utils_Lib
{
    public static class Paths
    {
        public static string DEFAULT_GAMEPATH = @"C:\Program Files (x86)\Origin Games\FIFA 21";
        public static string CONFIG_PATH = Path.Combine(Environment.CurrentDirectory, "config.json");
    }
}
