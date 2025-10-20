using System;
using System.Collections.Generic;

namespace Scoreboard.Config
{
    /// <summary>
    /// Configuration class for match status constants
    /// </summary>
    public static class MatchStatusConfig
    {
        /// <summary>
        /// Match status constants
        /// </summary>
        public static class Status
        {
            public const string NotStarted = "0";    // Chưa diễn ra
            public const string InProgress = "1";    // Đang diễn ra
            public const string Finished = "2";      // Đã kết thúc
        }

        /// <summary>
        /// Match status descriptions in Vietnamese
        /// </summary>
        public static class StatusText
        {
            public const string NotStarted = "Chưa diễn ra";
            public const string InProgress = "Đang diễn ra";
            public const string Finished = "Đã kết thúc";
        }

        /// <summary>
        /// Dictionary mapping status codes to Vietnamese text
        /// </summary>
        public static readonly Dictionary<string, string> StatusTextMap = new Dictionary<string, string>
        {
            { Status.NotStarted, StatusText.NotStarted },
            { Status.InProgress, StatusText.InProgress },
            { Status.Finished, StatusText.Finished }
        };

        /// <summary>
        /// Get status text by status code
        /// </summary>
        /// <param name="statusCode">Status code (0, 1, 2)</param>
        /// <returns>Vietnamese status text</returns>
        public static string GetStatusText(string statusCode)
        {
            return StatusTextMap.TryGetValue(statusCode ?? "0", out string text) ? text : "Không xác định";
        }

        /// <summary>
        /// Get status text by status code with null handling
        /// </summary>
        /// <param name="statusObj">Status object (can be null)</param>
        /// <returns>Vietnamese status text</returns>
        public static string GetStatusText(object statusObj)
        {
            var status = statusObj?.ToString() ?? Status.NotStarted;
            return GetStatusText(status);
        }

        /// <summary>
        /// Check if status is valid
        /// </summary>
        /// <param name="statusCode">Status code to check</param>
        /// <returns>True if valid status code</returns>
        public static bool IsValidStatus(string statusCode)
        {
            return StatusTextMap.ContainsKey(statusCode ?? "0");
        }

        /// <summary>
        /// Get all available status codes
        /// </summary>
        /// <returns>Array of status codes</returns>
        public static string[] GetAllStatusCodes()
        {
            return new string[] { Status.NotStarted, Status.InProgress, Status.Finished };
        }

        /// <summary>
        /// Get all status options for ComboBox
        /// </summary>
        /// <returns>Array of anonymous objects with Text and Value properties</returns>
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
        /// Check if match is active (in progress)
        /// </summary>
        /// <param name="statusCode">Status code to check</param>
        /// <returns>True if match is active</returns>
        public static bool IsActive(string statusCode)
        {
            return statusCode == Status.InProgress;
        }

        /// <summary>
        /// Check if match is finished
        /// </summary>
        /// <param name="statusCode">Status code to check</param>
        /// <returns>True if match is finished</returns>
        public static bool IsFinished(string statusCode)
        {
            return statusCode == Status.Finished;
        }

        /// <summary>
        /// Check if match is not started
        /// </summary>
        /// <param name="statusCode">Status code to check</param>
        /// <returns>True if match is not started</returns>
        public static bool IsNotStarted(string statusCode)
        {
            return statusCode == Status.NotStarted;
        }
    }
}
