using Icarus.Logic.Game;
using Icarus.Logic.Hooks;
using System;
using System.Windows.Forms;

namespace Icarus
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (var globalHook = new GlobalHook())
            using (var processMgr = new ProcessManager())
            using (var cameraMgr = new CameraManager(globalHook, processMgr))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main(processMgr, cameraMgr));
            }
        }
    }
}