using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DataModel
{
    public class user_state
    {
        public user_state()
        {
            userS = new HashSet<user>();
        }
        public int id { get; set; }
        public EnumsState code { get; set; }
        public string description { get; set; }
        public ICollection<user> userS { get; set; }
    }

    public enum EnumsState
    {
        Active, Blocked
    }
}
