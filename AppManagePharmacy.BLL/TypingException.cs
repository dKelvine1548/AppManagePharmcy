using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagePharmacy.BLL
{
   public  class TypingException:Exception
    {
        public List<KeyValuePair<string, string>> Errors { get; private set; }

        public TypingException() : base()
        {

        }
        public TypingException(string message) : base(message)
        {

        }

        public TypingException(string message, Exception innerException) : base(message, innerException)
        {

        }


    }
}
