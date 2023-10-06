using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class GameLogic
    {
        public List<Enemy> Enemies { get; } = new List<Enemy>();
        public List<Projectile> Projectiles { get; } = new List<Projectile>();
        public Player PlayerShip { get; } = new Player();

        public void SpawnEnemy(bool isMelon = false)
        {
            if (!isMelon)
            {
                Random random = new Random();
                EnemyType randomType = (EnemyType)random.Next(1, 4);
                int yPosition = 0;
                int yVelocity = 0;
                switch (randomType)
                {
                    case EnemyType.Strawberry:
                        yPosition = 1;
                        yVelocity = 5;
                        break;
                    case EnemyType.Banana:
                        yPosition = 0;
                        yVelocity = 5;
                        break;
                    case EnemyType.Grape:
                        yPosition = 0;
                        yVelocity = 5;
                        break;
                }
                Enemy spawnedEnemy = new Enemy(GameSettings.ENEMY_START_POS.X, GameSettings.ENEMY_START_POS.Y + yPosition, randomType, Direction.Right);
                spawnedEnemy.Velocity = new Vector((int)GameSettings.ENEMYSPEED, yVelocity);
                Enemies.Add(spawnedEnemy);
            }
            else
            {
                Enemy spawnedMelon = new Enemy(GameSettings.ENEMY_START_POS.X, GameSettings.ENEMY_START_POS.Y, EnemyType.Melon, Direction.Right);
                spawnedMelon.Velocity = new Vector(3, 3);
                Enemies.Add(spawnedMelon);
            }
        }
        public void MoveEnemy()
        {
            if (Enemies == null) return;

            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].Position.X + Enemies[i].Velocity.X > GameSettings.GAMEBOARD_X_LIMIT && Enemies[i].TravelDirection == Direction.Right)
                {
                    Enemies[i].TravelDirection = Direction.Left;
                    Enemies[i].Position.Y = Enemies[i].Position.Y + Enemies[i].Velocity.Y;
                }
                if (Enemies[i].Position.X - Enemies[i].Velocity.X <= 0 && Enemies[i].TravelDirection == Direction.Left)
                {
                    Enemies[i].TravelDirection = Direction.Right;
                    Enemies[i].Position.Y = Enemies[i].Position.Y + Enemies[i].Velocity.Y;
                }
                if (Enemies[i].Position.Y + Enemies[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT + 1)
                {
                    Enemies.Remove(Enemies[i]);
                }
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Move();
            }
        }
        public void MoveProjectile()
        {
            if (Projectiles == null) return;

            for (int i = 0; i < Projectiles.Count; i++)
            {
                if (Projectiles[i].Position.Y + Projectiles[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT && Projectiles[i].TravelDirection == Direction.Down)
                {
                    Projectiles.RemoveAt(i);
                }
                else if (Projectiles[i].Position.Y - Projectiles[i].Velocity.Y <= 0 && Projectiles[i].TravelDirection == Direction.Up)
                {
                    Projectiles.RemoveAt(i);
                }
            }

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Move();
            }
        }
        public void EnemyCollisionDetection()
        {
            if (Projectiles == null) return;
            for (int i = 0; i < Projectiles.Count; i++)
            {
                switch (Projectiles[i].Shooter)
                {
                    case Player:

                        for (int j = 0; j < Enemies.Count; j++)
                        {
                            if (Projectiles[i].Position.Y >= Enemies[i].Position.Y)
                            {

                            }
                        }

                        break;
                    case Enemy:
                        if (Projectiles[i].Position.Y >= Enemies[i].Position.Y)
                        {

                        }
                        break;
                }
            }
        }
        public void CheckProjectileBounderies()
        {
            for (int i = 0; i < Projectiles.Count; i++)
            {
                if (Projectiles[i].Position.Y + Projectiles[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT && Projectiles[i].TravelDirection == Direction.Down)
                {
                    Projectiles.RemoveAt(i);
                }
                else if (Projectiles[i].Position.Y - Projectiles[i].Velocity.Y <= 0 && Projectiles[i].TravelDirection == Direction.Up)
                {
                    Projectiles.RemoveAt(i);
                }
            }
        }
        public bool CheckPlayerBounderies(Direction direction)
        {
            if (direction == Direction.Left && !(PlayerShip.Position.X > GameSettings.GAMEBOARD_X_START))
            {
                return true;
            }
            else if (direction == Direction.Right && !(PlayerShip.Position.X < GameSettings.GAMEBOARD_X_LIMIT))
            {
                return true;
            }
            return false;
        }
        public void PlayerControls()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                Direction direction = Direction.None;
                switch (pressedKey.Key)
                {
                    case ConsoleKey.A:
                        direction = Direction.Left;
                        break;
                    case ConsoleKey.D:
                        direction = Direction.Right;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = Direction.Right;
                        break;
                    case ConsoleKey.Spacebar:
                        Projectiles.Add(PlayerShip.Shoot());
                        break;
                }
                if (!CheckPlayerBounderies(direction))
                {
                    PlayerShip.Move(direction);
                }
            }
        }
    }
}
