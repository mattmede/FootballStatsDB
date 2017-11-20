using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Fav_Team : IDatabaseEntry
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

        public void GetFields(out List<string> fields, bool need_id = false)
        {
            fields = new List<string>();
            if(need_id)
                fields.Add("FT_Id");

            fields.Add("Team_Id");
            fields.Add("User_Id");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("FT_Id", _id));

            parameters.Add(new KeyValuePair<string, object>("Team_Id" + suffix, _team_id));
            parameters.Add(new KeyValuePair<string, object>("User_Id" + suffix, _user_id));

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
