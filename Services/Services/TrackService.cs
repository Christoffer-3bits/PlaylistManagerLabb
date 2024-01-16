using DataAccess.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TrackService
    {
        private readonly TrackRepository _trackRepository;

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
