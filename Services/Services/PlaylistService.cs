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
        private readonly ITrackRepository _trackRepository;
        private readonly IPlaylistTrackRepository _playlistTrackRepository;

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

        public void AddTrackToPlaylist(int playlistId, int trackId)
        {
            var playlist = _playlistRepository.GetById(playlistId);
            var track = _trackRepository.GetById(trackId);

            if (playlist == null)
            {
                Console.WriteLine("Playlist not found.");
                return;
            }

            if (track == null)
            {
                Console.WriteLine("Track not found.");
                return;
            }

            var existingEntry = _playlistTrackRepository.GetByPlaylistIdAndTrackId(playlistId, trackId);

            if (existingEntry != null)
            {
                Console.WriteLine("This track is already in the playlist.");
                return;
            }

            var playlistTrack = new PlaylistTrack { PlaylistId = playlistId, TrackId = trackId };
            _playlistTrackRepository.Add(playlistTrack);

            Console.WriteLine("Track added to playlist successfully.");
        }
    }
}
