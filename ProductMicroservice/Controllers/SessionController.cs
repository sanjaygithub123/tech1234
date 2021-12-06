using System;
using AuthTest.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ProductMicroservice.Controllers  
{  
      
    [Route("api/[controller]")]  
    [ApiController]  
    public class SessionController : ControllerBase  
    {  
        private IConfiguration _config;  
  
        public SessionController(IConfiguration config)  
        {  
            _config = config;  
        }  
  
        [HttpGet]  
        public string GetSessionData()  
        {  
            const string sessionKey = "FirstSeen";
            const string sessionKey1 = "SessionCounter";
            DateTime dateFirstSeen;
            int vlu1 = 1;
            var value = HttpContext.Session.GetString(sessionKey);
            var value1 = HttpContext.Session.GetString(sessionKey1);
            if (string.IsNullOrEmpty(value))
            {
                dateFirstSeen = DateTime.Now;
                var serialisedDate = JsonConvert.SerializeObject(dateFirstSeen);
                HttpContext.Session.SetString(sessionKey, serialisedDate);
                HttpContext.Session.SetString(sessionKey1, "1");
            }
            else
            {
                dateFirstSeen = JsonConvert.DeserializeObject<DateTime>(value);
                vlu1 = Convert.ToInt32(value1) + 1;
                HttpContext.Session.SetString(sessionKey1, vlu1.ToString());
            }

            dynamic myDynamic = new System.Dynamic.ExpandoObject();
            myDynamic.DateSessionStarted = dateFirstSeen;
            myDynamic.Now = DateTime.Now;
            myDynamic.SessionCounter = $"Refresh page to increse session counter, SessionCounter = {vlu1}";


           return JsonConvert.SerializeObject(myDynamic);
            
        }  
    }  
}  