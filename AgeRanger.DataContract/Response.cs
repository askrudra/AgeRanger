using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.DataContract
{
    public class Response
    {
        private string _messageCode;
        private string _messageDetails;

        public string MessageCode
        {
            get
            {
                return _messageCode;
            }
            set
            {
                _messageCode = value;
            }
        }

        public string MessageDetails
        {
            get
            {
                return _messageDetails;
            }
            set
            {
                _messageDetails = value;
            }
        }
    }
}
