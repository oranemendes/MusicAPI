using Microsoft.EntityFrameworkCore;

namespace APIFilRouge.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<MusicItem> MusicItems { get; set; }
    }
}