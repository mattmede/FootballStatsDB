using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Player_Play
    {
        int _id,  _player_id, _player_stat_id;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Player_Id
        {
            get { return _player_id; }
        }

        public int Player_Stat_Id
        {
            get { return _player_stat_id; }
        }

        #endregion

    }
}
