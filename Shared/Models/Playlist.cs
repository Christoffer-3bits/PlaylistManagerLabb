﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public string Name { get; set; }
    }
}
