using QBRating.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.Model.Interface
{
    public interface IManager
    {
        Player Load(string name);
        bool Add(Player player);
        List<Player> LoadAll();
        void AddData();
    }
}
