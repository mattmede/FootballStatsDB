using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Player_Play : IDatabaseEntry
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

        public Player_Play(int playerid, int playerstatid)
        {
            _player_id = playerid;
            _player_stat_id = playerstatid;
        }


        public string GetTableName()
        {
            return "Player_Plays";
        }

        public void GetFields(out List<string> fields)
        {
            fields = new List<string>();
            fields.Add("PP_Id");
            fields.Add("Player_Id");
            fields.Add("Player_Stat_Id");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("Player_Id" + suffix, _player_id));
            parameters.Add(new KeyValuePair<string, object>("Player_Stat_Id" + suffix, _player_stat_id));

            return parameters;
        }
    }
}
