using System;
using FlooringMaster.BLL.Interfaces;
using FlooringMaster.BLL.Responses;
using FlooringMaster.BLL;
using System.Collections.Generic;
using FlooringMastery.Data;
using FlooringMaster.Models;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LookupOrder(string orderNumber, int numberID, string URL)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            response.Order = _orderRepository.LoadOrder(orderNumber, numberID, URL);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderNumber} is not a valid Order.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public bool WhichOneToAdd(Order orderInfo)
        {
            if (ValidationAdd(orderInfo.OrderID, orderInfo.CustomerName, orderInfo.AreaProvided))
            {
                _orderRepository.Add(orderInfo);
                return true;
            }
            return false;
        }

        public Order StartingToEdit(Order order)
        {
            return _orderRepository.LoadOrder(order.OrderID, order.NumberID, order.OrderID);
        }

        public void EditOrder(Order orderInfo, int numberID)
        {
            if (ValidationAdd(orderInfo.OrderID, orderInfo.CustomerName, orderInfo.AreaProvided))
            {
                _orderRepository.SaveOrder(orderInfo);
            }

        }

        public bool DeleteOrderID(Order orderInfo, int numberID)
        {
            _orderRepository.Delete(orderInfo);
            _orderRepository.DeleteTest(orderInfo);
            return _orderRepository.DeleteTest(orderInfo);
        }

        public string LoadCheckIndex(string order)
        {
            int newID = _orderRepository.checkIndex(order);
            return newID.ToString();
        }

        public bool ValidationAdd(string orderID, string customerName, decimal areaProvided)
        {
            if (String.IsNullOrWhiteSpace(orderID))
            {
                return false;
            }
            else if (customerName == string.Empty || customerName == " ")
            {
                return false;
            }
            else if (areaProvided < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
