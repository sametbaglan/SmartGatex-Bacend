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
    public class CustomerController : CustomBaseController
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromHeader] string Authorization)
        {
            if (!string.IsNullOrEmpty(AuthorizationControllFunc.getuserid(Authorization)))
            {
                var customers = await _customerService.GetCustomerWithUserid(AuthorizationControllFunc.getuserid(Authorization));
                if (customers.Count > 0)
                    return CreateActionResult(ResponseDto<List<CustomersDto>>.Success(customers, 200));
                else
                    return CreateActionResult(ResponseDto<List<CustomersDto>>.Success(200, "Customer Boş"));
            }
            else { return CreateActionResult(ResponseDto<List<CustomersDto>>.Fail("Unauthorize", 402, false)); }
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromHeader] string Authorization, CustomersDto entity)
        {
            if (!string.IsNullOrEmpty(AuthorizationControllFunc.getuserid(Authorization)))
            {
                entity.isActive = true;
                entity.isDeleted = false;
                entity.CreatedDate = System.DateTime.Now;
                entity.ModifyDate = System.DateTime.Now;
                entity.Userid = AuthorizationControllFunc.getuserid(Authorization);
                var result = await _customerService.AddAsync(entity);
                return CreateActionResult(ResponseDto<CustomersDto>.Success(entity, 200));
            }
            else { return CreateActionResult(ResponseDto<List<CustomersDto>>.Fail("Unauthorize", 402, false)); }
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete([FromHeader] string Authorization, string id)
        {

            var result = await _customerService.GetByIdAsync(id);
            if (result != null)
            {
                result.isActive = false;
                result.isDeleted = true;
                _customerService.Update(result);
                return CreateActionResult(ResponseDto<CustomersDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<CustomersDto>.Fail("Not Found", 400, false));


        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update([FromHeader] string Authorization, CustomersDto customers)
        {

            var result = await _customerService.GetByIdAsync(customers.Id);
            if (result != null)
            {
                result.ModifyDate = System.DateTime.Now;
                result.Name = customers.Name;
                result.Surname = customers.Surname;
                result.CustomerName = customers.CustomerName;
                _customerService.Update(result);
                return CreateActionResult(ResponseDto<CustomersDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<CustomersDto>.Fail("Not Found", 400, false));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromHeader] string Authorization, string id)
        {

            var result = await _customerService.GetByIdAsync(id);
            if (result != null)
            {
                return CreateActionResult(ResponseDto<CustomersDto>.Success(result, 200));
            }
            else
                return CreateActionResult(ResponseDto<CustomersDto>.Fail("Not Found", 400, false));

        }
    }
}
