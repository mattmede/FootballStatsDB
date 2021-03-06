﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Player_Stat : IDatabaseEntry
    {
        int _id, _week, _year, _rush_yards, _pass_yards, _receiving_yards, _tds, _fumbles, _interceptions_thrown, _tackles, _forced_fumbles, _interceptions;
        double _sacks;
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

        public int Receiving_Yards
        {
            get { return _receiving_yards; }
        }

        public int TDs
        {
            get { return _tds; }
        }

        public int Fumbles
        {
            get { return _fumbles; }
        }

        public int Interceptions_Thrown
        {
            get { return _interceptions_thrown; }
        }

        public int Tackles
        {
            get { return _tackles; }
        }

        public double Sacks
        {
            get { return _sacks; }
        }

        public int Forced_Fumbles
        {
            get { return _forced_fumbles; }
        }

        public int Interceptions
        {
            get { return _interceptions; }
        }

        #endregion

        public Player_Stat()
        { }

        public Player_Stat(int wk, int yr, int rushyrds, int passyrds, int recyards, int tds, int fumbles, int intercep_thrown, int tackles, double sacks, int forcedfumbles, int interceptions, int id = 0)
        {
            _week = wk;
            _year = yr;
            _rush_yards = rushyrds;
            _pass_yards = passyrds;
            _receiving_yards = recyards;
            _tds = tds;
            _fumbles = fumbles;
            _interceptions_thrown = intercep_thrown;
            _tackles = tackles;
            _sacks = sacks;
            _forced_fumbles = forcedfumbles;
            _interceptions = interceptions;
            _id = id;
        }

        public string GetTableName()
        {
            return "Player_Stats";
        }

        public void GetFields(out List<string> fields, bool need_id = false)
        {
            fields = new List<string>();

            if(need_id)
                fields.Add("Player_Stat_Id");

            fields.Add("Week");
            fields.Add("Year");
            fields.Add("Rush_Yards");
            fields.Add("Pass_Yards");
            fields.Add("Receiving_Yards");
            fields.Add("TDs");
            fields.Add("Fumbles");
            fields.Add("Interceptions_Thrown");
            fields.Add("Tackles");
            fields.Add("Sacks");
            fields.Add("Forced_Fumbles");
            fields.Add("Interceptions");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("Player_Stat_Id", _id));
            
            parameters.Add(new KeyValuePair<string, object>("Week" + suffix, _week));
            parameters.Add(new KeyValuePair<string, object>("Year" + suffix, _year));
            parameters.Add(new KeyValuePair<string, object>("Rush_Yards" + suffix, _rush_yards));
            parameters.Add(new KeyValuePair<string, object>("Pass_Yards" + suffix, _pass_yards));
            parameters.Add(new KeyValuePair<string, object>("Receiving_Yards" + suffix, _receiving_yards));
            parameters.Add(new KeyValuePair<string, object>("TDs" + suffix, _tds));
            parameters.Add(new KeyValuePair<string, object>("Fumbles" + suffix, _fumbles));
            parameters.Add(new KeyValuePair<string, object>("Interceptions_Thrown" + suffix, _interceptions_thrown));
            parameters.Add(new KeyValuePair<string, object>("Tackles" + suffix, _tackles));
            parameters.Add(new KeyValuePair<string, object>("Sacks" + suffix, _sacks));
            parameters.Add(new KeyValuePair<string, object>("Forced_Fumbles" + suffix, _forced_fumbles));
            parameters.Add(new KeyValuePair<string, object>("Interceptions" + suffix, _interceptions));

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
