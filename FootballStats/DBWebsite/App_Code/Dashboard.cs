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

    public List<StatPlayer> getFavoritePlayers(string username)
    {
        string user_string = "SELECT * FROM Users WHERE Username = \'" + username + "\'";

        SqlCommand command = new SqlCommand(user_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        var playerIds = new List<int>();
        var players = new List<Player>();
        var statPlayers = new List<StatPlayer>();
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
                var player = reader.GetInt32(1);
                playerIds.Add(player);
            }
        }

        connection.Close();
        foreach (int p in playerIds)
        {
            string getPlayers = "SELECT * FROM Players WHERE Player_Id = " + p;
            command = new SqlCommand(getPlayers, connection);

            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                players.Add(new Player(reader.GetInt32(2), reader.GetString(1), reader.GetInt32(0)));
            }
            connection.Close();
        }
        connection.Close();

        foreach (Player p in players)
        {
            var statIds = new List<int>();
            var stats = new List<Player_Stat>();
            string stat_string = "SELECT Player_Stat_Id FROM Player_Plays WHERE Player_Id = " + p.Id;
            command = new SqlCommand(stat_string, connection);

            connection.Open();
            reader = command.ExecuteReader();

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

    public List<Team> getFavoriteTeams(string username)
    {
        string user_string = "SELECT * FROM Users WHERE Username = \'" + username + "\'";

        SqlCommand command = new SqlCommand(user_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        var teamIds = new List<int>();
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
                var team = reader.GetInt32(1);
                teamIds.Add(team);
            }
        }

        connection.Close();

        foreach (int t in teamIds)
        {
            string getTeams = "SELECT * FROM Teams WHERE Team_Id = " + t;
            command = new SqlCommand(getTeams, connection);

            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                teams.Add(new Team(reader.GetString(1), reader.GetInt32(0)));
            }
            connection.Close();
        }
        connection.Close();

        return teams;
    }

    public void addFavPlayer(string player_name, string username)
    {
        var player_id = 0;

        //get player

        string getPlayer = "SELECT Player_Id FROM Players WHERE Player_Name = \'" + player_name + "\'";

        SqlCommand command = new SqlCommand(getPlayer, connection);

        connection.Open();
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            player_id = reader.GetInt32(0);
        }

        connection.Close();

        //get user

        string user_string = "SELECT * FROM Users WHERE Username = \'" + username + "\'";

        command = new SqlCommand(user_string, connection);

        connection.Open();
        reader = command.ExecuteReader();
        var user = new User();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                user = new User(reader.GetString(1), reader.GetString(2), reader.GetInt32(0));
            }
        }

        connection.Close();

        //insert fav player entry

        string insert_string = "INSERT INTO Fav_Player (Player_Id, User_Id) VALUES (" + player_id + "," + user.Id + ")";

        command = new SqlCommand(insert_string, connection);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void addFavTeam(string team_name, string username)
    {
        var team_id = 0;

        //get player

        string getTeam = "SELECT Team_Id FROM Teams WHERE Team_Name = \'" + team_name + "\'";

        SqlCommand command = new SqlCommand(getTeam, connection);

        connection.Open();
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            team_id = reader.GetInt32(0);
        }

        connection.Close();

        //get user

        string user_string = "SELECT * FROM Users WHERE Username = \'" + username + "\'";

        command = new SqlCommand(user_string, connection);

        connection.Open();
        reader = command.ExecuteReader();
        var user = new User();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                user = new User(reader.GetString(1), reader.GetString(2), reader.GetInt32(0));
            }
        }

        connection.Close();

        //insert fav player entry

        string insert_string = "INSERT INTO Fav_Team (Team_Id, User_Id) VALUES (" + team_id + "," + user.Id + ")";

        command = new SqlCommand(insert_string, connection);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}