using SmartGatex.DataAccess.Abstrack;
using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartGatex.DataAccess.Concrete
{
    public class CamsDal: ICamsDal
    {
        private readonly RepositoryDesignDal<CamsDto> _camsDto;
        private string CollectionName = "Cams";
        public CamsDal()
        {
            _camsDto = new RepositoryDesignDal<CamsDto>(CollectionName);
        }
        public async Task<CamsDto> AddAsync(CamsDto entity)
        {
            return await _camsDto.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task<CamsDto> GetByIdAsync(string camsid)
        {
            var result = await _camsDto.GetByIdAsync(x => x.Id == camsid);
            return result;
        }

        public async Task<List<CamsDto>> GetCamWithCustomerid(string customerid)
        {
            return await _camsDto.GetAllAsync(x =>x.isActive==true&&x.isDeleted==false&&x.CustomerId==customerid);
        }

        public async Task<List<CamsDto>> GetListAsync()
        {
            return await _camsDto.GetAllAsync(x => x.isDeleted == false && x.isActive == true)
                   .ConfigureAwait(false);
        }

        public bool Update(CamsDto entity)
        {
            return _camsDto.Update(entity, x => x.Id == entity.Id);
        }
    }
}
