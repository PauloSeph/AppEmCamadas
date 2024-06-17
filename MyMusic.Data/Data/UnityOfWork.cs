
using MyMusic.Core.Repositories;
using MyMusic.Data.Repositories;

namespace MyMusic.Data.Data
{

    // Provavelmente que nao usarei esse codigo - sendo assim preciso alterar algumas coisas.
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DataContext _context;
        private MusicRepository? _musicRepository;
        private ArtistRepository? _artistRepository;

        public UnityOfWork(DataContext context)
        {
            this._context = context;
        }

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

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