using Google.Protobuf.WellKnownTypes;
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
    public class PlayerShipTests
    {
        [TestMethod()]
        public void HitTest()
        {
            // arrange

            PlayerShip playership = new PlayerShip(0,1);
            PlayerShip playership2 = new PlayerShip(10, 2);
            PlayerShip playership3 = new PlayerShip(0, 11);

            Bullet bullet = new Bullet(0, 1, Direction.Up);
            Missile missile = new Missile(2, 0, Direction.Left);
            Laser laser = new Laser(0, 10, Direction.Right);

            // act

            playership.Hit(bullet);

            playership2.Hit(laser);
            playership2.Hit(laser);

            playership3.Hit(missile);
            playership3.Hit(missile);
            playership3.Hit(missile);

            // assert

            Assert.AreEqual(playership.HealthPoints, 2);
            Assert.AreEqual(playership2.HealthPoints, 1);
            Assert.AreEqual(playership3.HealthPoints, 0);

            Assert.IsTrue(playership.IsAlive);
            Assert.IsTrue(playership2.IsAlive);
            Assert.IsFalse(playership3.IsAlive);

            Assert.IsTrue(playership.IsHit);
            Assert.IsTrue(playership2.IsHit);
            Assert.IsTrue(playership3.IsHit);
        }
    }
}