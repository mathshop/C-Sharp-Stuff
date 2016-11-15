using FlooringMaster.BLL;
using FlooringMaster.BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace FlooringMastery.Data
{
    public class MockOrderRepository : IOrderRepository
    {
        private static List<Order> Orders = new List<Order>();

        public static void InMemoryOrderRepo()
        {
            Orders.Add(new Order
            {
                OrderID = "11223333",
                NumberID = 1,
                CustomerName = "Judy",
                State = States.MN,
                Product = ProductTypes.Carpet,
                AreaProvided = 100,
                TotalProductCost = 225,
                TotalLaborCost = 210,
                Tax = 6.875m,
                TotalPrice = 464.91m
            });

            Orders.Add(new Order
            {
                OrderID = "11223333",
                NumberID = 2,
                CustomerName = "Cheng",
                State = States.MN,
                Product = ProductTypes.Carpet,
                AreaProvided = 1,
                TotalProductCost = 225,
                TotalLaborCost = 210,
                Tax = 6.875m,
                TotalPrice = 900.91m
            });
        }

        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public int checkIndex(string orderID)
        {
            int newID = 0;
            foreach (var order in Orders)
            {
                if (order.OrderID == orderID)
                {
                    for (int i = 1; i <= order.NumberID; i++)
                    {
                        if (order.NumberID == i)
                        {
                            newID = i;
                        }
                    }
                }
            }
            newID++;
            return newID;
        }

        public void Delete(Order orderNumber)
        {
            foreach (var order in Orders)
            {
                if (orderNumber.OrderID == order.OrderID && orderNumber.NumberID == order.NumberID)
                {
                    Orders.Remove(orderNumber);
                    break;
                }
            }
        }

        public bool DeleteTest(Order orderNumber)
        {
            foreach (var order in Orders)
            {
                if (orderNumber.OrderID == order.OrderID && orderNumber.NumberID == order.NumberID)
                {
                    Orders.Remove(orderNumber);
                    return true;
                }
            }
            return false;
        }

        public Order LoadOrder(string orderNumber, int numberID, string url)
        {
            foreach (var order in Orders)
            {
                if (orderNumber == order.OrderID && numberID == order.NumberID)
                {
                    return order;
                }
            }
            return null;
        }

        public void SaveOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}




