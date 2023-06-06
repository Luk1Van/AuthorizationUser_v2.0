using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DataModel;

namespace User.Services.Interfaces
{
    public interface IuserServices
    {
        public user DeleteUser(int id);
        public user AddUser(user User);
        public IEnumerable<user> GetLogin(string login, string password);
        public bool CheckLogin(user User);
        public Task<IEnumerable<object>> GetUserById(int id);
        public Task<IEnumerable<object>> GetUser();
        public Task<IEnumerable<object>> GetUserAsync();
    }
}
