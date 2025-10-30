using System;
using System.Windows.Forms;
using Scoreboard.Data;

namespace Scoreboard
{
    static class Program
    {
        public static int CurrentUserId = 0;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += OnApplicationExit;
            Application.Run(new MainMDIForm());
        }
        static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUserId > 0)
                {
                    Repository.ClearUserActivity(CurrentUserId);
                }
            }
            catch
            {
            }
        }
    }
}
