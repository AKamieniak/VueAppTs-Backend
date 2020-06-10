using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using VueAppTsApi.Core.DTOs;
using VueAppTsApi.Core.Entities;
using VueAppTsApi.Core.Exceptions;
using VueAppTsApi.Core.Helpers;
using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AuthenticationService(IRepository repository, IMapper mapper)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthResponseDTO> Authenticate(string username, string password)
        {
            var user = (await _repository.GetByCondition<User>(u => u.Username == username)).FirstOrDefault();

            if (user == null)
            {
                throw new NotAuthorizedException("Wrong username");
            }

            if (!PasswordHelper.IsPasswordValid(password, user.PasswordHash))
            {
                throw new NotAuthorizedException("Wrong password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, username),
            };

            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials,
                audience: Constants.Audience,
                issuer: Constants.Issuer);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return new AuthResponseDTO
                       {
                           TokenType = "Bearer",
                           AccessToken = token,
                           ExpiresIn = 1 * 24 * 60 * 60 * 1000,
                           User = _mapper.Map<UserDTO>(user),
                        };
        }
    }
}