using System;
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
            string filename = args[1];
            string line;

            StreamReader file = new StreamReader(filename);

            while ((line = file.ReadLine()) != null)
            {

            }

            file.Close();

        }

        static Team_Stat ParseLine(string line)
        {
            string[] split_line = line.Split(' ');

            if (split_line[0] == "None")
                return null;
            

            int week_index = split_line.ToList().FindIndex((str => str == "Week:")) + 1;
            int rushyds_index = split_line.ToList().FindIndex((str => str.Contains("rushing_yds")));
            int passyds_index = split_line.ToList().FindIndex((str => str.Contains("passing_yds")));
            int recyds_index;
            int tds_index;
            int sacks_index;
            int forcedfumbles_index;
            int interceptions_index;


            int week = Convert.ToInt32(split_line[week_index]);

            return new Team_Stat();
        }
    }
}
