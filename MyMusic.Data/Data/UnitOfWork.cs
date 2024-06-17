
using MyMusic.Core.models;
using MyMusic.Core.Repositories;
using MyMusic.Data.Repositories;

namespace MyMusic.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        private MusicRepository? _musicRepository;
        private ArtistRepository? _artistRepository;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);
        public IBaseRepository<Artist> Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        // public IArtistRepository Artists
        // {
        //     get
        //     {
        //         if (_artistRepository == null)
        //         {
        //             _artistRepository = new ArtistRepository(_context);
        //         }
        //         return _artistRepository;
        //     }
        // }



        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();


        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}