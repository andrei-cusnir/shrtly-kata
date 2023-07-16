using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShrtLy.DAL.Entitites;

namespace ShrtLy.DAL.Repositories
{
    public class LinksRepository : ILinksRepository
    {
        private readonly ShrtLyContext _context;

        public LinksRepository(ShrtLyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LinkEntity>> GetAll(CancellationToken ct) => 
            await _context.Links.ToListAsync(ct);

        public async Task<LinkEntity?> GetById(int id, CancellationToken ct) =>
            await _context.Links.FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<LinkEntity> Create(LinkEntity link, CancellationToken ct)
        {
            await _context.Links.AddAsync(link, ct);
            await _context.SaveChangesAsync(ct);
            return link;
        }

        public async Task<LinkEntity> GetByUrl(string url, CancellationToken ct) =>
            await _context.Links.FirstOrDefaultAsync(x => x.Url == url, ct);

        public async Task<LinkEntity> GetByShortUrl(string url, CancellationToken ct) =>
            await _context.Links.FirstOrDefaultAsync(x => x.ShortUrl == url, ct);

        public async Task<bool> CheckIfExistByShortUrl(string shortUrl, CancellationToken ct)
        {
            return await _context.Links.AnyAsync(x => x.ShortUrl == shortUrl, ct);
        }
    }
}
