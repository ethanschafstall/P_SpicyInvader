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

        public void Run()
        {
            int enemySpawn = (int)GameSettings.ENEMYSPAWNRATE;
            int enemyMove = (int)GameSettings.ENEMYMOVERATE;
            int projectileMove = (int)GameSettings.PROJECTILEMOVERATE;
            int counter = 0;
            bool gameOver = false;
            string wonOrLost = "";
            while (!gameOver)
            {
                if ((counter == 0 || counter % enemySpawn == 0) && GameLogic.Enemies.Count < 21)
                {
                    GameLogic.SpawnEnemy();
                }
                if (counter % enemyMove == 0)
                {
                    wonOrLost = GameLogic.MoveEnemy();
                    GameLogic.ResetHitAnimations();

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
                GameLogic.UpdateExplosionLevel();
                GameLogic.RemoveDeadEnemey();

                counter++;
                Thread.Sleep(1);
                if (wonOrLost != "")
                {
                    gameOver = true;
                }
            }
            for (int i = 1; i < 4; i++)
            {
                View.ExplodePlayer(i, GameLogic.PlayerShip);
                Thread.Sleep(750);
            }
            switch (wonOrLost) 
            {
                case "won":
                    Console.WriteLine("you won!");
                    break;
                case "lost":
                    break;
            }

        }
    }
}
