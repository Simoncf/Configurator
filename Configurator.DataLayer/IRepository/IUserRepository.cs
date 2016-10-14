using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IUserRepository
    {
        User GetUser(string mail);
        IEnumerable<User> GetAllUsers();
        User SaveUser(User user);
        bool UpdateUser(User user);
        bool ChangePassword(int id, byte[] hash, byte[] salt);
    }
}
