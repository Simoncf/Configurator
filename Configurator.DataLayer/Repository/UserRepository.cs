using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        ProductConfiguratorEntities db = new ProductConfiguratorEntities();
        public bool ChangePassword(int id, byte[] hash, byte[] salt)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public User GetUser(string mail)
        {
            return db.Users.FirstOrDefault(x => x.LoginEmail == mail);
        }

        public User SaveUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
