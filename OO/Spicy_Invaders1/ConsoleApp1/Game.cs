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
            int counter = 0;

            while (true)
            {
                if ((counter == 0 || counter % (int)GameSettings.ENEMYSPAWNRATE == 0) && GameLogic.Enemies.Count < 10)
                {
                    GameLogic.SpawnEnemy();
                }
                if (counter % (int)GameSettings.ENEMYMOVERATE == 0)
                {
                    GameLogic.MoveEnemy();

                }


                if (counter % (int)GameSettings.PROJECTILEMOVERATE == 0)
                {
                    GameLogic.MoveProjectile();
                }
                GameLogic.PlayerControls(false);
                GameEngine.Clear();

                GameLogic.CheckProjectileBounderies();
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
