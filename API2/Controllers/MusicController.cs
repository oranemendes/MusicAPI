using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private readonly MusicService _musicService;

        public MusicController(MusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet]
        public ActionResult<List<Music>> Get() =>
            _musicService.Get();
        
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Music> Get(string id)
        {
            var music = _musicService.Get(id);

            if (music == null)
            {
                return NotFound();
            }

            return music;
    }
        
        [HttpPost]
        public ActionResult<Music> Create(Music music)
        {
            _musicService.Create(music);

            return CreatedAtRoute("GetMusic", new { id = music.Id.ToString() }, music);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Music musicIn)
        {
            var music = _musicService.Get(id);

            if (music == null)
            {
                return NotFound();
            }

            _musicService.Update(id, musicIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var music = _musicService.Get(id);

            if (music == null)
            {
                return NotFound();
            }

            _musicService.Remove(music.Id);

            return NoContent();
        }
    }
}