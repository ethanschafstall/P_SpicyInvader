using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Game
    {
        private GameEngine GameLogic { get; set; }
        private Player player { get; set; }

        private ILanguage language { get; set; }
        public Game(string name, ILanguage language, WeaponType weapon)
        {
            player = new Player(name);
            GameLogic = new GameEngine();
            GameLogic.PlayerShip.Weapon = weapon;
            this.language = language;
        }
        public Game(ILanguage language, WeaponType weapon) 
        {
            player = new Player();
            GameLogic = new GameEngine();
            this.language = language;
            GameLogic.PlayerShip.Weapon = weapon;
        }

        public void Run()
        {
            int enemySpawn = GameSettings.ENEMYSPAWNRATE;
            int enemyMove = GameSettings.ENEMYMOVERATE;
            int projectileMove = GameSettings.PROJECTILEMOVERATE;
            int titleXPos = (GameSettings.WINDOW_WIDTH - 70)/ 2;
            int counter = 0;
            bool gameOver = false;
            string wonOrLost = "";
            ConsoleColor colorTheme = ConsoleColor.White;
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
                View.DrawWindow(GameSettings.WINDOW_WIDTH-2, GameSettings.WINDOW_HEIGHT-2, colorTheme);
                View.DrawGameInfo(language.GameplayText() ,player.Score, player.Alias, GameSettings.WINDOW_WIDTH, 2);
                View.DrawGameTitle(titleXPos, 2);
                GameLogic.CheckProjectileBounderies();
                GameLogic.ProjectileCollisionDetection();
                View.DrawProjectiles(GameLogic.Projectiles);
                View.DrawPlayer(GameLogic.PlayerShip);
                View.DrawEnemies(GameLogic.Enemies);
                GameLogic.UpdateExplosionLevel();
                player.Score += GameLogic.RemoveDeadEnemey();

                counter++;
                Thread.Sleep(1);
                if (wonOrLost != "")
                {
                    gameOver = true;
                }
            }
            for (int i = 1; i < 4; i++)
            {
                View.DrawExplosion(i, GameLogic.PlayerShip);
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
