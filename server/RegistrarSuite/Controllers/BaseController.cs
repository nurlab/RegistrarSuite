using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RegistrarSuite.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistrarSuite.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public string LoggedInUserName { get { return _httpContextAccessor.HttpContext?.User?.Identity?.Name; } }
        public string ServerRootPath { get { return $"{Request.Scheme}://{Request.Host}{Request.PathBase}"; } }
        public string IP { get { return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString(); } }


    }
}
