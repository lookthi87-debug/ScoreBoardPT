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
            
            // Kiểm tra và tự động chuyển trạng thái trận đấu khi khởi động app
            CheckAndUpdateMatchStatus();
            
            Application.Run(new LoginForm());
        }
        /// <summary>
        /// Kiểm tra và tự động chuyển trạng thái trận đấu khi khởi động app
        /// </summary>
        static void CheckAndUpdateMatchStatus()
        {
            try
            {
                // Gọi function từ Repository để kiểm tra và cập nhật trạng thái trận đấu
                Repository.AutoEndMatchesAfterTimeout();
            }
            catch (Exception ex)
            {
                // Log lỗi nhưng không làm crash app
                System.Diagnostics.Debug.WriteLine($"Lỗi khi kiểm tra trạng thái trận đấu: {ex.Message}");
            }
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
