using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Registration.Models;

namespace Registration.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var services = new List<Service>
            {
                new Service {Name = "POP"},
                new Service {Name = "IMAP"},
                new Service {Name = "SMTP"},
                new Service {Name = "POP (Secure)"},
                new Service {Name = "IMAP (Secure)"},
                new Service {Name = "SMTP (Secure)"},
                new Service {Name = "Microsoft Exchange"},
            };
            

            var locaitons = new List<Location>
            {
                new Location{LocationName="Sydney"},
                new Location{LocationName="Melbourne"},
                new Location{LocationName="Brisbane"},
                new Location{LocationName="Perth"},
                new Location{LocationName="Adelaide"},
                new Location{LocationName="Hobart"},
                new Location{LocationName="Darwin"},
                new Location{LocationName="Wollongong"}
            };
            context.Services.AddRange(services);
            context.Locations.AddRange(locaitons);
            context.SaveChanges();
        }
    }
}