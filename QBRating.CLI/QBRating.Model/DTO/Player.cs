using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.Model.DTO
{
    public class Player
    {
        public string Name { get; set; }
        public int PassAttempted { get; set; }
        public int PassCompleted { get; set; }
        public int PassingYard { get; set; }
        public int PassingTD { get; set; }
        public int Interceptions { get; set; }
        public decimal CompletionPerAttemptW { get; set; }
        public decimal YardPerGainW { get; set; }
        public decimal TDPassesW { get; set; }
        public decimal IntW { get; set; }
        public double Rating { get; set; }
    }
}
