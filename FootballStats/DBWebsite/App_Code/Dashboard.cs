using DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Dashnboard
/// </summary>
public class Dashboard
{
    public Dashboard() { }

    private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=FootBallStatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    public List<Player> getFavoritePlayers(string username)
    {
        string user_string = "SELECT * FROM Users WHERE Username = \'" + username + "\'";

        SqlCommand command = new SqlCommand(user_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        var players = new List<Player>();
        var user = new User();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                user = new User(reader.GetString(1), reader.GetString(2), reader.GetInt32(0));
            }
        }

        connection.Close();

        string favPlayers_string = "SELECT * FROM Fav_Player WHERE User_Id = " + user.Id;

        command = new SqlCommand(favPlayers_string, connection);

        connection.Open();
        reader = command.ExecuteReader();

        //run when you get fav players
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var player = new Player(reader.GetInt32(2), reader.GetString(1), reader.GetInt32(0));
                players.Add(player);
            }
        }

        connection.Close();

        return players;
    }

    public List<Team> getFavoriteTeams(string username)
    {
        string user_string = "SELECT * FROM Users WHERE Username = \'" + username + "\'";

        SqlCommand command = new SqlCommand(user_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        var teams = new List<Team>();
        var user = new User();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                user = new User(reader.GetString(1), reader.GetString(2), reader.GetInt32(0));
            }
        }

        connection.Close();

        string favTeams_string = "SELECT * FROM Fav_Team WHERE User_Id = " + user.Id;

        command = new SqlCommand(favTeams_string, connection);

        connection.Open();
        reader = command.ExecuteReader();

        //run when you get fav players
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var player = new Team(reader.GetString(1), reader.GetInt32(0));
                teams.Add(player);
            }
        }

        connection.Close();

        return teams;
    }
}