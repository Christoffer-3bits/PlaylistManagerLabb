using DataAccess;
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
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}





static void DisplayFullList(PlaylistService _playlistService)
{
    var playlists = _playlistService.GetAllPlaylists();

    foreach (var playlist in playlists)
    {
        Console.WriteLine($" {playlist.PlaylistId}, Name: {playlist.Name}");
    }
}

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