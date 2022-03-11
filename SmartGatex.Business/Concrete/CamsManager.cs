using SmartGatex.Business.Abstrack;
using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartGatex.Business.Concrete
{
    public class CamsManager : ICamsService
    {
        private readonly ICamsDal _camsDal;
        public CamsManager(ICamsDal camsDal)
        {
            _camsDal = camsDal;
        }
        public Task<CamsDto> AddAsync(CamsDto entity)
        {
            return _camsDal.AddAsync(entity);
        }

        public Task<List<CamsDto>> GetAllAsync()
        {
            return _camsDal.GetListAsync();
        }

        public Task<CamsDto> GetByIdAsync(string id)
        {
            return _camsDal.GetByIdAsync(id);
        }

        public async Task<List<CamsDto>> GetCamWithCustomerid(string customerid)
        {
            return await _camsDal.GetCamWithCustomerid(customerid);
        }

        public bool Update(CamsDto entity)
        {
            return _camsDal.Update(entity);
        }
    }
}
