using QBRating.BLL;
using QBRating.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.CLI.Workflow
{
    class LoadMockData
    {
        public void Execute()
        {
            Manager manager = ManagerFactory.Create();
            manager.AddDataManager();
        }
    }
}
