using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Models
{
    public class User
    {
        public User()
        {
            Services = new HashSet<Service>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }

       
        public string UserName { get; set; }

       
        public string Password { get; set; }

        
        public string Country { get; set; }

      
        public string OrganisationName { get; set; }

        
        public string OrganisationAddress { get; set; }

        
        public string OrganisationContact { get; set; }

      
        public string PriFirstName { get; set; }

        
        public string PriLastName { get; set; }

        
        public string PriEmail { get; set; }

        public string SecFirstName { get; set; }

        public string SecLastName { get; set; }

        public string SecEmail { get; set; }

        public int? Rate { get; set; }

        public string ServiceSource { get; set; }
        public int? EmployeesNo { get; set; }
        public string Comments { get; set; }

        public bool? NewsLetters { get; set; }

        public int? LocationId { get; set; }

        public virtual Location Location { get; set;  }

        public virtual ICollection<Service> Services { get; set; }
    }
}