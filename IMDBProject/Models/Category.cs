﻿using System;
using System.Collections.Generic;

namespace IMDBProject.Models
{
    public partial class Category
    {
        public Category()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
