#nullable enable
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShrtLy.DAL.Entitites;

namespace ShrtLy.DAL.Repositories
{
    public interface ILinksRepository
    {
        public Task<LinkEntity> Create(LinkEntity link, CancellationToken ct);
        public Task<LinkEntity?> GetById(int id, CancellationToken ct);
        public Task<IEnumerable<LinkEntity>> GetAll(CancellationToken ct);
        public Task<LinkEntity> GetByUrl(string url, CancellationToken ct);
        public Task<LinkEntity?> GetByShortUrl(string url, CancellationToken ct);
        public Task<bool> CheckIfExistByShortUrl(string shortUrl, CancellationToken ct);
    }
}