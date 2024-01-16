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
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public List<Track> SearchTracks(string criteria)
        {
            var allTracks = _trackRepository.GetAll();

            var filteredTracks = allTracks.Where(t =>
                t.Name.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                t.Artist.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                t.Genre.Contains(criteria, StringComparison.OrdinalIgnoreCase)).ToList();

            return filteredTracks;
        }
    }
}
