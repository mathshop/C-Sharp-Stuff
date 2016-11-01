using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class StartMenuTest
    {
        [Test]
        public void CheckTranslationConverstion()
        {
            //StartMenu testing = new StartMenu();
            var result = 'A';           
            int actual = 0;
            Assert.AreEqual(result, actual);
        }

       
    }
}
