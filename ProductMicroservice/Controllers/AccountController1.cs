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
    public class Account1Controller : ControllerBase  
    {  
        private IConfiguration _config;  
  
        public Account1Controller(IConfiguration config)  
        {  
            _config = config;  
        }  
  
       

        [HttpGet]  
    public  string GoogleResponse()
    {
        var result = HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;
 
        var claims = result.Principal.Identities
            .FirstOrDefault().Claims.Select(claim => new
        {
            claim.Issuer,
            claim.OriginalIssuer,
            claim.Type,
            claim.Value
        });
 
        return JsonConvert.SerializeObject(claims);
    }
    }  
}  