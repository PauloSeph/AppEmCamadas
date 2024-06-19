using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMusic.Core.models;
using MyMusic.Core.Repositories;
using MyMusic.Core.Services;



/* NESSAS CLASSES DE SERVICO nós teremos as regras de negocio, como por exmeplo, podemos verificar algo 
 como por exemplo, se aquele nome está correto ou se a ideia está correta, apesar que temos as validacoes.

Mas por exemplo, aqui podemos tratar daquela ideia de criar as parcelas para cada venda, ou seja, de acordo com 
a quantidade de parcelas criar as parcelas relacionadas a essa venda, etc.

Então qualquer outra verificacao que seja relacionado a uma regra do negocio de se passada aqui antes
para depois ir para o banco de dados. Isso porque como o MIddleware, quando usamos algumas validacoes
como de Data Annotations ou de tipos de dados, ele basicamente já retorna a resposta sem mesmo entrar no
controller. Lembrando que tem os outros validators que podemos fazer como teve nesse curso usando as DTOs.
*/
namespace MyMusic.Services
{
    public class ArtistService : IArtistService
    {

        
        private readonly IUnitOfWork _unitOfWork;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Artist> CreateArtist(Artist newArtist)
        {

            
             await _unitOfWork.Artists
                .AddAsync(newArtist);               

            return newArtist;
        }

        public async Task DeleteArtist(Artist artist)
        {
            _unitOfWork.Artists.Remove(artist);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await _unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            artistToBeUpdated.Name = artist.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}