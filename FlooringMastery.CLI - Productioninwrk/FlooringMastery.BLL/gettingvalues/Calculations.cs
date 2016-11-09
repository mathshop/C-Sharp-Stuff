using FlooringMaster.BLL;
using FlooringMaster.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.gettingvalues
{
   public class Calculations
    {
        // I eventually want to read from a database of cost and labor cost so it can easily be implemented rather than saying 2.10m everytime...
        public decimal totalProductCost(ProductTypes product, Order order)
        {
            if (product == ProductTypes.Carpet)
            {
                order.TotalProductCost = order.AreaProvided * 2.25m;
            }
            if (product == ProductTypes.Laminate)
            {
                order.TotalProductCost = order.AreaProvided * 1.75m;
            }
            if (product == ProductTypes.Tile)
            {
                order.TotalProductCost = order.AreaProvided * 3.50m;
            }
            if (product == ProductTypes.Wood)
            {
                order.TotalProductCost = order.AreaProvided * 5.15m;
            }
            return order.TotalProductCost;
        }

        public decimal totalLaborCost(ProductTypes product, Order order)
        {
            if (product == ProductTypes.Carpet)
            {
                order.TotalLaborCost = order.AreaProvided * 2.10m;
            }
            if (product == ProductTypes.Laminate)
            {
                order.TotalLaborCost = order.AreaProvided * 2.10m;
            }
            if (product == ProductTypes.Tile)
            {
                order.TotalLaborCost = order.AreaProvided * 4.15m;
            }
            if (product == ProductTypes.Wood)
            {
                order.TotalLaborCost = order.AreaProvided * 4.75m;
            }
            return order.TotalLaborCost;
        }

        public decimal getTax(States state, Order order)
        {
            if (state == States.IA)
            {
                order.Tax = 6.00m;
            }
            if (state == States.MN)
            {
                order.Tax = 6.875m;
            }
            if (state == States.SD)
            {
                order.Tax = 4.50m;
            }
            if (state == States.ND)
            {
                order.Tax = 5.00m;
            }
            if (state == States.WI)
            {
                order.Tax = 5.00m;
            }
            return order.Tax;
        }

        public decimal getTotalPrice(States state, Order order)
        {
            if (state == States.IA)
            {
                order.TotalPrice = (order.TotalLaborCost + order.TotalProductCost) * 1.06m;
            }
            if (state == States.MN)
            {
                order.TotalPrice = (order.TotalLaborCost + order.TotalProductCost) * 1.06875m;
            }

            if (state == States.SD)
            {
                order.TotalPrice = (order.TotalLaborCost + order.TotalProductCost) * 1.045m;
            }
            if (state == States.ND)
            {
                order.TotalPrice = (order.TotalLaborCost + order.TotalProductCost) * 1.05m;
            }
            if (state == States.WI)
            {
                order.TotalPrice = (order.TotalLaborCost + order.TotalProductCost) * 1.05m;
            }
            return Decimal.Round(order.TotalPrice,2);
        }
    }
}
