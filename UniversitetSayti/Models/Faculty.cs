using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Faculty
    {
        public int Facultyid { get; set; }
        public string Name { get; set; }
        public string News { get; set; }
        public int? Directionid { get; set; }

        public virtual Direction Direction { get; set; }
    }
}
