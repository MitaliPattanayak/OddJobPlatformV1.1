using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OddJobPlatformV1._1.Models
{
    public class Validators
    {
        public string getFullName(string firstName, string lastName)
        {
            string fullName = firstName + ' ' + lastName;
            return fullName;
        }

        public bool checkRequiredFields(Job job)
        {
            if (String.IsNullOrEmpty(job.jobName) || String.IsNullOrEmpty(job.jobType) || String.IsNullOrEmpty(job.contactEmail) || String.IsNullOrEmpty(job.contactNum))
                return false;
            else
                return true;
        }

        public bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ExpiryDateValidation(DateTime expiryDate)
        {
            bool result = false;
            if (expiryDate < DateTime.UtcNow)
            {
                 result = false;
            }
            else
                result = true;

            return result;
        }

        public int CheckLimitOfApplicationNumbers()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            int count = db.Applications.ToList().Count;
            return count;
        }
    }
}