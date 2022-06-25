using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Direction
    {
        public Direction()
        {
            Faculties = new HashSet<Faculty>();
        }

        public int Directionid { get; set; }
        public int? Groupid { get; set; }
        public int? Chairid { get; set; }
        public string Name { get; set; }

        public virtual Chair Chair { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
