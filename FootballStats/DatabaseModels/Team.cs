﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Team : IDatabaseEntry
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

        public string GetTableName()
        {
            return "Teams";
        }

        public void GetFields(out List<string> fields)
        {
            fields = new List<string>();
            fields.Add("Team_Id");
            fields.Add("Name");
        }

        public List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "")
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>("Team_Id" + suffix, _id));
            parameters.Add(new KeyValuePair<string, object>("Name" + suffix, _name));

            if (!onlyUniqueItems)
            {
                parameters.Add(new KeyValuePair<string, object>("Name" + suffix, _name));
            }

            return parameters;
        }

    }
}