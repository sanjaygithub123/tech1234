using System;
using Microsoft.Extensions.Configuration;

namespace Pms.ProductMicroservice.Common
{
    public static class PMSConfiguration
    {
        public static IConfiguration Configuration; 

        public static string GetConfig(string key)
        {
           return Configuration.GetSection(key).Value; 
        }
        
    }
}