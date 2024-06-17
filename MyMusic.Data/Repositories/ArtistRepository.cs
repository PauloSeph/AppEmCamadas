using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMusic.Core.models;
using MyMusic.Core.Repositories;
using MyMusic.Data.Data;

namespace MyMusic.Data.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(DataContext context)
         : base(context)
        { }

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await Context.Artists
            .Include(a => a.Musics)
            .ToListAsync();

        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            var artista = Context.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);

            return artista!;
        }
    }
}