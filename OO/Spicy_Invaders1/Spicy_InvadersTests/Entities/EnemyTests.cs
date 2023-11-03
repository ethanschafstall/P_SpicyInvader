using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Tests
{
    [TestClass()]
    public class EnemyTests
    {
        [TestMethod()]
        public void HitTest()
        {
            // arrange
            Enemy enemy = new Enemy(10, 10, EnemyType.Strawberry);
            Enemy enemy2 = new Enemy(10, 10, EnemyType.Melon);
            Enemy enemy3 = new Enemy(10, 10, EnemyType.Banana);

            int baseHealth = enemy.HealthPoints;
            int baseHealth2 = enemy2.HealthPoints;
            int baseHealth3 = enemy3.HealthPoints;

            Bullet bullet = new Bullet(0, 1, Direction.Up);
            Missile missile = new Missile(2, 0, Direction.Left);
            Laser laser = new Laser(0, 10, Direction.Right);

            // act
            enemy.Hit(bullet);
            enemy2.Hit(laser);
            enemy3.Hit(missile);

            // assert
            Assert.AreEqual(enemy.HealthPoints, baseHealth - bullet.Damage);
            Assert.AreEqual(enemy2.HealthPoints, baseHealth2 - laser.Damage);
            Assert.AreEqual(enemy3.HealthPoints, baseHealth3 - missile.Damage);

        }
        [TestMethod()]
        public void HitTest2()
        {
            // attribut
            Enemy enemy = new Enemy(10, 10, EnemyType.Strawberry);
            Enemy enemy2 = new Enemy(10, 10, EnemyType.Banana);

            Bullet bullet = new Bullet(0, 1, Direction.Up);
            Missile missile = new Missile(2, 0, Direction.Left);

            // act
            enemy.Hit(bullet);
            enemy.Hit(bullet);
            enemy2.Hit(missile);

            // assert
            Assert.IsFalse(enemy.IsAlive);
            Assert.AreEqual(enemy.ExplosionLevel, 1);
            Assert.IsFalse(enemy2.IsAlive);
            Assert.AreEqual(enemy2.ExplosionLevel, 1);


        }
    }
}