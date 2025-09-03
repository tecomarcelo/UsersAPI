using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Application.Dtos.Requests
{
    public class ForgotPasswordRequestDto
    {
        [Required(ErrorMessage = "Informe o email do usuário.")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string? Email { get; set; }
    }
}
