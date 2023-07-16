using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShrtLy.BLL.Modules.Shortening.Dtos;
using ShrtLy.BLL.Modules.Shortening.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShrtLy.Api.Controllers
{
    [Route("api/links")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly string _domain;
        private readonly IShorteningService _shorteningService;

        public LinksController(IShorteningService service, IConfiguration cfg)
        {
            _domain = cfg.GetValue<string>("Domain");
            _shorteningService = service;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateShortLink(string url, CancellationToken ct)
        {
            if(!_shorteningService.CheckIfValidUrl(url))
                return BadRequest("Url is not Valid");

            if (url.Contains($"{_domain}/goto")) 
                return BadRequest("You cant create short link from short link!");
            
            var result = await _shorteningService.CreateNewOrGetExisting(url, ct);
            return $"{_domain}/goto/{result}";
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinkDto>>> GetShortLinks(CancellationToken ct)
        {
            return Ok(await _shorteningService.GetAll(ct));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LinkDto>> GetById(int id, CancellationToken ct)
        {
            var res = await _shorteningService.GetById(id, ct);
            return res is not null ? Ok(res) : NotFound();
        }

    }
}
