using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGatex.Business.Abstrack;
using SmartGatex.DataAccess.Dtos;
using SmartGatex.DataAccess.Dtos.ResponsesDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGatex.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CamsController : CustomBaseController
    {
        private readonly ICamsService _camsService;
        public CamsController(ICamsService camsService)
        {
            _camsService = camsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCamWithCustomerid(string customerid)
        {
                var camlist = await _camsService.GetCamWithCustomerid(customerid);
                if (camlist.Count > 0)
                    return CreateActionResult(ResponseDto<List<CamsDto>>.Success(camlist, 200));
                else
                    return CreateActionResult(ResponseDto<List<CamsDto>>.Success(200, "No Cams"));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _camsService.GetByIdAsync(id);
            if (result != null)
            {
                return CreateActionResult(ResponseDto<CamsDto>.Success(result, 200));
            }
            else
                return CreateActionResult(ResponseDto<CamsDto>.Fail("No Cams", 200, false));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CamsDto entity)
        {
            entity.isActive = true;
            entity.isDeleted = false;
            entity.CreatedDate = System.DateTime.Now;
            entity.ModifyDate = System.DateTime.Now;
            var result = await _camsService.AddAsync(entity);
            return CreateActionResult(ResponseDto<CamsDto>.Success(200, "Success"));
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _camsService.GetByIdAsync(id);
            if (result != null)
            {
                result.isActive = false;
                result.isDeleted = true;
                _camsService.Update(result);
                return CreateActionResult(ResponseDto<CamsDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<CamsDto>.Fail("Not Found", 400, false));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CamsDto customers)
        {
            var result = await _camsService.GetByIdAsync(customers.Id);
            if (result != null)
            {
                result.ModifyDate = System.DateTime.Now;
                result.Description = customers.Description;
                result.Model = customers.Model;
                result.SerialNumber = customers.SerialNumber;
                result.Brand = customers.Brand;
                return CreateActionResult(ResponseDto<CustomersDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<CustomersDto>.Fail("Not Found", 400, false));
        }
    }
}
