using DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class StatPlayer
{
    public Player player;
    public List<Player_Stat> player_stats;

    public StatPlayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public StatPlayer(Player p, List<Player_Stat> st)
    {
        player = p;
        player_stats = st;
    }
}

public class SummedPlayerStats
{
    public int total_yards;
    public int rush_yards;
    public int pass_yards;
    public int receiving_yards;
    public int tds;
    public int fumbles;
    public int interceptions_thrown;
    public int tackles;
    public int sacks;
    public int ffs;
    public int interceptions;

    public SummedPlayerStats()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SummedPlayerStats(List<Player_Stat> st)
    {
        foreach(Player_Stat ps in st)
        {
            rush_yards += ps.Rush_Yards;
            pass_yards += ps.Pass_Yards;
            receiving_yards += ps.Receiving_Yards;
            tds += ps.TDs;
            fumbles += ps.Fumbles;
            interceptions_thrown += ps.Interceptions_Thrown;
            tackles += ps.Tackles;
            sacks += ps.Sacks;
            ffs += ps.Forced_Fumbles;
            interceptions += ps.Interceptions;
        }

        total_yards = rush_yards + pass_yards + receiving_yards;
    }
}