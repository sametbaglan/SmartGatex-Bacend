using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Business.Abstrack
{
    public interface ICustomerService
    {
        Task<List<CustomersDto>> GetAllAsync();
        Task<CustomersDto> GetByIdAsync(string id);
        Task<CustomersDto> AddAsync(CustomersDto entity);
        bool Update(CustomersDto entity);
  Task<List<CustomersDto>> GetCustomerWithUserid(string userid);
    }
}
