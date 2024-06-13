using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Core.models
{
    public class Artist
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Music> Musics { get; set; } = new List<Music>();
    }
}