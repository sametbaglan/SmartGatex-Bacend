using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Concrete
{
    public class LicencePlateDal : ILicencePlateDal
    {
        private readonly RepositoryDesignDal<LicencePlatesDto> _licencedto;
        private string CollectionName = "LicencePlate";
        public LicencePlateDal()
        {
            _licencedto = new RepositoryDesignDal<LicencePlatesDto>(CollectionName);
        }
        public async Task<LicencePlatesDto> AddAsync(LicencePlatesDto entity)
        {
            return await _licencedto.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task<LicencePlatesDto> GetByIdAsync(string customerid)
        {
            var result = await _licencedto.GetByIdAsync(x => x.Id == customerid);
            return result;
        }

        public async Task<List<LicencePlatesDto>> GetLicencePlateWithUserid(string userid)
        {
            return await _licencedto.GetAllAsync(x => x.isActive==true&&x.isDeleted==false&&x.Userid == userid);
        }

        public async Task<List<LicencePlatesDto>> GetListAsync()
        {
            return await _licencedto.GetAllAsync(x => x.isDeleted == false && x.isActive == true)
                .ConfigureAwait(false);
        }

        public bool Update(LicencePlatesDto entity)
        {
            return _licencedto.Update(entity, x => x.Id == entity.Id);
        }
    }
}
