using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.BLL.Responses
{
  public  class OrderLookupResponse : Response
    {
        public Order Order { get; set; }
        public int NumberID { get; set; }
    }
}
