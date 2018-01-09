using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OddJobPlatformV1._1.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int jobID { get; set; }
    }

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            Database.SetInitializer<ApplicationDBContext>(new DropCreateDatabaseAlways<ApplicationDBContext>());
        }
        public DbSet<Application> Applications { get; set; }
    }
}