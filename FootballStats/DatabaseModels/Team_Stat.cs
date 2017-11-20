using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Team_Stat : IDatabaseEntry
    {
        int _id, _week, _year, _wins, _losses, _rush_yards, _pass_yards, _receiving_yards, _tds, _sacks, _interceptions, _forced_fumbles;

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

        public int Wins
        {
            get { return _wins; }
        }

        public int Losses
        {
            get { return _losses; }
        }

        public int Rush_Yards
        {
            get { return _rush_yards; }
        }

        public int Pass_Yards
        {
            get { return _pass_yards; }
        }

        public int Receiving_Yards
        {
            get { return _receiving_yards; }
        }

        public int TDs
        {
            get { return _tds; }
        }

        public int Sacks
        {
            get { return _sacks; }
        }

        public int Interceptions
        {
            get { return _interceptions; }
        }

        public int Forced_Fumbles
        {
            get { return _forced_fumbles; }
        }

        #endregion

        public Team_Stat()
        { }

        public Team_Stat(int wk, int yr, int wins, int losses, int rushyrds, int passyrds, int recyards, int tds, int sacks, int forcedfumbles, int interceptions, int id = 0)
        {
            _week = wk;
            _year = yr;
            _wins = wins;
            _losses = losses;
            _rush_yards = rushyrds;
            _pass_yards = passyrds;
            _receiving_yards = recyards;
            _tds = tds;
            _sacks = sacks;
            _forced_fumbles = forcedfumbles;
            _interceptions = interceptions;
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
            fields.Add("Wins");
            fields.Add("Losses");
            fields.Add("Rush_Yards");
            fields.Add("Pass_Yards");
            fields.Add("Receiving_Yards");
            fields.Add("TDs");
            fields.Add("Sacks");
            fields.Add("Interceptions");
            fields.Add("Forced_Fumbles");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("Team_Stat_Id", _id));
            
            parameters.Add(new KeyValuePair<string, object>("Week" + suffix, _week));
            parameters.Add(new KeyValuePair<string, object>("Year" + suffix, _year));
            parameters.Add(new KeyValuePair<string, object>("Wins" + suffix, _wins));
            parameters.Add(new KeyValuePair<string, object>("Losses" + suffix, _losses));
            parameters.Add(new KeyValuePair<string, object>("Rush_Yards" + suffix, _rush_yards));
            parameters.Add(new KeyValuePair<string, object>("Pass_Yards" + suffix, _pass_yards));
            parameters.Add(new KeyValuePair<string, object>("Receiving_Yards" + suffix, _receiving_yards));
            parameters.Add(new KeyValuePair<string, object>("TDs" + suffix, _tds));
            parameters.Add(new KeyValuePair<string, object>("Sacks" + suffix, _sacks));
            parameters.Add(new KeyValuePair<string, object>("Interceptions" + suffix, _interceptions));
            parameters.Add(new KeyValuePair<string, object>("Forced_Fumbles" + suffix, _forced_fumbles));

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
