using QBRating.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBRating.Model.DTO;

namespace QBRating.Data
{
    public class MockRepository : IManager
    {
        public static List<Player> Players = new List<Player>();

        public void MockRepositoryData()
        {         
            Players.Add(new Player
            {
                Name = "Steve Young",
                PassAttempted = 461,
                PassCompleted = 324,
                PassingYard = 3969,
                PassingTD = 35,
                Interceptions = 10,

            });

            Players.Add(new Player
            {
                Name = "Daunte Culpepper",
                PassAttempted = 548,
                PassCompleted = 379,
                PassingYard = 4717,
                PassingTD = 39,
                Interceptions = 11,

            });
            Players.Add(new Player
            {
                Name = "Randall Cunningham",
                PassAttempted = 425,
                PassCompleted = 259,
                PassingYard = 3704,
                PassingTD = 34,
                Interceptions = 10,

            });
        }

        public bool Add(Player player)
        {
            Players.Add(player);
            foreach (var newPlayer in Players)
            {
                if (newPlayer.Name == player.Name)
                {
                    return true;
                }                          
            }
            return false;
        }

        public Player Load(string name)
        {
            foreach (var player in Players)
            {
                if(player.Name.ToUpper() == name.ToUpper())
                {
                    return player;
                }               
            }
            return null;
        }

        public List<Player> LoadAll()
        {           
            return Players;
        }

        public void AddData()
        {
            MockRepositoryData();
        }
    }
}
