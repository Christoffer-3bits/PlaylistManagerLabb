using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DataAccess
{
    public class MusicDbContext : DbContext
    {
        
            public DbSet<Playlist> Playlists { get; set; }
            public DbSet<Track> Tracks { get; set; }
            public DbSet<PlaylistTrack> PlaylistTracks { get; set; }

            public MusicDbContext()
            {
            }

            public MusicDbContext(DbContextOptions<MusicDbContext> options)
                : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PlaylistsDb;Trusted_Connection=True;");
                }
            }
        
    }
}
