using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OddJobPlatformV1._1.Models;
using System.Web.Mvc;
using OddJobPlatformV1._1.Controllers;
using System.Threading.Tasks;
using System.Data.Entity;


namespace OddJobPlatformv1._1.Test
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void CheckControllerReturnsViewNameTest()
        {
            JobsController controller = new JobsController();
            ViewResult result =  controller.Create() as ViewResult;
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void GetFullNameTest()
        {
            string firstName = "Mitali";
            string lastname = "Pattanayak";

            string fullname = "Mitali Pattanayak";
            Validators objVal = new Validators();
            string result = objVal.getFullName(firstName, lastname);

            Assert.AreEqual(fullname, result);
        }

        [TestMethod] // Check Job Name is not null or empty in 'Create Job' page.
        public void Invalid_When_JobName_Is_Null()
        {
            Validators objVal = new Validators();
            Job obj = new Job();
            obj.jobType = "Part-time";
            obj.contactEmail = "test@jk.kil";
            obj.contactNum = "07897889009";
            obj.jobName = "";
            Assert.AreEqual(objVal.checkRequiredFields(obj), false);
        }

        [TestMethod] // Check Job Type is not null or empty in 'Create Job' page.
        public void Invalid_When_JobType_Is_Null()
        {
            Validators objVal = new Validators();
            Job obj = new Job();
            obj.jobName = "Cleaning";
            obj.contactEmail = "test@jk.kil";
            obj.contactNum = "07897889009";
            Assert.AreEqual(objVal.checkRequiredFields(obj), false);
        }

        [TestMethod] // Check Contact Email is not null or empty in 'Create Job' page.
        public void Invalid_When_contactEmail_Is_Null()
        {
            Validators objVal = new Validators();
            Job obj = new Job();
            obj.jobName = "Cleaning";
            obj.jobType = "Part-time";
            obj.contactNum = "07897889009";
            Assert.AreEqual(objVal.checkRequiredFields(obj), false);
        }

        [TestMethod] // Check Contact Number is not null or empty in 'Create Job' page.
        public void Invalid_When_contactNum_Is_Null()
        {
            Validators objVal = new Validators();
            Job obj = new Job();
            obj.jobName = "Cleaning";
            obj.jobType = "Part-time";
            obj.contactEmail = "test@jk.kil";
            Assert.AreEqual(objVal.checkRequiredFields(obj), false);
        }

        [TestMethod] //Check if no required field is empty or null
        public void Valid_When_Nofield_Is_NotNull()
        {
            Validators objVal = new Validators();

            Job obj = new Job();
            obj.jobName = "Cleaning";
            obj.jobType = "Part-time";
            obj.contactEmail = "test@jk.kil";
            obj.contactNum = "23457890";
            Assert.AreEqual(objVal.checkRequiredFields(obj), true);
        }


        [TestMethod] // Check if Email is in correct format
        public void Check_ValidEmail()
        {
            Validators objVal = new Validators();
            Job obj = new Job();
            string email = "test@jk.kil";
            Assert.AreEqual(objVal.emailIsValid(email), true);
        }

        [TestMethod]
        public void Validate_Model_Given_ContactEmail_Exceeds_100_Characters()
        {
            var model = new Job()
            {
                contactEmail = new string('*', 101)
            };
            var results = TestModelHelper.Validate(model);
            Assert.AreNotEqual(1, results.Count);
        }

        [TestMethod]
        public void Validate_ExpiryDate_GreaterOrEqual_to_currentDate()
        {
            DateTime currentDate = DateTime.Now;
            DateTime expiryDate = Convert.ToDateTime("13/12/2017");
            Validators objVal = new Validators();
            bool result = objVal.ExpiryDateValidation(expiryDate);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void Validate_ExpiryDate_GreaterOrEqual_to_currentDate_New()
        {
            DateTime currentDate = DateTime.Now;
            DateTime expiryDate = DateTime.Now.AddDays(2);
            Validators objVal = new Validators();
            bool result = objVal.ExpiryDateValidation(expiryDate);
            Assert.AreEqual(result, true);
        }
    }
}
    
