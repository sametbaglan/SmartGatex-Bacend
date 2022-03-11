using SmartGatex.Business.Abstrack;
using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal  customerDal)
        {
            _customerDal = customerDal;
        }
        public Task<CustomersDto> AddAsync(CustomersDto entity)
        {
            return _customerDal.AddAsync(entity);
        }

        public Task<List<CustomersDto>> GetAllAsync()
        {
            return _customerDal.GetListAsync();
        }

        public Task<CustomersDto> GetByIdAsync(string id)
        {
            return _customerDal.GetByIdAsync(id);
        }

        public async Task<List<CustomersDto>> GetCustomerWithUserid(string userid)
        {
            return await _customerDal.GetCustomerWithUserid(userid);
        }

        public bool Update(CustomersDto entity)
        {
            return _customerDal.Update(entity);
        }
    }
}
