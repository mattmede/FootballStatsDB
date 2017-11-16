using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Fav_Player
    {
        int _id, _player_id, _user_id;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Player_Id
        {
            get { return _player_id; }
        }

        public int User_Id
        {
            get { return _user_id; }
        }

        #endregion

    }
}
