using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DataModel
{
    public class user_group
    {
        public user_group()
        {
            userG = new HashSet<user>();
        }
        public int id { get; set; }
        public EnumsGroup code { get; set; }
        public string description { get; set; }
        public ICollection<user> userG { get; set; }
    }

    public enum EnumsGroup
    {
        Admin, User
    }
}
