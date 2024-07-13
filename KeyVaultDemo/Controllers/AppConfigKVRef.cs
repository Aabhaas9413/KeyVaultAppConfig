using Microsoft.AspNetCore.Mvc;

namespace KeyVaultDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppConfigKVRef : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AppConfigKVRef(ILogger<AppConfigKVRef> logger, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetKeyValue")]
        public string Get()
        {
            var all_config = bool.Parse(_configuration["TestApp:Settings:UseSampleKey"]) ? _configuration["TestApp:Settings:KeyVaultMessage"]
                                                                                         : _configuration["TestApp:Settings:Sample"];
            return all_config;
        }
    }
}
