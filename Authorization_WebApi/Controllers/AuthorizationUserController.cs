using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using User.DataModel;
using User.Services.Interfaces;

namespace Authorization_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationUserController : ControllerBase
    {
        private readonly IuserServices _iuserServices;
    
        public AuthorizationUserController(IuserServices iuserServices)
        {
            _iuserServices = iuserServices;
        }

        [HttpGet("id")]
        public async Task<ActionResult<user>> Get(int id)
        {
            try
            {
                if (id != 0)
                {
                    var value = await Task.Run(() => _iuserServices.GetUserById(id));
                    return Ok(value);
                }
                var result = await Task.Run(() => _iuserServices.GetUser());
                return Ok(result);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<user>> Post(user user)
        {
            try
            {


                bool login = _iuserServices.CheckLogin(user);
                if (!login)
                {
                    string message = "Этот логин занят. Выберите другой.";
                    return this.StatusCode(StatusCodes.Status409Conflict, message);
                }


                var new_user = _iuserServices.AddUser(user);


                return Ok(new_user);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var delete = await Task.Run(() => _iuserServices.DeleteUser(id));
                return Ok(delete);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
