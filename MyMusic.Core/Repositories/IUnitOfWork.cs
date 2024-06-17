using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MyMusic.Core.models;

namespace MyMusic.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        
        // Duas maneira de implementar, tanto faz o que se usar, contanto que a IMusicRepository implemente o BaseRepositorio
        // e o mesmo para Artist.
        IMusicRepository Musics { get;}
        IBaseRepository<Artist> Artists { get; }
        Task<int> CommitAsync();
    }
}