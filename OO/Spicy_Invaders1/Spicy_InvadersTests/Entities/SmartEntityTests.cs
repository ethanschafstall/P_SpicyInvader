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
    public class SmartEntityTests
    {
        [TestMethod()]
        public void ShootTest()
        {
            // Arrange

            SmartEntity smartEnity = new PlayerShip(0, 1);
            SmartEntity smartEnity2 = new PlayerShip(3, 1);
            SmartEntity smartEnity3 = new Enemy(2, 10, EnemyType.Strawberry);
            SmartEntity smartEnity4 = new Enemy(5, 3, EnemyType.Banana);

            smartEnity.Weapon = WeaponType.Gun;
            smartEnity2.Weapon = WeaponType.LaserGun;
            smartEnity3.Weapon = WeaponType.MissileLauncher;
            smartEnity4.Weapon = WeaponType.Gun;

            // Act

            Projectile projectile = smartEnity.Shoot();
            Projectile projectile2 = smartEnity2.Shoot();
            Projectile projectile3 = smartEnity3.Shoot();
            Projectile projectile4 = smartEnity4.Shoot();

            // Assert

            Assert.AreEqual(projectile.GetType(), typeof(Bullet));
            Assert.AreEqual(projectile2.GetType(), typeof(Laser));
            Assert.AreEqual(projectile3.GetType(), typeof(Missile));
            Assert.AreEqual(projectile4.GetType(), typeof(Bullet));

            Assert.AreEqual(smartEnity.Position.X, projectile.Position.X);
            Assert.AreEqual(smartEnity.Position.Y, projectile.Position.Y);

            Assert.AreEqual(smartEnity2.Position.X, projectile2.Position.X);
            Assert.AreEqual(smartEnity2.Position.Y, projectile2.Position.Y);

            Assert.AreEqual(smartEnity3.Position.X, projectile3.Position.X);
            Assert.AreEqual(smartEnity3.Position.Y, projectile3.Position.Y);

            Assert.AreEqual(smartEnity4.Position.X, projectile4.Position.X);
            Assert.AreEqual(smartEnity4.Position.Y, projectile4.Position.Y);

            Assert.AreEqual(smartEnity.FaceDirection, projectile.TravelDirection);
            Assert.AreEqual(smartEnity2.FaceDirection, projectile2.TravelDirection);
            Assert.AreEqual(smartEnity3.FaceDirection, projectile3.TravelDirection);
            Assert.AreEqual(smartEnity4.FaceDirection, projectile4.TravelDirection);

        }
    }
}