#nullable enable
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ShrtLy.BLL.Modules.Shortening.Dtos;

namespace ShrtLy.BLL.Modules.Shortening.Services
{
    public interface IShorteningService
    {
        Task<LinkDto?> GetById(int id, CancellationToken ct);
        Task<LinkDto?> GetByShortUrl(string shortUrl, CancellationToken ct);
        Task<IEnumerable<LinkDto>> GetAll(CancellationToken ct);
        Task<string> CreateNewOrGetExisting(string url, CancellationToken ct);
        Task<bool> CheckIfExistByShortUrl(string shortUrl, CancellationToken ct);
        bool CheckIfValidUrl(string text);
    }
}