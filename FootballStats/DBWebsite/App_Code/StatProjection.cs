using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Linq;
using DatabaseModels;

/// <summary>
/// Summary description for StatProjection
/// </summary>
public class StatProjection
{
    private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=FootBallStatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


    public StatProjection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Player_Stat GetProjectedPlayerStats(string player_name)
    {

        int player_id = GetPlayerId(player_name);

        List<int> stat_ids = GetPlayerStatsIds(player_id);

        return ProjectPlayerStats(stat_ids);
      
    }

    private int GetPlayerId(string name)
    {
        string find_player_id_command = @"SELECT Player_Id FROM Players WHERE Player_Name = '" + name + @"';";

        SqlCommand command = new SqlCommand(find_player_id_command, connection);

        connection.Open();
        var reader = command.ExecuteReader();

        reader.Read();

        int player_id = reader.GetInt32(0);
        
        connection.Close();

        return player_id;
    }

    private List<int> GetPlayerStatsIds(int player_id)
    {
        string get_plays_command = "SELECT Player_Stat_Id FROM Player_Plays WHERE Player_Id = " + player_id + ";";

        List<int> ids = new List<int>();

        SqlCommand command = new SqlCommand(get_plays_command, connection);

        connection.Open();

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            ids.Add(reader.GetInt32(0));
        }

        connection.Close();

        return ids;
    }

    private Player_Stat GetPlayerStat(int id)
    {
        string get_stats_command = "SELECT Rush_Yards, Pass_Yards, Receiving_Yards, TDs, Fumbles, Interceptions_Thrown, Tackles, Sacks, Forced_Fumbles, Interceptions FROM Player_Stats WHERE Player_Stat_Id = " + id;
        SqlCommand command = new SqlCommand(get_stats_command, connection);

        connection.Open();

        var reader = command.ExecuteReader();

        reader.Read();

        Player_Stat stat = new Player_Stat(0, 2016, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
        
        connection.Close();

        return stat;

    }


    private Player_Stat ProjectPlayerStats(List<int> stat_ids)
    {
        int rush_yards = 0, pass_yards = 0, receiving_yards = 0, tds = 0, fumbles = 0, interceptions_thrown = 0, tackles = 0, forced_fumbles = 0, interceptions = 0;
        int sacks = 0;

        
        foreach(int id in stat_ids)
        {
            Player_Stat stat = GetPlayerStat(id);

            rush_yards += stat.Rush_Yards;
            pass_yards += stat.Pass_Yards;
            receiving_yards += stat.Receiving_Yards;
            tds += stat.TDs;
            fumbles += stat.Fumbles;
            interceptions_thrown += stat.Interceptions_Thrown;
            tackles += stat.Tackles;
            sacks += stat.Sacks;
            forced_fumbles += stat.Forced_Fumbles;
            interceptions += stat.Interceptions;

        }

        rush_yards /= stat_ids.Count;
        pass_yards /= stat_ids.Count;
        receiving_yards /= stat_ids.Count;
        tds /= stat_ids.Count;
        fumbles /= stat_ids.Count;
        interceptions_thrown /= stat_ids.Count;
        tackles /= stat_ids.Count;
        forced_fumbles /= stat_ids.Count;
        interceptions /= stat_ids.Count;
        sacks /= stat_ids.Count;

        return new Player_Stat(0, 2016, rush_yards, pass_yards, receiving_yards, tds, fumbles, interceptions_thrown, tackles, sacks, forced_fumbles, interceptions);
    }


    public Team_Stat GetProjectedTeamStats(string team_name)
    {
        int team_id = GetTeamId(team_name);

        List<int> stat_ids = GetTeamStatsIds(team_id);

        return ProjectTeamStats(stat_ids);
    }

    private int GetTeamId(string name)
    {
        string find_player_id_command = @"SELECT Team_Id FROM Teams WHERE Team_Name = '" + name + @"';";

        SqlCommand command = new SqlCommand(find_player_id_command, connection);

        connection.Open();
        var reader = command.ExecuteReader();

        reader.Read();

        int team_id = reader.GetInt32(0);

        connection.Close();

        return team_id;
    }

    private List<int> GetTeamStatsIds(int team_id)
    {
        string get_plays_command = "SELECT Team_Stat_Id FROM Team_Plays WHERE Team_Id = " + team_id + ";";

        List<int> ids = new List<int>();

        SqlCommand command = new SqlCommand(get_plays_command, connection);

        connection.Open();

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            ids.Add(reader.GetInt32(0));
        }

        connection.Close();

        return ids;
    }

    private Team_Stat GetTeamStat(int id)
    {
        string get_stats_command = "SELECT Rush_Yards, Pass_Yards, First_Downs, Total_Yards, Penalty_Count, Penalty_Yards, Turnovers, Punt_Count, Punt_Yards, Punt_Average FROM Team_Stats WHERE Team_Stat_Id = " + id;
        SqlCommand command = new SqlCommand(get_stats_command, connection);

        connection.Open();

        var reader = command.ExecuteReader();

        reader.Read();

        Team_Stat stat = new Team_Stat(0, 2016, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));

        connection.Close();

        return stat;

    }


    private Team_Stat ProjectTeamStats(List<int> stat_ids)
    {
        int rush_yards = 0, pass_yards = 0, first_downs = 0, total_yards = 0, penalty_count = 0, penalty_yards = 0, turnovers = 0, punt_count = 0, punt_yards = 0, punt_average = 0;

        foreach (int id in stat_ids)
        {
            Team_Stat stat = new Team_Stat();
                stat = GetTeamStat(id);

            rush_yards += stat.Rush_Yards;
            pass_yards += stat.Pass_Yards;
            //first_downs += stat.First_Downs;
            //total_yards += stat.Total_Yards;
            //penalty_count += stat.Penalty_Count;
            //penalty_yards += stat.Penalty_Yards;
            //turnovers += stat.Turnovers;
            //punt_count += stat.Punt_Count;
            //punt_yards += stat.Punt_Yards;
            //punt_average += stat.Punt_Average;

        }

        rush_yards /= stat_ids.Count;
        pass_yards /= stat_ids.Count;
        first_downs /= stat_ids.Count;
        total_yards /= stat_ids.Count;
        penalty_count /= stat_ids.Count;
        penalty_yards /= stat_ids.Count;
        turnovers /= stat_ids.Count;
        punt_count /= stat_ids.Count;
        punt_yards /= stat_ids.Count;
        punt_average /= stat_ids.Count;

        var  teamstat = new Team_Stat(0, 2016, rush_yards, pass_yards, first_downs, total_yards, penalty_count, penalty_yards, turnovers, punt_count, punt_yards, punt_average);

        return teamstat;
    }
}