using System.Collections;
using User.DataModel;
using User.DbContext;
using User.Services.Interfaces;

namespace User.Services
{
    public class userServices : IuserServices
    {
        private readonly UserDbContext _userDbContext;

        public userServices(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }


        public user AddUser(user user)
        {
            var admin = from u in _userDbContext.Users
                        where u.user_group_id == 2
                        select u;

            user realUser = user;

            if (admin.Count() > 0)
            {
                realUser.user_group_id = 1;
            }

            realUser.user_state_id = 1;
            _userDbContext.Users.Add(realUser);
            _userDbContext.SaveChanges();
            return realUser;
        }

        public bool CheckLogin(user User)
        {
            user check = User;
            var login = from u in _userDbContext.Users
                        where u.login == check.login && u.user_state_id == 1
                        select u;
            if (login.Count() > 0)
            {
                return false;
            }
            return true;
        }

        public user DeleteUser(int id)
        {
            var user = _userDbContext.Users.FirstOrDefault(c => c.id == id);
            user.user_state_id = 2;
            user.user_group_id = 1;
            _userDbContext.SaveChanges();
            return user;
        }


        public IEnumerable<user> GetLogin(string login, string password)
        {
            var result = from u in _userDbContext.Users
                         where u.login == login && u.password == password
                         select u;
            return result;
        }

        public async Task<IEnumerable<object>> GetUser()
        {
            var result = from u in _userDbContext.Users
                         join s in _userDbContext.user_States on u.user_state_id equals s.id
                         join g in _userDbContext.user_Groups on u.user_group_id equals g.id
                         select new
                         {
                             IdState = s.id,
                             CodeState = s.code,
                             DescriptionState = s.description,
                             IdGroup = g.id,
                             CodeGroup = g.code,
                             DescriptionGroup = g.description,
                         };
            return result;
        }

        public async Task<IEnumerable<object>> GetUserAsync()
        {
            var result = from u in _userDbContext.Users.AsParallel()
                         join s in _userDbContext.user_States on u.user_state_id equals s.id
                         join g in _userDbContext.user_Groups on u.user_group_id equals g.id
                         select new
                         {
                             IdState = s.id,
                             CodeState = s.code,
                             DescriptionState = s.description,
                             IdGroup = g.id,
                             CodeGroup = g.code,
                             DescriptionGroup = g.description,
                         };
            return result;
        }

        public async Task<IEnumerable<object>> GetUserById(int id)
        {
            var result = from u in _userDbContext.Users
                         join s in _userDbContext.user_States on u.user_state_id equals s.id
                         join g in _userDbContext.user_Groups on u.user_group_id equals g.id
                         where u.id == id
                         select new
                         {
                             IdState = s.id,
                             CodeState = s.code,
                             DescriptionState = s.description,
                             IdGroup = g.id,
                             CodeGroup = g.code,
                             DescriptionGroup = g.description,
                         };
            return result;
        }
    }
}