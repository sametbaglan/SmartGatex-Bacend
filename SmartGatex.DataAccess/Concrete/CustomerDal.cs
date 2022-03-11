using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Concrete
{
    public class CustomerDal : ICustomerDal
    {
        private readonly RepositoryDesignDal<CustomersDto> _customerdal;
        private string CollectionName = "Customer";
        public CustomerDal()
        {
            _customerdal = new RepositoryDesignDal<CustomersDto>(CollectionName);
        }

        public async Task<CustomersDto> AddAsync(CustomersDto entity)
        {
            return await _customerdal.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task<CustomersDto> GetByIdAsync(string customerid)
        {
            var result = await _customerdal.GetByIdAsync(x => x.Id == customerid);
            return result;
        }
        public async Task<List<CustomersDto>> GetCustomerWithUserid(string userid)
        {
            return await _customerdal.GetAllAsync(x =>x.isDeleted==false&&x.isActive==true&& x.Userid == userid);
        }
        public async Task<List<CustomersDto>> GetListAsync()
        {
            return await _customerdal.GetAllAsync(x => x.isDeleted == false && x.isActive == true)
                .ConfigureAwait(false);
        }
        public bool Update(CustomersDto entity)
        {
            return _customerdal.Update(entity, x => x.Id == entity.Id);
        }
    }
}
