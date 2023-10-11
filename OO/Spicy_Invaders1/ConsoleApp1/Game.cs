using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Game
    {
        GameLogic GameLogic { get; set; }
        public Game()
        {
            GameLogic = new GameLogic();
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
                GameLogic.PlayerControls(false);
                GameEngine.Clear();

                GameLogic.CheckProjectileBounderies();
                GameLogic.ProjectileCollisionDetection();
                GameEngine.DrawProjectiles(GameLogic.Projectiles);
                GameEngine.DrawPlayer(GameLogic.PlayerShip);
                GameEngine.DrawEnemies(GameLogic.Enemies);


                counter++;
                Thread.Sleep(1);
            }
            return true;
        }
    }
}
