using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Core.models;

namespace MyMusic.Data.Configurations
{
 public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseMySqlIdentityColumn();
                
            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Artist)
                .WithMany(a => a.Musics)
                .HasForeignKey(m => m.ArtistId);

            builder
                .ToTable("Musics");
        }
    }
}