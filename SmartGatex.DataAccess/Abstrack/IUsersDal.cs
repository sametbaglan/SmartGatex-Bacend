using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Abstrack
{
    public interface IUsersDal
    {
        Task<List<UsersDto>> GetListAsync();
        Task<UsersDto> GetByIdAsync(string userid);
        Task<UsersDto> AddAsync(UsersDto entity);
        bool Update(UsersDto entity);
        Task<UsersDto> GetUsersWithPasswordAndEmail(string email,string password);
        Task<string> Token(string email,string password);
    }
}
