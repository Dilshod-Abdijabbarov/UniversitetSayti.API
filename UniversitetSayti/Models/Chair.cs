using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Chair
    {
        public Chair()
        {
            Directions = new HashSet<Direction>();
        }

        public int Chairid { get; set; }
        public string Information { get; set; }
        public int? Chairemployeeid { get; set; }
        public int? Scienceid { get; set; }

        public virtual ChairEmployee Chairemployee { get; set; }
        public virtual Science Science { get; set; }
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
