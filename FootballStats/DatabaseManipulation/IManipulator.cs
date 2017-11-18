using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatabaseModels;

namespace DatabaseManipulator
{
    public interface IManipulator
    {
        void Insert(IDatabaseEntry entry);
        void Delete(IDatabaseEntry entry);
        void Edit(IDatabaseEntry entry);
        IDatabaseEntry SelectEntry(int id);
        List<IDatabaseEntry> SelectMultipleEntries(List<int> ids);
        void AddParameters(SqlCommand cmd, List<KeyValuePair<string, object>> parameters);
    } 
}
