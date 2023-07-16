using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShrtLy.BLL.Modules.Shortening.Dtos;
using ShrtLy.DAL.Entitites;
using ShrtLy.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShrtLy.BLL.Modules.Shortening.Services
{
    public class ShorteningService : IShorteningService
    {
        private readonly char[] _baseChars = new char[] {
            '0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T',
            'U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x'
        };

        private readonly ILinksRepository _linksRepo;
        private readonly IMapper _mapper;

        public ShorteningService(ILinksRepository linksRepo, IMapper mapper)
        {
            _linksRepo = linksRepo;
            _mapper = mapper;
        }

        public async Task<string> CreateNewOrGetExisting(string url, CancellationToken ct = default)
        {
            var entity = await _linksRepo.GetByUrl(url, ct);
            if (entity is not null)
                return entity.ShortUrl;

            var shortUrl = ShortifyLink(url);

            return (await _linksRepo.Create(new() { ShortUrl = shortUrl,  Url = url }, ct)).ShortUrl;
        }

        public async Task<IEnumerable<LinkDto>> GetAll(CancellationToken ct) =>
            _mapper.Map<List<LinkDto>>(await _linksRepo.GetAll(ct));

        public async Task<LinkDto> GetById(int id, CancellationToken ct) =>
            _mapper.Map<LinkDto>(await _linksRepo.GetById(id, ct));

        public async Task<LinkDto> GetByShortUrl(string shortUrl, CancellationToken ct) =>
            _mapper.Map<LinkDto>(await _linksRepo.GetByShortUrl(shortUrl, ct));

        private string ShortifyLink(string url)
        {
            Thread.Sleep(1);//make everything unique while looping
            long ticks = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;//EPOCH

            int i = 32;
            char[] buffer = new char[i];
            int targetBase = _baseChars.Length;

            do
            {
                buffer[--i] = _baseChars[ticks % targetBase];
                ticks = ticks / targetBase;
            }
            while (ticks > 0);

            char[] result = new char[32 - i];
            Array.Copy(buffer, i, result, 0, 32 - i);

            return new string(result);
        }

        public async Task<bool> CheckIfExistByShortUrl(string shortUrl, CancellationToken ct)
        {
            return await _linksRepo.CheckIfExistByShortUrl(shortUrl, ct);
        }

        public bool CheckIfValidUrl(string text)
        {
            return Uri.TryCreate(text, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
