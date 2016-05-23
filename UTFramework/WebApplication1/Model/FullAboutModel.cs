using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class FullAboutModel
    {
        public string CompanyName { get; set; }
        public DateTime FoundDateTime { get; set; }
        public bool ISSAAS { get; set; }
        public int MemberCount { get; set; }

        public List<MemberModel> Members { get; set; }
    }
}