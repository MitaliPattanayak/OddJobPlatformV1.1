using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OddJobPlatformV1._1.Models
{
    public class Job
    {
        public int jobId { get; set; }
        public string jobName { get; set; }
        public string jobType { get; set; }
        public string JobDescription { get; set; }
        public string contactEmail { get; set; }
        public string contactNum { get; set; }
        public int salary { get; set; }
        public string address { get; set; }
        public DateTime expiryDate { get; set; }

    }

    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}