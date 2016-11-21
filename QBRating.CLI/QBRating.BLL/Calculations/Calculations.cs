using QBRating.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.BLL.Calculations
{
    public class Calculations
    {
        public decimal CalcCompletionPercent(Player player)
        {
            decimal x = player.PassCompleted;
            decimal y = player.PassAttempted;
            decimal z = (((x / y) * 100) - 30) * 0.05m;
            if (z > 2.375m)
            {
                player.CompletionPerAttemptW = 2.375m;
                return 2.375m;
            }
            var results = Math.Round(z, 3);
            player.CompletionPerAttemptW = results;
            return results;
        }

        public decimal CalcYPA(Player player)
        {
            decimal x = player.PassingYard;
            decimal y = player.PassAttempted;
            decimal z = ((x / y) - 3) * 0.25m;
            if (z > 2.375m)
            {
                player.YardPerGainW = 2.375m;
                return 2.375m;
            }
            var results = Math.Round(z, 3);
            player.YardPerGainW = results;
            return results;
        }

        public decimal CalcTDPercent(Player player)
        {
            var x = player.PassingTD;
            var y = player.PassAttempted;
            decimal z = (decimal)x / y * 100;
            decimal final = z * 0.2m;
            if (final > 2.375m)
            {
                player.TDPassesW = 2.375m;
                return 2.375m;
            }
            var results = Math.Round(final, 3);
            player.TDPassesW = results;
            return results;
        }

        public decimal CalcIntPercent(Player player)
        {
            var x = player.Interceptions;
            var y = player.PassAttempted;
            decimal z = (decimal)x / y * 100;
            decimal i = z * 0.25m;
            decimal final = 2.375m - i;
            if (final <= 0)
            {
                player.IntW = 0;
                return 0;
            }
            var results = Math.Round(final, 3);
            player.IntW = results;
            return results;
        }

        public decimal CalcRating(Player player)
        {
            var x = CalcCompletionPercent(player);
            var y = CalcYPA(player);
            var z = CalcTDPercent(player);
            var i = CalcIntPercent(player);
            var sum = x + y + z + i;

            var results = (sum / 6) * 100;
            results = Math.Round(results, 1);
            player.Rating = (double)results;
            return results;
        }
    }
}
