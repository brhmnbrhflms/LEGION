using System;
using System.Collections.Generic;

namespace LEGION.Models
{
    public partial class Nabor
    {
        public Nabor()
        {
            Arenda = new HashSet<Arendum>();
        }

        public int Id { get; set; }
        public string ArendaComputer { get; set; } = null!;
        public TimeSpan TimeBegin { get; set; }
        public int Cost { get; set; }
        public TimeSpan TimeOut { get; set; }
        public int? DayBegin { get; set; }
        public int? DayEnd { get; set; }

        public virtual ICollection<Arendum> Arenda { get; set; }
    }
}
