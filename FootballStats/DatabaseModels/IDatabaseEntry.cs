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
        void GetFields(out List<string> fields, bool need_id = false);
        string GetParameterString(List<KeyValuePair<string, object>> parameters, bool need_id = false, string suffix = "");
        List<KeyValuePair<string, object>> GetKeyValuePairs(bool need_id = false, string suffix = "");
    }
}
