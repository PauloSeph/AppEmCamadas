using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using MyMusic.Core.models;
using MyMusic.Core.Services;

namespace MyMusic.Api.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class MusicsController : ControllerBase
    {

        private readonly IMusicService _musicService;
        public MusicsController(IMusicService musicService)
        {
            this._musicService = musicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();
            return Ok(musics);
        }
    }
}