using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Business.Abstrack
{
    public interface ICamsService
    {
        Task<List<CamsDto>> GetAllAsync();
        Task<CamsDto> GetByIdAsync(string id);
        Task<CamsDto> AddAsync(CamsDto entity);
        bool Update(CamsDto entity);
        Task<List<CamsDto>> GetCamWithCustomerid(string customerid);
    }
}
