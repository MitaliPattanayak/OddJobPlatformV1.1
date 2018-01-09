using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OddJobPlatformV1._1.Models
{
    public class JobProvider
    {
        [Key]
        public int jpID { get; set; }
        [Display(Name = "Name")]
        //[Required]
        public string jpName { get; set; }
        //[Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }
       // [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
       // [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
       // [Required]
        [Display(Name = "Email Id")]
        public string email { get; set; }
       // [Required]
        [Display(Name = "Contact Number")]
        public string contactNum { get; set; }
    }


    public class JobProviderDBContext : DbContext
    {
        public JobProviderDBContext()
        {

        }
        public DbSet<JobProvider> JobProviders { get; set; }
    }
}