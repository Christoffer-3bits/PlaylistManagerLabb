using DataAccess.Interface;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly MusicDbContext _context;

        public PlaylistRepository(MusicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Playlist> GetAll()
        {
            return _context.Playlists.ToList();
        }

        public void Add(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
        }
    }
}
