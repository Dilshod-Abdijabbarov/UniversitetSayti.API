using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Group
    {
        public Group()
        {
            Directions = new HashSet<Direction>();
        }

        public int Groupid { get; set; }
        public string Name { get; set; }
        public int Room { get; set; }
        public int? Studentid { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
