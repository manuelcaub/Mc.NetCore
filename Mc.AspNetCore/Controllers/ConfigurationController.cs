namespace Mc.AspNetCore.Controllers
{
    using Mc.AspNetCore.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    [Produces("application/json")]
    [Route("api/Configuration")]
    public class ConfigurationController : ControllerBase
    {
        private readonly Data data;

        public ConfigurationController(IOptionsSnapshot<Data> options)
        {
            this.data = options.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(data.ConnectionString);
        }
    }
}