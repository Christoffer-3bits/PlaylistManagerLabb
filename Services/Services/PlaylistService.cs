using DataAccess.Interface;
using DataAccess.Repositories;
using Services.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public IEnumerable<Playlist> GetAllPlaylists()
        {
            return _playlistRepository.GetAll();
        }

        public void CreatePlaylist(Playlist newPlaylist)
        {
            _playlistRepository.Add(newPlaylist);
        }
    }
}
