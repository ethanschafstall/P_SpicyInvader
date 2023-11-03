using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spicy_Invaders;


namespace Entity.Tests
{
    [TestClass]
    public class EnemySpawnerTests
    {
        [TestMethod]
        public void SpawnEnemyTest()
        {
            // Arrange
            GameEngine gameEngine = new GameEngine();
            GameEngine gameEngine2 = new GameEngine();
            GameEngine gameEngine3 = new GameEngine();

            int expectedCount = gameEngine.Enemies.Count + 1;
            int expectedCount2 = gameEngine2.Enemies.Count + 2;
            int expectedCount3 = gameEngine2.Enemies.Count + 3;

            // Act
            gameEngine.SpawnEnemy(false);

            gameEngine2.SpawnEnemy(false);
            gameEngine2.SpawnEnemy(false);

            gameEngine3.SpawnEnemy(false);
            gameEngine3.SpawnEnemy(false);
            gameEngine3.SpawnEnemy(false);

            // Assert
            Assert.AreEqual(expectedCount, gameEngine.Enemies.Count);
            Assert.AreEqual(expectedCount2, gameEngine2.Enemies.Count);
            Assert.AreEqual(expectedCount2, gameEngine2.Enemies.Count);
        }

        [TestMethod]
        public void SpawnEnemyTest2()
        {
            // Arrange
            GameEngine gameEngine = new GameEngine();
            GameEngine gameEngine2 = new GameEngine();
            GameEngine gameEngine3 = new GameEngine();

            // Act
            gameEngine.SpawnEnemy(false);
            gameEngine.SpawnEnemy(true);

            gameEngine2.SpawnEnemy(true);
            gameEngine2.SpawnEnemy(true);

            gameEngine3.SpawnEnemy(false);
            gameEngine3.SpawnEnemy(false);

            // Assert
            Assert.AreNotEqual(EnemyType.Melon, gameEngine.Enemies.First().Type);
            Assert.AreEqual(EnemyType.Melon, gameEngine.Enemies.Last().Type);

            Assert.AreEqual(EnemyType.Melon, gameEngine2.Enemies.First().Type);
            Assert.AreEqual(EnemyType.Melon, gameEngine2.Enemies.Last().Type);

            Assert.AreNotEqual(EnemyType.Melon, gameEngine3.Enemies.First().Type);
            Assert.AreNotEqual(EnemyType.Melon, gameEngine3.Enemies.Last().Type);
        }
    }
}