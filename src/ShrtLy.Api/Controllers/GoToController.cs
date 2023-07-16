using Microsoft.AspNetCore.Mvc;
using ShrtLy.BLL.Modules.Shortening.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ShrtLy.Api.Controllers
{
    [Route("goto")]
    [ApiController]
    public class GoToController : ControllerBase
    {
        private IShorteningService _shorteningService;

        public GoToController(IShorteningService shorteningService)
        {
            _shorteningService = shorteningService;
        }

        [HttpGet("{shortUrl}")]
        public async Task<ActionResult> RedirectToLink(string shortUrl, CancellationToken ct)
        {
            var link = await _shorteningService.GetByShortUrl(shortUrl, ct);

            return link is not null ? Redirect(link.Url) : NotFound();

        }
    }
}
