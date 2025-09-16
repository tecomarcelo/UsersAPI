using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Domain.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public override string Message
            => "Acesso negado. Usuário ou senha inválidos.";
    }
}
