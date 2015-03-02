using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models
{
    public class Location
    {
        public Location()
        {
            Users=new HashSet<User>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<User> Users { get; set; } 
    }
}