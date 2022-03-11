using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Business.Abstrack
{
    public interface IUsersService
    {
        Task<List<UsersDto>> GetAllAsync();
        Task<UsersDto> GetByIdAsync( string id);
        Task<UsersDto> AddAsync(UsersDto entity);
        bool Update(UsersDto entity);
        Task<UsersDto> GetUsersWithPasswordAndEmail(string email,string password);
        Task<string> Token(string email, string password);
    }
}
