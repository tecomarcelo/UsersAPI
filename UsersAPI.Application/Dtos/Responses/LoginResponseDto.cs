using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Application.Dtos.Responses
{
    public class LoginResponseDto
    {
        public string? AccessToken { get; set; }
        public DateTime? Expiration { get; set; }
        public UserResponseDto? User { get; set; }
    }
}
