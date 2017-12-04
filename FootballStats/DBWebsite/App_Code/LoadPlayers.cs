using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseManipulation;
using DatabaseModels;
using System.Data.SqlClient;

/// <summary>
/// Summary description for LoadPlayers
/// </summary>
public class LoadPlayers
{
    public LoadPlayers() { }

    private static SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=FootBallStatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    public  static List<StatPlayer> GetPlayers()
    {
        var dbManipulator = new Database_Manipulator();
        var players = new List<Player>();
        var statPlayers = new List<StatPlayer>();

        SqlCommand command;

        players = dbManipulator.SelectAllEntries();

        foreach(Player p in players)
        {
            var statIds = new List<int>();
            var stats = new List<Player_Stat>();
            string stat_string = "SELECT Player_Stat_Id FROM Player_Plays WHERE Player_Id = " + p.Id;
            command = new SqlCommand(stat_string, connection);

            connection.Open();
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    statIds.Add(reader.GetInt32(0));
                }
            }
            connection.Close();

            foreach (int stat in statIds)
            {
                string getStats = "SELECT * FROM Player_Stats WHERE Player_Stat_Id = " + stat;

                command = new SqlCommand(getStats, connection);
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        stats.Add(new Player_Stat(reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                            reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7),
                            reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11),
                            reader.GetInt32(12), reader.GetInt32(0)));
                    }
                }
                connection.Close();
            }
            statPlayers.Add(new StatPlayer(p, stats));
        }

        return statPlayers;
    }
}