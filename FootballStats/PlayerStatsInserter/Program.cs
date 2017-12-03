using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseModels;
using DatabaseManipulation;
using System.IO;

namespace PlayerStatsInserter
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"../../../../nflgame_Data/player_stats.txt";
            string line;

            StreamReader file = new StreamReader(filename);

            List<KeyValuePair<int, Player_Stat>> player_stats = new List<KeyValuePair<int, Player_Stat>>();

            while ((line = file.ReadLine()) != null)
            {
                KeyValuePair<int, Player_Stat> current_stat = ParseLine(line);
                if (current_stat.Value == null)
                    continue;
                else
                    player_stats.Add(current_stat);
            }

            InsertPlayerStats(player_stats);

            file.Close();

        }

        static KeyValuePair<int, Player_Stat> ParseLine(string line)
        {
            string[] split_line = line.Split(' ');

            if (split_line[0] == "None")
                return new KeyValuePair<int, Player_Stat>(0, null);

            string name = split_line[0] + " " + split_line[1];

            int week_index = split_line.ToList().FindIndex((str => str == "Week:")) + 1;
            int rushyrds_index = split_line.ToList().FindIndex((str => str == "rushing_yds:")) + 1;
            int passyrds_index = split_line.ToList().FindIndex((str => str == "passing_yds:")) + 1;
            int recyard_index = split_line.ToList().FindIndex((str => str == "receiving_yds:")) + 1;
            int rec_tds_index = split_line.ToList().FindIndex((str => str == "receiving_tds:")) + 1;
            int rushing_tds_index = split_line.ToList().FindIndex((str => str == "rushing_tds:")) + 1;
            int rushing_lngtd_index = split_line.ToList().FindIndex((str => str == "rushing_lngtd:")) + 1;
            int rec_lngtd_index = split_line.ToList().FindIndex((str => str == "receiving_lngtd:")) + 1;
            int fumbled_index = split_line.ToList().FindIndex((str => str == "fumbles_lost:")) + 1;
            int intercept_thrown_index;
            int tackles_index = split_line.ToList().FindIndex((str => str == "defense_tkl:")) + 1;
            int sacks_index = split_line.ToList().FindIndex((str => str == "defense_sk:")) + 1;
            int forced_fumbles_index = split_line.ToList().FindIndex((str => str == "fumbles_forced:")) + 1;
            int interception_index = split_line.ToList().FindIndex((str => str == "defense_int:")) + 1;

            int rushyds = GetStatValue(rushyrds_index, split_line);
            int passyds = GetStatValue(passyrds_index, split_line);
            int recyard = GetStatValue(recyard_index, split_line);

            int rec_tds = GetStatValue(rec_tds_index, split_line);
            int rushing_tds = GetStatValue(rushing_tds_index, split_line);
            int rushing_lngtds = GetStatValue(rushing_lngtd_index, split_line);
            int rec_lngtd = GetStatValue(rec_lngtd_index, split_line);
            int tds = rec_tds + rushing_tds + rushing_lngtds + rec_lngtd;

            int fumbled = GetStatValue(fumbled_index, split_line);
            int tackles = GetStatValue(tackles_index, split_line);
            double sacks = GetSacks(sacks_index, split_line);
            int forced_fumbles = GetStatValue(forced_fumbles_index, split_line);
            int interceptions = GetStatValue(interception_index, split_line);

            int week = Convert.ToInt32(split_line[week_index]);

            name = name.Replace(@"'", @"''");

            string find_player_id_command = @"SELECT Player_Id FROM Players WHERE Player_Name = '" + name + @"';";
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=FootBallStatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand command = new SqlCommand(find_player_id_command, connection);

            connection.Open();
            var reader = command.ExecuteReader();


            reader.Read();

            int player_id = 0;

            try
            {
                player_id = reader.GetInt32(0);
            }
            catch
            {
                return new KeyValuePair<int, Player_Stat>(0, null);
            }

            connection.Close();

            return new KeyValuePair<int, Player_Stat>(player_id, new Player_Stat(week, 2016, rushyds, passyds, recyard, tds, fumbled, 0, tackles, sacks, forced_fumbles, interceptions));
        }

        static void InsertPlayerStats(List<KeyValuePair<int, Player_Stat>> stats)
        {
            Database_Manipulator manipulator = new Database_Manipulator();
            foreach (KeyValuePair<int, Player_Stat> stat in stats)
            {
                int stat_id = manipulator.Insert(stat.Value);
                manipulator.Insert(new Player_Play(stat.Key, stat_id));
            }
        }

        static int GetStatValue(int index, string[] split_line)
        {
            if (index == 0)
                return 0;
            else
            {
                split_line[index] = split_line[index].Replace(',', ' ');
                return Convert.ToInt32(split_line[index]);
            }
        }

        static double GetSacks(int index, string[] split_line)
        {
            if (index == 0)
                return 0;
            else
            {
                split_line[index] = split_line[index].Replace(',', ' ');
                return Convert.ToDouble(split_line[index]);
            }
        }
    }
}
