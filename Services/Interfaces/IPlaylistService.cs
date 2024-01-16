using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPlaylistService
    {
        IEnumerable<Playlist> GetAllPlaylists();
        void CreatePlaylist(Playlist newPlaylist);
        void AddTrackToPlaylist(int playlistId, int trackId);
        void UpdatePlaylistName(int playlistId, string newName);
        void DeletePlaylist(int playlistId);
    }
}
