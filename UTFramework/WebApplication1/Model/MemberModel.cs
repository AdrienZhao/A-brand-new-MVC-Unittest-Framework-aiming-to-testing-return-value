using System.Collections.Generic;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class MemberModel
    {
        public string Name { get; set; }
        public bool female { get; set; }
        public int PhoneNumber { get; set; }

        public List<ParentModel> parents { get; set; }
    }
}
