using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Team_Play : IDatabaseEntry
    {
        int _id, _team_id, _team_stat_id;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Team_Id
        {
            get { return _team_id; }
        }

        public int Team_Stat_Id
        {
            get { return _team_stat_id; }
        }

        #endregion

        public Team_Play()
        { }

        public Team_Play(int teamid, int teamstatid)
        {
            _team_id = teamid;
            _team_stat_id = teamstatid;
        }

        public string GetTableName()
        {
            return "Team_Plays";
        }

        public void GetFields(out List<string> fields)
        {
            fields = new List<string>();
            fields.Add("TP_Id");
            fields.Add("Team_Id");
            fields.Add("Team_Stat_Id");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("Team_Id" + suffix, _team_id));
            parameters.Add(new KeyValuePair<string, object>("Team_Stat_Id" + suffix, _team_stat_id));

            return parameters;
        }

    }
}
