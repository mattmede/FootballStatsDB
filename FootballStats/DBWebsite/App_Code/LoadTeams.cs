using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseManipulation;
using DatabaseModels;

/// <summary>
/// Summary description for LoadPlayers
/// </summary>
public class LoadTeams
{
    public LoadTeams() { }

    public static List<Team> GetTeams()
    {
        var dbManipulator = new Database_Manipulator();
        var teams = new List<Team>();

        teams = dbManipulator.SelectAllTeams();

        return teams;
    }
}