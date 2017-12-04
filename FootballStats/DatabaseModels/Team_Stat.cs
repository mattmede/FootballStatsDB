using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Team_Stat : IDatabaseEntry
    {
        int _id, _week, _year, _rush_yards, _pass_yards, _first_downs, _total_yards, _penalty_count, _penalty_yards, _turnovers, _punt_count, _punt_yards, _punt_average;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Week
        {
            get { return _week; }
        }

        public int Year
        {
            get { return _year; }
        }

        public int Rush_Yards
        {
            get { return _rush_yards; }
        }

        public int Pass_Yards
        {
            get { return _pass_yards; }
        }

        public int First_Downs
        {
            get { return _first_downs; }
        }

        public int Total_Yards
        {
            get { return _total_yards; }
        }

        public int Penalty_Count
        {
            get { return _penalty_count; }
        }

        public int Penalty_Yards
        {
            get { return _penalty_yards; }
        }

        public int Turnovers
        {
            get { return _turnovers; }
        }

        public int Punt_Count
        {
            get { return _punt_count; }
        }

        public int Punt_Yards
        {
            get { return _punt_yards; }
        }

        public int Punt_Average
        {
            get { return _punt_average; }
        }
        
        #endregion

        public Team_Stat()
        { }

        public Team_Stat(int wk, int yr, int rushyrds, int passyrds, int firstdowns, int totalyds, int pen_count, int pen_yds, int turnovers, int punt_count, int punt_yds, int punt_avg, int id = 0)
        {
            _week = wk;
            _year = yr;
            _rush_yards = rushyrds;
            _pass_yards = passyrds;
            _first_downs = firstdowns;
            _total_yards = totalyds;
            _penalty_count = pen_count;
            _penalty_yards = pen_yds;
            _turnovers = turnovers;
            _punt_count = punt_count;
            _punt_yards = punt_yds;
            _punt_average = punt_avg;
            _id = id;
        }

        public string GetTableName()
        {
            return "Team_Stats";
        }

        public void GetFields(out List<string> fields, bool need_id = false)
        {
            fields = new List<string>();

            if(need_id)
                fields.Add("Team_Stat_Id");

            fields.Add("Week");
            fields.Add("Year");
            fields.Add("Rush_Yards");
            fields.Add("Pass_Yards");
            fields.Add("First_Downs");
            fields.Add("Total_Yards");
            fields.Add("Penalty_Count");
            fields.Add("Penalty_Yards");
            fields.Add("Turnovers");
            fields.Add("Punt_Count");
            fields.Add("Punt_Yards");
            fields.Add("Punt_Average");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("Team_Stat_Id", _id));
            
            parameters.Add(new KeyValuePair<string, object>("Week" + suffix, _week));
            parameters.Add(new KeyValuePair<string, object>("Year" + suffix, _year));
            parameters.Add(new KeyValuePair<string, object>("Rush_Yards" + suffix, _rush_yards));
            parameters.Add(new KeyValuePair<string, object>("Pass_Yards" + suffix, _pass_yards));
            parameters.Add(new KeyValuePair<string, object>("First_Downs" + suffix, _first_downs));
            parameters.Add(new KeyValuePair<string, object>("Total_Yards" + suffix, _total_yards));
            parameters.Add(new KeyValuePair<string, object>("Penalty_Count" + suffix, _penalty_count));
            parameters.Add(new KeyValuePair<string, object>("Penalty_Yards" + suffix, _penalty_yards));
            parameters.Add(new KeyValuePair<string, object>("Turnovers" + suffix, _turnovers));
            parameters.Add(new KeyValuePair<string, object>("Punt_Count" + suffix, _punt_count));
            parameters.Add(new KeyValuePair<string, object>("Punt_Yards" + suffix, _punt_yards));
            parameters.Add(new KeyValuePair<string, object>("Punt_Average" + suffix, _punt_average));

            return parameters;
        }

        public string GetParameterString(List<KeyValuePair<string, object>> parameters, bool need_id = false, string suffix = "")
        {
            string parameter_string = "";

            parameters = GetKeyValuePairs(need_id, suffix);

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                if (parameter.Equals(parameters.First()))
                    parameter_string += " @" + parameter.Key;
                else
                    parameter_string += ", @" + parameter.Key;
            }

            return parameter_string;
        }
    }
}
