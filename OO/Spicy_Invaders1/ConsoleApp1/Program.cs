
namespace Spicy_Invaders
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Projectile> enemyProjectiles = new List<Projectile>();
            List<Projectile> playerProjectiles = new List<Projectile>();
            Enemy enemy1 = new Enemy(0,0, Enemy.EnemyType.Banana, MovableEntity.Direction.Right);
            Enemy enemy2 = new Enemy(5, 1, Enemy.EnemyType.Strawberry, MovableEntity.Direction.Right);
            Enemy enemy3 = new Enemy(10, 1, Enemy.EnemyType.Strawberry, MovableEntity.Direction.Right);
            Enemy enemy4 = new Enemy(15, 0, Enemy.EnemyType.Grape, MovableEntity.Direction.Right);
            Enemy enemy5 = new Enemy(20, 0, Enemy.EnemyType.Banana, MovableEntity.Direction.Right);
            Enemy enemy6 = new Enemy(25, 1, Enemy.EnemyType.Strawberry, MovableEntity.Direction.Right);
            Enemy enemy7 = new Enemy(30, 1 , Enemy.EnemyType.Strawberry, MovableEntity.Direction.Right);
            Enemy enemy8 = new Enemy(35, 0, Enemy.EnemyType.Grape, MovableEntity.Direction.Right);
            enemy3.HorizontalMoveSpeed = 1;
            enemy7.HorizontalMoveSpeed = 1;
            enemy3.VerticalMoveSpeed = 1;
            enemy7.VerticalMoveSpeed = 1;
            Player newPlayer = new Player(20,26);

            List<Enemy> myEnemies = new List<Enemy>() { enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8};
            int counter = 0;
            GameEngine.Init();

            while (true) 
            {


                CheckEnemyBounderies(ref myEnemies);
                CheckProjectileBounderies(ref enemyProjectiles);
                if (counter % 1 == 0)
                {
                    MoveEnemy(ref myEnemies);
                    MoveProjectile(ref enemyProjectiles);
                    MovePlayer(ref newPlayer, ref enemyProjectiles);
                }
                GameEngine.Clear();
                GameEngine.DrawEnemies(myEnemies);
                GameEngine.DrawProjectiles(enemyProjectiles);
                GameEngine.DrawPlayer(newPlayer);
                Thread.Sleep(30);
                counter++;
                if (counter == 20) 
                {
                    enemyProjectiles.Add(myEnemies[0].Shoot());
                }
            }
        }
        static void CheckEnemyBounderies(ref List<Enemy> myEnemies) 
        {
            for (int i = 0; i < myEnemies.Count; i++)
            {
                if (myEnemies[i].XPos + myEnemies[i].HorizontalMoveSpeed > GameSettings.GameboardWidth && myEnemies[i].CurrentDirection == MovableEntity.Direction.Right)
                {
                    myEnemies[i].CurrentDirection = MovableEntity.Direction.Left;
                    myEnemies[i].YPos = myEnemies[i].YPos + myEnemies[i].VerticalMoveSpeed;
                }
                if (myEnemies[i].XPos - myEnemies[i].HorizontalMoveSpeed <= 0 && myEnemies[i].CurrentDirection == MovableEntity.Direction.Left)
                {
                    myEnemies[i].CurrentDirection = MovableEntity.Direction.Right;
                    myEnemies[i].YPos = myEnemies[i].YPos + myEnemies[i].VerticalMoveSpeed;
                }
            }
        }
        static void MoveEnemy(ref List<Enemy> myEnemies)
        {
            if (myEnemies == null) return;
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
                myProjectiles[i].Move();
            }
        }
        static void CheckProjectileBounderies(ref List<Projectile> myProjectiles)
        {
            for (int i = 0; i < myProjectiles.Count; i++)
            {
                if (myProjectiles[i].YPos + myProjectiles[i].VerticalMoveSpeed > GameSettings.GameboardHeight && myProjectiles[i].CurrentDirection == MovableEntity.Direction.Down)
                {
                    myProjectiles.RemoveAt(i);
                }
                else if (myProjectiles[i].YPos - myProjectiles[i].VerticalMoveSpeed <= 0 && myProjectiles[i].CurrentDirection == MovableEntity.Direction.Up)
                {
                    myProjectiles.RemoveAt(i);
                }
            }
        }
        static void MovePlayer(ref Player newPlayer, ref List<Projectile> playerProjectiles)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                MovableEntity.Direction direction = MovableEntity.Direction.None;
                switch (pressedKey.Key)
                {
                    case ConsoleKey.A:
                        direction = MovableEntity.Direction.Left;
                        break;
                    case ConsoleKey.D:
                        direction = MovableEntity.Direction.Right;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = MovableEntity.Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = MovableEntity.Direction.Right;
                        break;
                    case ConsoleKey.Spacebar:
                        playerProjectiles.Add(newPlayer.Shoot());
                        break;
                }
                newPlayer.Move(direction);
            }
        }
    }
}