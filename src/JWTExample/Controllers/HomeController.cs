using JWTExample.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;

        public HomeController(TokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpGet]
        [Route("GetToken")]
        public IActionResult GetToken()
        {
            return Ok(_tokenGenerator.GetToken());
        }

        [HttpGet]
        [Route("GetA")]
        [Authorize(Roles = "A")]
        public IActionResult GetA()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetB")]
        [Authorize(Roles = "B")]
        public IActionResult GetB()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetAB")]
        [Authorize(Roles = "A,B")]
        public IActionResult GetAB()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetD")]
        [Authorize(Roles = "D")]
        public IActionResult GetD()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetAuthorize")]
        [Authorize]
        public IActionResult GetAuthorize()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetAnonim")]
        public IActionResult GetAnonim()
        {
            return Ok();
        }
    }
}
