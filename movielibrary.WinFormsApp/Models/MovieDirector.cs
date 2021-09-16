using System;
using System.Collections.Generic;

#nullable disable

namespace movielibrary.WinFormsApp.Models
{
    public partial class MovieDirector
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
