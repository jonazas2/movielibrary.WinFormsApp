using System;
using System.Collections.Generic;

#nullable disable

namespace movielibrary.WinFormsApp.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public TimeSpan? Length { get; set; }
        public string ReleaseCountry { get; set; }
        public string Photo { get; set; }
    }
}
