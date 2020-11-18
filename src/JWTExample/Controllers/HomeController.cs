using JWTExample.Interfaces;
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
        private readonly IAuthorizedUserResolver _authorizedUserResolver;

        public HomeController(TokenGenerator tokenGenerator, IAuthorizedUserResolver authorizedUserResolver)
        {
            _tokenGenerator = tokenGenerator;
            _authorizedUserResolver = authorizedUserResolver;
        }

        [HttpGet]
        [Route("GetToken")]
        public IActionResult GetToken()
        {
            return Ok(_tokenGenerator.GetToken());
        }

        [HttpGet]
        [Route("GetMail")]
        [Authorize(Roles = "A")]
        public IActionResult GetMail()
        {
            return Ok(_authorizedUserResolver.GetMail);
        }

        [HttpGet]
        [Route("GetFullname")]
        [Authorize(Roles = "B")]
        public IActionResult GetFullname()
        {
            return Ok(_authorizedUserResolver.GetFullname);
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
