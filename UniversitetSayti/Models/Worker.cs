using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class Worker
    {
        public int Workerid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Addres { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
    }
}
