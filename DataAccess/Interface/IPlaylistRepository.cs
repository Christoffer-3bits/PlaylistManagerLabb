using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IPlaylistRepository
    {
        IEnumerable<Playlist> GetAll();
        void Add(Playlist playlist);
        void Update(Playlist playlist);
        void Delete(Playlist playlist);
        Playlist GetById(int id);
    }
}
