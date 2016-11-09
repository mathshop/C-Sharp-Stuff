using FlooringMaster.BLL;
using FlooringMaster.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.Models.Responses
{
    public class TaxDepositResponse : Response
    {
        public Order Order { get; set; }
        public decimal preTax { get; set; }

    }
}
