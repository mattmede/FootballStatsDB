using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Team : IDatabaseEntry
    {

        int _id;
        string _name;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        #endregion

        public Team()
        { }

        public Team(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public string GetTableName()
        {
            return "Teams";
        }

        public void GetFields(out List<string> fields, bool need_id = false)
        {
            fields = new List<string>();

            if(need_id)
                fields.Add("Team_Id");

            fields.Add("Team_Name");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("Team_Id", _id));

            parameters.Add(new KeyValuePair<string, object>("Team_Name" + suffix, _name));

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
