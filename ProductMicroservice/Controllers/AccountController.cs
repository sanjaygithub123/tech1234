using System.Linq;
using System.Threading.Tasks;
using AuthTest.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ProductMicroservice.Controllers  
{  
      
    [Route("api/[controller]")]  
    [ApiController]  
    public class AccountController : ControllerBase  
    {  
        private IConfiguration _config;  
  
        public AccountController(IConfiguration config)  
        {  
            _config = config;  
        }  
  
        [HttpGet]  
        public IActionResult GetLogin()  
        {  
            var properties = new AuthenticationProperties { RedirectUri = "https://localhost:5001/api/Account1/"};
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }  

    }  
}  