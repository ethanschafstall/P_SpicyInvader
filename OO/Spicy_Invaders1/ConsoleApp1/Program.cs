
namespace Spicy_Invaders
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Projectile> enemyProjectiles = new List<Projectile>();
            List<Projectile> playerProjectiles = new List<Projectile>();

            Player newPlayer = new Player(GameSettings.PLAYER_START_POS.X, GameSettings.PLAYER_START_POS.Y);
            newPlayer.CanFire = true;
            List<Enemy> myEnemies = new List<Enemy>();
            List<Enemy> myMelons = new List<Enemy>();

            double counter = 0;
            GameEngine.Init();

            while (true)
            {
                if ((counter == 0 || counter % 1.50 == 0))
                {
                    myEnemies.Add(SpawnEnemy());
                }
                if (counter % 20 == 0)
                {
                    myEnemies.Add(SpawnEnemy(true));
                }
                if (counter % 2 == 0)
                {
                    newPlayer.CanFire = true;
                }
                CheckProjectileBounderies(ref enemyProjectiles);
                CheckProjectileBounderies(ref playerProjectiles);
                if (counter % .5 == 0)
                {
                    MoveEnemy(ref myEnemies);
                    //MoveProjectile(ref enemyProjectiles);
                }
                if (counter % .25 == 0)
                {
                    MoveEnemy(ref myMelons);
                    //MoveProjectile(ref enemyProjectiles);
                }
                if (counter % 0.50 == 0)
                {
                    MoveProjectile(ref enemyProjectiles);
                    MoveProjectile(ref playerProjectiles);
                }

                PlayerControls(ref newPlayer, ref playerProjectiles);
                GameEngine.Clear();
                CheckEnemyCollisions(ref myEnemies, ref playerProjectiles);
                GameEngine.DrawEnemies(myEnemies);
                GameEngine.DrawProjectiles(enemyProjectiles);
                GameEngine.DrawProjectiles(playerProjectiles);
                GameEngine.DrawPlayer(newPlayer);
                Thread.Sleep(30);
                counter+=0.25;

                if (counter % 10 == 0)
                {
                    Random random = new Random();
                    int whichEnemy = random.Next(0, myEnemies.Count);
                    enemyProjectiles.Add(myEnemies[whichEnemy].Shoot());
                }
            }
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
            spawnedEnemy.Velocity = new Vector((int)GameSettings.ENEMYSPEED,yVelocity);
            return spawnedEnemy;
            }
            else
            {
                Enemy spawnedMelon = new Enemy(GameSettings.ENEMY_START_POS.X, GameSettings.ENEMY_START_POS.Y, EnemyType.Melon, Direction.Right);
                spawnedMelon.Velocity = new Vector(6, 1);
                return spawnedMelon;
            }
        }
        static void MoveEnemy(ref List<Enemy> myEnemies)
        {
            if (myEnemies == null) return;

            for (int i = 0; i < myEnemies.Count; i++)
            {
                if (myEnemies[i].Position.X + myEnemies[i].Velocity.X > GameSettings.GAMEBOARD_X_LIMIT && myEnemies[i].CurrentDirection == Direction.Right)
                {
                    myEnemies[i].CurrentDirection = Direction.Left;
                    myEnemies[i].Position.Y = myEnemies[i].Position.Y + myEnemies[i].Velocity.Y;
                }
                if (myEnemies[i].Position.X - myEnemies[i].Velocity.X <= 0 && myEnemies[i].CurrentDirection == Direction.Left)
                {
                    myEnemies[i].CurrentDirection = Direction.Right;
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
                if (myProjectiles[i].Position.Y + myProjectiles[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT && myProjectiles[i].CurrentDirection == Direction.Down)
                {
                    myProjectiles.RemoveAt(i);
                }
                else if (myProjectiles[i].Position.Y - myProjectiles[i].Velocity.Y <= 0 && myProjectiles[i].CurrentDirection == Direction.Up)
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
                if (myProjectiles[i].Position.Y + myProjectiles[i].Velocity.Y > GameSettings.GAMEBOARD_Y_LIMIT && myProjectiles[i].CurrentDirection == Direction.Down)
                {
                    myProjectiles.RemoveAt(i);
                }
                else if (myProjectiles[i].Position.Y - myProjectiles[i].Velocity.Y <= 0 && myProjectiles[i].CurrentDirection == Direction.Up)
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
                        if (player.CanFire) { playerProjectiles.Add(player.Shoot()); }
                        player.CanFire = false;
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

        static void CheckEnemyCollisions(ref List<Enemy> myEnemies, ref List<Projectile> playerProjectiles)
        {
            for (int i = 0; i < playerProjectiles.Count; i++)
            {
                for (int j = 0; j < myEnemies.Count; j++)
                {
                    // Adjust this threshold as needed for your game to consider a hit
                    int collisionThreshold = 2;

                    if (Math.Abs(playerProjectiles[i].Position.X - myEnemies[j].Position.X) <= collisionThreshold
                        && Math.Abs(playerProjectiles[i].Position.Y - myEnemies[j].Position.Y) <= collisionThreshold)
                    {
                        myEnemies[j].HealthPoints -= playerProjectiles[i].Damage;
                        myEnemies[j].IsDamaged = true;
                        playerProjectiles.RemoveAt(i);
                        if (myEnemies[j].HealthPoints <= 0)
                        {
                            myEnemies.RemoveAt(j);
                        }
                        break;
                    }
                }
            }
        }
    }
}