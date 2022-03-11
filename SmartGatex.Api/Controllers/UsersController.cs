using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGatex.Api.Model.UserAuthorize;
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
    public class UsersController : CustomBaseController
    {
        private IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public class Token
        {
            public string Value { get; set; }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin(UsersDto model)
        {      
            model.Password = CommonMethods.ConvertToEncryp(model.Password);
            var user =  _usersService.GetUsersWithPasswordAndEmail(model.Email,model.Password);
            if (user.Result == null)
            {
                return CreateActionResult(ResponseDto<Token>.Fail("Hesap Bulunamamıştır.", 420, false));
            }
            else
            {
                var result = await _usersService.Token(model.Email, model.Password);
                Token tkn = new Token();
                tkn.Value = result;
                return CreateActionResult(ResponseDto<Token>.Success(tkn, 200));
            }
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var camlist = await _usersService.GetAllAsync();
            if (camlist.Count > 0)
                return CreateActionResult(ResponseDto<List<UsersDto>>.Success(camlist, 200));
            else
                return CreateActionResult(ResponseDto<List<UsersDto>>.Success(200, "No Cams"));
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            var result = await _usersService.GetByIdAsync(id);
            if (result != null)
            {
                result.Password = CommonMethods.ConvertDecrypt(result.Password);
                return CreateActionResult(ResponseDto<UsersDto>.Success(result, 200));
            }
            else
                return CreateActionResult(ResponseDto<UsersDto>.Fail("No Cams", 200, false));
        }
        [HttpPost]
 
        public async Task<IActionResult> AddAsync(UsersDto entity)
        {

            entity.Password = CommonMethods.ConvertToEncryp(entity.Password);
            entity.isActive = true;
            entity.isDeleted = false;
            entity.CreatedDate = System.DateTime.Now;
            entity.ModifyDate = System.DateTime.Now;
            var result = await _usersService.AddAsync(entity);
            return CreateActionResult(ResponseDto<UsersDto>.Success(200, "Success"));
        }
        [HttpPost("{id}")]
 
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _usersService.GetByIdAsync(id);
            if (result != null)
            {
                result.isActive = false;
                result.isDeleted = true;
                _usersService.Update(result);
                return CreateActionResult(ResponseDto<UsersDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<UsersDto>.Fail("Not Found", 400, false));
        }
        [HttpPost]
 
        public async Task<IActionResult> Update(UsersDto users)
        {
            var result = await _usersService.GetByIdAsync(users.Id);
            if (result != null)
            {
                result.ModifyDate = System.DateTime.Now;
                result.Password = users.Password;
                return CreateActionResult(ResponseDto<UsersDto>.Success(200, "Success"));
            }
            else
                return CreateActionResult(ResponseDto<UsersDto>.Fail("Not Found", 400, false));
        }
    }
}
