using System;
using DatabaseManipulation;
using DatabaseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManipulatorTest
{
    [TestClass]
    public class DeleteTest
    {

        [TestMethod]
        public void Delete_Player_Test()
        {
            Player player = new Player(44, "Football Guy", 2);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(player);
        }

        [TestMethod]
        public void Delete_Team_Test()
        {
            Team team = new Team("Football Team", 2);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(team);
        }

        [TestMethod]
        public void Delete_User_Test()
        {
            User user = new User("User", "Password", 2);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(user);
        }

        [TestMethod]
        public void Delete_Fav_Player_Test()
        {
            Fav_Player fav_player = new Fav_Player(1, 1, 3);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(fav_player);
        }

        [TestMethod]
        public void Delete_Fav_Team_Test()
        {
            Fav_Team fav_team = new Fav_Team(1, 1, 3);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(fav_team);
        }

        [TestMethod]
        public void Delete_Player_Stat_Test()
        {
            Player_Stat player_Stat = new Player_Stat(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(player_Stat);
        }

        [TestMethod]
        public void Delete_Team_Stat_Test()
        {
            Team_Stat team_Stat = new Team_Stat(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(team_Stat);
        }

        [TestMethod]
        public void Delete_Team_Play_Test()
        {
            Team_Play team_play = new Team_Play(1, 1, 2);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(team_play);
        }

        [TestMethod]
        public void Delete_Player_Play_Test()
        {
            Player_Play player_play = new Player_Play(1, 1, 3);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Delete(player_play);
        }
    }
}
