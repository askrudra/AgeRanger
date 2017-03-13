using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRanger.Business;
using AgeRanger.Interface;
using AgeRanger.DataContract;

namespace AgeRanger.Test
{
    /// <summary>
    /// Testing various functions of PersonBizTest
    /// </summary>
    [TestClass]
    public class PersonBizTest
    {
        public PersonBizTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAgeGroupDataTest()
        {
            PersonBiz person = new PersonBiz();
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();
            var listpfPerson =  person.GetListOfAgeGroup(sqlFactory);

            Assert.IsTrue(listpfPerson.ListOfAgeGroup.Count > 0?true:false || listpfPerson.Message[0].MessageCode != "Error");
        }

        [TestMethod]
        public void AddNewPersonTest()
        {
            bool result = false;

            PersonBiz person = new PersonBiz();

            PersonModel newPerson = new PersonModel();

            newPerson.FirstName = "Anna";
            newPerson.LastName = "George";
            newPerson.Age = 34;
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();
            var response =  person.AddNewPerson(newPerson, sqlFactory);

            var ListofPerson =  person.SearchForPerson(newPerson, sqlFactory);
            foreach (var item in ListofPerson.lPersonModel)
            {
                if (item.FirstName == newPerson.FirstName || item.LastName == newPerson.LastName)
                {
                    result = true;
                }
                
            }
            Assert.IsTrue(result == true);

        }

        [TestMethod]
        public void GetListofPersonTest()
        {
            PersonBiz person = new PersonBiz();
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();

            var listperson =  person.GetListOfPerson(sqlFactory);

            Assert.IsTrue(listperson.lPersonModel.Count > 0 ? true : false || listperson.Message.Count == 0);
        }

        [TestMethod]
        public void GetListOfPersonWithDescription()
        {
            PersonBiz person = new PersonBiz();
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();

            var listperson = person.GetListOfPersonWithDescription(sqlFactory);
        }
    }
}
