using SmartGatex.Business.Abstrack;
using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Business.Concrete
{
    public class LicencePlateManager : ILicencePlateService
    {
        private ILicencePlateDal _licencePlateDal;
        public LicencePlateManager(ILicencePlateDal licencePlateDal)
        {
            _licencePlateDal = licencePlateDal;
        }
        public Task<LicencePlatesDto> AddAsync(LicencePlatesDto entity)
        {
            return _licencePlateDal.AddAsync(entity);
        }

        public Task<List<LicencePlatesDto>> GetAllAsync()
        {
            return _licencePlateDal.GetListAsync();
        }

        public Task<LicencePlatesDto> GetByIdAsync(string id)
        {
            return _licencePlateDal.GetByIdAsync(id);
        }

        public async Task<List<LicencePlatesDto>> GetLicencePlateWithUserid(string userid)
        {
            return await _licencePlateDal.GetLicencePlateWithUserid(userid);
        }

        public bool Update(LicencePlatesDto entity)
        {
            return _licencePlateDal.Update(entity);
        }
    }
}
