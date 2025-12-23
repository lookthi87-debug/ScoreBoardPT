using System;

namespace Scoreboard.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}