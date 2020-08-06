using Microsoft.AspNetCore.Mvc;
using ShrtLy.Api.ViewModels;
using ShrtLy.BLL;
using System.Collections.Generic;
using System.Linq;

namespace ShrtLy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly IShorteningService service;

        public LinksController(IShorteningService service)
        {
            this.service = service;
        }

        [HttpGet]
        public string GetShortLink(string url)
        {
            return service.ProcessLink(url);
        }

        [HttpGet("all")]
        public IEnumerable<LinkViewModel> GetShortLinks()
        {
            var dtos = service.GetShortLinks();

            List<LinkViewModel> viewModels = new List<LinkViewModel>();
            for (int i = 0; i < dtos.Count(); i++)
            {
                var element = dtos.ElementAt(i);
                viewModels.Add(new LinkViewModel {
                    Id = element.Id,
                    ShortUrl = element.ShortUrl,
                    Url = element.Url
                });
            }

            return viewModels;
        }
    }
}
