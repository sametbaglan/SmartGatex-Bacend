using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Abstrack
{
    public interface ICustomerDal
    {
        Task<List<CustomersDto>> GetListAsync();
        Task<CustomersDto> GetByIdAsync(string customerid);
        Task<CustomersDto> AddAsync(CustomersDto entity);
        bool Update(CustomersDto entity);
        Task<List<CustomersDto>> GetCustomerWithUserid(string userid);

    }
}
