using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Interfaces.Services;
using UsersAPI.Domain.Models;

namespace UsersAPI.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService? _userDomainService;
        private readonly IMapper? _mapper;

        public UserAppService(IUserDomainService? userDomainService, IMapper? mapper)
        {
            _userDomainService = userDomainService;
            _mapper = mapper;
        }

        public UserResponseDto Add(UserAddRequestDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = DateTime.Now
            };

            _userDomainService?.Add(user);

            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Update(Guid id, UserUpdateRequestDto dto)
        {
            var user = _userDomainService?.Get(id);
            user.Name = dto.Name;

            _userDomainService?.Update(user);

            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Delete(Guid id)
        {
            var user = _userDomainService?.Get(id);
            _userDomainService?.Delete(user);

            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Get(Guid id)
        {
            var user = _userDomainService?.Get(id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public void Dispose()
        {
            _userDomainService?.Dispose();
        }
    }
}
