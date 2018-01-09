using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OddJobPlatformV1._1.Models
{
    public class JobSeeker
    {
        [Key]
        public int jsId { get; set; }
        [Required]
        public string jsName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string postCode { get; set; }
        [Required]
        public string mobile { get; set; }
        //  public string cv { get; set; }
        [Required]
        public string emailId { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class JobSeekerDBContext: DbContext
    {
        public JobSeekerDBContext()
        {
            Database.SetInitializer<JobSeekerDBContext>(new DropCreateDatabaseAlways<JobSeekerDBContext>());
            //  Database.SetInitializer<JobDBContext>(new DropCreateDatabaseAlways<JobDBContext>());
            //  Database.SetInitializer<JobDBContext>(new JobDBContext>());

        }
        public DbSet<JobSeeker> JobSeekers { get; set; }
    }

}