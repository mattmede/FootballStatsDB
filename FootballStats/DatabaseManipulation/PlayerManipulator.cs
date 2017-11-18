using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseModels;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DatabaseManipulator
{
    public class PlayerManipulator : IManipulator
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=NATHANPC\SQLEXPRESS;Initial Catalog=FootBallStatTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void Insert(IDatabaseEntry player)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Players (Name, Number) VALUES (@Name, @Number);", connection);

            AddParameters(command, player.GetKeyValuePairs(false));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Edit(IDatabaseEntry player)
        {
            SqlCommand command = new SqlCommand("UPDATE Players SET Name = @Name, Number = @Number WHERE Player_Id = @Player_Id;", connection);

            AddParameters(command, player.GetKeyValuePairs());

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(IDatabaseEntry player)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Players WHERE Player_Id = @Player_Id;", connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IDatabaseEntry SelectEntry(int id)
        {

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("id", id));

            SqlCommand command = new SqlCommand("SELECT FROM Players WHERE Player_Id = @id", connection);

            connection.Open();
            command.ExecuteReader();
            connection.Close();

            return new Player();
        }

        public List<IDatabaseEntry> SelectMultipleEntries(List<int> ids)
        {
            SqlCommand command = new SqlCommand("SELECT FROM Players WHERE Player_Id = ", connection);

            connection.Open();
            command.ExecuteReader();
            connection.Close();

            return new List<IDatabaseEntry>();
        }

        public void AddParameters(SqlCommand cmd, List<KeyValuePair<string, object>> parameters)
        {
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                cmd.Parameters.AddWithValue(pair.Key, pair.Value);
            }
        }
    }
}
