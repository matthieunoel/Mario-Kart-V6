using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionMKV6
{
    class ClassePasserelle
    {
        private const string DbString = "va-11 hall-a";

        private int testvar { get; set; }

        public ClassePasserelle()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool SendTournamentInfoToBase()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Tournament> GetAllTournaments()
        {
            return new List<Tournament>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TournamentId"></param>
        /// <returns></returns>
        Tournament GetTournamentInfo(int TournamentId)
        {
            return new Tournament();
        }
    }

    class Tournament
    {

    }


}
