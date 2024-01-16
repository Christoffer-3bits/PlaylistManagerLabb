using DataAccess.Interface;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PlaylistTrackRepository : IPlaylistTrackRepository
    {
        private readonly MusicDbContext _context;

        public PlaylistTrackRepository(MusicDbContext context)
        {
            _context = context;
        }

        public List<Track> GetTracksByPlaylistId(int playlistId)
        {
            return _context.PlaylistTracks
                .Where(pt => pt.PlaylistId == playlistId)
                .Select(pt => pt.Track)
                .ToList();
        }

        public PlaylistTrack GetByPlaylistIdAndTrackId(int playlistId, int trackId)
        {
            return _context.PlaylistTracks
                .FirstOrDefault(pt => pt.PlaylistId == playlistId && pt.TrackId == trackId);
        }

        public void Add(PlaylistTrack playlistTrack)
        {
            _context.PlaylistTracks.Add(playlistTrack);
            _context.SaveChanges();
        }

        public void Remove(PlaylistTrack playlistTrack)
        {
            _context.PlaylistTracks.Remove(playlistTrack);
            _context.SaveChanges();
        }
    }
}
