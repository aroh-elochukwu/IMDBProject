using System;
using System.Collections.Generic;

namespace IMDBProject.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Role> Roles { get; set; }
    }
}
