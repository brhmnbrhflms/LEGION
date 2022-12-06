using System;
using System.Collections.Generic;

namespace LEGION.Models
{
    public partial class Arendum
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PackId { get; set; }
        public int UserId { get; set; }
        public DateTime DateArenda { get; set; }

        public virtual Nabor Pack { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
