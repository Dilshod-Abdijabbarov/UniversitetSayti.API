using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Student
    {
        public Student()
        {
            Groups = new HashSet<Group>();
        }

        public int Studentid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasportSeria { get; set; }
        public int? Pasportnumber { get; set; }
        public string Addres { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
