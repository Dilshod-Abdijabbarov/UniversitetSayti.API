using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class ChairEmployee
    {
        public ChairEmployee()
        {
            Chairs = new HashSet<Chair>();
        }

        public int Chairemployeeid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Rank { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Chair> Chairs { get; set; }
    }
}
