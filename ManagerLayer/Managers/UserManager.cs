using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public RegisterModel RegisterUser(RegisterModel register)
        {
            return this.repository.RegisterUser(register);
        }

        public LoginModel loginUser(LoginModel login)
        {
            return this.repository.loginUser(login);
        }
    }
}
