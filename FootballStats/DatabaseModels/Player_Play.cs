using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Player_Play : IDatabaseEntry
    {
        int _id,  _player_id, _player_stat_id;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Player_Id
        {
            get { return _player_id; }
        }

        public int Player_Stat_Id
        {
            get { return _player_stat_id; }
        }

        #endregion

        public Player_Play()
        { }

        public Player_Play(int playerid, int playerstatid, int id = 0)
        {
            _player_id = playerid;
            _player_stat_id = playerstatid;
            _id = id;
        }


        public string GetTableName()
        {
            return "Player_Plays";
        }

        public void GetFields(out List<string> fields, bool need_id = false)
        {
            fields = new List<string>();

            if(need_id)
                fields.Add("PP_Id");

            fields.Add("Player_Id");
            fields.Add("Player_Stat_Id");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("PP_Id", _id));

            parameters.Add(new KeyValuePair<string, object>("Player_Id" + suffix, _player_id));
            parameters.Add(new KeyValuePair<string, object>("Player_Stat_Id" + suffix, _player_stat_id));

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
