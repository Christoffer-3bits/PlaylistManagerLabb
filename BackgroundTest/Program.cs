using DataAccess;
using DataAccess.Interface;
using DataAccess.Repositories;
using Services.Services;
using Shared.Models;

var playlistRepository = new PlaylistRepository(new MusicDbContext());
var _playlistService = new PlaylistService(playlistRepository);

while (true)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Display full list");
    Console.WriteLine("2. Create new playlist");
    Console.WriteLine("E. Exit");

    var input = Console.ReadLine().ToUpper();

    switch (input)
    {
        case "1":
            DisplayFullList(_playlistService);
            break;
        case "E":
            return;
        case "2":
            CreateNewPlaylist(_playlistService);
            break;
        case "3":
            UpdatePlaylistSubMenu(_playlistService);
            break;
        case "4":
            DeletePlaylist(_playlistService);
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
    Console.Clear();
}

static void UpdatePlaylistSubMenu(PlaylistService _playlistService)
{
    DisplayFullList(_playlistService);
    Console.WriteLine("Please select a playlist:");
    var selectedPlaylist = Console.ReadLine();

    int playlistId;
    if (!int.TryParse(selectedPlaylist, out playlistId))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        return;
    }

    while (true)
    {
        Console.Clear();
        DisplayTracksInPlaylist(playlistId);

        Console.WriteLine("1. Add track");
        Console.WriteLine("2. Remove track");
        Console.WriteLine("3. Update playlist name");
        Console.WriteLine("4. Return to main menu");

        var input = Console.ReadLine().ToUpper();

        switch (input)
        {
            case "1":
                AddTrackToPlaylist(_playlistService, playlistId);
                break;
            case "2":
                RemoveTrackFromPlaylist(_playlistService, playlistId);
                break;
            case "3":
                UpdatePlaylistName(_playlistService, playlistId);
                break;
            case "4":
                Console.Clear();
                return;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
}


#region display
static void DisplayFullList(PlaylistService _playlistService)
{
    var playlists = _playlistService.GetAllPlaylists();

    foreach (var playlist in playlists)
    {
        Console.WriteLine($" {playlist.PlaylistId}, Name: {playlist.Name}");
    }
}

static void DisplayTracksInPlaylist(int playlistId)
{
    // First, check if the playlist exists
    var playlist = playlistRepository.GetById(playlistId);

    if (playlist == null)
    {
        Console.WriteLine("Playlist not found.");
        return;
    }

    // Then, get the tracks associated with the playlist
    var tracks = playlistTrackRepository.GetTracksByPlaylistId(playlistId);

    if (tracks == null || tracks.Count == 0)
    {
        Console.WriteLine("No tracks found in this playlist.");
        return;
    }

    // Display the tracks
    foreach (var track in tracks)
    {
        Console.WriteLine($"Track ID: {track.TrackId}, Track Name: {track.Name}");
    }
}

#endregion


static void CreateNewPlaylist(PlaylistService _playlistService)
{
    Console.WriteLine("Enter name of new playlist");
    var name = Console.ReadLine();

    var newPlaylist = new Playlist
    {
        Name = name
    };

    _playlistService.CreatePlaylist(newPlaylist);
}

static void AddTrackToPlaylist(PlaylistService _playlistService, TrackService _trackService, int playlistId)
{
    while (true)
    {
        Console.WriteLine("Search for a track to add, or 'C' to cancel:");
        SearchTracks(_trackService);

        Console.WriteLine("Enter the ID of the track you want to add, or 'C' to cancel:");
        var input = Console.ReadLine();

        if (input.ToUpper() == "C")
        {
            return;
        }

        int trackId;
        if (!int.TryParse(input, out trackId))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }

        _playlistService.AddTrackToPlaylist(playlistId, trackId);

        Console.WriteLine("Track added successfully.");
        return;
    }
}

static void RemoveTrackFromPlaylist(PlaylistService _playlistService)
{

}

static void UpdatePlaylistName(PlaylistService _playlistService)
{

}

static void DeletePlaylist(PlaylistService _playlistService)
{

}

static void SearchTracks(TrackService _trackService)
{
    while (true)
    {
        Console.WriteLine("Enter search criteria (name, artist, genre), or 'C' to cancel:");
        var criteria = Console.ReadLine();

        if (criteria.ToUpper() == "C")
        {
            return;
        }

        var tracks = _trackService.SearchTracks(criteria);

        if (tracks.Count == 0)
        {
            Console.WriteLine("No tracks found.");
        }
        else
        {
            foreach (var track in tracks)
            {
                Console.WriteLine($"Track ID: {track.TrackId}, Name: {track.Name}, Artist: {track.Artist}, Genre: {track.Genre}");
            }
        }
    }
}