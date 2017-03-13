using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.DataContract
{
    public class ListAgeGroup:BaseModel
    {
        public List<AgeGroupModel>  ListOfAgeGroup { get; set; }
        
    }
}
