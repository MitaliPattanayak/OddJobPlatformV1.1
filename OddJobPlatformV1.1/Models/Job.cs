using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OddJobPlatformV1._1.Models
{
    public class Job
    {
        public int jobId { get; set; }
        [Required]
        public string jobName { get; set; }
        [Required]
        public string jobType { get; set; }
        public string JobDescription { get; set; }
        [Required]
        [StringLength(100)]
        public string contactEmail { get; set; }
        [Required]
        public string contactNum { get; set; }
        public int salary { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public DateTime expiryDate { get; set; }

    }

    public class JobDBContext : DbContext
    {
        public JobDBContext()
        {
            //  Database.SetInitializer<JobDBContext>(new DropCreateDatabaseAlways<JobDBContext>());
          //  Database.SetInitializer<JobDBContext>(new JobDBContext>());
        }
        public DbSet<Job> Jobs { get; set; }
    }
}