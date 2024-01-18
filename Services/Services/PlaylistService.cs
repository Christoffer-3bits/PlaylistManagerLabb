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

        public void CreatePlaylist(string name)
        {
            var newPlaylist = new Playlist
            {
                Name = name
            };

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

        public void RemoveTrackFromPlaylist(int playlistId, int trackId)
        {
            var playlistTrack = _playlistTrackRepository.GetByPlaylistIdAndTrackId(playlistId, trackId);
            if (playlistTrack != null)
            {
                _playlistTrackRepository.Remove(playlistTrack);
            }
        }

        public void UpdatePlaylistName(int playlistId, string newName)
        {
            var playlist = _playlistRepository.GetById(playlistId);
            if (playlist != null)
            {
                playlist.Name = newName;
                _playlistRepository.Update(playlist);
            }
        }

        public void DeletePlaylist(int playlistId)
        {
            var playlist = _playlistRepository.GetById(playlistId);
            if (playlist != null)
            {
                _playlistRepository.Delete(playlist);
            }
        }

        public string GetPlaylistNameById(int id)
        {
            var playlist = _playlistRepository.GetById(id);
            return playlist?.Name;
        }
    }
}
