using AgeRanger.Business;
using AgeRanger.DataContract;
using AgeRanger.Data;
using AgeRanger.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgeRanger.Controllers
{
    public class PersonController : ApiController
    {
        [Route("api/person/getlitsofperson")]
        [HttpGet]
        public ListOfPersons GetListOfPersons()
        {
            ListOfPersons lPersons = new ListOfPersons();
            PersonBiz personBiz = new PersonBiz();
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();
            lPersons = personBiz.GetListOfPersonWithDescription(sqlFactory);
            return lPersons;
        }

        [Route("api/person/addperson")]
        [HttpPost]
        public Response AddPerson(PersonModel newPerson)
        {
            PersonBiz personBiz = new PersonBiz();
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();
            

           return  personBiz.AddNewPerson(newPerson, sqlFactory);
        }

        [Route("api/person/searchperson/{name}")]
        [HttpGet]

        public ListOfPersons SearchPerson(string name)
        {
            PersonBiz personBiz = new PersonBiz();
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();
            PersonModel person = new PersonModel();
            person.FirstName = name;
            person.LastName = name;

            return personBiz.SearchForPerson(person, sqlFactory);
        }

        [Route("api/person/editperson")]
        [HttpPost]
        public Response EditPerson(PersonModel person)
        {
            PersonBiz personBiz = new PersonBiz();
            AgeRanger.Data.AgeRangerDataFactory ageRangerDataFactory = new Data.AgeRangerDataFactory();
            ISqlFactory sqlFactory = ageRangerDataFactory.GetReposotory();

            return personBiz.EditPerson(person, sqlFactory);

             
        }

    }
}
