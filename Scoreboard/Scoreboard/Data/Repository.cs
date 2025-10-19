using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2010.Excel;
using Npgsql;
using Scoreboard.Data;
using Scoreboard.Models;


namespace Scoreboard.Data
{
    public static class Repository
    {
        private static NpgsqlConnection Conn => PostgresHelper.SharedConn;

        // ====================================================
        // ROLES
        // ====================================================
        public static List<RoleModel> GetAllRoles()
        {
            var list = new List<RoleModel>();
            using (var cmd = new NpgsqlCommand("SELECT id, name FROM Roles ORDER BY id", Conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(new RoleModel { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }
            return list;
        }

        public static RoleModel GetRoleById(int id)
        {
            using (var cmd = new NpgsqlCommand("SELECT id, name FROM Roles WHERE id=@id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read())
                        return new RoleModel { Id = reader.GetInt32(0), Name = reader.GetString(1) };
            }
            return null;
        }

        public static void AddRole(string name)
        {
            using (var cmd = new NpgsqlCommand("INSERT INTO Roles(name) VALUES(@n)", Conn))
            {
                cmd.Parameters.AddWithValue("@n", name);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateRole(RoleModel r)
        {
            using (var cmd = new NpgsqlCommand("UPDATE Roles SET name=@n WHERE id=@id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", r.Id);
                cmd.Parameters.AddWithValue("@n", r.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteRole(int id)
        {
            using (var cmd = new NpgsqlCommand("DELETE FROM Roles WHERE id=@id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // ====================================================
        // USERS
        // ====================================================
        public static List<UserModel> GetAllUsers()
        {
            var list = new List<UserModel>();
            using (var cmd = new NpgsqlCommand(@"
                SELECT u.id, u.name, u.password, u.role_id, u.fullname, u.phone, u.email, r.name AS role_name
                FROM Users u
                LEFT JOIN Roles r ON u.role_id = r.id
                WHERE u.isactive='1'
                ORDER BY u.id", Conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    list.Add(new UserModel
                    {
                        Id = dr.GetInt32(0),
                        Name = dr.GetString(1),
                        Password = dr.GetString(2),
                        RoleId = dr.IsDBNull(3) ? (int?)null : dr.GetInt32(3),
                        Fullname = dr.IsDBNull(4) ? null : dr.GetString(4),
                        Phone = dr.IsDBNull(5) ? null : dr.GetString(5),
                        Email = dr.IsDBNull(6) ? null : dr.GetString(6),
                        RoleName = dr.IsDBNull(7) ? null : dr.GetString(7)
                    });
                }
            }
            return list;
        }

        public static List<UserModel> SearchUser(string search)
        {
            // If no search term provided, return all users (preserves previous behavior)
            if (string.IsNullOrWhiteSpace(search))
                return GetAllUsers();

            var list = new List<UserModel>();
            string sql = @"
                    SELECT u.id, u.name, u.password, u.role_id, u.fullname, u.phone, u.email, r.name AS role_name
                    FROM Users u
                    LEFT JOIN Roles r ON u.role_id = r.id
                    WHERE u.isactive='1'
                      AND (
                            u.name     ILIKE @q OR
                            COALESCE(u.email, '')    ILIKE @q OR
                            COALESCE(u.phone, '')    ILIKE @q OR
                            COALESCE(u.fullname, '') ILIKE @q
                          )
                    ORDER BY u.id";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@q", "%" + search.Trim() + "%");

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new UserModel
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Password = dr.GetString(2),
                            RoleId = dr.IsDBNull(3) ? (int?)null : dr.GetInt32(3),
                            Fullname = dr.IsDBNull(4) ? null : dr.GetString(4),
                            Phone = dr.IsDBNull(5) ? null : dr.GetString(5),
                            Email = dr.IsDBNull(6) ? null : dr.GetString(6),
                            RoleName = dr.IsDBNull(7) ? null : dr.GetString(7)
                        });
                    }
                }
            }
            return list;
        }
        public static UserModel GetUserById(int id)
        {
            using (var cmd = new NpgsqlCommand(@"
                SELECT id, name, password, role_id, fullname, phone, email
                FROM Users WHERE id=@id and isactive='1'", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new UserModel
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Password = dr.GetString(2),
                            RoleId = dr.IsDBNull(3) ? (int?)null : dr.GetInt32(3),
                            Fullname = dr.IsDBNull(4) ? null : dr.GetString(4),
                            Phone = dr.IsDBNull(5) ? null : dr.GetString(5),
                            Email = dr.IsDBNull(6) ? null : dr.GetString(6)
                        };
                    }
                }
            }
            return null;
        }
        public static UserModel GetUserByName(string username)
        {
            using (var cmd = new NpgsqlCommand(@"
                SELECT id, name, password, role_id, fullname, phone, email
                FROM Users WHERE name=@u AND isactive='1'", Conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new UserModel
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Password = dr.GetString(2),
                            RoleId = dr.IsDBNull(3) ? (int?)null : dr.GetInt32(3),
                            Fullname = dr.IsDBNull(4) ? null : dr.GetString(4),
                            Phone = dr.IsDBNull(5) ? null : dr.GetString(5),
                            Email = dr.IsDBNull(6) ? null : dr.GetString(6)
                        };
                    }
                }
            }
            return null;
        }
        public static void AddUser(UserModel u)
        {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO Users (name, password, role_id, fullname, phone, email, isactive)
                VALUES (@n, @p, @r, @f, @ph, @e, '1')", Conn))
            {
                cmd.Parameters.AddWithValue("@n", u.Name);
                cmd.Parameters.AddWithValue("@p", u.Password);
                if (u.RoleId.HasValue)
                    cmd.Parameters.AddWithValue("@r", u.RoleId.Value);
                else
                    cmd.Parameters.AddWithValue("@r", DBNull.Value);

                cmd.Parameters.AddWithValue("@f", (object)u.Fullname ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ph", (object)u.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)u.Email ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateUser(UserModel u)
        {
            using (var cmd = new NpgsqlCommand(@"
                UPDATE Users
                   SET name=@n, password=@p, role_id=@r, fullname=@f, phone=@ph, email=@e
                 WHERE id=@id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", u.Id);
                cmd.Parameters.AddWithValue("@n", u.Name);
                cmd.Parameters.AddWithValue("@p", u.Password);
                if (u.RoleId.HasValue)
                    cmd.Parameters.AddWithValue("@r", u.RoleId.Value);
                else
                    cmd.Parameters.AddWithValue("@r", DBNull.Value);

                cmd.Parameters.AddWithValue("@f", (object)u.Fullname ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ph", (object)u.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)u.Email ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteUser(int id)
        {
            using (var cmd = new NpgsqlCommand(@"
                UPDATE Users
                   SET isactive='0'
                 WHERE id=@id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public static void AddDefaultUser()
        {
            string countSql = "SELECT COUNT(*) FROM Users;";
            using (var cmdCount = new NpgsqlCommand(countSql, Conn))
            {
                int userCount = Convert.ToInt32(cmdCount.ExecuteScalar());

                if (userCount == 0)
                {
                    // Nếu chưa có user, tạo tài khoản mặc định admin / Abc12345
                    string insertSql = @"
                        INSERT INTO Users (name, password, role_id, fullname, phone, email, isActive)
                        VALUES ('Admin', @p, 1, 'Administrator', '', '', '1');";

                    using (var cmdInsert = new NpgsqlCommand(insertSql, Conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@p", Security.HashPassword("Abc12345"));
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }
        // ====================================================
        // TOURNAMENTS
        // ====================================================
        public static List<TournamentModel> GetAllTournaments()
        {
            var list = new List<TournamentModel>();
            string sql = @"
                SELECT 
                    t.id, 
                    t.name, 
                    t.start, 
                    t.""end"", 
                    t.description, 
                    t.match_class_id, 
                    mcl.name AS match_class_name
                FROM Tournaments t
                LEFT JOIN MatchClass mcl ON t.match_class_id = mcl.id
                ORDER BY t.start DESC;
            ";
            using (var cmd = new NpgsqlCommand(sql, Conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new TournamentModel
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Start = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                        End = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                        Description = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        match_class_id = reader.GetInt32(5),
                        match_class_name = reader.IsDBNull(6) ? "" : reader.GetString(6)
                    });
                }
            }
            return list;
        }
        public static TournamentModel GetAllTournamentsById(int id)
        {
            using (var cmd = new NpgsqlCommand("SELECT t.id, t.name, t.start, t.\"end\", t.description, t.match_class_id, mcl.name as match_class_name" +
                " FROM Tournaments t " +
                " LEFT JOIN Matchclass mcl ON t.match_class_id = mcl.id" +
                " WHERE t.id = @id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TournamentModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Start = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                            End = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            Description = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            match_class_id = reader.GetInt32(5),
                            match_class_name = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }

        public static List<TournamentModel> GetAllTournamentsByClassId(int id)
        {
            var tournaments = new List<TournamentModel>();

            string query = "SELECT t.id, t.name, t.start, t.\"end\", t.description, t.match_class_id, mcl.name AS match_class_name " +
                           "FROM Tournaments t " +
                           "LEFT JOIN Matchclass mcl ON t.match_class_id = mcl.id ";

            // Nếu id > 0 thì lọc theo class_id
            if (id > 0)
                query += "WHERE t.match_class_id = @id";

            using (var cmd = new NpgsqlCommand(query, Conn))
            {
                if (id > 0)
                    cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tournaments.Add(new TournamentModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Start = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                            End = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            Description = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            match_class_id = reader.GetInt32(5),
                            match_class_name = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                }
            }

            return tournaments;
        }

        public static void AddTournament(TournamentModel t)
        {
            using (var cmd = new NpgsqlCommand(
                "INSERT INTO Tournaments(name,start,\"end\",description,match_class_id) VALUES(@n,@s,@e,@d,@ma)", Conn))
            {
                cmd.Parameters.AddWithValue("@n", t.Name);
                cmd.Parameters.AddWithValue("@s", t.Start.HasValue ? (object)t.Start.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@e", t.End.HasValue ? (object)t.End.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@d", t.Description ?? "");
                cmd.Parameters.AddWithValue("@ma", t.match_class_id);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateTournament(TournamentModel t)
        {
            using (var cmd = new NpgsqlCommand(@"
                UPDATE Tournaments
                   SET name = @n,
                       start = @s,
                       ""end"" = @e,
                       description = @d,
                       match_class_id = @ma
                 WHERE id = @id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.Parameters.AddWithValue("@n", t.Name);
                cmd.Parameters.AddWithValue("@s", t.Start.HasValue ? (object)t.Start.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@e", t.End.HasValue ? (object)t.End.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@d", (object)t.Description ?? "");
                cmd.Parameters.AddWithValue("@ma", t.match_class_id);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteTournament(int id)
        {
            try
            {
                //Kiểm tra có trận nào status != 0 hay không
                string checkSql = "SELECT COUNT(*) FROM Matches WHERE Tournament_Id = @id AND status <> 0";
                using (var checkCmd = new NpgsqlCommand(checkSql, Conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show(
                            "Không thể xóa giải đấu này vì có trận đang hoạt động hoặc đã kết thúc!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                        return;
                    }
                }

                // Nếu tất cả Matches đều status = 0, cho phép xóa Tournament
                string sql = "DELETE FROM Tournaments WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, Conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Đã xóa giải đấu (và toàn bộ trận đấu, hiệp đấu liên quan).",
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Không tìm thấy giải đấu để xóa!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa giải đấu:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ====================================================
        // MATCHES
        // ====================================================
        public static string GenerateMatchCode()
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"{today}";

            string sql = @"
                SELECT id 
                FROM Matches 
                WHERE id LIKE @prefix || '%'
                ORDER BY id DESC 
                LIMIT 1;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@prefix", prefix);

                var lastCodeObj = cmd.ExecuteScalar();
                int nextNumber = 1;

                if (lastCodeObj != null && lastCodeObj != DBNull.Value)
                {
                    string lastCode = lastCodeObj.ToString();
                    // Lấy 4 số cuối cùng
                    string numberPart = lastCode.Substring(lastCode.Length - 5);
                    if (int.TryParse(numberPart, out int num))
                    {
                        nextNumber = num + 1;
                    }
                }
                // Ghép lại thành mã mới,5 chữ số sau cùng
                string newCode = $"{prefix}-{nextNumber.ToString("D5")}";
                return newCode;
            }
        }
        public static List<MatchModel> GetMatchesByTournament(int tournamentId)
        {
            var list = new List<MatchModel>();
            string sql = @"
                SELECT 
                    m.id, m.team1, m.team2, m.score1, m.score2, m.start, m.""end"", 
                    m.time, m.referee_id, u.name AS referee_name, 
                    m.note, m.show_toggle, m.status, m.tournament_id, t.name AS tournament_name
                FROM Matches m
                LEFT JOIN Users u ON m.referee_id = u.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE m.tournament_id=@tid ORDER BY m.id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@tid", tournamentId);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var match = new MatchModel
                        {
                            Id = dr.GetString(0),
                            Team1 = dr.IsDBNull(1) ? null : dr.GetString(1),
                            Team2 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Score1 = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                            Score2 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            Start = dr.IsDBNull(5) ? (DateTime?)null : dr.GetDateTime(5),
                            End = dr.IsDBNull(6) ? (DateTime?)null : dr.GetDateTime(6),
                            Time = dr.IsDBNull(7) ? null : dr.GetString(7),
                            RefereeId = dr.IsDBNull(8) ? (int?)null : dr.GetInt32(8),
                            RefereeName = dr.IsDBNull(9) ? null : dr.GetString(9),
                            Note = dr.IsDBNull(10) ? null : dr.GetString(10),
                            ShowToggle = dr.IsDBNull(11) ? 0 : dr.GetInt32(11),
                            Status = dr.IsDBNull(12) ? null : dr.GetString(12),
                            TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14)
                        };

                        // Parse multiple referees from note field if exists
                        ParseMultipleRefereesFromNote(match);

                        list.Add(match);
                    }
                }
            }
            return list;
        }
        public static List<MatchModel> GetAllMatches()
        {
            var list = new List<MatchModel>();
            string sql = @"
                    SELECT 
                        m.id, m.team1, m.team2, m.score1, m.score2, m.start, m.""end"", 
                        m.time, m.referee_id, u.name AS referee_name, 
                        m.note, m.show_toggle, m.status, m.tournament_id, t.name as tournamentname, t.match_class_id,ms.name as matchclassname,
                        t.start as tournament_start, t.""end"" as tournament_end
                    FROM Matches m
                    LEFT JOIN Users u ON m.referee_id = u.id
                    LEFT JOIN Tournaments t ON m.tournament_id = t.id
                    LEFT JOIN MatchClass ms ON t.match_class_id = ms.id
                    ORDER BY m.id;
                ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var match = new MatchModel
                    {
                        Id = dr.GetString(0),
                        Team1 = dr.IsDBNull(1) ? null : dr.GetString(1),
                        Team2 = dr.IsDBNull(2) ? null : dr.GetString(2),
                        Score1 = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                        Score2 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                        Start = dr.IsDBNull(5) ? (DateTime?)null : dr.GetDateTime(5),
                        End = dr.IsDBNull(6) ? (DateTime?)null : dr.GetDateTime(6),
                        Time = dr.IsDBNull(7) ? null : dr.GetString(7),
                        RefereeId = dr.IsDBNull(8) ? (int?)null : dr.GetInt32(8),
                        RefereeName = dr.IsDBNull(9) ? null : dr.GetString(9),
                        Note = dr.IsDBNull(10) ? null : dr.GetString(10),
                        ShowToggle = dr.IsDBNull(11) ? 0 : dr.GetInt32(11),
                        Status = dr.IsDBNull(12) ? null : dr.GetString(12),
                        TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                        TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14),
                        MatchClassId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                        MatchClassName = dr.IsDBNull(16) ? null : dr.GetString(16),
                        TournamentStart = dr.IsDBNull(17) ? (DateTime?)null : dr.GetDateTime(17),
                        TournamentEnd = dr.IsDBNull(18) ? (DateTime?)null : dr.GetDateTime(18)
                    };

                    // Parse multiple referees from note field if exists
                    ParseMultipleRefereesFromNote(match);

                    list.Add(match);
                }
            }

            return list;
        }
        public static MatchModel GetMatchById(string id)
        {
            string sql = @"
                SELECT 
                    m.id, m.team1, m.team2, m.score1, m.score2, m.start, m.""end"", 
                    m.time, m.referee_id, u.name AS referee_name, 
                    m.note, m.show_toggle, m.status, m.tournament_id, t.name AS tournament_name, t.match_class_id,ms.name as matchclassname,
                    t.start as tournament_start, t.""end"" as tournament_end
                FROM Matches m
                LEFT JOIN Users u ON m.referee_id = u.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                LEFT JOIN MatchClass ms ON t.match_class_id = ms.id
                WHERE m.id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        var match = new MatchModel
                        {
                            Id = dr.GetString(0),
                            Team1 = dr.IsDBNull(1) ? null : dr.GetString(1),
                            Team2 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Score1 = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                            Score2 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            Start = dr.IsDBNull(5) ? (DateTime?)null : dr.GetDateTime(5),
                            End = dr.IsDBNull(6) ? (DateTime?)null : dr.GetDateTime(6),
                            Time = dr.IsDBNull(7) ? null : dr.GetString(7),
                            RefereeId = dr.IsDBNull(8) ? (int?)null : dr.GetInt32(8),
                            RefereeName = dr.IsDBNull(9) ? null : dr.GetString(9),
                            Note = dr.IsDBNull(10) ? null : dr.GetString(10),
                            ShowToggle = dr.IsDBNull(11) ? 0 : dr.GetInt32(11),
                            Status = dr.IsDBNull(12) ? null : dr.GetString(12),
                            TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14),
                            MatchClassId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                            MatchClassName = dr.IsDBNull(16) ? null : dr.GetString(16),
                            TournamentStart = dr.IsDBNull(17) ? (DateTime?)null : dr.GetDateTime(17),
                            TournamentEnd = dr.IsDBNull(18) ? (DateTime?)null : dr.GetDateTime(18)
                        };

                        // Parse multiple referees from note field if exists
                        ParseMultipleRefereesFromNote(match);

                        return match;
                    }
                }
            }

            return null;
        }

        // Helper method to parse multiple referees from note field
        private static void ParseMultipleRefereesFromNote(MatchModel match)
        {
            if (!string.IsNullOrEmpty(match.Note) && match.Note.Contains("[Referees:"))
            {
                try
                {
                    // Extract referee info from note field
                    int startIndex = match.Note.IndexOf("[Referees:");
                    int endIndex = match.Note.IndexOf("]", startIndex);

                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        string refereesInfo = match.Note.Substring(startIndex + 10, endIndex - startIndex - 10);
                        match.Note = match.Note.Substring(0, startIndex).Trim(); // Remove referee info from note

                        // Parse referee IDs and names
                        var parts = refereesInfo.Split('|');
                        foreach (var part in parts)
                        {
                            var idName = part.Split(':');
                            if (idName.Length == 2 && int.TryParse(idName[0], out int id))
                            {
                                match.RefereeIds.Add(id);
                                match.RefereeNames.Add(idName[1]);
                            }
                        }
                    }
                }
                catch
                {
                    // If parsing fails, keep the original data
                }
            }
            else if (match.RefereeId.HasValue)
            {
                // For backward compatibility, add the single referee
                match.RefereeIds.Add(match.RefereeId.Value);
                match.RefereeNames.Add(match.RefereeName ?? "");
            }
        }

        // Helper method to prepare note field with multiple referees
        private static string PrepareNoteWithReferees(MatchModel m)
        {
            string note = m.Note ?? "";

            if (m.RefereeIds != null && m.RefereeIds.Count > 0 && m.RefereeNames != null && m.RefereeNames.Count > 0)
            {
                // Add referee info to note field
                var refereePairs = new List<string>();
                for (int i = 0; i < m.RefereeIds.Count && i < m.RefereeNames.Count; i++)
                {
                    refereePairs.Add($"{m.RefereeIds[i]}:{m.RefereeNames[i]}");
                }
                string refereesInfo = "[Referees:" + string.Join("|", refereePairs) + "]";
                note = note + " " + refereesInfo;
            }

            return note.Trim();
        }

        public static void AddMatch(MatchModel m)
        {
            string sql = @"
                INSERT INTO Matches
                (id, team1, team2, score1, score2, start, ""end"", time, referee_id, note, show_toggle, status, tournament_id)
                VALUES
                (@id, @t1, @t2, @s1, @s2, @st, @et, @time, @rid, @note, @show, @stt, @tid);
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", m.Id);
                cmd.Parameters.AddWithValue("@t1", m.Team1 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@t2", m.Team2 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@s1", m.Score1);
                cmd.Parameters.AddWithValue("@s2", m.Score2);
                cmd.Parameters.AddWithValue("@st", m.Start.HasValue ? (object)m.Start.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@et", m.End.HasValue ? (object)m.End.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@time", m.Time ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rid", m.RefereeId.HasValue ? (object)m.RefereeId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@note", PrepareNoteWithReferees(m)); // Updated to include multiple referees
                cmd.Parameters.AddWithValue("@show", m.ShowToggle);
                cmd.Parameters.AddWithValue("@stt", m.Status ?? "0");
                cmd.Parameters.AddWithValue("@tid", m.TournamentId.HasValue ? (object)m.TournamentId.Value : DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatch(MatchModel m)
        {
            string sql = @"
                UPDATE Matches SET
                    team1 = @t1,
                    team2 = @t2,
                    score1 = @s1,
                    score2 = @s2,
                    start = @st,
                    ""end"" = @et,
                    time = @time,
                    referee_id = @rid,
                    note = @note,
                    show_toggle = @show,
                    status = @stt,
                    tournament_id = @tid
                WHERE id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", m.Id);
                cmd.Parameters.AddWithValue("@t1", m.Team1 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@t2", m.Team2 ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@s1", m.Score1);
                cmd.Parameters.AddWithValue("@s2", m.Score2);
                cmd.Parameters.AddWithValue("@st", m.Start.HasValue ? (object)m.Start.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@et", m.End.HasValue ? (object)m.End.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@time", m.Time ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rid", m.RefereeId.HasValue ? (object)m.RefereeId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@note", PrepareNoteWithReferees(m)); // Updated to include multiple referees
                cmd.Parameters.AddWithValue("@show", m.ShowToggle);
                cmd.Parameters.AddWithValue("@stt", m.Status ?? "0");
                cmd.Parameters.AddWithValue("@tid", m.TournamentId.HasValue ? (object)m.TournamentId.Value : DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchStatus(string id, string status)
        {
            string sql = @"
                UPDATE Matches 
                SET status = @st
                WHERE id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@st", status);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchScore1(string id, int score)
        {
            string sql = @"
                UPDATE Matches 
                SET score1 = @sc
                WHERE id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@sc", score);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchScore2(string id, int score)
        {
            string sql = @"
                UPDATE Matches 
                SET score2 = @sc
                WHERE id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@sc", score);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteMatch(string id)
        {
            using (var cmd1 = new NpgsqlCommand("DELETE FROM MatchSets WHERE match_id=@id", Conn))
            {
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.ExecuteNonQuery();
            }
            using (var cmd2 = new NpgsqlCommand("DELETE FROM Matches WHERE id=@id", Conn))
            {
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();
            }
        }
        // ====================================================
        // MATCHSETS
        // ====================================================
        public static List<MatchsetModel> GetActiveMatchSetsByUser(int userId)
        {
            var list = new List<MatchsetModel>();
            string sql = @"
                SELECT 
                    ms.id,
                    ms.match_id,
                    m.team1,
                    m.team2,
                    m.score1 AS total_score1,
                    m.score2 AS total_score2,
                    ms.time,
                    ms.note,
                    ms.status,
                    ms.referee_id,
                    u.name AS referee_name,
                    ms.ClassSets_id,
                    COALESCE(ms.ClassSetsName, cs.name) AS classsets_name,
                    m.tournament_id,
                    t.name AS tournament_name,
                    cs.Match_Class_Id AS MatchClassId,
                    mtl.name as MatchClassName
                FROM MatchSets ms
                INNER JOIN Matches m ON ms.match_id = m.id
                LEFT JOIN Users u ON ms.referee_id = u.id
                LEFT JOIN ClassSets cs ON ms.ClassSets_id = cs.id
                LEFT JOIN MatchClass mtl ON cs.Match_Class_Id = mtl.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE ms.status = '1'
                  AND ms.referee_id = @uid
                ORDER BY m.id, ms.id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@uid", userId);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new MatchsetModel
                        {
                            Id = dr.GetInt32(0),
                            MatchId = dr.GetString(1),
                            Team1 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Team2 = dr.IsDBNull(3) ? null : dr.GetString(3),
                            TotalScore1 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            TotalScore2 = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                            Time = dr.IsDBNull(6) ? null : dr.GetString(6),
                            Note = dr.IsDBNull(7) ? null : dr.GetString(7),
                            Status = dr.IsDBNull(8) ? null : dr.GetString(8),
                            RefereeId = dr.IsDBNull(9) ? (int?)null : dr.GetInt32(9),
                            RefereeName = dr.IsDBNull(10) ? null : dr.GetString(10),
                            ClassSets_Id = dr.IsDBNull(11) ? (int?)null : dr.GetInt32(11),
                            ClassSetsName = dr.IsDBNull(12) ? null : dr.GetString(12),
                            TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14),
                            MatchClassId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                            MatchClassName = dr.IsDBNull(16) ? null : dr.GetString(16)
                        });
                    }
                }
            }

            return list;
        }
        public static MatchsetModel GetNoActiveMatchSetsByMatchId(string matchId)
        {

            MatchsetModel result = null;
            string sql = @"
                SELECT 
                    ms.id,
                    ms.match_id,
                    m.team1,
                    m.team2,
                    m.score1 AS total_score1,
                    m.score2 AS total_score2,
                    ms.score1,
                    ms.score2,
                    ms.time,
                    ms.note,
                    ms.status,
                    ms.referee_id,
                    u.name AS referee_name,
                    ms.ClassSets_id,
                    COALESCE(ms.ClassSetsName, cs.name) AS classsets_name,
                    m.tournament_id,
                    t.name AS tournament_name,
                    cs.Match_Class_Id AS MatchClassId,
                    mtl.name as MatchClassName
                FROM MatchSets ms
                INNER JOIN Matches m ON ms.match_id = m.id
                LEFT JOIN Users u ON ms.referee_id = u.id
                LEFT JOIN ClassSets cs ON ms.ClassSets_id = cs.id
                LEFT JOIN MatchClass mtl ON cs.Match_Class_Id = mtl.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE ms.status = '0'
                  AND ms.match_id = @id
                ORDER BY ms.ClassSets_id,m.id, ms.id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", matchId);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = new MatchsetModel
                        {
                            Id = dr.GetInt32(0),
                            MatchId = dr.GetString(1),
                            Team1 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Team2 = dr.IsDBNull(3) ? null : dr.GetString(3),
                            TotalScore1 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            TotalScore2 = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                            Score1 = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                            Score2 = dr.IsDBNull(7) ? 0 : dr.GetInt32(7),
                            Time = dr.IsDBNull(8) ? null : dr.GetString(8),
                            Note = dr.IsDBNull(9) ? null : dr.GetString(9),
                            Status = dr.IsDBNull(10) ? null : dr.GetString(10),
                            RefereeId = dr.IsDBNull(11) ? (int?)null : dr.GetInt32(11),
                            RefereeName = dr.IsDBNull(12) ? null : dr.GetString(12),
                            ClassSets_Id = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            ClassSetsName = dr.IsDBNull(14) ? null : dr.GetString(14),
                            TournamentId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                            TournamentName = dr.IsDBNull(16) ? null : dr.GetString(16),
                            MatchClassId = dr.IsDBNull(17) ? (int?)null : dr.GetInt32(17),
                            MatchClassName = dr.IsDBNull(18) ? null : dr.GetString(18)
                        };
                    }
                }
            }
            return result;
        }
        public static List<MatchModel> GetMatchesByStatus(string status)
        {
            var list = new List<MatchModel>();
            string sql = @"
                SELECT 
                    m.id, m.team1, m.team2, m.score1, m.score2, m.start, m.""end"", 
                    m.time, m.referee_id, u.name AS referee_name, 
                    m.note, m.show_toggle, m.status, m.tournament_id, t.name AS tournament_name
                FROM Matches m
                LEFT JOIN Users u ON m.referee_id = u.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE m.status=@status;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@status", status);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var match = new MatchModel
                        {
                            Id = dr.GetString(0),
                            Team1 = dr.IsDBNull(1) ? null : dr.GetString(1),
                            Team2 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Score1 = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                            Score2 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            Start = dr.IsDBNull(5) ? (DateTime?)null : dr.GetDateTime(5),
                            End = dr.IsDBNull(6) ? (DateTime?)null : dr.GetDateTime(6),
                            Time = dr.IsDBNull(7) ? null : dr.GetString(7),
                            RefereeId = dr.IsDBNull(8) ? (int?)null : dr.GetInt32(8),
                            RefereeName = dr.IsDBNull(9) ? null : dr.GetString(9),
                            Note = dr.IsDBNull(10) ? null : dr.GetString(10),
                            ShowToggle = dr.IsDBNull(11) ? 0 : dr.GetInt32(11),
                            Status = dr.IsDBNull(12) ? null : dr.GetString(12),
                            TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14)
                        };
                        list.Add(match);
                    }
                }
            }
            return list;
        }

        public static List<MatchModel> GetMatchesShowToggle()
        {
            var list = new List<MatchModel>();
            string sql = @"
                SELECT 
                    m.id, m.team1, m.team2, m.score1, m.score2, m.start, m.""end"", 
                    m.time, m.referee_id, u.name AS referee_name, 
                    m.note, m.show_toggle, m.status, m.tournament_id, t.name AS tournament_name
                FROM Matches m
                LEFT JOIN Users u ON m.referee_id = u.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE m.status='1' AND m.show_toggle=1;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var match = new MatchModel
                        {
                            Id = dr.GetString(0),
                            Team1 = dr.IsDBNull(1) ? null : dr.GetString(1),
                            Team2 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Score1 = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                            Score2 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            Start = dr.IsDBNull(5) ? (DateTime?)null : dr.GetDateTime(5),
                            End = dr.IsDBNull(6) ? (DateTime?)null : dr.GetDateTime(6),
                            Time = dr.IsDBNull(7) ? null : dr.GetString(7),
                            RefereeId = dr.IsDBNull(8) ? (int?)null : dr.GetInt32(8),
                            RefereeName = dr.IsDBNull(9) ? null : dr.GetString(9),
                            Note = dr.IsDBNull(10) ? null : dr.GetString(10),
                            ShowToggle = dr.IsDBNull(11) ? 0 : dr.GetInt32(11),
                            Status = dr.IsDBNull(12) ? null : dr.GetString(12),
                            TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14)
                        };
                        list.Add(match);
                    }
                }
            }
            return list;
        }
        public static List<MatchsetModel> GetActiveMatchSetsByMatchId(string matchId)
        {
            var list = new List<MatchsetModel>();
            string sql = @"
                SELECT 
                    ms.id,
                    ms.match_id,
                    m.team1,
                    m.team2,
                    m.score1 AS total_score1,
                    m.score2 AS total_score2,
                    ms.time,
                    ms.note,
                    ms.status,
                    ms.referee_id,
                    u.name AS referee_name,
                    ms.ClassSets_id,
                    COALESCE(ms.ClassSetsName, cs.name) AS classsets_name,
                    m.tournament_id,
                    t.name AS tournament_name,
                    cs.Match_Class_Id AS MatchClassId,
                    mtl.name as MatchClassName
                FROM MatchSets ms
                INNER JOIN Matches m ON ms.match_id = m.id
                LEFT JOIN Users u ON ms.referee_id = u.id
                LEFT JOIN ClassSets cs ON ms.ClassSets_id = cs.id
                LEFT JOIN MatchClass mtl ON cs.Match_Class_Id = mtl.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE ms.status = '1'
                  AND ms.match_id = @id
                ORDER BY ms.ClassSets_id,m.id, ms.id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", matchId);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new MatchsetModel
                        {
                            Id = dr.GetInt32(0),
                            MatchId = dr.GetString(1),
                            Team1 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Team2 = dr.IsDBNull(3) ? null : dr.GetString(3),
                            TotalScore1 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            TotalScore2 = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                            Time = dr.IsDBNull(6) ? null : dr.GetString(6),
                            Note = dr.IsDBNull(7) ? null : dr.GetString(7),
                            Status = dr.IsDBNull(8) ? null : dr.GetString(8),
                            RefereeId = dr.IsDBNull(9) ? (int?)null : dr.GetInt32(9),
                            RefereeName = dr.IsDBNull(10) ? null : dr.GetString(10),
                            ClassSets_Id = dr.IsDBNull(11) ? (int?)null : dr.GetInt32(11),
                            ClassSetsName = dr.IsDBNull(12) ? null : dr.GetString(12),
                            TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14),
                            MatchClassId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                            MatchClassName = dr.IsDBNull(16) ? null : dr.GetString(16)
                        });
                    }
                }
            }

            return list;
        }
        public static MatchsetModel GetNextMatchDetail(string matchId, int userId)
        {
            MatchsetModel result = null;

            string sql = @"
                SELECT 
                    ms.id,
                    ms.match_id,
                    m.team1,
                    m.team2,
                    m.score1 AS total_score1,
                    m.score2 AS total_score2,
                    ms.time,
                    ms.note,
                    ms.status,
                    ms.referee_id,
                    u.name AS referee_name,
                    ms.ClassSets_id,
                    COALESCE(ms.ClassSetsName, cs.name) AS classsets_name,
                    m.tournament_id,
                    t.name AS tournament_name,
                    cs.Match_Class_Id AS MatchClassId,
                    mtl.name as MatchClassName
                FROM MatchSets ms
                INNER JOIN Matches m ON ms.match_id = m.id
                LEFT JOIN Users u ON ms.referee_id = u.id
                LEFT JOIN ClassSets cs ON ms.ClassSets_id = cs.id
                LEFT JOIN MatchClass mtl ON cs.Match_Class_Id = mtl.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE ms.status = '0'
                  AND ms.match_id = @mid
                  AND (ms.referee_id = @uid OR @uid = 0 OR @uid IS NULL)
                ORDER BY ms.id ASC LIMIT 1;
            ";

            using (var cmd = new NpgsqlCommand(sql, PostgresHelper.SharedConn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@uid", userId);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = new MatchsetModel
                        {
                            Id = dr.GetInt32(0),
                            MatchId = dr.GetString(1),
                            Team1 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Team2 = dr.IsDBNull(3) ? null : dr.GetString(3),
                            TotalScore1 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            TotalScore2 = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                            Time = dr.IsDBNull(6) ? null : dr.GetString(6),
                            Note = dr.IsDBNull(7) ? null : dr.GetString(7),
                            Status = dr.IsDBNull(8) ? null : dr.GetString(8),
                            RefereeId = dr.IsDBNull(9) ? (int?)null : dr.GetInt32(9),
                            RefereeName = dr.IsDBNull(10) ? null : dr.GetString(10),
                            ClassSets_Id = dr.IsDBNull(11) ? (int?)null : dr.GetInt32(11),
                            ClassSetsName = dr.IsDBNull(12) ? null : dr.GetString(12),
                            TournamentId = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            TournamentName = dr.IsDBNull(14) ? null : dr.GetString(14),
                            MatchClassId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                            MatchClassName = dr.IsDBNull(16) ? null : dr.GetString(16)
                        };
                    }
                }
            }

            return result;
        }
        public static List<MatchsetModel> GetMatchSetsByMatchId(string matchId)
        {
            var list = new List<MatchsetModel>();
            string sql = @"
                SELECT 
                    ms.id,
                    ms.match_id,
                    m.team1,
                    m.team2,
                    m.score1 AS total_score1,
                    m.score2 AS total_score2,
                    ms.score1,
                    ms.score2,
                    ms.time,
                    ms.note,
                    ms.status,
                    ms.referee_id,
                    u.name AS referee_name,
                    ms.ClassSets_id,
                    COALESCE(ms.ClassSetsName, cs.name) AS classsets_name,
                    m.tournament_id,
                    t.name AS tournament_name,
                    cs.Match_Class_Id AS MatchClassId,
                    mtl.name as MatchClassName
                FROM MatchSets ms
                INNER JOIN Matches m ON ms.match_id = m.id
                LEFT JOIN Users u ON ms.referee_id = u.id
                LEFT JOIN ClassSets cs ON ms.ClassSets_id = cs.id
                LEFT JOIN MatchClass mtl ON cs.Match_Class_Id = mtl.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE ms.match_id = @mid
                ORDER BY ms.id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new MatchsetModel
                        {
                            Id = dr.GetInt32(0),
                            MatchId = dr.GetString(1),
                            Team1 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Team2 = dr.IsDBNull(3) ? null : dr.GetString(3),
                            TotalScore1 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            TotalScore2 = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                            Score1 = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                            Score2 = dr.IsDBNull(7) ? 0 : dr.GetInt32(7),
                            Time = dr.IsDBNull(8) ? null : dr.GetString(8),
                            Note = dr.IsDBNull(9) ? null : dr.GetString(9),
                            Status = dr.IsDBNull(10) ? null : dr.GetString(10),
                            RefereeId = dr.IsDBNull(11) ? (int?)null : dr.GetInt32(11),
                            RefereeName = dr.IsDBNull(12) ? null : dr.GetString(12),
                            ClassSets_Id = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            ClassSetsName = dr.IsDBNull(14) ? null : dr.GetString(14),
                            TournamentId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                            TournamentName = dr.IsDBNull(16) ? null : dr.GetString(16),
                            MatchClassId = dr.IsDBNull(17) ? (int?)null : dr.GetInt32(17),
                            MatchClassName = dr.IsDBNull(18) ? null : dr.GetString(18)
                        });
                    }
                }
            }

            return list;
        }
        public static MatchsetModel GetMatchSetByMatchAndId(string matchId, int id)
        {
            string sql = @"
                SELECT 
                    ms.id,
                    ms.match_id,
                    m.team1,
                    m.team2,
                    m.score1 AS total_score1,
                    m.score2 AS total_score2,
                    ms.score1,
                    ms.score2,
                    ms.time,
                    ms.note,
                    ms.status,
                    ms.referee_id,
                    u.name AS referee_name,
                    ms.ClassSets_id,
                    COALESCE(ms.ClassSetsName, cs.name) AS classsets_name,
                    m.tournament_id,
                    t.name AS tournament_name,
                    cs.Match_Class_Id AS MatchClassId,
                    mtl.name as MatchClassName,
                    ms.start
                FROM MatchSets ms
                INNER JOIN Matches m ON ms.match_id = m.id
                LEFT JOIN Users u ON ms.referee_id = u.id
                LEFT JOIN ClassSets cs ON ms.ClassSets_id = cs.id
                LEFT JOIN MatchClass mtl ON cs.Match_Class_Id = mtl.id
                LEFT JOIN Tournaments t ON m.tournament_id = t.id
                WHERE ms.match_id = @mid AND ms.id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new MatchsetModel
                        {
                            Id = dr.GetInt32(0),
                            MatchId = dr.GetString(1),
                            Team1 = dr.IsDBNull(2) ? null : dr.GetString(2),
                            Team2 = dr.IsDBNull(3) ? null : dr.GetString(3),
                            TotalScore1 = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            TotalScore2 = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                            Score1 = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                            Score2 = dr.IsDBNull(7) ? 0 : dr.GetInt32(7),
                            Time = dr.IsDBNull(8) ? null : dr.GetString(8),
                            Note = dr.IsDBNull(9) ? null : dr.GetString(9),
                            Status = dr.IsDBNull(10) ? null : dr.GetString(10),
                            RefereeId = dr.IsDBNull(11) ? (int?)null : dr.GetInt32(11),
                            RefereeName = dr.IsDBNull(12) ? null : dr.GetString(12),
                            ClassSets_Id = dr.IsDBNull(13) ? (int?)null : dr.GetInt32(13),
                            ClassSetsName = dr.IsDBNull(14) ? null : dr.GetString(14),
                            TournamentId = dr.IsDBNull(15) ? (int?)null : dr.GetInt32(15),
                            TournamentName = dr.IsDBNull(16) ? null : dr.GetString(16),
                            MatchClassId = dr.IsDBNull(17) ? (int?)null : dr.GetInt32(17),
                            MatchClassName = dr.IsDBNull(18) ? null : dr.GetString(18),
                            Start = dr.IsDBNull(2) ? (DateTime?)null : dr.GetDateTime(19),
                        };
                    }
                }
            }

            return null;
        }
        public static void AddMatchSet(MatchsetModel m)
        {
            int nextId = 1;
            using (var cmd = new NpgsqlCommand("SELECT COALESCE(MAX(id), 0) + 1 FROM MatchSets WHERE match_id = @mid", Conn))
            {
                cmd.Parameters.AddWithValue("@mid", m.MatchId);
                nextId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            string sql = @"
                INSERT INTO MatchSets
                (id, match_id, score1, score2, start, ""end"", time, note, status, ClassSets_id, referee_id, ClassSetsName)
                VALUES (@id, @mid, @s1, @s2, @st, @et, @t, @note, @stt, @cid, @rid, @csname);
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", nextId);
                cmd.Parameters.AddWithValue("@mid", m.MatchId);
                cmd.Parameters.AddWithValue("@s1", m.Score1);
                cmd.Parameters.AddWithValue("@s2", m.Score2);
                cmd.Parameters.AddWithValue("@st", DBNull.Value);
                cmd.Parameters.AddWithValue("@et", DBNull.Value);
                cmd.Parameters.AddWithValue("@t", m.Time ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@note", m.Note ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@stt", (object)m.Status ?? "0");
                cmd.Parameters.AddWithValue("@rid", m.RefereeId.HasValue ? (object)m.RefereeId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@cid", m.ClassSets_Id.HasValue ? (object)m.ClassSets_Id.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@csname", m.ClassSetsName ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchSet(MatchsetModel m)
        {
            string sql = @"
                UPDATE MatchSets SET
                    match_id = @mid,
                    score1 = @s1,
                    score2 = @s2,
                    time = @t,
                    note = @note,
                    status = @stt,
                    referee_id = @rid,
                    ClassSets_id = @cid
                WHERE id = @id;
            ";
            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@id", m.Id);
                cmd.Parameters.AddWithValue("@mid", m.MatchId);
                cmd.Parameters.AddWithValue("@s1", m.Score1);
                cmd.Parameters.AddWithValue("@s2", m.Score2);
                cmd.Parameters.AddWithValue("@t", m.Time);
                cmd.Parameters.AddWithValue("@note", m.Note);
                cmd.Parameters.AddWithValue("@stt", (object)m.Status ?? "0");
                cmd.Parameters.AddWithValue("@rid", m.RefereeId.HasValue ? (object)m.RefereeId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@cid", m.ClassSets_Id.HasValue ? (object)m.ClassSets_Id.Value : DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchSetStatus(string matchId, int id, string status)
        {
            string sql = @"
                UPDATE MatchSets 
                SET status = @st
                WHERE match_id = @mid AND id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@st", status ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchSetTime(string matchId, int id, string time)
        {
            string sql = @"
                UPDATE MatchSets 
                SET time = @t
                WHERE match_id = @mid AND id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@t", time);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchSetScore1(string matchId, int id, int score)
        {
            string sql = @"
                UPDATE MatchSets 
                SET score1 = @sc
                WHERE match_id = @mid AND id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@sc", score);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchSetScore2(string matchId, int id, int score)
        {
            string sql = @"
                UPDATE MatchSets 
                SET score2 = @sc
                WHERE match_id = @mid AND id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@sc", score);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteMatchSet(string matchId, int id)
        {
            using (var cmd = new NpgsqlCommand("DELETE FROM MatchSets WHERE match_id = @mid AND id = @id", Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // ====================================================
        // ACTIVITIES
        // ====================================================
        public static void AddActivity(int userId, string activity)
        {
            using (var cmd = new NpgsqlCommand("INSERT INTO Activities(user_id, activity) VALUES(@u,@a)", Conn))
            {
                cmd.Parameters.AddWithValue("@u", userId);
                cmd.Parameters.AddWithValue("@a", activity);
                cmd.ExecuteNonQuery();
            }
        }
        // ====================================================
        // MATCHCLASS
        // ====================================================
        public static List<MatchClassModel> GetAllMatchClasses()
        {
            var list = new List<MatchClassModel>();

            using (var cmd = new NpgsqlCommand(@"SELECT id, name, period_type, standard_periods, periods_to_win, 
                allow_overtime, max_overtime_periods, allow_tie, created_at, updated_at FROM MatchClass ORDER BY id", Conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    list.Add(new MatchClassModel
                    {
                        Id = dr.GetInt32(0),
                        Name = dr.GetString(1),
                        PeriodType = dr.IsDBNull(2) ? null : dr.GetString(2),
                        StandardPeriods = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                        PeriodsToWin = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                        AllowOvertime = dr.IsDBNull(5) ? false : dr.GetBoolean(5),
                        MaxOvertimePeriods = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                        AllowTie = dr.IsDBNull(7) ? false : dr.GetBoolean(7),
                        CreatedAt = dr.IsDBNull(8) ? DateTime.Now : dr.GetDateTime(8),
                        UpdatedAt = dr.IsDBNull(9) ? DateTime.Now : dr.GetDateTime(9)
                    });
                }
            }

            return list;
        }

        public static void AddMatchClass(MatchClassModel m)
        {
            using (var cmd = new NpgsqlCommand(@"INSERT INTO MatchClass(name, period_type, standard_periods, periods_to_win, 
                allow_overtime, max_overtime_periods, allow_tie, created_at, updated_at) 
                VALUES(@n, @pt, @sp, @ptw, @ao, @mop, @at, @ca, @ua)", Conn))
            {
                cmd.Parameters.AddWithValue("@n", m.Name);
                cmd.Parameters.AddWithValue("@pt", string.IsNullOrEmpty(m.PeriodType) ? (object)DBNull.Value : m.PeriodType);
                cmd.Parameters.AddWithValue("@sp", m.StandardPeriods);
                cmd.Parameters.AddWithValue("@ptw", m.PeriodsToWin);
                cmd.Parameters.AddWithValue("@ao", m.AllowOvertime);
                cmd.Parameters.AddWithValue("@mop", m.MaxOvertimePeriods);
                cmd.Parameters.AddWithValue("@at", m.AllowTie);
                cmd.Parameters.AddWithValue("@ca", DateTime.Now);
                cmd.Parameters.AddWithValue("@ua", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateMatchClass(MatchClassModel m)
        {
            using (var cmd = new NpgsqlCommand(@"UPDATE MatchClass SET name=@n, period_type=@pt, standard_periods=@sp, 
                periods_to_win=@ptw, allow_overtime=@ao, max_overtime_periods=@mop, allow_tie=@at, updated_at=@ua 
                WHERE id=@id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", m.Id);
                cmd.Parameters.AddWithValue("@n", m.Name);
                cmd.Parameters.AddWithValue("@pt", string.IsNullOrEmpty(m.PeriodType) ? (object)DBNull.Value : m.PeriodType);
                cmd.Parameters.AddWithValue("@sp", m.StandardPeriods);
                cmd.Parameters.AddWithValue("@ptw", m.PeriodsToWin);
                cmd.Parameters.AddWithValue("@ao", m.AllowOvertime);
                cmd.Parameters.AddWithValue("@mop", m.MaxOvertimePeriods);
                cmd.Parameters.AddWithValue("@at", m.AllowTie);
                cmd.Parameters.AddWithValue("@ua", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        // ====================================================
        // CLASSSETS
        // ====================================================
        public static List<ClassSetsModel> GetAllClassSets()
        {
            var list = new List<ClassSetsModel>();
            using (var cmd = new NpgsqlCommand("SELECT id, name, Match_Class_Id FROM ClassSets ORDER BY id", Conn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    list.Add(new ClassSetsModel
                    {
                        Id = dr.GetInt32(0),
                        Name = dr.GetString(1),
                        Match_Class_Id = dr.IsDBNull(2) ? (int?)null : dr.GetInt32(2)
                    });
                }
            }
            return list;
        }
        public static List<ClassSetsModel> GetAllClassSetsByClassId(int id)
        {
            var list = new List<ClassSetsModel>();
            using (var cmd = new NpgsqlCommand("SELECT id, name, Match_Class_Id FROM ClassSets " +
                " WHERE Match_Class_Id=@ml " +
                " ORDER BY id", Conn))
            {
                cmd.Parameters.AddWithValue("@ml", id);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new ClassSetsModel
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Match_Class_Id = dr.IsDBNull(2) ? (int?)null : dr.GetInt32(2)
                        });
                    }
                }
            }
            return list;
        }
        public static ClassSetsModel GetClassSetById(int id)
        {
            using (var cmd = new NpgsqlCommand("SELECT id, name, Match_Class_Id FROM ClassSets WHERE id=@id", PostgresHelper.SharedConn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new ClassSetsModel
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Match_Class_Id = dr.IsDBNull(2) ? (int?)null : dr.GetInt32(2)
                        };
                    }
                }
            }
            return null;
        }

        public static void AddClassSet(ClassSetsModel c)
        {
            using (var cmd = new NpgsqlCommand("INSERT INTO ClassSets(name, Match_Class_Id) VALUES(@n, @m)", PostgresHelper.SharedConn))
            {
                cmd.Parameters.AddWithValue("@n", c.Name);
                if (c.Match_Class_Id.HasValue)
                    cmd.Parameters.AddWithValue("@m", c.Match_Class_Id.Value);
                else
                    cmd.Parameters.AddWithValue("@m", DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateClassSet(ClassSetsModel c)
        {
            using (var cmd = new NpgsqlCommand("UPDATE ClassSets SET name=@n, Match_Class_Id=@m WHERE id=@id", PostgresHelper.SharedConn))
            {
                cmd.Parameters.AddWithValue("@id", c.Id);
                cmd.Parameters.AddWithValue("@n", c.Name);
                if (c.Match_Class_Id.HasValue)
                    cmd.Parameters.AddWithValue("@m", c.Match_Class_Id.Value);
                else
                    cmd.Parameters.AddWithValue("@m", DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteClassSet(int id)
        {
            using (var cmd = new NpgsqlCommand("DELETE FROM ClassSets WHERE id=@id", PostgresHelper.SharedConn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // ====================================================
        // MATCH CLASS HELPER METHODS
        // ====================================================
        public static MatchClassModel GetMatchClassById(int id)
        {
            using (var cmd = new NpgsqlCommand(@"SELECT id, name, period_type, standard_periods, periods_to_win, 
                allow_overtime, max_overtime_periods, allow_tie, created_at, updated_at FROM MatchClass WHERE id = @id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new MatchClassModel
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            PeriodType = dr.IsDBNull(2) ? null : dr.GetString(2),
                            StandardPeriods = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                            PeriodsToWin = dr.IsDBNull(4) ? 0 : dr.GetInt32(4),
                            AllowOvertime = dr.IsDBNull(5) ? false : dr.GetBoolean(5),
                            MaxOvertimePeriods = dr.IsDBNull(6) ? 0 : dr.GetInt32(6),
                            AllowTie = dr.IsDBNull(7) ? false : dr.GetBoolean(7),
                            CreatedAt = dr.IsDBNull(8) ? DateTime.Now : dr.GetDateTime(8),
                            UpdatedAt = dr.IsDBNull(9) ? DateTime.Now : dr.GetDateTime(9)
                        };
                    }
                }
            }
            return null;
        }

        public static void CreateOvertimePeriod(string matchId, int currentSetId, string periodName, int refereeId)
        {
            // Get current match details
            var currentMatch = GetMatchSetByMatchAndId(matchId, currentSetId);
            if (currentMatch == null) return;

            // Get match class details
            var matchClass = GetMatchClassById(currentMatch.MatchClassId ?? 0);
            if (matchClass == null) return;

            // Create new overtime period
            var overtimeSet = new MatchsetModel
            {
                MatchId = matchId,
                Team1 = currentMatch.Team1,
                Team2 = currentMatch.Team2,
                Score1 = 0,
                Score2 = 0,
                Time = "00:00",
                Note = periodName,
                Status = "0", // Inactive initially
                RefereeId = refereeId,
                RefereeName = currentMatch.RefereeName,
                ClassSets_Id = currentMatch.ClassSets_Id,
                ClassSetsName = periodName,
                TournamentId = currentMatch.TournamentId,
                TournamentName = currentMatch.TournamentName,
                MatchClassId = currentMatch.MatchClassId,
                MatchClassName = currentMatch.MatchClassName
            };

            AddMatchSet(overtimeSet);
        }

        public static void CreatePenaltyShootout(string matchId, int refereeId)
        {
            // Get current match details
            var match = GetMatchById(matchId);
            if (match == null) return;

            // Create penalty shootout period
            var penaltySet = new MatchsetModel
            {
                MatchId = matchId,
                Team1 = match.Team1,
                Team2 = match.Team2,
                Score1 = 0,
                Score2 = 0,
                Time = "00:00",
                Note = "Đá penalty",
                Status = "0", // Inactive initially
                RefereeId = refereeId,
                RefereeName = match.RefereeName,
                ClassSets_Id = null, // Special period
                ClassSetsName = "Đá penalty",
                TournamentId = match.TournamentId,
                TournamentName = match.TournamentName,
                MatchClassId = match.MatchClassId,
                MatchClassName = match.MatchClassName
            };

            AddMatchSet(penaltySet);
        }
        public static void StartMatchSet(string matchId, int id)
        {
            string sql = @"
                UPDATE MatchSets 
                SET status = '1', start = NOW()
                WHERE match_id = @mid AND id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EndMatchSet(string matchId, int id)
        {
            string sql = @"
                UPDATE MatchSets 
                SET status = '2', ""end"" = NOW()
                WHERE match_id = @mid AND id = @id;
            ";

            using (var cmd = new NpgsqlCommand(sql, Conn))
            {
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

}