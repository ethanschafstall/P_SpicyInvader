
namespace Spicy_Invaders
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Projectile> enemyProjectiles = new List<Projectile>();
            List<Projectile> playerProjectiles = new List<Projectile>();

            Player newPlayer = new Player(GameSettings.PLAYER_START_POS.X, GameSettings.PLAYER_START_POS.Y);

            List<Enemy> myEnemies = new List<Enemy>();
            List<Enemy> myMelons = new List<Enemy>();

            double counter = 0;
            GameEngine.Init();
            new Game().Run();


            //while (true)
            //{
            //    if ((counter == 0 || counter % 1.50 == 0))
            //    {
            //        myEnemies.Add(SpawnEnemy());
            //    }
            //    if (counter % 20 == 0)
            //    {
            //        myMelons.Add(SpawnEnemy(true));
            //    }

            //    CheckProjectileBounderies(ref enemyProjectiles);
            //    CheckProjectileBounderies(ref playerProjectiles);
            //    if (counter % .5 == 0)
            //    {
            //        MoveEnemy(ref myEnemies);
            //        //MoveProjectile(ref enemyProjectiles);
            //    }
            //    if (counter % .25 == 0)
            //    {
            //        MoveEnemy(ref myMelons);
            //        //MoveProjectile(ref enemyProjectiles);
            //    }
            //    if (counter % 0.50 == 0)
            //    {
            //        MoveProjectile(ref enemyProjectiles);
            //        MoveProjectile(ref playerProjectiles);
            //    }

            //    PlayerControls(ref newPlayer, ref playerProjectiles);
            //    GameEngine.Clear();
            //    GameEngine.DrawEnemies(myEnemies);
            //    GameEngine.DrawEnemies(myMelons);
            //    GameEngine.DrawProjectiles(enemyProjectiles);
            //    GameEngine.DrawProjectiles(playerProjectiles);
            //    GameEngine.DrawPlayer(newPlayer);
            //    Thread.Sleep(30);
            //    counter+=0.25;

            //    if (counter % 10 == 0)
            //    {
            //        Random random = new Random();
            //        int whichEnemy = random.Next(0, myEnemies.Count);
            //        enemyProjectiles.Add(myEnemies[whichEnemy].Shoot());
            //    }
            //}
        }
        static Enemy SpawnEnemy(bool isMelon = false)
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
            spawnedEnemy.Velocity = new Vector((int)GameSettings.ENEMYVELOCITY,yVelocity);
            return spawnedEnemy;
            }
            else
            {
                Enemy spawnedMelon = new Enemy(GameSettings.ENEMY_START_POS.X, GameSettings.ENEMY_START_POS.Y, EnemyType.Melon, Direction.Right);
                spawnedMelon.Velocity = new Vector(3, 3);
                return spawnedMelon;
            }
        }
        static void MoveEnemy(ref List<Enemy> myEnemies)
        {
            if (myEnemies == null) return;

            for (int i = 0; i < myEnemies.Count; i++)
            {
                if (myEnemies[i].Position.X + myEnemies[i].Velocity.X > GameSettings.GAMEBOARD_X_LIMIT && myEnemies[i].TravelDirection == Direction.Right)
                {
                    myEnemies[i].TravelDirection = Direction.Left;
                    myEnemies[i].Position.Y = myEnemies[i].Position.Y + myEnemies[i].Velocity.Y;
                }
                if (myEnemies[i].Position.X - myEnemies[i].Velocity.X <= 0 && myEnemies[i].TravelDirection == Direction.Left)
                {
                    myEnemies[i].TravelDirection = Direction.Right;
                    myEnemies[i].Position.Y = myEnemies[i].Position.Y + myEnemies[i].Velocity.Y;
                }
                if (myEnemies[i].Position.Y + myEnemies[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT+1)
                {
                    myEnemies.Remove(myEnemies[i]);
                }
            }

            for (int i = 0; i < myEnemies.Count; i++)
            {
                myEnemies[i].Move();
            }
        }
        static void MoveProjectile(ref List<Projectile> myProjectiles)
        {
            if (myProjectiles == null) return;

            for (int i = 0; i < myProjectiles.Count; i++)
            {
                if (myProjectiles[i].Position.Y + myProjectiles[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT && myProjectiles[i].TravelDirection == Direction.Down)
                {
                    myProjectiles.RemoveAt(i);
                }
                else if (myProjectiles[i].Position.Y - myProjectiles[i].Velocity.Y <= 0 && myProjectiles[i].TravelDirection == Direction.Up)
                {
                    myProjectiles.RemoveAt(i);
                }
            }

            for (int i = 0; i < myProjectiles.Count; i++)
            {
                myProjectiles[i].Move();
            }
        }
        static void CheckProjectileBounderies(ref List<Projectile> myProjectiles)
        {
            for (int i = 0; i < myProjectiles.Count; i++)
            {
                if (myProjectiles[i].Position.Y + myProjectiles[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT && myProjectiles[i].TravelDirection == Direction.Down)
                {
                    myProjectiles.RemoveAt(i);
                }
                else if (myProjectiles[i].Position.Y - myProjectiles[i].Velocity.Y <= 0 && myProjectiles[i].TravelDirection == Direction.Up)
                {
                    myProjectiles.RemoveAt(i);
                }
            }
        }
        static void PlayerControls(ref Player player, ref List<Projectile> playerProjectiles)
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
                        playerProjectiles.Add(player.Shoot());
                        break;
                }
                if (direction == Direction.Left && !(player.Position.X > GameSettings.GAMEBOARD_X_START))
                {
                    return;
                }
                else if (direction == Direction.Right && !(player.Position.X < GameSettings.GAMEBOARD_X_LIMIT))
                {
                    return;
                }
                player.Move(direction);
            }
        }
    }
}