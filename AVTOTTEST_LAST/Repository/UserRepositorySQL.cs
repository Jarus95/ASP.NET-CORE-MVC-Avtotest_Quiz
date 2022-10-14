using AVTOTTEST_LAST.Models;
using Microsoft.Data.Sqlite;

namespace AVTOTTEST_LAST.Repository
{
    public class UserRepositorySQL
    {
        public SqliteConnection connection;
        private string sqlite = "Data Source=avto.db";

        public UserRepositorySQL()
        {
            connection = new SqliteConnection(sqlite);
            CreateTable();
        }

        private void CreateTable()
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "CREATE TABLE if not exists users(id integer primary key autoincrement, Ism text, Tel text, Parol text)";
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void InsertIntoTable(User user)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT into users(ism,tel,parol) VALUES(@name,@phone,@password);";
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public bool CheckUser(User user)
        {
            int usercount = 0;
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT COUNT(*) FROM users  where Tel = {user.Phone}";
            var data = cmd.ExecuteReader();
            while (data.Read())
            {
                usercount = data.GetInt32(0);
            }
            connection.Close();
            return usercount != 0 ? true : false;

            //
        }
    }
}
