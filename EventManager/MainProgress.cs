using System;
using System.IO;
using System.Configuration;

namespace EventManager
{
    class MainProgress
    {
        static void ReadWithEF()
        {
            var appSetting = ConfigurationManager.AppSettings["dataDir"];
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(baseDir, appSetting);
            var fullPath = Path.GetFullPath(path);
            AppDomain.CurrentDomain.SetData("DataDirectory", fullPath);
        }

        static void Main()
        {
            Menu menu = new Menu();
            menu.Main();
        }
    }
}
