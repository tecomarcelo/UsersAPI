using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;

namespace UsersAPI.Application.Interfaces.Application
{
    public interface IAuthAppService : IDisposable
    {
        LoginResponseDto Login(LoginRequestDto dto);
        UserResponseDto ForgotPassword(ForgotPasswordRequestDto dto);
        UserResponseDto ResetPassword(Guid id, ResetPasswordRequestDto dto);
    }
}
