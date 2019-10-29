using API2.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace API2.Services
{
    public class MusicService
    {

        private readonly IMongoCollection<Music> _musics;

        public MusicService(IMusicDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _musics = database.GetCollection<Music>(settings.MusicsCollectionName);
        }

        public List<Music> Get() =>
            _musics.Find(music => true).ToList();

        public Music Get(string id) =>
            _musics.Find<Music>(music => music.Id == id).FirstOrDefault();

        public Music Create(Music music)
        {
            _musics.InsertOne(music);
            return music;
        }

        public void Update(string id, Music musicIn) =>
            _musics.ReplaceOne(music => music.Id == id, musicIn);

        public void Remove(Music musicIn) =>
            _musics.DeleteOne(music => music.Id == musicIn.Id);

        public void Remove(string id) =>
            _musics.DeleteOne(music => music.Id == id);
    }
}