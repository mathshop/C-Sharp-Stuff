using NUnit.Framework;
using QBRating.BLL;
using QBRating.BLL.Calculations;
using QBRating.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBRating.Test
{
    [TestFixture]
    public class Program
    {
        [TestCase("Cheng", 461, 324, 3969, 35, 10, 112.8, true)]
        [TestCase("Cheng", 300, 400, 3969, 35, 10, 112.8, false)]
        [TestCase("Cheng", 1, 1, 3969, 35, 10, 112.8, false)]
        [TestCase("Cheng", 1, 1, 3969, 10, 0, 112.8, false)]
        [TestCase("Cheng", 0, 1, 3969, 10, 0, 112.8, false)]
        [TestCase("Cheng", -1, 1, 3969, 10, 0, 112.8, false)]
        [TestCase("Cheng", 1, -1, 3969, 10, 0, 112.8, false)]
        [TestCase("Cheng", 1, 1, 3969, 10, -1, 112.8, false)]
        [TestCase("Cheng", 461, 324, 3969, 35, 10 * -1, -10, false)]
        public void AddingPlayer(string playerName, int passesAttempt, int passesComplete, int passYards, int tD, int interceptions, double qbRating, bool expected)
        {
            Manager manager = ManagerFactory.Create();
            Player player = new Player();
            player.Name = playerName;
            player.PassAttempted = passesAttempt;
            player.PassCompleted = passesComplete;
            player.PassingYard = passYards;
            player.PassingTD = tD;
            player.Interceptions = interceptions;
            player.Rating = qbRating;
            var check = manager.AddManager(player);
            Assert.AreEqual(expected, check);

        }

        [TestCase(461, 324, 2.014)]
        public void CalcCompletion(int passAttempt, int passComplete, decimal completion)
        {
            Calculations calc = new Calculations();
            Player player = new Player();
            player.PassAttempted = passAttempt;
            player.PassCompleted = passComplete;
            var result = calc.CalcCompletionPercent(player);
            Assert.AreEqual(completion, result);
        }

        [TestCase(461, 3969, 1.402)]
        public void CalcYPA(int passAttempt, int passYards, decimal completion)
        {
            Calculations calc = new Calculations();
            Player player = new Player();
            player.PassAttempted = passAttempt;
            player.PassingYard = passYards;
            var result = calc.CalcYPA(player);
            Assert.AreEqual(completion, result);
        }

        [TestCase(35, 461, 1.518)]
        public void CalcTD(int td, int attempts, decimal completion)
        {
            Calculations calc = new Calculations();
            Player player = new Player();
            player.PassAttempted = attempts;
            player.PassingTD = td;
            var result = calc.CalcTDPercent(player);
            Assert.AreEqual(completion, result);
        }

        [TestCase(10, 461, 1.833)]
        public void CalcInt(int interceptions, int attempts, decimal completion)
        {
            Calculations calc = new Calculations();
            Player player = new Player();
            player.PassAttempted = attempts;
            player.Interceptions = interceptions;
            var result = calc.CalcIntPercent(player);
            Assert.AreEqual(completion, result);
        }

        [TestCase(461, 324, 3969, 35, 10, 112.8)]
        [TestCase(300, 200, 2500, 20, 5, 107.6)]
        public void CalcRating(int attempt, int completions, int yards, int td, int ints, decimal rating)
        {
            Calculations calc = new Calculations();
            Player player = new Player();
            player.PassAttempted = attempt;
            player.PassCompleted = completions;
            player.PassingYard = yards;
            player.PassingTD = td;
            player.Interceptions = ints;
            var results = calc.CalcRating(player);
            Assert.AreEqual(rating, results);
        }
    }
}
