using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using AgeRanger.DataContract;
using AgeRanger.Interface;
using System.Data.Common;

namespace AgeRanger.Data
{
    public class PersonDb:IPersonDB
    {
        public Response EditPerson(PersonModel personModel, ISqlFactory iSqlFactory)
        {
            Response response = new Response();
            try
            {
                DbCommand command;
                using (DbConnection conn = iSqlFactory.CreateConnection())
                {
                    string Sqlcommand =string.Format("Update Person Set FirstName = '{0}',LastName = '{1}',Age = {2} Where Id = {3};", personModel.FirstName, personModel.LastName, personModel.Age, personModel.Id);
                    conn.Open();

                    command = iSqlFactory.ExecuteCommand(Sqlcommand, conn);
                    int i = command.ExecuteNonQuery();

                    if (i > 0)
                    {
                        response.MessageCode = "Ok";
                        response.MessageDetails = "Update Successfull.";
                    }
                }
            }
            catch (DbException DbEx)
            {
                response.MessageCode = "Error";
                response.MessageDetails = DbEx.Message;
            }
            return response;
        }

        /// <summary>
        /// Get all data from from AgeGroup
        /// </summary>
        /// <param name="iSqlFactory"></param>
        /// <returns>list</returns>
        public ListAgeGroup GetAgeGroup(ISqlFactory iSqlFactory)
        {
            ListAgeGroup lAgeGroup = new ListAgeGroup();
            lAgeGroup.ListOfAgeGroup = new List<AgeGroupModel>();
            try
            {
                DbDataReader datareader;
                DbCommand command;
                string sqlcommand = "SELECT * From AgeGroup";
                using (DbConnection conn = iSqlFactory.CreateConnection())
                {
                    conn.Open();

                    command = iSqlFactory.ExecuteCommand(sqlcommand, conn);
                    datareader = command.ExecuteReader();

                    while (datareader.Read())
                    {
                        var ageGroup = new AgeGroupModel();

                        ageGroup.Id = Convert.ToInt32(datareader["Id"]);
                        ageGroup.MinAge = Convert.ToInt32(datareader["MinAge"] == DBNull.Value ? null : datareader["MinAge"]);
                        ageGroup.MaxAge = Convert.ToInt32(datareader["MaxAge"] == DBNull.Value ? null : datareader["MaxAge"]);
                        ageGroup.Description = datareader["Description"].ToString();

                        lAgeGroup.ListOfAgeGroup.Add(ageGroup);
                    }
                }
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

        /// <summary>
        /// Get record from Person table.
        /// </summary>
        /// <param name="selectCommand"></param>
        /// <returns></returns>
        public ListOfPersons GetDataFromPersonTable(ISqlFactory iSqlFactory)
        {
            ListOfPersons lPerson = new ListOfPersons();
            lPerson.lPersonModel = new List<PersonModel>();
            PersonModel person;
            try
            {
                DbCommand command;
                DbDataReader datareader;
                string Sqlcommand = "Select * from Person";
                using (DbConnection conn = iSqlFactory.CreateConnection())
                {
                    conn.Open();
                    command = iSqlFactory.ExecuteCommand(Sqlcommand, conn);
                    datareader = command.ExecuteReader();

                    while (datareader.Read())
                    {
                        person = new PersonModel();
                        person.Id = Convert.ToInt32(datareader["Id"]);
                        person.FirstName = datareader["FirstName"].ToString();
                        person.LastName = datareader["LastName"].ToString();
                        person.Age = Convert.ToInt32(datareader["Age"]);

                        lPerson.lPersonModel.Add(person);
                    }

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

        /// <summary>
        /// Insert data into Person Table
        /// </summary>
        /// <param name="personModel"></param>
        /// <param name="iSqlFactory"></param>
        /// <returns>Object</returns>
        public Response InsertDataIntoPersonTable(PersonModel personModel, ISqlFactory iSqlFactory)
        {
            Response response = new Response();
            try
            {
                DbCommand command;
                string Sqlcommand = string.Format("Insert into Person (FirstName, LastName, Age) values('{0}','{1}',{2})", personModel.FirstName, personModel.LastName, personModel.Age);

                using (DbConnection conn = iSqlFactory.CreateConnection())
                {
                    conn.Open();
                    command = iSqlFactory.ExecuteCommand(Sqlcommand, conn);
                    int i = command.ExecuteNonQuery();

                    if (i > 0)
                    {
                        response.MessageCode = "Ok";
                        response.MessageDetails = "Successfully added new Paerson.";
                    }
                }

            }
            catch (DbException ex)
            {

                response.MessageCode = "Error";
                response.MessageDetails = ex.Message;
            }
            return response;
        }

        
    }
}
