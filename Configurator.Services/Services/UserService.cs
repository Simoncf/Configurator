using Configurator.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Services.ServiceModels;
using Configurator.DataLayer.IRepository;

namespace Configurator.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var list = new List<UserModel>();
            foreach (var u in users)
            {
                var i = new UserModel();
                i.Id = u.Id;
                i.FirstName = u.FirstName;
                i.LastName = u.LastName;
                i.LoginEmail = u.LoginEmail;
                i.Password = u.Password;
                i.Address = u.Address;
                i.Telephone = u.Telephone;
                i.Company = u.Company;
                i.IsAdmin = u.IsAdmin;
                list.Add(i);
            }
            return list;
        }

        public UserModel GetUser(string mail)
        {
            var u = _userRepository.GetUser(mail);
            var i = new UserModel();
            i.Id = u.Id;
            i.FirstName = u.FirstName;
            i.LastName = u.LastName;
            i.LoginEmail = u.LoginEmail;
            i.Password = u.Password;
            i.Address = u.Address;
            i.Telephone = u.Telephone;
            i.Company = u.Company;
            i.IsAdmin = u.IsAdmin;

            return i;
        }
    }
}
