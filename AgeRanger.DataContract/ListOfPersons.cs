using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.DataContract
{
    public class ListOfPersons:BaseModel
    {
        public List<PersonModel> lPersonModel { get; set; }
          
    }
}
