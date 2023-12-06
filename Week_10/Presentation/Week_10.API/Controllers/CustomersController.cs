using Microsoft.AspNetCore.Mvc;
using Week_10_2.Infrastructure.Services;

namespace Week_10_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public CustomersController()
        {

        }

        [HttpGet]
        public void Get(string name)
        {
            ConfigurationService.GetInstance().GetValue(name);
        }
    }
}