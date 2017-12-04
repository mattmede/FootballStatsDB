using System;
using DatabaseManipulation;
using DatabaseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManipulatorTest
{
    [TestClass]
    public class InsertTest
    {
        [TestMethod]
        public void Insert_Player_Test()
        {
            Player player = new Player(44, "Football Guy");
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(player);
        }

        [TestMethod]
        public void Insert_Team_Test()
        {
            Team team = new Team("Football Team");
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(team);
        }

        [TestMethod]
        public void Insert_User_Test()
        {
            User user = new User("User", "Password");
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(user);
        }

        [TestMethod]
        public void Insert_Fav_Player_Test()
        {
            Fav_Player fav_player = new Fav_Player(1,1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(fav_player);
        }

        [TestMethod]
        public void Insert_Fav_Team_Test()
        {
            Fav_Team fav_team = new Fav_Team(1, 1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(fav_team);
        }

        [TestMethod]
        public void Insert_Player_Stat_Test()
        {
            Player_Stat player_Stat = new Player_Stat(0,0,0,0,0,0,0,0,0,0,0,0);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(player_Stat);
        }

        [TestMethod]
        public void Insert_Team_Stat_Test()
        {
            Team_Stat team_Stat = new Team_Stat(0,0,0,0,0,0,0,0,0,0,0,0);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(team_Stat);
        }

        [TestMethod]
        public void Insert_Team_Play_Test()
        {
            Team_Play team_play = new Team_Play(1,1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(team_play);
        }

        [TestMethod]
        public void Insert_Player_Play_Test()
        {
            Player_Play player_play = new Player_Play(1,1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Insert(player_play);
        }


    }
}
