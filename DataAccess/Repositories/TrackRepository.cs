using DataAccess.Interface;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly MusicDbContext _context;

        public TrackRepository(MusicDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Track> GetAll()
        {
            return _context.Tracks.ToList();
        }
    }
}
