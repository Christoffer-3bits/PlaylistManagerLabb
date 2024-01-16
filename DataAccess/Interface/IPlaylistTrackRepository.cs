using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IPlaylistTrackRepository
    {
        List<Track> GetTracksByPlaylistId(int playlistId);
        PlaylistTrack GetByPlaylistIdAndTrackId(int playlistId, int trackId);
        void Add(PlaylistTrack playlistTrack);
        void Remove(PlaylistTrack playlistTrack);
    }
}
