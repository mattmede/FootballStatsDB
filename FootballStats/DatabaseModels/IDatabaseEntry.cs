using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public interface IDatabaseEntry
    {
        string GetTableName();
        void GetFields(out List<string> fields);
        List<KeyValuePair<string, object>> GetKeyValuePairs(bool onlyUniqueItems = false, string suffix = "");
    }
}
