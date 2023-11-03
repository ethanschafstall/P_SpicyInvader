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
    public class MovableEntityTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            // Arrange
            MovableEntity movableEntity = new Drop(0,0, DropType.weaponUpgrade);
            MovableEntity movableEntity2 = new Bullet(1,1);
            MovableEntity movableEntity3 = new PlayerShip(2,2);
            MovableEntity movableEntity4 = new Enemy(3,3, EnemyType.Strawberry);

            movableEntity.Velocity = new Vector(1, 3);
            movableEntity2.Velocity = new Vector(2, 1);
            movableEntity3.Velocity = new Vector(4, 8);
            movableEntity4.Velocity = new Vector(0, 5);

            movableEntity.TravelDirection = Direction.Up;
            movableEntity2.TravelDirection = Direction.Left;
            movableEntity3.TravelDirection = Direction.Right;
            movableEntity4.TravelDirection = Direction.Down;

            // Assert

            movableEntity.Move();
            movableEntity2.Move();
            movableEntity3.Move();
            movableEntity4.Move();

            // Act

            Assert.AreEqual(movableEntity.Position.X, 0);
            Assert.AreEqual(movableEntity.Position.Y, -3);

            Assert.AreEqual(movableEntity2.Position.X, -1);
            Assert.AreEqual(movableEntity2.Position.Y, 1);

            Assert.AreEqual(movableEntity3.Position.X, 6);
            Assert.AreEqual(movableEntity3.Position.Y, 2);

            Assert.AreEqual(movableEntity4.Position.X, 3);
            Assert.AreEqual(movableEntity4.Position.Y, 8);
        }
    }
}