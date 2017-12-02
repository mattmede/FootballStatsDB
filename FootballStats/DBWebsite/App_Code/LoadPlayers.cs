using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseManipulation;
using DatabaseModels;

/// <summary>
/// Summary description for LoadPlayers
/// </summary>
public class LoadPlayers
{
    public LoadPlayers() { }

    public  static List<Player> GetPlayers()
    {
        var dbManipulator = new Database_Manipulator();
        var players = new List<Player>();

        players = dbManipulator.SelectAllEntries();

        return players;
    }
}