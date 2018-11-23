using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Person
    {
        public Person()
        {
            Coach = new HashSet<Coach>();
            Player = new HashSet<Player>();
        }

        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Hometown { get; set; }
        public string Biography { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public ICollection<Coach> Coach { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}
