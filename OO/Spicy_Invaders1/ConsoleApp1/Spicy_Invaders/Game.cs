using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Language;
using Entity;
using Data;

namespace Spicy_Invaders
{
    /// <summary>
    /// Class which runs the game. Basically the bridge between the other MVC classes.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// GameEngine used
        /// </summary>
        public GameEngine GameLogic { get; set; }
        /// <summary>
        /// Using Playing
        /// </summary>
        public Player Player { get; set; }
        /// <summary>
        /// Screen color option for text, title and border.
        /// </summary>
        private ConsoleColor _color { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        private ILanguage _language { get; set; }


        public Game(ILanguage language, WeaponType weapon, ConsoleColor color, List<ConsoleKey> controls)
        {
            Player = new Player();
            GameLogic = new GameEngine(controls);
            this._language = language;
            GameLogic.PlayerShip.Weapon = weapon;
            _color = color;

        }
        /// <summary>
        /// Game loop.
        /// </summary>
        public void Run()
        {
            // different variables from gamesetting class
            int enemySpawnRate = GameSettings.ENEMYSPAWNRATE;
            int enemyMove = GameSettings.ENEMYMOVERATE;
            int projectileMove = GameSettings.PROJECTILEMOVERATE;
            int titleXPos = (GameSettings.WINDOW_WIDTH - 70) / 2;

            // variables needed for running game loop
            int counter = 0;
            bool gameOver = false;
            int wave = 1;
            bool spawnEnemies = true;
            int normalEnemyToSpawn = 5;
            int melonsToBeSpawned = 1;

            // gameloop
            while (!gameOver)
            {
                // check if o key is pressed so the menu opens
                CheckIfOKeyPressed();

                // if the an enemy can be spawned
                if ((counter == 0 || counter % enemySpawnRate == 0))
                {
                    // if wave is multiply of 3 (meaning its a melon wave), and no normal enemies are to be spawned
                    if (wave % 3 == 0 && normalEnemyToSpawn == 0)
                    {
                        melonsToBeSpawned = wave / 3;
                    }
                    // if its a melon wave and the amount of melons to be spawned is not 0
                    if (wave % 3 == 0 && melonsToBeSpawned != 0)
                    {
                        
                        spawnEnemies = false;
                        GameLogic.SpawnEnemy(true);
                        melonsToBeSpawned -= 1;
                    }
                    // if the enemy count is the same as amount of enemys to be spawn > stop spawning enemies
                    if (GameLogic.Enemies.Count == normalEnemyToSpawn)
                    {
                        spawnEnemies = false;
                    }
                    // if enemies can be spawned and the enemy count is below the amount to be spawned > spawn enemies true
                    if (spawnEnemies && (GameLogic.Enemies.Count < normalEnemyToSpawn))
                    {
                        GameLogic.SpawnEnemy(false, wave);
                    }
                    // If Enemy count is 0 > wave increase, can spawn enemies again, add enemies to be spawned
                    if (GameLogic.Enemies.Count == 0)
                    {
                        normalEnemyToSpawn += 1;
                        spawnEnemies = true;
                        wave++;
                    }

                }
                // if enemies can move > then update enemies positions, and reset hit animations
                if (counter % enemyMove == 0)
                {
                    GameLogic.MoveEnemy();
                    GameLogic.ResetHitAnimations();
                }
                // if projectiles can move > then update projectiles positions, and reset hit animations
                if (counter % projectileMove == 0)
                {
                    GameLogic.MoveProjectile();
                }

                // player movement controls
                GameLogic.PlayerControls();
                // clear screen
                View.Clear();
                // display window border
                View.DrawWindow(GameSettings.WINDOW_WIDTH - 2, GameSettings.WINDOW_HEIGHT - 2, _color);
                // display game info
                View.DrawGameInfo(_language.GameplayText(), Player.Score, Player.Alias, GameSettings.WINDOW_WIDTH, 2, wave);
                // display game title
                View.DrawGameTitle(titleXPos, 2, _color, _language);
                // check projectile positions
                GameLogic.CheckProjectileBounderies();
                // check if projectile positions and enemy/player positions overlap
                GameLogic.ProjectileCollisionDetection();
                // display projectiles
                View.DrawProjectiles(GameLogic.Projectiles);
                // display player
                View.DrawPlayer(GameLogic.PlayerShip);
                // display enemies
                View.DrawEnemies(GameLogic.Enemies);
                // update explosion level for explosion animation
                GameLogic.UpdateExplosionLevel();
                // add points to player score while also removing dead enemies from enemy list
                Player.Score += GameLogic.RemoveDeadEnemey();

                counter++;
                Thread.Sleep(1);
                // if player is dead than game
                if (GameLogic.PlayerShip.IsAlive == false)
                {
                    gameOver = true;
                }
            }
            // display player ship exploding
            for (int i = 1; i < 4; i++)
            {
                View.DrawExplosion(i, GameLogic.PlayerShip);
                Thread.Sleep(750);
            }

            View.DrawWindow(GameSettings.WINDOW_WIDTH - 2, GameSettings.WINDOW_HEIGHT - 2, _color);
            Console.SetCursorPosition(10, 10);
            if (Data.Data.Init()) 
            {
                Console.Write("Enter username");
                Player.Alias = Console.ReadLine();
                Data.Data.SetPlayerScore(Player.Alias, Player.Score);
            }
            Thread.Sleep(1500);
            return;
            
        }
        /// <summary>
        /// In game menu to change options during gameplay
        /// </summary>
        /// <param name="openMenu">if the menu is to be opened or closed</param>
        /// <param name="whichMenu">which menu</param>
        private void InGameMenu(ref bool openMenu, ref int whichMenu)
        {
            MenuCreator creator = new MenuCreator();
            creator.Color = _color;

            switch (whichMenu)
            {
                case 0:
                    
                    switch (creator.GameplayOpitionsMenu(0).Run())
                    {
                        case 0:
                            openMenu = false;
                            return;
                        case 1:
                            whichMenu = 1;
                            return;
                        case 2:
                            whichMenu = 2;
                            return;
                        case 3:
                            Environment.Exit(0);
                            return;
                    }
                    break;
                case 1:
                    switch (creator.GameplayOpitionsMenu(1).Run())
                    {
                        case 0:
                            _color = ConsoleColor.Red;
                            break;
                        case 1:
                            _color = ConsoleColor.Blue;
                            break;
                        case 2:
                            _color = ConsoleColor.Green;
                            break;
                        case 3:
                            _color = ConsoleColor.Cyan;
                            break;
                        case 4:
                            _color = ConsoleColor.Magenta;
                            break;
                    }
                    whichMenu = 0;
                    break;
                case 2:
                    switch (creator.GameplayOpitionsMenu(2).Run())
                    {
                        case 0:
                            GameLogic.PlayerShip.Weapon = WeaponType.Gun;
                            break;
                        case 1:
                            GameLogic.PlayerShip.Weapon = WeaponType.LaserGun;
                            break;
                        case 2:
                            GameLogic.PlayerShip.Weapon = WeaponType.MissileLauncher;
                            break;
                    }
                    whichMenu = 0;
                    break;

            }


        }
        private void CheckIfOKeyPressed() 
        {
            return;
            // If player has opened menu. DISABLE FOR THE MOMENT AS IT IS BUGGY.

            bool openMenu = false;
            int whichMenu = 0;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.O)
                {
                    openMenu = true;
                }
            }
            if (openMenu)
            {
                InGameMenu(ref openMenu, ref whichMenu);
            }
        }
    }
}
