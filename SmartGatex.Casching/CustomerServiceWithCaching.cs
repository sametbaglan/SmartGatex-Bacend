using Microsoft.Extensions.Caching.Memory;
using SmartGatex.Business.Abstrack;
using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Casching
{
    public class CustomerServiceWithCaching : ICustomerService
    {
        private const string CacheKey = "customerCache";
        private readonly IMemoryCache _memoryCache;
        private readonly ICustomerDal _customerDal;
        public CustomerServiceWithCaching(IMemoryCache memoryCache, ICustomerDal customerDal)
        {
            _customerDal = customerDal;
            _memoryCache = memoryCache;

            if (!_memoryCache.TryGetValue(CacheKey, out _))
            {
                _memoryCache.Set(CacheKey, _customerDal.GetListAsync());
            }
        }
        public async Task<CustomersDto> AddAsync(CustomersDto entity)
        {
            await _customerDal.AddAsync(entity);
            await CacheAllCustomerAsync();
            return entity;

        }

        public Task<List<CustomersDto>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<List<CustomersDto>>(CacheKey));
        }

        public async Task<CustomersDto> GetByIdAsync(string id)
        {
            var customer =  _memoryCache.Get<CustomersDto>( await _customerDal.GetByIdAsync(id));
            return customer;
        }

        public  bool Update(CustomersDto entity)
        {
             _customerDal.Update(entity);
             CacheAllCustomerAsync();
            return true;
        }

        public async Task CacheAllCustomerAsync()
        {
             _memoryCache.Set(CacheKey, await _customerDal.GetListAsync());
        }
    }
}
