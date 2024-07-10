
using Microsoft.EntityFrameworkCore;
using MyMusic.Core.models;
using MyMusic.Core.Repositories;
using MyMusic.Data.Data;

namespace MyMusic.Data.Repositories
{
    public class MusicRepository : BaseRepository<Music>, IMusicRepository
    {

        // Contexto está vindo da MusicRepository, tem chamar o construtor base se nao, nao é possivel acessa-lo.
        public MusicRepository(DataContext context)
            : base(context)
        { }


        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await Context.Musics
                .Include(m => m.Artist)
                .ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            var test = await Context.Musics
                .Include(m => m.Artist)
                .SingleOrDefaultAsync(m => m.Id == id);

            return test!;
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await Context.Musics
                .Include(m => m.Artist)
                .Where(m => m.ArtistId == artistId)
                .ToListAsync();
        }
    }






}