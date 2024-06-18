using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Api.Resources
{
    public class SaveMusicResource
    {
        public required string Name {get; set;}
        public int ArtistId {get; set;}
    }
}