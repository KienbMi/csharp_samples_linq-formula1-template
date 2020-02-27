using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Core.Contracts;

namespace Formula1.Core.Entities
{
    public class TotalResultDto<T> where T : ICompetitor
    {
        public T Competitor { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return $"{Position} {Competitor.Name} {Points, -4}";
        }
    }
}
