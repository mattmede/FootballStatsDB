using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Player_Stat
    {
        int _id, _week, _year, _rush_yards, _pass_yards, _receiving_yards, _tds, _fumbles, _interceptions_thrown, _tackles, _sacks, _forced_fumbles, _interceptions;

        #region ' Properties '

        public int Id
        {
            get { return _id; }
        }

        public int Week
        {
            get { return _week; }
        }

        public int Year
        {
            get { return _year; }
        }

        public int Rush_Yards
        {
            get { return _rush_yards; }
        }

        public int Pass_Yards
        {
            get { return _pass_yards; }
        }

        public int Receiving_Yards
        {
            get { return _receiving_yards; }
        }

        public int TDs
        {
            get { return _tds; }
        }

        public int Fumbles
        {
            get { return _fumbles; }
        }

        public int Interceptions_Thrown
        {
            get { return _interceptions_thrown; }
        }

        public int Tackles
        {
            get { return _tackles; }
        }

        public int Sacks
        {
            get { return _sacks; }
        }

        public int Forced_Fumbles
        {
            get { return _forced_fumbles; }
        }

        public int Interceptions
        {
            get { return _interceptions; }
        }

        #endregion
    }
}
