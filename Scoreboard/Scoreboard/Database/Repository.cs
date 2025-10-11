using System;
using System.Collections.Generic;
using Npgsql;
using Scoreboard.Database;

namespace Scoreboard.Database
{
    public static class Repository
    {
        public static event Action SettingsChanged;

        public static User Authenticate(string username, string password)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Username, PasswordHash, Role FROM Users WHERE Username=@u";
                cmd.Parameters.AddWithValue("@u", username);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        var hash = r.GetString(2);
                        if (Utilities.Security.VerifyPassword(password, hash))
                        {
                            return new User { Id = r.GetInt32(0), Username = r.GetString(1), Role = r.GetString(3) };
                        }
                    }
                }
            }
            return null;
        }

        public static List<User> GetAllUsers()
        {
            var list = new List<User>();
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Username, Role, Name FROM Users";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(new User { Id = r.GetInt32(0), Username = r.GetString(1), Role = r.GetString(2) ,Name = r.GetString(3) });
                }
            }
            return list;
        }
        public static List<User> GetAllUsersByUserName(string UserName)
        {
            var list = new List<User>();
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Username, Role, Name FROM Users WHERE UserName = @uc";
                cmd.Parameters.AddWithValue("@uc", UserName);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(new User { Id = r.GetInt32(0), Username = r.GetString(1), Role = r.GetString(2), Name = r.GetString(3) });
                }
            }
            return list;
        }

        public static User GetUsersById(int userId)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Username, Role, Name FROM Users WHERE Id = @userId";
                cmd.Parameters.AddWithValue("@userId", userId);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return new User { Id = r.GetInt32(0), Username = r.GetString(1), Role = r.GetString(2), Name = r.GetString(3) };
                    }
                }
            }
            return null;
        }
        public static List<User> GetAllUserNotAdmin(string strRole)
        {
            var list = new List<User>();
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Username, Role, Name FROM Users where Role <> @Role";
                cmd.Parameters.AddWithValue("@Role", strRole);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(new User { Id = r.GetInt32(0), Username = r.GetString(1), Role = r.GetString(2), Name = r.GetString(3) });
                }
            }
            return list;
        }
        public static void AddUser(string username, string password, string role, string name)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Users (Username, PasswordHash, Role, Name) VALUES (@u,@p,@r,@n)";
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", Utilities.Security.HashPassword(password));
                cmd.Parameters.AddWithValue("@r", role);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateUser(User user)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                // If password is being updated, hash it
                if (!string.IsNullOrEmpty(user.Password))
                {
                    cmd.CommandText = "UPDATE Users SET PasswordHash=@p, Role=@r, Name=@n WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@p", Utilities.Security.HashPassword(user.Password));
                    cmd.Parameters.AddWithValue("@r", user.Role);
                    cmd.Parameters.AddWithValue("@n", user.Name);
                    cmd.Parameters.AddWithValue("@id", user.Id);
                }
                else
                {
                    // If no password change, don't update the password field
                    cmd.CommandText = "UPDATE Users SET Role=@r, Name=@n WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@r", user.Role);
                    cmd.Parameters.AddWithValue("@n", user.Name);
                    cmd.Parameters.AddWithValue("@id", user.Id);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteUser(int id)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<MatchModel> GetAllMatches()
        {
            var list = new List<MatchModel>();
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Title, Team1, Team2, Score1, Score2,SetsName, Sets, StartTime, ElapsedSeconds, IsPaused, Status, ShowToggle,UserId FROM Matches";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new MatchModel {
                            Id = r.GetInt32(0),
                            Title = r.IsDBNull(1)?"":r.GetString(1),
                            Team1 = r.IsDBNull(2)?"":r.GetString(2),
                            Team2 = r.IsDBNull(3)?"":r.GetString(3),
                            Score1 = r.GetInt32(4),
                            Score2 = r.GetInt32(5),
                            SetsName = r.IsDBNull(6) ? "" : r.GetString(6),
                            Sets = r.GetInt32(7),
                            StartTime = r.IsDBNull(8) ? "" : r.GetString(8),
                            ElapsedSeconds = r.GetInt32(9),
                            IsPaused = r.GetInt32(10),
                            Status = r.GetInt32(11),
                            ShowToggle = r.GetBoolean(12),
                            UserId = r.GetInt32(13),
                        });
                    }
                }
            }
            return list;
        }
        public static List<MatchModel> GetShowMatchesUser(User uc)
        {
            var list = new List<MatchModel>();
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Title, Team1, Team2, Score1, Score2,SetsName, Sets, StartTime, ElapsedSeconds, IsPaused, Status, ShowToggle,UserId FROM Matches Where ShowToggle = true AND UserId = @uc";
                cmd.Parameters.AddWithValue("@uc", uc.Id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new MatchModel
                        {
                            Id = r.GetInt32(0),
                            Title = r.IsDBNull(1) ? "" : r.GetString(1),
                            Team1 = r.IsDBNull(2) ? "" : r.GetString(2),
                            Team2 = r.IsDBNull(3) ? "" : r.GetString(3),
                            Score1 = r.GetInt32(4),
                            Score2 = r.GetInt32(5),
                            SetsName = r.IsDBNull(6) ? "" : r.GetString(6),
                            Sets = r.GetInt32(7),
                            StartTime = r.IsDBNull(8) ? "" : r.GetString(8),
                            ElapsedSeconds = r.GetInt32(9),
                            IsPaused = r.GetInt32(10),
                            Status = r.GetInt32(11),
                            ShowToggle = r.GetBoolean(12),
                            UserId = r.GetInt32(13),
                        });
                    }
                }
            }
            return list;
        }
        public static List<MatchModel> GetShowMatchesToggle()
        {
            var list = new List<MatchModel>();
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Title, Team1, Team2, Score1, Score2,SetsName, Sets, StartTime, ElapsedSeconds, IsPaused, Status, ShowToggle,UserId FROM Matches Where ShowToggle = true";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new MatchModel
                        {
                            Id = r.GetInt32(0),
                            Title = r.IsDBNull(1) ? "" : r.GetString(1),
                            Team1 = r.IsDBNull(2) ? "" : r.GetString(2),
                            Team2 = r.IsDBNull(3) ? "" : r.GetString(3),
                            Score1 = r.GetInt32(4),
                            Score2 = r.GetInt32(5),
                            SetsName = r.IsDBNull(6) ? "" : r.GetString(6),
                            Sets = r.GetInt32(7),
                            StartTime = r.IsDBNull(8) ? "" : r.GetString(8),
                            ElapsedSeconds = r.GetInt32(9),
                            IsPaused = r.GetInt32(10),
                            Status = r.GetInt32(11),
                            ShowToggle = r.GetBoolean(12),
                            UserId = r.GetInt32(13),
                        });
                    }
                }
            }
            return list;
        }
        public static int CreateMatch(MatchModel m)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Matches (Title, Team1, Team2, Score1, Score2,SetsName, Sets, StartTime, ElapsedSeconds, IsPaused, Status, ShowToggle,UserId) VALUES (@t,@a,@b,@s1,@s2,@setn,@set,@str,@ela,@isp,@sts,@tog,@uc) RETURNING Id";
                cmd.Parameters.AddWithValue("@t", m.Title);
                cmd.Parameters.AddWithValue("@a", m.Team1);
                cmd.Parameters.AddWithValue("@b", m.Team2);
                cmd.Parameters.AddWithValue("@s1", m.Score1);
                cmd.Parameters.AddWithValue("@s2", m.Score2);
                cmd.Parameters.AddWithValue("@setn", m.SetsName);
                cmd.Parameters.AddWithValue("@set", m.Sets);
                cmd.Parameters.AddWithValue("@str", m.StartTime);
                cmd.Parameters.AddWithValue("@ela", m.ElapsedSeconds);
                cmd.Parameters.AddWithValue("@isp", m.IsPaused);
                cmd.Parameters.AddWithValue("@sts", m.Status);
                cmd.Parameters.AddWithValue("@tog", m.ShowToggle);
                cmd.Parameters.AddWithValue("@uc", m.UserId);
                var id = (int)cmd.ExecuteScalar();
                return id;
            }
        }

        public static void UpdateMatch(MatchModel m)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Matches SET Title=@t,Team1=@a,Team2=@b,Score1=@s1,Score2=@s2,SetsName=@setn,Sets=@set,StartTime=@str,ElapsedSeconds=@ela,IsPaused=@isp,Status=@sts,ShowToggle=@tog,UserId=@uc WHERE Id=@id";
                cmd.Parameters.AddWithValue("@t", m.Title);
                cmd.Parameters.AddWithValue("@a", m.Team1);
                cmd.Parameters.AddWithValue("@b", m.Team2);
                cmd.Parameters.AddWithValue("@s1", m.Score1);
                cmd.Parameters.AddWithValue("@s2", m.Score2);
                cmd.Parameters.AddWithValue("@setn", m.SetsName);
                cmd.Parameters.AddWithValue("@set", m.Sets);
                cmd.Parameters.AddWithValue("@str", m.StartTime);
                cmd.Parameters.AddWithValue("@ela", m.ElapsedSeconds);
                cmd.Parameters.AddWithValue("@isp", m.IsPaused);
                cmd.Parameters.AddWithValue("@sts", m.Status);
                cmd.Parameters.AddWithValue("@tog", m.ShowToggle);
                cmd.Parameters.AddWithValue("@uc", m.UserId);
                cmd.Parameters.AddWithValue("@id", m.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteMatch(int id)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Matches WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static MatchModel GetMatchById(int id)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Title, Team1, Team2, Score1, Score2,SetsName, Sets, StartTime, ElapsedSeconds, IsPaused, Status,ShowToggle,UserId FROM Matches WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return new MatchModel {
                            Id = r.GetInt32(0),
                            Title = r.IsDBNull(1) ? "" : r.GetString(1),
                            Team1 = r.IsDBNull(2) ? "" : r.GetString(2),
                            Team2 = r.IsDBNull(3) ? "" : r.GetString(3),
                            Score1 = r.GetInt32(4),
                            Score2 = r.GetInt32(5),
                            SetsName = r.IsDBNull(6) ? "" : r.GetString(6),
                            Sets = r.GetInt32(7),
                            StartTime = r.IsDBNull(8) ? "" : r.GetString(8),
                            ElapsedSeconds = r.GetInt32(9),
                            IsPaused = r.GetInt32(10),
                            Status = r.GetInt32(11),
                            ShowToggle = r.GetBoolean(12),
                            UserId= r.GetInt32(13),
                        };
                    }
                }
            }
            return null;
        }

        public static string GetSetting(string key, string defaultValue = null)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Value FROM Settings WHERE Key=@k";
                cmd.Parameters.AddWithValue("@k", key);
                var o = cmd.ExecuteScalar();
                if (o == null || o == DBNull.Value) return defaultValue;
                return o.ToString();
            }
        }

        public static void SetSetting(string key, string value)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Settings (Key, Value) VALUES (@k,@v) ON CONFLICT (Key) DO UPDATE SET Value = @v";
                cmd.Parameters.AddWithValue("@k", key);
                cmd.Parameters.AddWithValue("@v", value);
                cmd.ExecuteNonQuery();
            }
            SettingsChanged?.Invoke();
        }
        public static void SaveMatchState(MatchState state)
        {
            using (var conn = PostgreSQLHelper.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Matches
                                SET Score1=@s1, Score2=@s2, ElapsedSeconds=@secs
                                WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@s1", state.Score1);
                    cmd.Parameters.AddWithValue("@s2", state.Score2);
                    cmd.Parameters.AddWithValue("@secs", state.ElapsedSeconds);
                    cmd.Parameters.AddWithValue("@id", state.MatchId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}