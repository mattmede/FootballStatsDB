using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Player : IDatabaseEntry
    {
        private int _id, _number;
        private string _name;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Number
        {
            get { return _number; }
        }

        public string Name
        {
            get { return _name; }
        }

        #endregion  

        public string GetTableName()
        {
            return "Players";
        }

        public void GetFields(out List<string> fields)
        {
            fields = new List<string>();
            fields.Add("Number");
            fields.Add("Name");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("Player_Id" + suffix, _id));
            parameters.Add(new KeyValuePair<string, object>("Name" + suffix, _name));
            parameters.Add(new KeyValuePair<string, object>("Number" + suffix, _number));

            if (!onlyUniqueItems)
            {
                parameters.Add(new KeyValuePair<string, object>("Name" + suffix, _name));
                parameters.Add(new KeyValuePair<string, object>("Number" + suffix, _number));
            }

            return parameters;
        }
    }
}
