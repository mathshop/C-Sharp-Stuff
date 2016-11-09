using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMaster.Models;

namespace FlooringMaster.BLL
{
    public static class OrderManagerFactory
    {
        static string mode;
        public static  OrderManager Create()
        {
             mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "TestSystem":
                    return new OrderManager(new MockOrderRepository());
                case "LiveSystem":
                    return new OrderManager(new FileAccountRepository(FilePath.directoryfolder));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
            
        } 
        public static bool IsTestSystemOn()
        {
            Create();
            if (mode == "TestSystem")
            {
                return true;
            }
            return false;
        }
    }
}
