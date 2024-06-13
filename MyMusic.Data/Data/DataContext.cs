using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMusic.Core.models;
using MyMusic.Data.Configurations;

namespace MyMusic.Data.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Music> Artists { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        // usando os arquivos de configuracao / map
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }

    }
}