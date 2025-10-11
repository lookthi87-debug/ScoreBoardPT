using System;
using System.Windows.Forms;
using MaterialSkin;
using Scoreboard.Utilities;

namespace Scoreboard
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Initialize database with default admin account if needed
            DatabaseInitializer.InitializeDatabase();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Initialize MaterialSkinManager
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, 
                Primary.BlueGrey900, 
                Primary.BlueGrey500, 
                Accent.LightBlue200, 
                TextShade.WHITE
            );
            
            Application.Run(new LoginForm());
        }
    }
}