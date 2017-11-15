using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class Player : IDatabaseEntry
    {
        private int _number;
        private string _name;

        #region ' Properties '

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
    }
}
