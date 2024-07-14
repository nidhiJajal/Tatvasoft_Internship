using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        BALLogin _balLogin;

        public LoginController(BALLogin balLogin)
        {
            _balLogin = balLogin;
        }

        ResponseResult result = new ResponseResult();
        [HttpPost]
        public ResponseResult LoginUser(User user)
        {
            try
            {
                result.Data = _balLogin.UserLogin(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
    }
}
