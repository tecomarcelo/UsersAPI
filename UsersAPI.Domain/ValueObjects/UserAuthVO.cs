using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Domain.ValueObjects
{
    public class UserAuthVO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; } //perfil
        public DateTime SignedAt { get; set; }
    }
}
