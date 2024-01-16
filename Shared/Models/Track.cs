using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }

        public string Artist { get; set; }

        public string Genre { get; set; }
        
    }
}
