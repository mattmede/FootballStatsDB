using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Player : IDatabaseEntry
    {
        private int? _id, _number;
        private string _name;

        #region ' Properties '

        public int? Id
        {
            get { return _id; }
        }

        public int? Number
        {
            get { return _number; }
        }

        public string Name
        {
            get { return _name; }
        }

        #endregion  

        public Player ()
        { }

        public Player(int number, string name, int? id = 0)
        {
            _number = number;
            _name = name;
            _id = id;
        }

        public string GetTableName()
        {
            return "Players";
        }

        public void GetFields(out List<string> fields, bool need_id = false)
        {
            fields = new List<string>();
            if (need_id)
                fields.Add("Player_Id");

            fields.Add("Player_Number");
            fields.Add("Player_Name");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("Player_Id", _id));

            parameters.Add(new KeyValuePair<string, object>("Player_Number" + suffix, _number));
            parameters.Add(new KeyValuePair<string, object>("Player_Name" + suffix, _name));

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
