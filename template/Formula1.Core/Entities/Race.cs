using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1.Core.Entities
{
    public class Race
    {
        public string City { get; set; }
        public int Number { get; set; }
    }
}
