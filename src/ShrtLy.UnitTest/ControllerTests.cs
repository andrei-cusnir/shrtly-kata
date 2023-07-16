using Moq;
using NUnit.Framework;
using ShrtLy.Api.Controllers;
using ShrtLy.BLL.Modules.Shortening.Dtos;
using ShrtLy.BLL.Modules.Shortening.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShrtLy.UnitTest
{
    public class ControllerTests
    {
        public LinksController controller { get; set; }
        public Mock<IShorteningService> serviceMock;

        public static List<LinkDto> viewModels = new List<LinkDto>
            {
                new LinkDto
                {
                    Id = 1,
                    ShortUrl = "short-url-1",
                    Url = "url-1"
                },
                new LinkDto
                {
                    Id = 2,
                    ShortUrl = "short-url-2",
                    Url = "url-2"
                }
            };

        public static List<LinkDto> linkDtos = new List<LinkDto>
            {
                new LinkDto
                {
                    Id = 1,
                    ShortUrl = "short-url-1",
                    Url = "url-1"
                },
                new LinkDto
                {
                    Id = 2,
                    ShortUrl = "short-url-2",
                    Url = "url-2"
                }
            };

        [SetUp]
        public void Setup()
        {
            serviceMock = new Mock<IShorteningService>();
            controller = new LinksController(serviceMock.Object);
        }

        [Test]
        public async Task GetShortLink_ProcessLinkHasBeenCalled()
        {
            await controller.CreateShortLink("http://google.com",default);

            serviceMock.Verify(x => x.CreateNewOrGetExisting("http://google.com", default), Times.Once);
        }

        [Test]
        public void GetShortLink_ProcessLinksHasBeenCalled()
        {
            serviceMock.Setup(x => x.GetAll(default));

            controller.GetShortLinks(default);

            serviceMock.Verify(x => x.GetAll(default), Times.Once);
        }

        [Test]
        public void GetShortLinks_AllLinksAreCorrect()
        {
            serviceMock.Setup(x => x.GetAll(default));

            controller.GetShortLinks(default);

            for (int i = 0; i < linkDtos.Count; i++)
            {
                Assert.AreEqual(viewModels[i].Id, linkDtos[i].Id);
                Assert.AreEqual(viewModels[i].ShortUrl, linkDtos[i].ShortUrl);
                Assert.AreEqual(viewModels[i].Url, linkDtos[i].Url);
            }
        }
    }
}
