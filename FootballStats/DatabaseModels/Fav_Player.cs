using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Fav_Player : IDatabaseEntry
    {
        int _id, _player_id, _user_id;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Player_Id
        {
            get { return _player_id; }
        }

        public int User_Id
        {
            get { return _user_id; }
        }

        #endregion

        public Fav_Player()
        { }

        public Fav_Player(int player_id, int user_id)
        {
            _player_id = player_id;
            _user_id = user_id;
        }

        public string GetTableName()
        {
            return "Fav_Player";
        }

        public void GetFields(out List<string> fields)
        {
            fields = new List<string>();
            fields.Add("FP_Id");
            fields.Add("Player_Id");
            fields.Add("User_Id");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("Player_Id" + suffix, _player_id));
            parameters.Add(new KeyValuePair<string, object>("User_Id" + suffix, _user_id));

            return parameters;
        }

    }
}
