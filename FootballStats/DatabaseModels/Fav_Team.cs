using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Fav_Team : IDatabaseEntry
    {
        int _id,  _team_id,  _user_id;


        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Team_Id
        {
            get { return _team_id; }
        }

        public int User_Id
        {
            get { return _user_id; }
        }

        #endregion

        public Fav_Team()
        { }

        public Fav_Team(int teamid, int userid)
        {
            _team_id = teamid;
            _user_id = userid;
        }

        public string GetTableName()
        {
            return "Fav_Team";
        }

        public void GetFields(out List<string> fields)
        {
            fields = new List<string>();
            fields.Add("FT_Id");
            fields.Add("Team_Id");
            fields.Add("User_Id");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("Team_Id" + suffix, _team_id));
            parameters.Add(new KeyValuePair<string, object>("User_Id" + suffix, _user_id));

            return parameters;
        }

    }
}
