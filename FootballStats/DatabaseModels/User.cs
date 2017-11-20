using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class User : IDatabaseEntry
    {
        int _id;
        string _username, _password;

        #region ' Properties ' 

        public int Id
        {
            get { return _id; }
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }

        #endregion

        public User()
        { }

        public User(string username, string password, int id = 0)
        {
            _username = username;
            _password = password;
            _id = id;
        }

        public string GetTableName()
        {
            return "Users";
        }

        public void GetFields(out List<string> fields, bool need_id = false)
        {
            fields = new List<string>();
            
            if(need_id)
                fields.Add("User_Id");

            fields.Add("Username");
            fields.Add("Password");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();

            if (need_id)
                parameters.Add(new KeyValuePair<string, object>("User_Id", _id));

            parameters.Add(new KeyValuePair<string, object>("Username" + suffix, _username));
            parameters.Add(new KeyValuePair<string, object>("Password" + suffix, _password));

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
