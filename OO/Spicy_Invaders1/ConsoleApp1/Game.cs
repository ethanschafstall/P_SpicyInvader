using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Game
    {
        GameEngine GameLogic { get; set; }

        public Game()
        {
            GameLogic = new GameEngine();
        }

        public bool Run()
        {
            int enemySpawn = (int)GameSettings.ENEMYSPAWNRATE;
            int enemyMove = (int)GameSettings.ENEMYMOVERATE;
            int projectileMove = (int)GameSettings.PROJECTILEMOVERATE;
            int counter = 0;

            while (true)
            {
                if ((counter == 0 || counter % enemySpawn == 0) && GameLogic.Enemies.Count < 20)
                {
                    GameLogic.SpawnEnemy();
                }
                if (counter % enemyMove == 0)
                {
                    GameLogic.MoveEnemy();

                }


                if (counter % projectileMove == 0)
                {
                    GameLogic.MoveProjectile();
                }
                GameLogic.PlayerControls();
                View.Clear();

                GameLogic.CheckProjectileBounderies();
                GameLogic.ProjectileCollisionDetection();
                View.DrawProjectiles(GameLogic.Projectiles);
                View.DrawPlayer(GameLogic.PlayerShip);
                View.DrawEnemies(GameLogic.Enemies);
                GameLogic.RemoveDeadEnemey();

                counter++;
                Thread.Sleep(1);
            }
            return true;
        }
    }
}
