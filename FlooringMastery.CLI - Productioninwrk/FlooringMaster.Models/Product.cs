using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.BLL
{
    public class Product
    {
        public ProductTypes Type { get; set; }
        public decimal CostSqFt {get;set;}
        public decimal LaborSqFt { get; set; }
    }
}
