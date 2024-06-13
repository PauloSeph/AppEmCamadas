using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Core.models
{
    public class Music
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ArtistId { get; set; }
        public required Artist Artist { get; set; }
    }
}