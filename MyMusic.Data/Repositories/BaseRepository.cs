using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Repositories;
using MyMusic.Data.Data;

namespace MyMusic.Data.Repositories
{
    // o Context.Set: 
    // Retorna uma DbSet<TEntity> instância para acesso a entidades do tipo especificado no contexto e no repositório subjacente.
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext Context;
        
        public BaseRepository(DataContext context)
        {
            this.Context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }


         // Observe que o retorno desa funcao é um tipo Expression Function.
        // Argument 2: cannot convert from 'bool' to 'System.Linq.Expressions.Expression<System.Func<TEntity, bool>>'

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return  await Context.Set<TEntity>().ToListAsync();
        }

        // Essa chamada retornar um ValueTask pois usamos o FindAsync
        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id)!;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate)!;
        }
    }

        //NOTA
        /* Nas classes posteriores que implementam esse RepositoryBase
        ele está referenciando o Construtor base mas usando outro nome para o DbContext, como MyMusicDbContext

        public MusicRepository(MyMusicDbContext context) 
            : base(context)
        { }
        
        E basicamente para falar que esse cara é o Contexto, define uma propriedade e no metodo get define que o Contexto do Base Repository
        é um MyMusicDbContext.

            private MyMusicDbContext MyMusicDbContext
        {
            get { return Context as MyMusicDbContext; }
        }
        
        */


        // Não sei qual é a vantagem de fazer isso, parece deixar o codigo mais confuso do que simplesmente usar o contexto herdado.
}