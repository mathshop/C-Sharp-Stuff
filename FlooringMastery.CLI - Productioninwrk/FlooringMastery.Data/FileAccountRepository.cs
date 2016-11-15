using FlooringMaster.BLL;
using FlooringMaster.BLL.Interfaces;
using FlooringMaster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class FileAccountRepository : IOrderRepository
    {
        private string _filePath;
        public FileAccountRepository(string filePath)
        {
            _filePath = filePath;
        }

        public bool CheckIfExist(string URL)
        {
            if (File.Exists(URL))
            {
                return true;
            }
            return false;
        }
        public List<Order> GetAllOrderInfo(string URL)
        {
            List<Order> orders = new List<Order>();

            if (CheckIfExist(URL))
            {
                using (StreamReader sr = new StreamReader(URL, true))
                {
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Order newOrder = new Order();
                        string[] column = line.Split(',');
                        newOrder.NumberID = int.Parse(column[0]);
                        newOrder.OrderID = column[1];
                        newOrder.CustomerName = column[2];
                        newOrder.State = (States)Enum.Parse(typeof(States), column[3]);
                        newOrder.Product = (ProductTypes)Enum.Parse(typeof(ProductTypes), column[4]);
                        newOrder.AreaProvided = Decimal.Parse(column[5]);
                        newOrder.TotalProductCost = Decimal.Parse(column[6]);
                        newOrder.TotalLaborCost = Decimal.Parse(column[7]);
                        newOrder.Tax = Decimal.Parse(column[8]);
                        newOrder.TotalPrice = Decimal.Parse(column[9]);
                        orders.Add(newOrder);
                    }
                }
            }
            else
            {
                CreateOrderFile(orders);
            }
            return orders;
        }

        public Order LoadOrder(string orderID, int numberID, string URL)
        {
            List<Order> orders = GetAllOrderInfo(URL);
            foreach (var order in orders)
            {
                if (orderID == order.OrderID && numberID == order.NumberID)
                {
                    return order;
                }
            }
            return null;
        }

        public void CreateOrderFile(List<Order> accounts)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);
            foreach (var account in accounts)
            {
                string newTextFile = $"{FilePath.directoryfolder}\\Orders_{account.OrderID}.txt";
                using (StreamWriter sw = new StreamWriter(newTextFile))
                {
                    sw.WriteLine("NumberID,OrderID,CustomerName,State,Product,AreaProvided,TotalProductCost,TotalLaborCost,Tax,TotalPrice");
                }
            }
        }

        public void SaveOrder(Order orderInfo)
        {
            FileAccountRepository fileAccount = new FileAccountRepository($"{FilePath.directoryfolder}\\Orders_{orderInfo.OrderID}.txt");
            List<Order> orders = fileAccount.GetAllOrderInfo($"{FilePath.directoryfolder}\\Orders_{orderInfo.OrderID}.txt");
            fileAccount.CreateOrderFile(orders);
            foreach (var order in orders)
            {
                if (order.OrderID == orderInfo.OrderID && order.NumberID == orderInfo.NumberID)
                {
                    order.CustomerName = orderInfo.CustomerName;
                    order.State = orderInfo.State;
                    order.Product = orderInfo.Product;
                    order.AreaProvided = orderInfo.AreaProvided;
                    order.TotalProductCost = orderInfo.TotalProductCost;
                    order.TotalLaborCost = orderInfo.TotalLaborCost;
                    order.Tax = orderInfo.Tax;
                    order.TotalPrice = orderInfo.TotalPrice;
                }

                using (StreamWriter sw = new StreamWriter($"{FilePath.directoryfolder}\\Orders_{orderInfo.OrderID}.txt", true))
                {
                    string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", order.NumberID, order.OrderID, order.CustomerName, order.State, order.Product, order.AreaProvided, order.TotalProductCost, order.TotalLaborCost, order.Tax, order.TotalPrice);
                    sw.WriteLine(line);
                }
            }
        }

        public void Delete(Order orderInfo)
        {
            List<Order> orders = GetAllOrderInfo($"{FilePath.directoryfolder}\\Orders_{orderInfo.OrderID}.txt");
            CreateOrderFile(orders);
            foreach (var order in orders)
            {
                if (order.OrderID == orderInfo.OrderID && order.NumberID == orderInfo.NumberID)
                {
                    continue;
                }
                string newTextFile = $"{FilePath.directoryfolder}\\Orders_{orderInfo.OrderID}.txt";
                using (StreamWriter sw = new StreamWriter(newTextFile, true))
                {
                    string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", order.NumberID, order.OrderID, order.CustomerName, order.State, order.Product, order.AreaProvided, order.TotalProductCost, order.TotalLaborCost, order.Tax, order.TotalPrice);
                    sw.WriteLine(line);
                }
            }
        }

        public void Add(Order orderInfo)
        {
            if (File.Exists($"{FilePath.directoryfolder}\\Orders_{orderInfo.OrderID}.txt"))
            {
                using (StreamWriter sw = new StreamWriter($"{FilePath.directoryfolder}\\Orders_{orderInfo.OrderID}.txt", true))
                {
                    string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", orderInfo.NumberID, orderInfo.OrderID, orderInfo.CustomerName, orderInfo.State, orderInfo.Product, orderInfo.AreaProvided, orderInfo.TotalProductCost, orderInfo.TotalLaborCost, orderInfo.Tax, orderInfo.TotalPrice);
                    sw.WriteLine(line);
                }
            }
        }

        public int checkIndex(string orderID)
        {
            int newID = 0;
            FileAccountRepository fileOrder = new FileAccountRepository($"{FilePath.directoryfolder}\\Orders_{orderID}.txt");
            List<Order> orders = fileOrder.GetAllOrderInfo($"{FilePath.directoryfolder}\\Orders_{orderID}.txt");
            foreach (var order in orders)
            {
                newID = order.NumberID;
                for (int i = 1; i <= orders.Count; i++)
                {
                    if (order.NumberID == i)
                    {
                        newID = i;
                    }
                }
            }
            newID++;
            return newID;
        }

        public bool DeleteTest(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
