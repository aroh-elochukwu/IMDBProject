using System;
using System.Collections.Generic;

namespace IMDBProject.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }
    }
}
