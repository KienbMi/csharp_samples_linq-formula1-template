using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Core.Entities;

namespace Formula1.Core
{
    public class ResultCalculator
    {
        /// <summary>
        /// Berechnet aus den Ergebnissen den aktuellen WM-Stand für die Fahrer
        /// </summary>
        /// <returns>DTO für die Fahrerergebnisse</returns>
        public static IEnumerable<TotalResultDto<Driver>> GetDriverWmTable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Berechnet aus den Ergebnissen den aktuellen WM-Stand für die Teams
        /// </summary>
        /// <returns>DTO für die Teamergebnisse</returns>
        public static IEnumerable<TotalResultDto<Team>> GetTeamWmTable()
        {
            throw new NotImplementedException();
        }
    }
}



