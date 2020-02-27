using Formula1.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Core.Entities
{
    public class Driver : ICompetitor
    {
        public string Name { get; }

        public Driver(string driverName)
        {
            Name = driverName;
        }
    }
}
