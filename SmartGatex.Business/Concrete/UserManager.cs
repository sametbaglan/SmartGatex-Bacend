using SmartGatex.Business.Abstrack;
using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Business.Concrete
{
    public class UserManager : IUsersService
    {
        private readonly IUsersDal _usersDal;
        public UserManager(IUsersDal  usersDal)
        {
            _usersDal = usersDal;
        }
        public Task<UsersDto> AddAsync(UsersDto entity)
        {
            return _usersDal.AddAsync(entity);
        }

        public Task<List<UsersDto>> GetAllAsync()
        {
            return _usersDal.GetListAsync();
        }

        public Task<UsersDto> GetByIdAsync(string id)
        {
            return _usersDal.GetByIdAsync(id);
        }

        public async Task<UsersDto> GetUsersWithPasswordAndEmail(string email,string password)
        {
            return await _usersDal.GetUsersWithPasswordAndEmail(email,password);
        }

        public Task<string> Token(string email, string password)
        {
            return _usersDal.Token(email, password);
        }

        public bool Update(UsersDto entity)
        {
            return _usersDal.Update(entity);
        }
    }
}
