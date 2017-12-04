using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBaseModels;
using System.Data.SqlClient;

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

    public Player_Stat GetProjectedStats(string player_name)
    {

        int player_id = GetPlayerId(player_name);

        List<int> stat_ids = GetPlayerStatsIds(player_id);

        return ProjectStats(stat_ids);
      
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
        string get_stats_command = "SELECT (Rush_Yards, Pass_Yards, Receiving_Yards, TDs, Fumbles, Interceptions_Thrown, Tackles, Sacks, Forced_Fubmles, Interceptions) FROM Player_Stats WHERE Player_Stat_Id = " + id;
        SqlCommand command = new SqlCommand(get_stats_command, connection);

        connection.Open();

        var reader = command.ExecuteReader();

        reader.Read();

        Player_Stat stat = new Player_Stat(0, 2016, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
        
        connection.Close();

        return stat;

    }


    private Player_Stat ProjectStats(List<int> stat_ids)
    {
        int rush_yards = 0, pass_yards = 0, receiving_yards = 0, tds = 0, fumbles = 0, interceptions_thrown = 0, tackles = 0, forced_fumbles = 0, interceptions = 0;
        double sacks = 0;

        
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
            forced_fumbles += stat.ForcedFumbles;
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
    
}