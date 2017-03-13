using AgeRanger.Interface;
using AgeRanger.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using AgeRanger.Data;
using System.Data.SQLite;

namespace AgeRanger.Business
{
    public class PersonBiz : IPerson
    {
        public Response AddNewPerson(PersonModel personModel, ISqlFactory sqlFactory)
        {
            Response response = new Response();
            try
            {                
                IPersonDB person = new PersonDb();
                response = person.InsertDataIntoPersonTable(personModel, sqlFactory);

            }
            catch (DbException ex)
            {

                response.MessageCode = "Error";
                response.MessageDetails = ex.Message;
            }
            return response;
        }

        public Response EditPerson(PersonModel editPerson, ISqlFactory iSqlFactory)
        {
            Response response = new Response();
            try
            {
                IPersonDB person = new PersonDb();
                response = person.EditPerson(editPerson, iSqlFactory);

            }
            catch (DbException ex)
            {

                response.MessageCode = "Error";
                response.MessageDetails = ex.Message;
            }
            return response;
        }

        public ListAgeGroup GetListOfAgeGroup(ISqlFactory iSqlFactory)
        {
            ListAgeGroup lAgeGroup = new ListAgeGroup();
            
            try
            {
                IPersonDB person = new PersonDb();
                lAgeGroup = person.GetAgeGroup(iSqlFactory);
            }
            catch (DbException ex)
            {

                lAgeGroup.Message.Add(new Response
                {
                    MessageCode = "Error",
                    MessageDetails = ex.Message
                });
            }


            return lAgeGroup;
        }

        public ListOfPersons GetListOfPerson(ISqlFactory sqlFactory)
        {
            ListOfPersons lPerson = new ListOfPersons();
            try
            {
                IPersonDB person = new PersonDb();
                lPerson = person.GetDataFromPersonTable(sqlFactory);
            }
            catch (DbException ex)
            {

                lPerson.Message.Add(new Response {
                    MessageCode = "Error",
                     MessageDetails = ex.Message
                });
            }

            return lPerson;
            
        }

        public ListOfPersons GetListOfPersonWithDescription(ISqlFactory iSqlFactory)
        {
            ListOfPersons lPerson = new ListOfPersons();
            try
            {
                IPersonDB person = new PersonDb();
               var ageGroup = GetListOfAgeGroup(iSqlFactory);

                lPerson = person.GetDataFromPersonTable(iSqlFactory);

                foreach (var item in lPerson.lPersonModel)
                {
                    item.Description = ageGroup.ListOfAgeGroup.Where(x => x.MinAge <= item.Age && x.MaxAge > item.Age).Select(z => z.Description).SingleOrDefault();
                }
            }
            catch (DbException ex)
            {

                lPerson.Message.Add(new Response
                {
                    MessageCode = "Error",
                    MessageDetails = ex.Message
                });
            }

            return lPerson;
        }

        public ListOfPersons SearchForPerson(PersonModel personModel, ISqlFactory iSqlFactory)
        {
            ListOfPersons lSearchPerson = new ListOfPersons();
            try
            {
                IPersonDB person = new PersonDb();
                var lPerson = GetListOfPersonWithDescription(iSqlFactory);
                lSearchPerson.lPersonModel = lPerson.lPersonModel.Where(x => x.FirstName == personModel.FirstName || x.LastName == personModel.LastName)
                    .Select(z=> new PersonModel {
                         Id = z.Id,
                          FirstName = z.FirstName,
                           LastName = z.LastName,
                           Age = z.Age,
                           Description = z.Description
                }).ToList();
            }
            catch (DbException ex)
            {

                lSearchPerson.Message.Add(new Response
                {
                    MessageCode = "Error",
                    MessageDetails = ex.Message
                });
            }

            return lSearchPerson;
            
        }
    }
}
