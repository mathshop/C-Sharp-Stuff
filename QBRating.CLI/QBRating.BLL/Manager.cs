using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBRating.Data;
using QBRating.Model.Interface;
using QBRating.Model.DTO;
using QBRating.Model.Responses;

namespace QBRating.BLL
{
    public class Manager
    {
        private IManager _IManager;

        public Manager(IManager mockRepository)
        {
            _IManager = mockRepository;
        }

        public bool AddManager(Player playerInfo)
        {
            if (Validate(playerInfo))
            {
                _IManager.Add(playerInfo);
                return true;
            }
            return false;
        }

        public Player LoadManager(string name)
        {
            Player player = new Player();
            player = _IManager.Load(name);
            return player;
        }

        public void AddDataManager()
        {
            _IManager.AddData();
        }
        public List<Player> LoadAllManager()
        {
            var allPlayer = _IManager.LoadAll().ToList();
            return allPlayer;
        }

        public LookUpResponse LookResponse(string player)
        {
            LookUpResponse response = new LookUpResponse();
            response.player = _IManager.Load(player);

            if (response.player == null)
            {
                response.Success = false;
                response.Message = $"{player} is not a valid Name.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public bool Validate(Player player)
        {
            if (player.Name == string.Empty || player.Name == " ")
            {
                return false;
            }
            else if (player.Interceptions < 0 || player.Interceptions > player.PassAttempted - player.PassCompleted)
            {
                return false;
            }
            else if (player.PassCompleted > player.PassAttempted || player.PassCompleted < 0 || player.PassAttempted < 1)
            {
                return false;
            }
            else if (player.PassingTD > player.PassCompleted || player.PassingTD < 0)
            {
                return false;
            }
            return true;
        }
    }
}
