using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Domain.ValueObjects;

namespace UsersAPI.Domain.Interfaces.Security
{
    public interface ITokenService
    {
        string CreateToken(UserAuthVO userAuth);
    }
}
