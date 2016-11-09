using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RockPaperScissorsV2.BLL;
namespace RockPaperScissorsV2.BLL.Tests
{
    [TestFixture]
    public class RockPaperScissorsGameTests
    {


        //paper beats rock
        //scissors beats paper
        //rock beats scissors
        //rock draws with rock
        //scissors draws with scissors
        //paper draws with paper
        [Test]
        public void RockBeatsScissors()
        {
            IPlayer player1 = new ScissorsPlayer();
            IPlayer player2 = new RockPlayer();
            RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);

            Outcome result = game.Play();

            Assert.AreEqual(Outcome.Player2Wins, result);
        }
        [Test]
        public void RockAlwaysBeatsScissors()
        {
            IPlayer player1 = new RockPlayer();
            IPlayer player2 = new ScissorsPlayer();
            RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);

            Outcome result = game.Play();

            Assert.AreEqual(Outcome.Player1Wins, result);
        }
        [Test]
        public void PaperBeatsRock()
        {
            IPlayer player1 = new PaperPlayer();
            IPlayer player2 = new RockPlayer();
            RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);

            Outcome result = game.Play();

            Assert.AreEqual(Outcome.Player1Wins, result);
        }
        [Test]
        public void ScissorsBeatsPaper()
        {
            IPlayer player1 = new ScissorsPlayer();
            IPlayer player2 = new PaperPlayer();
            RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);

            Outcome result = game.Play();

            Assert.AreEqual(Outcome.Player1Wins, result);
        }
        [Test]
        public void RockDrawsRock()
        {
            IPlayer player1 = new RockPlayer();
            IPlayer player2 = new RockPlayer();
            RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);

            Outcome result = game.Play();

            Assert.AreEqual(Outcome.Draw, result);
        }
        [Test]
        public void ScissorsDrawScissors()
        {
            IPlayer player1 = new ScissorsPlayer();
            IPlayer player2 = new ScissorsPlayer();
            RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);

            Outcome result = game.Play();

            Assert.AreEqual(Outcome.Draw, result);
        }
        [Test]
        public void PaperDrawsPaper()
        {
            IPlayer player1 = new PaperPlayer();
            IPlayer player2 = new PaperPlayer();
            RockPaperScissorsGame game = new RockPaperScissorsGame(player1, player2);

            Outcome result = game.Play();

            Assert.AreEqual(Outcome.Draw, result);
        }
    }
}
