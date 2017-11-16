using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    class Team_Stat
    {
        int _id, _week, _year, _wins, _losses, _rush_yards, _pass_yards, _receiving_yards, _tds, _sacks, _interceptions, _forced_fumbles;

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

        public int Wins
        {
            get { return _wins; }
        }

        public int Losses
        {
            get { return _losses; }
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

        public int Sacks
        {
            get { return _sacks; }
        }

        public int Interceptions
        {
            get { return _interceptions; }
        }

        public int Forced_Fumbles
        {
            get { return _forced_fumbles; }
        }

        #endregion
    }
}
