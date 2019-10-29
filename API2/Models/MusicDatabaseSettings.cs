namespace API2.Models
{
    public class MusicDatabaseSettings : IMusicDatabaseSettings
    {
        public string MusicsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMusicDatabaseSettings
    {
        string MusicsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}