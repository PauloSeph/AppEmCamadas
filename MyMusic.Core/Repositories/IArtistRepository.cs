using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMusic.Core.models;

namespace MyMusic.Core.Repositories
{

    // Estamos estendendo/Herdando a BaseRepositoryInterface
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}

