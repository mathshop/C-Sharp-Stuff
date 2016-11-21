using QBRating.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.BLL
{
    public class ManagerFactory
    {
        public static Manager Create()
        {
            var mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "TestSystem":
                    return new Manager(new MockRepository());
                case "LiveSystem":
                    //for future implementations            
                default:
                    throw new Exception("Mode value in app config is not valid");
            }

        }
    }
}
