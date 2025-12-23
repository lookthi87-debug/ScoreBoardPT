using System;
using System.Collections.Generic;

namespace Scoreboard.Config
{
    /// <summary>
    /// Lớp cấu hình cho các hằng số trạng thái trận đấu
    /// </summary>
    public static class MatchStatusConfig
    {
        /// <summary>
        /// Hằng số trạng thái trận đấu
        /// </summary>
        public static class Status
        {
            public const string NotStarted = "0";    // Chưa diễn ra
            public const string InProgress = "1";    // Đang diễn ra
            public const string Finished = "2";      // Đã kết thúc
        }

        /// <summary>
        /// Mô tả trạng thái trận đấu bằng tiếng Việt
        /// </summary>
        public static class StatusText
        {
            public const string NotStarted = "Chưa diễn ra";
            public const string InProgress = "Đang diễn ra";
            public const string Finished = "Đã kết thúc";
        }

        /// <summary>
        /// Từ điển ánh xạ mã trạng thái sang văn bản tiếng Việt
        /// </summary>
        public static readonly Dictionary<string, string> StatusTextMap = new Dictionary<string, string>
        {
            { Status.NotStarted, StatusText.NotStarted },
            { Status.InProgress, StatusText.InProgress },
            { Status.Finished, StatusText.Finished }
        };

        /// <summary>
        /// Lấy văn bản trạng thái theo mã trạng thái
        /// </summary>
        /// <param name="statusCode">Mã trạng thái (0, 1, 2)</param>
        /// <returns>Văn bản trạng thái tiếng Việt</returns>
        public static string GetStatusText(string statusCode)
        {
            return StatusTextMap.TryGetValue(statusCode ?? "0", out string text) ? text : "Không xác định";
        }

        /// <summary>
        /// Lấy văn bản trạng thái theo đối tượng trạng thái với xử lý null
        /// </summary>
        /// <param name="statusObj">Đối tượng trạng thái (có thể null)</param>
        /// <returns>Văn bản trạng thái tiếng Việt</returns>
        public static string GetStatusText(object statusObj)
        {
            var status = statusObj?.ToString() ?? Status.NotStarted;
            return GetStatusText(status);
        }

        /// <summary>
        /// Kiểm tra xem trạng thái có hợp lệ không
        /// </summary>
        /// <param name="statusCode">Mã trạng thái cần kiểm tra</param>
        /// <returns>True nếu là mã trạng thái hợp lệ</returns>
        public static bool IsValidStatus(string statusCode)
        {
            return StatusTextMap.ContainsKey(statusCode ?? "0");
        }

        /// <summary>
        /// Lấy tất cả các mã trạng thái có sẵn
        /// </summary>
        /// <returns>Mảng các mã trạng thái</returns>
        public static string[] GetAllStatusCodes()
        {
            return new string[] { Status.NotStarted, Status.InProgress, Status.Finished };
        }

        /// <summary>
        /// Lấy tất cả các tùy chọn trạng thái cho ComboBox
        /// </summary>
        /// <returns>Mảng các đối tượng ẩn danh với thuộc tính Text và Value</returns>
        public static object[] GetStatusOptions()
        {
            return new object[]
            {
                new { Text = StatusText.NotStarted, Value = Status.NotStarted },
                new { Text = StatusText.InProgress, Value = Status.InProgress },
                new { Text = StatusText.Finished, Value = Status.Finished }
            };
        }

        /// <summary>
        /// Kiểm tra xem trận đấu có đang hoạt động (đang diễn ra) không
        /// </summary>
        /// <param name="statusCode">Mã trạng thái cần kiểm tra</param>
        /// <returns>True nếu trận đấu đang hoạt động</returns>
        public static bool IsActive(string statusCode)
        {
            return statusCode == Status.InProgress;
        }

        /// <summary>
        /// Kiểm tra xem trận đấu đã kết thúc chưa
        /// </summary>
        /// <param name="statusCode">Mã trạng thái cần kiểm tra</param>
        /// <returns>True nếu trận đấu đã kết thúc</returns>
        public static bool IsFinished(string statusCode)
        {
            return statusCode == Status.Finished;
        }

        /// <summary>
        /// Kiểm tra xem trận đấu chưa bắt đầu chưa
        /// </summary>
        /// <param name="statusCode">Mã trạng thái cần kiểm tra</param>
        /// <returns>True nếu trận đấu chưa bắt đầu</returns>
        public static bool IsNotStarted(string statusCode)
        {
            return statusCode == Status.NotStarted;
        }
    }
}
