using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Fav_Team
    {
        int _id,  _team_id,  _user_id;


        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Team_Id
        {
            get { return _team_id; }
        }

        public int User_Id
        {
            get { return _user_id; }
        }

        #endregion
    }
}
