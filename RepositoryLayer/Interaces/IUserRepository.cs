using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interaces
{
    public interface IUserRepository
    {
         RegisterModel RegisterUser(RegisterModel register);
         LoginModel loginUser(LoginModel login);
    }
}
