
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Concrete
{
    public class UserDal : IUsersDal
    {
        private readonly RepositoryDesignDal<UsersDto> _userDto;
        private string CollectionName = "Users";
        private IConfiguration _configuration;
        public UserDal(IConfiguration configuration)
        {
            _configuration = configuration;
            _userDto = new RepositoryDesignDal<UsersDto>(CollectionName);
        }
        public async Task<UsersDto> AddAsync(UsersDto entity)
        {
            return await _userDto.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task<UsersDto> GetByIdAsync(string userid)
        {
            var result = await _userDto.GetByIdAsync(x => x.Id == userid);
            return result;
        }

        public async Task<List<UsersDto>> GetListAsync()
        {
            return await _userDto.GetAllAsync(x => x.isDeleted == false && x.isActive == true)
             .ConfigureAwait(false);
        }

        public async Task<UsersDto> GetUsersWithPasswordAndEmail(string email, string password)
        {
            var user = await _userDto.GetByIdAsync(x => x.Email == email && x.Password == password&&x.isActive==true&&x.isDeleted==false);
            return user;
        }

        public async Task<string> Token(string email, string password)
        {
            var user = await _userDto.GetByIdAsync(x => x.Email == email && x.Password == password);
            if (user == null) return null;
            var tokenKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("TokenKey"));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id",user.Id),
                    new Claim(ClaimTypes.Email,user.Email)

                }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(

                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            return   token;
        }

        public bool Update(UsersDto entity)
        {
            return _userDto.Update(entity, x => x.Id == entity.Id);
        }
    }
}
