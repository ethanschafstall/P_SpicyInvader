using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    /// <summary>
    /// GameLogic class the handles all game behaviours/calculations.
    /// </summary>
    public class GameLogic
    {

        public List<Enemy> Enemies { get; }
        public List<Projectile> Projectiles { get; }
        public Player PlayerShip { get; }

        public GameLogic()
        {
            Enemies = new List<Enemy>();
            Projectiles = new List<Projectile>();
            PlayerShip = new Player(GameSettings.PLAYER_START_POS.X, GameSettings.PLAYER_START_POS.Y);
        }

        /// <summary>
        /// Method responsible for creating new enemy objects and adding them to the Enemies list. 
        /// </summary>
        /// <param name="isMelon">bool if is melon enemy is to be spawned</param>
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
                        yPosition = 0;
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
                spawnedEnemy.Velocity = new Vector((int)GameSettings.ENEMYVELOCITY, yVelocity);
                Enemies.Add(spawnedEnemy);
            }
            else
            {
                Enemy spawnedMelon = new Enemy(GameSettings.ENEMY_START_POS.X, GameSettings.ENEMY_START_POS.Y, EnemyType.Melon, Direction.Right);
                spawnedMelon.Velocity = new Vector(3, 3);
                Enemies.Add(spawnedMelon);
            }
        }

        /// <summary>
        /// Method responsible for moving enemy objects from Enemies list, and removing them from said list, based on enemy move direction and gameboard limits.
        /// </summary>
        /// <returns> Returns true if an enemy has reached bottom gameboard limit, otherwise returns false</returns>
        public bool MoveEnemy()
        {
            if (Enemies == null) return false;

            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].Position.X + Enemies[i].Velocity.X > GameSettings.GAMEBOARD_X_LIMIT && Enemies[i].TravelDirection == Direction.Right)
                {
                    Enemies[i].TravelDirection = Direction.Left;
                    Enemies[i].Position.Y = Enemies[i].Position.Y + Enemies[i].Velocity.Y;
                }
                if (Enemies[i].Position.X - Enemies[i].Velocity.X <= GameSettings.GAMEBOARD_X_START && Enemies[i].TravelDirection == Direction.Left)
                {
                    Enemies[i].TravelDirection = Direction.Right;
                    Enemies[i].Position.Y = Enemies[i].Position.Y + Enemies[i].Velocity.Y;
                }
                if (Enemies[i].Position.Y + Enemies[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT)
                {
                    Enemies.Remove(Enemies[i]);
                    return true;
                }
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Move();
            }
                return false;
        }

        /// <summary>
        /// Method responsible for moving projectile objects from Projectiles list, and removing them from said list. Based on projectile move direction and gameboard limits
        /// </summary>
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

        /// <summary>
        /// Method responsible for checking projectile positions and comparing them with the enemy/player positions to see if there is a collision. 
        /// </summary>
        /// <returns>Returns true if the player was hit, otherwise false</returns>
        public void ProjectileCollisionDetection()
        {
            if (Projectiles == null) return;

            for (int i = 0; i < Projectiles.Count; i++)
            {
                if (Projectiles[i].TravelDirection == Direction.Up)
                {
                    for (int j = 0; j < Enemies.Count; j++)
                    {
                        bool yAxisCondition = false;

                        if (Projectiles[i] is Laser)
                        // Because the laser travels at a faster speed than other projectile types the standard condition
                        // doesn't work as intended so there is a special condition only for the Laser type.
                        {
                            yAxisCondition = Projectiles[i].Position.Y <= Enemies[j].Position.Y+3 || Projectiles[i].Position.Y - Projectiles[i].Velocity.Y <= Enemies[j].Position.Y+3;
                        }
                        else
                        {
                            yAxisCondition = Projectiles[i].Position.Y <= Enemies[j].Position.Y+3;
                        }

                        if (!(Enemies[j].enemyType == EnemyType.Melon))
                        // if the enemy being shot at is not a melon, as melons are bigger so need a different
                        {
                            if (yAxisCondition &&
                                Projectiles[i].Position.X >= Enemies[j].Position.X &&
                                Projectiles[i].Position.X <= Enemies[j].Position.X + 3)
                                // if the projectile x and y postions intersect with the enemy x and y postions then remove both from the list
                            {
                                Enemies[j].Hit(Projectiles[i]);
                                Projectiles.RemoveAt(i);
                                break;
                            }

                        }
                        else
                        {
                            if (yAxisCondition &&
                                Projectiles[i].Position.X >= Enemies[j].Position.X &&
                                Projectiles[i].Position.X <= Enemies[j].Position.X + 4)
                            // if the projectile x and y postions intersect with the enemy x and y postions then remove both from the list
                            {
                                Enemies[j].Hit(Projectiles[i]);
                                Projectiles.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
                else if (Projectiles[i].TravelDirection == Direction.Down)
                {
                    if (Projectiles[i].Position.Y < PlayerShip.Position.Y &&
                        Projectiles[i].Position.X >= PlayerShip.Position.X &&
                        Projectiles[i].Position.X <= PlayerShip.Position.X + 2)
                    {
                        PlayerShip.Hit(Projectiles[i]);
                    }
                }

            }
            return;
        }

        /// <summary>
        /// Method responsible for checking projectile positions and comparing them with the gameboard limits, removing projectiles if they reached a certain boundery
        /// </summary>
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

        /// <summary>
        /// Method responsible for making sure the player is within gameboard bounderies
        /// </summary>
        /// <param name="direction">The direction the player is trying to move in</param>
        /// <returns>Returns true player has reached a limit, otherwise false</returns>
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

        /// <summary>
        ///  Method responsible translating key inputs into player actions.
        /// </summary>
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
