using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.DataContract
{
    public enum ResponseStatus { Ok = 0, Error = 1 }
    public  class BaseModel
    {
        public List<Response> Message { get; set; }
        public ResponseStatus Staus { get; set; }

        public BaseModel()
        {
            Message = new List<Response>();
        }

        public void AddMessage(Response message)
        {
            Message.Add(message);
        }
    }
}
