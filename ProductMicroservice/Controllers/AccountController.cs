using System;
using System.Linq;
using System.Threading.Tasks;
using AuthTest.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pms.ProductMicroservice.Common;

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
            var env1 = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            var properties = new AuthenticationProperties { RedirectUri = PMSConstant.Env=="Development"? $"{PMSConstant.DefaultBaseURL}/api/product/":$"{PMSConstant.BaseURL}/api/product/"};
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }  

    }  
}  