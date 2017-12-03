using System;
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
            string filename = args[1];
            string line;

            StreamReader file = new StreamReader(filename);

            List<Player_Stat> player_stats = new List<Player_Stat>();

            while ((line = file.ReadLine()) != null)
            {
                Player_Stat current_stat = ParseLine(line);
                if(current_stat == null)
                    continue;
                else
                    player_stats.Add(current_stat);
            }

            file.Close();

        }

        static Player_Stat ParseLine(string line)
        {
            string[] split_line = line.Split(' ');

            if (split_line[0] == "None")
                return null;

            string name = split_line[0] + " " + split_line[1];

            int week_index = split_line.ToList().FindIndex((str => str == "Week:")) + 1;
            int rushyrds_index = split_line.ToList().FindIndex((str => str == "rushing_yds:")) + 1;
            int passyrds_index = split_line.ToList().FindIndex((str => str == "passing_yds:")) + 1;
            int recyard_index = split_line.ToList().FindIndex((str => str == "receiving_yds:")) + 1;
            int tds_index;
            int fumbled_index = split_line.ToList().FindIndex((str => str == "fumbles_lost:")) + 1;
            int intercept_thrown_index;
            int tackles_index = split_line.ToList().FindIndex((str => str == "defense_tkl:")) + 1;
            int sacks_index = split_line.ToList().FindIndex((str => str == "defense_sk:")) + 1;
            int forced_fumbles_index = split_line.ToList().FindIndex((str => str == "fumbles_forced:")) + 1;
            int interception_index = split_line.ToList().FindIndex((str => str == "defense_int:")) + 1;

            int week = Convert.ToInt32(split_line[week_index]);

            return new Player_Stat();
        }
    }
}
