﻿using ErrorOr;
using LoudVoice.Application.Common.Authentications;
using LoudVoice.Application.Common.Cqrs.Queries;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.Common.Errors;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Application.User.Queries.Login;
using LoudVoice.Domain.Users.Factories;

namespace LoudVoice.Application.User.Queries.LoginUser
{
    public class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, ErrorOr<UserDto>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginUserQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<UserDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            if(_userRepository.GetUserByEmailAsync(
                request.Email, cancellationToken).Result is not Domain.Users.Entity.User user)
            {
                return ApplicationErrors.UserNotFound;
            }

            if (user.Login != request.Login || user.Password != request.Password)
            {
                return ApplicationErrors.InvalidAuthentication;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new UserDto(
                user.Id, 
                user.Login, 
                user.Email, 
                user.Password, 
                token);
        }
    }
}
