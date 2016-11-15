using FlooringMaster.BLL;
using FlooringMaster.BLL.Responses;
using FlooringMastery.BLL;
using FlooringMastery.CLI;
using FlooringMastery.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class FreeOrderTest
    {
        [TestCase("11223333", 2, "11223333", true)]
        [TestCase("99999999", 9, "99999999", false)]
        [TestCase("", 1, "", false)]
        public void CanDisplayFreeOrderTestData(string orderID, int index, string url, bool result)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrder(orderID, index, url);
            Assert.AreEqual(result, response.Success);
        }

        [TestCase("11223333", "3")]
        [TestCase("11111111", "1")]
        [TestCase("04252016", "1")]
        public void IndexCounter(string orderID, string expected)
        {
            MockOrderRepository.InMemoryOrderRepo();
            OrderManager manager = OrderManagerFactory.Create();
            var checkIndex = manager.LoadCheckIndex(orderID);
            Assert.AreEqual(expected, checkIndex);
        }


        [TestCase("33333333", 1, "billybob", States.MN, ProductTypes.Laminate, 100, true)]
        [TestCase("33333333", 1, "billybob", States.IA, ProductTypes.Carpet, -100, false)]
        [TestCase("", 1, "billybob", States.IA, ProductTypes.Carpet, -100, false)]
        [TestCase("33333333", 0, "billybob", States.IA, ProductTypes.Carpet, -100, false)]
        [TestCase("33333333", 1, "", States.IA, ProductTypes.Carpet, -100, false)]
        public void CanAddSuccessfully(string order, int id, string customername, States state, ProductTypes product, decimal area, bool expected)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order neworder = new Order();
            neworder.Product = product;
            neworder.NumberID = id;
            neworder.State = state;
            neworder.AreaProvided = area;
            neworder.OrderID = order;
            neworder.CustomerName = customername;
            manager.ValidationAdd(order, customername, area);
            MockOrderRepository.InMemoryOrderRepo();
            var checkIndex = manager.WhichOneToAdd(neworder);
            Assert.AreEqual(expected, checkIndex);
        }

        [TestCase("11223333", 1, true)]
        [TestCase("11223383", 2, false)]
        [TestCase("", 2, false)]

        public void CanRemoveSuccessfully(string order, int index, bool expected)
        {
            Order neworder = new Order();
            neworder.OrderID = order;
            neworder.NumberID = index;
            MockOrderRepository.InMemoryOrderRepo();
            OrderManager manager = OrderManagerFactory.Create();
            var x = manager.DeleteOrderID(neworder, index);
            Assert.AreEqual(expected, x);
        }
    }
}
