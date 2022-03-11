using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGatex.Api.Model;
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
    public class LicencePlatesController : CustomBaseController
    {
        private readonly ILicencePlateService _licencePlateService;
        public LicencePlatesController(ILicencePlateService licencePlateService)
        {
            _licencePlateService = licencePlateService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromHeader] string Authorization)
        {
            if (!string.IsNullOrEmpty(AuthorizationControllFunc.getuserid(Authorization)))
            {
                var Licenceplatelist = await _licencePlateService.GetLicencePlateWithUserid(AuthorizationControllFunc.getuserid(Authorization));
                if (Licenceplatelist.Count > 0)
                    return CreateActionResult(ResponseDto<List<LicencePlatesDto>>.Success(Licenceplatelist, 200));
                else
                    return CreateActionResult(ResponseDto<List<LicencePlatesDto>>.Success(200, "No LicencePlate"));
            }
            else
            {
                return CreateActionResult(ResponseDto<List<CustomersDto>>.Fail("Unauthorize", 402, false));
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _licencePlateService.GetByIdAsync(id);
            if (result != null)
            {
                return CreateActionResult(ResponseDto<LicencePlatesDto>.Success(result, 200));
            }
            else
                return CreateActionResult(ResponseDto<LicencePlatesDto>.Fail("No Cams", 200, false));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromHeader] string Authorization,LicencePlatesDto entity)
        {
            if (!string.IsNullOrEmpty(AuthorizationControllFunc.getuserid(Authorization)))
            {
                entity.isActive = true;
                entity.isDeleted = false;
                entity.CreatedDate = System.DateTime.Now;
                entity.ModifyDate = System.DateTime.Now;
                entity.Userid = AuthorizationControllFunc.getuserid(Authorization);
                var result = await _licencePlateService.AddAsync(entity);
                return CreateActionResult(ResponseDto<LicencePlatesDto>.Success(200, "Success"));
            }
            else
            {
                return CreateActionResult(ResponseDto<List<CustomersDto>>.Fail("Unauthorize", 402, false));
            }
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _licencePlateService.GetByIdAsync(id);
            if (result != null)
            {
                result.isActive = false;
                result.isDeleted = true;
                _licencePlateService.Update(result);
                return CreateActionResult(ResponseDto<LicencePlatesDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<LicencePlatesDto>.Fail("Not Found", 400, false));
        }
        [HttpPost]
        public async Task<IActionResult> Update(LicencePlatesDto customers)
        {
            var result = await _licencePlateService.GetByIdAsync(customers.Id);
            if (result != null)
            {
                result.ModifyDate = System.DateTime.Now;
                result.LicencePlate = customers.LicencePlate;
                return CreateActionResult(ResponseDto<LicencePlatesDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<LicencePlatesDto>.Fail("Not Found", 400, false));
        }
    }
}
