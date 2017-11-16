using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class User : IDatabaseEntry
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

        public string GetTableName()
        {
            return "Users";
        }

        public void GetFields(out List<string> fields)
        {
            fields = new List<string>();
            fields.Add("User_Id");
            fields.Add("Username");
            fields.Add("Password");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("User_Id" + suffix, _id));
            parameters.Add(new KeyValuePair<string, object>("Username" + suffix, _username));
            parameters.Add(new KeyValuePair<string, object>("Password" + suffix, _password));

            if (!onlyUniqueItems)
            {
                parameters.Add(new KeyValuePair<string, object>("Username" + suffix, _username));
                parameters.Add(new KeyValuePair<string, object>("Password" + suffix, _password));
            }

            return parameters;
        }

    }
}
