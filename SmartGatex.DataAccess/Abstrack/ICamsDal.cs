using SmartGatex.DataAccess.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.DataAccess.Abstrack
{
    public interface ICamsDal
    {
        Task<List<CamsDto>> GetListAsync();
        Task<CamsDto> GetByIdAsync(string camsid);
        Task<CamsDto> AddAsync(CamsDto entity);
        bool Update(CamsDto entity);
        Task<List<CamsDto>> GetCamWithCustomerid(string customerid);
    }
}
