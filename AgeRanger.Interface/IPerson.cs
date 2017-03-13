using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgeRanger.DataContract;

namespace AgeRanger.Interface
{
    public  interface IPerson
    {
        Response AddNewPerson(PersonModel personModel, ISqlFactory iSqlFactory);

        ListOfPersons GetListOfPerson(ISqlFactory iSqlFactory);

        ListOfPersons SearchForPerson(PersonModel personModel, ISqlFactory iSqlFactory);

        ListAgeGroup GetListOfAgeGroup(ISqlFactory iSqlFactory);

        ListOfPersons GetListOfPersonWithDescription(ISqlFactory iSqlFactory);

        Response EditPerson(PersonModel editPerson, ISqlFactory iSqlFactory);

    }
}
