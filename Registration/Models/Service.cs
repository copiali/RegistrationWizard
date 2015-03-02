using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Registration.Models
{
    public class Service
    {
        public Service()
        {
            Users=new HashSet<User>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public  virtual ICollection<User> Users { get; set; } 
    }
}