using System;
using DatabaseManipulation;
using DatabaseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManipulatorTest
{
    [TestClass]
    public class UpdateTest
    {

        [TestMethod]
        public void Update_Player_Test()
        {
            Player player = new Player(43, "Football Guy", 1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Edit(player);
        }

        [TestMethod]
        public void Update_Team_Test()
        {
            Team team = new Team("Football Team 2", 1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Edit(team);
        }

        [TestMethod]
        public void Update_User_Test()
        {
            User user = new User("User 2", "Password 2", 1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Edit(user);
        }

        [TestMethod]
        public void Update_Player_Stat_Test()
        {
            Player_Stat player_Stat = new Player_Stat(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Edit(player_Stat);
        }

        [TestMethod]
        public void Update_Team_Stat_Test()
        {
            Team_Stat team_Stat = new Team_Stat(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            Database_Manipulator manipulator = new Database_Manipulator();
            manipulator.Edit(team_Stat);
        }


        //Commented out because they are hard to work with due to being all foreign keys
        //[TestMethod]
        //public void Update_Team_Play_Test()
        //{
        //    Team_Play team_play = new Team_Play(2, 2, 1);
        //    Database_Manipulator manipulator = new Database_Manipulator();
        //    manipulator.Edit(team_play);
        //}

        //[TestMethod]
        //public void Update_Player_Play_Test()
        //{
        //    Player_Play player_play = new Player_Play(2, 2, 1);
        //    Database_Manipulator manipulator = new Database_Manipulator();
        //    manipulator.Edit(player_play);
        //}

        //[TestMethod]
        //public void Update_Fav_Player_Test()
        //{
        //    Fav_Player fav_player = new Fav_Player(2, 2, 2);
        //    Database_Manipulator manipulator = new Database_Manipulator();
        //    manipulator.Edit(fav_player);
        //}

        //[TestMethod]
        //public void Update_Fav_Team_Test()
        //{
        //    Fav_Team fav_team = new Fav_Team(2, 2, 2);
        //    Database_Manipulator manipulator = new Database_Manipulator();
        //    manipulator.Edit(fav_team);
        //}
    }
}
