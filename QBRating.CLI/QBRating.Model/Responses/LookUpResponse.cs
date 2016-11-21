using QBRating.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.Model.Responses
{
    public class LookUpResponse : Response
    {
        public Player player { get; set; }
        public List<Player> players { get; set; }
    }
}
