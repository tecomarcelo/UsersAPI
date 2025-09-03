using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;

namespace UsersAPI.Application.Interfaces.Application
{
    public interface IUserAppService : IDisposable
    {
        UserResponseDto Add(UserAddRequestDto dto);
        UserResponseDto Update(Guid id, UserUpdateRequestDto dto);
        UserResponseDto Delete(Guid id);
        UserResponseDto Get(Guid id);
    }
}
