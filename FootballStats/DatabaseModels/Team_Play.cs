using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Team_Play
    {
        int _id, _team_id, _team_stat_id;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Team_Id
        {
            get { return _team_id; }
        }

        public int Team_Stat_Id
        {
            get { return _team_stat_id; }
        }

        #endregion

    }
}
