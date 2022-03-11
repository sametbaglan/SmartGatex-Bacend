using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Abstrack
{
    public interface ILicencePlateDal
    {
        Task<List<LicencePlatesDto>> GetListAsync();
        Task<LicencePlatesDto> GetByIdAsync(string licenceid);
        Task<LicencePlatesDto> AddAsync(LicencePlatesDto entity);
        bool Update(LicencePlatesDto entity);
        Task<List<LicencePlatesDto>> GetLicencePlateWithUserid(string userid);
    }
}
