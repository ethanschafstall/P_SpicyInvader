using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Language;
using Entity;

namespace Spicy_Invaders
{
    public class Game
    {
        public GameEngine GameLogic { get; set; }
        public Player Player { get; set; }
        private ConsoleColor _color { get; set; }
        private ILanguage _language { get; set; }

        public Game(ILanguage language, WeaponType weapon, ConsoleColor color, List<ConsoleKey> controls)
        {
            Player = new Player();
            GameLogic = new GameEngine(controls);
            this._language = language;
            GameLogic.PlayerShip.Weapon = weapon;
            _color = color;

        }

        public void Run()
        {
            int enemySpawnRate = GameSettings.ENEMYSPAWNRATE;
            int enemyMove = GameSettings.ENEMYMOVERATE;
            int projectileMove = GameSettings.PROJECTILEMOVERATE;
            int titleXPos = (GameSettings.WINDOW_WIDTH - 70) / 2;
            int counter = 0;
            bool gameOver = false;
            string wonOrLost = "";
            int level = 1;
            bool spawnEnemies = true;
            int amountToSpawn = 5;
            int melonAmount = 1;
            while (!gameOver)
            {

                if ((counter == 0 || counter % enemySpawnRate == 0))
                {

                    if (level % 3 == 0 && amountToSpawn == 0)
                    {
                        melonAmount = level / 3;
                    }
                    if (level % 3 == 0 && melonAmount != 0)
                    {
                        spawnEnemies = false;
                        GameLogic.SpawnEnemy(true);
                        melonAmount -= 1;
                    }
                    if (GameLogic.Enemies.Count == amountToSpawn)
                    {
                        spawnEnemies = false;
                    }
                    if (spawnEnemies && (GameLogic.Enemies.Count < amountToSpawn))
                    {
                        GameLogic.SpawnEnemy(false);
                    }
                    if (GameLogic.Enemies.Count == 0)
                    {
                        amountToSpawn += 1;
                        spawnEnemies = true;
                        level++;
                    }

                }


                if (counter % enemyMove == 0)
                {
                    GameLogic.MoveEnemy();
                    GameLogic.ResetHitAnimations();
                }


                if (counter % projectileMove == 0)
                {
                    GameLogic.MoveProjectile();
                }

                GameLogic.PlayerControls();
                View.Clear();
                View.DrawWindow(GameSettings.WINDOW_WIDTH - 2, GameSettings.WINDOW_HEIGHT - 2, _color);
                View.DrawGameInfo(_language.GameplayText(), Player.Score, Player.Alias, GameSettings.WINDOW_WIDTH, 2, level);
                View.DrawGameTitle(titleXPos, 2, _color, _language);
                GameLogic.CheckProjectileBounderies();
                GameLogic.ProjectileCollisionDetection();
                View.DrawProjectiles(GameLogic.Projectiles);
                View.DrawPlayer(GameLogic.PlayerShip);
                View.DrawEnemies(GameLogic.Enemies);
                GameLogic.UpdateExplosionLevel();
                Player.Score += GameLogic.RemoveDeadEnemey();

                counter++;
                Thread.Sleep(1);

                if (!GameLogic.PlayerShip.IsAlive)
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
