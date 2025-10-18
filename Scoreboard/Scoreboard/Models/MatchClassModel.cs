using System;

namespace Scoreboard.Models
{
    public class MatchClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PeriodType { get; set; } // Cách gọi mỗi phần của trận đấu: Half (hiệp), Quarter (hiệp nhỏ), Set (ván)
        public int StandardPeriods { get; set; } // Số lượng hiệp/set tiêu chuẩn trong 1 trận: 2 (bóng đá), 5 (bóng chuyền)
        public int PeriodsToWin { get; set; } // Số hiệp/set cần thắng để kết thúc trận: 2 (bóng đá), 3 (bóng chuyền)
        public bool AllowOvertime { get; set; } // Có cho phép hiệp phụ hay không: true cho bóng đá, false cho bóng chuyền
        public int MaxOvertimePeriods { get; set; } // Số hiệp phụ tối đa cho phép: 2 với bóng đá, 0 nếu không có
        public bool AllowTie { get; set; } // Có cho phép hòa không: true nếu có thể hòa, false nếu phải có thắng thua
        public DateTime CreatedAt { get; set; } // Ngày tạo bản ghi
        public DateTime UpdatedAt { get; set; } // Ngày cập nhật gần nhất
    }
}