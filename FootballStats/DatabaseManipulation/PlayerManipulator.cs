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
    class PlayerManipulator : IManipulator
    {
        private SqlConnection connection = new SqlConnection();

        public void Insert(IDatabaseEntry player)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Players VALUES ", connection);

        }

        public void Edit(IDatabaseEntry player)
        {
            SqlCommand command = new SqlCommand("UPDATE Players ", connection);
        }

        public void Delete(IDatabaseEntry player)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Players WHERE ", connection);
        }

        public IDatabaseEntry SelectEntry(int id)
        {

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("id", id));

            SqlCommand command = new SqlCommand("SELECT FROM Players WHERE Player_Id = @id", connection);

            return new Player();
        }

        public List<IDatabaseEntry> SelectMultipleEntries(List<int> ids)
        {
            SqlCommand command = new SqlCommand("SELECT FROM Players WHERE Player_Id = ", connection);

            return new List<IDatabaseEntry>();
        }
    }
}
