using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace KeyVaultDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppConfigKVRef : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IConfigurationRefresher _configurationRefresher;

        public AppConfigKVRef(IConfiguration configuration, IConfigurationRefresherProvider refresherProvider)
        {
            _configuration = configuration;
            _configurationRefresher = refresherProvider.Refreshers.First();
        }

        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            var all_config = bool.Parse(_configuration["TestApp:Settings:UseSampleKey"]) ? _configuration["TestApp:Settings:KeyVaultMessage"]
                                                                                         : _configuration["TestApp:Settings:Sample"];
            return all_config;
        }

        [HttpGet]
        [Route("GetRefreshedSecret")]
        public async Task<string> GetRefreshedSecret()
        {
           
            await _configurationRefresher.TryRefreshAsync();

            var all_config = bool.Parse(_configuration["TestApp:Settings:UseSampleKey"]) ? _configuration["TestApp:Settings:KeyVaultMessage"]
                                                                                          : _configuration["TestApp:Settings:Sample"];
            return all_config;
        }
    }
}
