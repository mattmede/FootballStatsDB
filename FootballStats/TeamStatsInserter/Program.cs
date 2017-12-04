using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseModels;
using DatabaseManipulation;
using System.IO;

namespace TeamStatsInserter
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"../../../../nflgame_Data/team_stats.txt";
            string line;

            StreamReader file = new StreamReader(filename);

            List<KeyValuePair<int, Team_Stat>> team_stats = new List<KeyValuePair<int, Team_Stat>>();

            while ((line = file.ReadLine()) != null)
            {
                KeyValuePair<int, Team_Stat> current_stat = ParseLine(line);
                if (current_stat.Value == null)
                    continue;
                else
                    team_stats.Add(current_stat);
            }

            InsertTeamStats(team_stats);

            file.Close();

        }

        static KeyValuePair<int,Team_Stat> ParseLine(string line)
        {
            string[] split_line = line.Split(' ');

            string name = split_line[0];

            int week_index = split_line.ToList().FindIndex((str => str == "Week:")) + 1;
            int rushyds_index = split_line.ToList().FindIndex((str => str.Contains("rushing_yds")));
            int passyds_index = split_line.ToList().FindIndex((str => str.Contains("passing_yds")));
            int first_downs_index = split_line.ToList().FindIndex((str => str.Contains("first_downs")));
            int total_yards_index = split_line.ToList().FindIndex((str => str.Contains("total_yards")));
            int penalty_count_index = split_line.ToList().FindIndex((str => str.Contains("penalty_cnt")));
            int penalty_yards_index = split_line.ToList().FindIndex((str => str.Contains("penalty_yds")));
            int turnovers_index = split_line.ToList().FindIndex((str => str.Contains("turnovers")));
            int punt_count_index = split_line.ToList().FindIndex((str => str.Contains("punt_cnt")));
            int punt_yards_index = split_line.ToList().FindIndex((str => str.Contains("punt_yds")));
            int punt_average_index = split_line.ToList().FindIndex((str => str.Contains("punt_avg")));

            int week = Convert.ToInt32(split_line[week_index]);

            int rush_yards = GetStatValue(rushyds_index, split_line);
            int pass_yards = GetStatValue(passyds_index, split_line);
            int first_downs = GetStatValue(first_downs_index, split_line);
            int total_yards = GetStatValue(total_yards_index, split_line);
            int penalty_count = GetStatValue(penalty_count_index, split_line);
            int penalty_yards = GetStatValue(penalty_yards_index, split_line);
            int turnovers = GetStatValue(turnovers_index, split_line);
            int punt_count = GetStatValue(punt_count_index, split_line);
            int punt_yards = GetStatValue(punt_yards_index, split_line);
            int punt_average = GetStatValue(punt_average_index, split_line);

            string find_player_id_command = @"SELECT Team_Id FROM Teams WHERE Team_Name = '" + name + @"';";
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=FootBallStatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand command = new SqlCommand(find_player_id_command, connection);

            connection.Open();
            var reader = command.ExecuteReader();


            reader.Read();

            int team_id = 0;

            try
            {
                team_id = reader.GetInt32(0);
            }
            catch
            {
                return new KeyValuePair<int, Team_Stat>(0, null);
            }

            connection.Close();


            return new KeyValuePair<int, Team_Stat>(team_id, new Team_Stat(week, 2016, rush_yards, pass_yards, first_downs, total_yards, penalty_count, penalty_yards, turnovers, punt_count, punt_yards, punt_average));
        }

        static int GetStatValue(int index, string[] split_string)
        {
            if (index <= 0)
                return 0;
            else
            {
                return Convert.ToInt32(split_string[index].Split('=')[1].Replace(',', ' '));
            }
        }

        static void InsertTeamStats(List<KeyValuePair<int, Team_Stat>> stats)
        {
            Database_Manipulator manipulator = new Database_Manipulator();
            foreach (KeyValuePair<int, Team_Stat> stat in stats)
            {
                int stat_id = manipulator.Insert(stat.Value);
                manipulator.Insert(new Team_Play(stat.Key, stat_id));
            }
        }
    }
}
