using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.BLL.Interfaces
{
   public interface IOrderRepository
    {
        Order LoadOrder(string orderNumber, int numberID, string URL); //display
        void SaveOrder(Order order);
        void Delete(Order order);
        bool DeleteTest(Order order);
        void Add(Order order);
        int checkIndex(string orderID);
    }
}
