﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseModels;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DatabaseManipulation
{
    public class Database_Manipulator
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=NATHANPC\SQLEXPRESS;Initial Catalog=FootBallStatTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void Insert(IDatabaseEntry entry)
        {
            string command_string = "INSERT INTO " + entry.GetTableName();
            List<string> fields = new List<string>();
            entry.GetFields(out fields);

            AddFieldNames(ref command_string, fields);

            command_string += " VALUES (";
            command_string += entry.GetParameterString(entry.GetKeyValuePairs());
            command_string += ");";

            SqlCommand command = new SqlCommand(command_string, connection);

            AddParameters(command, entry.GetKeyValuePairs(false));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Edit(IDatabaseEntry entry)
        {
            string command_string = "UPDATE " + entry.GetTableName() + " SET ";

            List<KeyValuePair<string, object>> parameters = entry.GetKeyValuePairs();

            foreach(KeyValuePair<string, object> pair in parameters)
            {
                command_string += pair.Key + " = @" + pair.Key;
                if (!pair.Equals(parameters.Last()))
                    command_string += ", ";
            }

            parameters = entry.GetKeyValuePairs(true);

            command_string += " WHERE " + parameters.First().Key + " = @" + parameters.First().Key + ";"; 

            SqlCommand command = new SqlCommand(command_string, connection);

            AddParameters(command, entry.GetKeyValuePairs(true));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(IDatabaseEntry entry)
        {
            List<KeyValuePair<string, object>> parameters = entry.GetKeyValuePairs(true);

            string command_string = "DELETE FROM " + entry.GetTableName() + " WHERE " + parameters.First().Key + " = @" + parameters.First().Key + ";";


            SqlCommand command = new SqlCommand(command_string, connection);
            command.Parameters.AddWithValue(parameters.First().Key, parameters.First().Value);

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

        private void AddParameters(SqlCommand cmd, List<KeyValuePair<string, object>> parameters)
        {
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                cmd.Parameters.AddWithValue(pair.Key, pair.Value);
            }
        }

        private void AddFieldNames(ref string command_string, List<string> fieldnames)
        {
            command_string += "(";

            foreach(string field in fieldnames)
            {
                command_string += field;

                if (field != fieldnames.Last())
                    command_string += ",";
            }

            command_string += ") ";
        }
    }
}
