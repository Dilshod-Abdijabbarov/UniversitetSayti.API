using System;
using System.Collections.Generic;

#nullable disable

namespace UniversitetSayti.Models
{
    public partial class News
    {
        public int Newsid { get; set; }
        public string Title { get; set; }
        public byte[] Picture { get; set; }
        public string Video { get; set; }
    }
}
