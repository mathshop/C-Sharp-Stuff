using FlooringMaster.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.BLL
{
    public class Order
    {
        public string OrderID { get; set; }
        public int NumberID { get; set; }
        public string CustomerName { get; set; }
        public States State { get; set; }
        public ProductTypes Product { get; set; }
        public decimal AreaProvided { get; set; }
        public decimal TotalProductCost { get; set; }
        public decimal TotalLaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
