using AgeRanger.DataContract;
namespace AgeRanger.Interface
{
    public interface IPersonDB
    {
        ListOfPersons GetDataFromPersonTable(ISqlFactory iSqlFactory);

        Response InsertDataIntoPersonTable(PersonModel person, ISqlFactory iSqlFactory);

        Response EditPerson(PersonModel personModel, ISqlFactory iSqlFactory);

        ListAgeGroup GetAgeGroup(ISqlFactory iSqlFactory);
    }
}