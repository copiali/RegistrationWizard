using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.ViewModels
{
    public class UserSignUpModel
    {
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

        public List<int> Services { get; set; } 

        public int? Location { get; set;  }

        public int? Rate { get; set; }

        public string ServiceSource { get; set; }

        public int? EmployeesNo { get; set; }

        public  string  Comments { get; set; }

        public string NewsLetters { get; set; }
    }
}