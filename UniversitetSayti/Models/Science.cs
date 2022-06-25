using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Science
    {
        public Science()
        {
            Chairs = new HashSet<Chair>();
        }

        public int Scienceid { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }

        public virtual ICollection<Chair> Chairs { get; set; }
    }
}
