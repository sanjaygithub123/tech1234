using System;

namespace Pms.ProductMicroservice.Common
{
    public static class PMSConstant
    {
        public static string BaseURL = PMSConfiguration.GetConfig("BASE_URL");
        public static string DefaultBaseURL = "https://localhost:5001";
 
        
    }
}