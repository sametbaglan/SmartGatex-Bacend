using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Business.Abstrack
{
    public interface ILicencePlateService
    {
        Task<List<LicencePlatesDto>> GetAllAsync();
        Task<LicencePlatesDto> GetByIdAsync(string id);
        Task<LicencePlatesDto> AddAsync(LicencePlatesDto entity);
        bool Update(LicencePlatesDto entity);
        Task<List<LicencePlatesDto>> GetLicencePlateWithUserid(string userid);
    }
}
