using System;
using System.Collections.Generic;

#nullable disable

namespace movielibrary.WinFormsApp.Models
{
    public partial class Director
    {
        public int DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}
