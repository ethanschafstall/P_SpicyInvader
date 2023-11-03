using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Spicy_Invaders
{
    /// <summary>
    /// GameLogic class the handles all game behaviours/calculations.
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ConsoleKey> ControlKeys { get; set; }
        public List<Enemy> Enemies { get; }
        public List<Projectile> Projectiles { get; }
        public PlayerShip PlayerShip { get; }
        public GameEngine(List<ConsoleKey> consoleKeys)
        {
            this.Enemies = new List<Enemy>();
            this.Projectiles = new List<Projectile>();
            this.PlayerShip = new PlayerShip(GameSettings.PLAYER_START_POS.X, GameSettings.PLAYER_START_POS.Y);
            this.ControlKeys = consoleKeys;
        }
        public GameEngine()
        {
            this.Enemies = new List<Enemy>();
            this.Projectiles = new List<Projectile>();
            this.PlayerShip = new PlayerShip(GameSettings.PLAYER_START_POS.X, GameSettings.PLAYER_START_POS.Y);
            this.ControlKeys = new List<ConsoleKey>() { ConsoleKey.LeftArrow, ConsoleKey.RightArrow };
        }
        /// <summary>
        /// Method responsible for creating new enemy objects and adding them to the Enemies list. 
        /// </summary>
        /// <param name="isMelon">bool if is melon enemy is to be spawned</param>
        public void SpawnEnemy(bool isMelon, int wave = 0)
        {
            if (!isMelon)
            {
                Random random = new Random();

                EnemyType randomType = (EnemyType)random.Next(1, 4 + wave);

                int yPosition = 0;
                int yVelocity = 5;
                
                if ((int)randomType-3 > 3)
                {
                    randomType = EnemyType.Grape;
                }
                else
                {
                    randomType = (EnemyType)random.Next(1, 3);
                }

                Enemy spawnedEnemy = new Enemy(GameSettings.ENEMY_START_POS.X, GameSettings.ENEMY_START_POS.Y + yPosition, randomType, Direction.Right);
                spawnedEnemy.Velocity = new Vector((int)GameSettings.ENEMYVELOCITY, yVelocity);
                Enemies.Add(spawnedEnemy);
            }
            else
            {
                Enemy spawnedMelon = new Enemy(GameSettings.ENEMY_START_POS.X, GameSettings.ENEMY_START_POS.Y, EnemyType.Melon, Direction.Right);
                spawnedMelon.Velocity = new Vector(2, 2);
                Enemies.Add(spawnedMelon);
            }
        }

        /// <summary>
        /// Method responsible for moving enemy objects from Enemies list, and removing them from said list, based on enemy move direction and gameboard limits.
        /// </summary>
        /// <returns> Returns true if an enemy has reached bottom gameboard limit, otherwise returns false</returns>
        public void MoveEnemy()
        {
            if (Enemies == null) return;

            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].IsAlive && Enemies[i].Position.X + Enemies[i].Velocity.X > GameSettings.GAMEBOARD_X_LIMIT && Enemies[i].TravelDirection == Direction.Right)
                {
                    Enemies[i].TravelDirection = Direction.Left;
                    Enemies[i].Position.Y = Enemies[i].Position.Y + Enemies[i].Velocity.Y;
                }
                if (Enemies[i].IsAlive && Enemies[i].Position.X - Enemies[i].Velocity.X <= GameSettings.GAMEBOARD_X_START && Enemies[i].TravelDirection == Direction.Left)
                {
                    Enemies[i].TravelDirection = Direction.Right;
                    Enemies[i].Position.Y = Enemies[i].Position.Y + Enemies[i].Velocity.Y;
                }
                if (Enemies[i].Position.Y + Enemies[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT)
                {

                    PlayerShip.IsAlive = false;
                    return;
                }
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].IsAlive)
                {
                    Enemies[i].Move();

                }

            }
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
                        {
                            // Special condition for Laser type
                            yAxisCondition = Projectiles[i].Position.Y <= Enemies[j].Position.Y + 3 ||
                                            (Projectiles[i].Position.Y - Projectiles[i].Velocity.Y < Enemies[j].Position.Y + 3 &&
                                             Projectiles[i].Position.Y >= Enemies[j].Position.Y);
                        }
                        else
                        {
                            // Regular condition for other projectiles
                            yAxisCondition = Projectiles[i].Position.Y <= Enemies[j].Position.Y + 3 &&
                                            Projectiles[i].Position.Y >= Enemies[j].Position.Y;
                        }

                        if (yAxisCondition &&
                            Projectiles[i].Position.X >= Enemies[j].Position.X &&
                            Projectiles[i].Position.X <= Enemies[j].Position.X + Enemies[j].EntityWidth)
                        {
                            Enemies[j].Hit(Projectiles[i]);
                            Projectiles.RemoveAt(i);
                            break;
                        }
                    }
                }
                else if (Projectiles[i].TravelDirection == Direction.Down)
                {
                    if (Projectiles[i].Position.Y < PlayerShip.Position.Y &&
                        Projectiles[i].Position.X >= PlayerShip.Position.X &&
                        Projectiles[i].Position.X <= PlayerShip.Position.X + PlayerShip.EntityWidth)
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
            int maxProjectilesOnScreen = 0;
            ConsoleKey leftKey = ControlKeys[0];
            ConsoleKey rightKey = ControlKeys[1];

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                Direction direction = Direction.None;

                if (pressedKey.Key == leftKey)
                {
                    direction = Direction.Left;
                }
                if (pressedKey.Key == rightKey)
                {
                    direction = Direction.Right;
                }
                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    
                    switch (PlayerShip.Weapon)
                    {
                        case WeaponType.Gun:
                            maxProjectilesOnScreen =  3;
                            break;
                        case WeaponType.LaserGun:
                            maxProjectilesOnScreen = 2;
                            break;
                        case WeaponType.MissileLauncher:
                            maxProjectilesOnScreen = 4;
                            break;
                    }
                    if (Projectiles.Count < maxProjectilesOnScreen)
                    {
                        Projectiles.Add(PlayerShip.Shoot());

                    }
                }

                if (!CheckPlayerBounderies(direction))
                {
                    PlayerShip.Move(direction);
                }
            }
        }
        public void ResetHitAnimations()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].IsHit = false;
            }
            PlayerShip.IsHit = false;
        }
        public int RemoveDeadEnemey()
        {
            int points = 0;
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].IsAlive == false && Enemies[i].ExplosionLevel == 4)
                {
                    points += Enemies[i].Points;
                    Enemies.RemoveAt(i);
                }
            }
            return points;
        }

        public void UpdateExplosionLevel()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                switch (Enemies[i].ExplosionLevel)
                {
                    case 1:
                        Enemies[i].ExplosionLevel = 2;
                        break;
                    case 2:
                        Enemies[i].ExplosionLevel = 3;
                        break;
                    case 3:
                        Enemies[i].ExplosionLevel = 4;
                        break;
                }
            }
        }
    }
}
