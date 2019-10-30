using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;

namespace API2.Controllers
{
    [EnableCors("localhost:4200, http://localhost:4200","*","*")]
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private readonly MusicService _musicService;

        public MusicController(MusicService musicService)
        {
            _musicService = musicService;
        }

        [EnableCors("localhost:4200, http://localhost:4200","*","*")]
        [HttpGet]
        public ActionResult<List<Music>> Get() =>
            _musicService.Get();
        
        [EnableCors("localhost:4200, http://localhost:4200","*", "*")]
        [HttpGet("{id:length(24)}", Name = "GetMusic")]
        public ActionResult<Music> Get(string id)
        {
            var music = _musicService.Get(id);

            if (music == null)
            {
                return NotFound();
            }

            return music;
    }
        
        [EnableCors( "localhost:4200, http://localhost:4200", "*", "*")]
        [HttpPost]
        public ActionResult<Music> Create(Music music)
        {
            _musicService.Create(music);

            return CreatedAtRoute("GetMusic", new { id = music.Id.ToString() }, music);
        }

        [EnableCors( "localhost:4200, http://localhost:4200",  "*", "*")]
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

        [EnableCors("localhost:4200, http://localhost:4200","*",  "*")]
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