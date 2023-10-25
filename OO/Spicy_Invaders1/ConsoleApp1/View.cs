using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    /// <summary>
    /// GameEngine Handles all visual aspects of the game. 
    /// </summary>
    public class View
    {
        private static List<string> _strawberrySprite;

        private static List<ConsoleColor> _strawberryColors;

        private static List<string> _bananaSprite;

        private static List<ConsoleColor> _bananaColors;

        private static List<string> _grapeSprite;

        private static List<ConsoleColor> _grapeColors;

        private static List<string> _melonSprite;

        private static List<ConsoleColor> _melonColors;

        private static List<string> _pepperSprite;

        private static List<ConsoleColor> _pepperColors;

        private static List<string> _missileSpriteDown;

        private static List<ConsoleColor> _missileColorsDown;

        private static List<string> _missileSpriteUp;

        private static List<ConsoleColor> _missileColorsUp;

        private static List<ConsoleColor> _HitColors;

        private static List<string> _explosionSprite1;

        private static List<string> _explosionSprite2;

        private static List<string> _explosionSprite3;

        private static List<ConsoleColor> _explosionColors1;

        private static List<ConsoleColor> _explosionColors2;

        private static List<ConsoleColor> _explosionColors3;

        static View()
        {
            _strawberrySprite = new List<string> { " w ", "\\ /" };

            _strawberryColors = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Green };

            _bananaSprite = new List<string> { "  ,", " /|", "/ /", "// " };

            _bananaColors = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.DarkGreen };

            _grapeSprite = new List<string> { " ? ", "OoO", "oOo", " o " };

            _grapeColors = new List<ConsoleColor> { ConsoleColor.DarkMagenta, ConsoleColor.Green };

            _melonSprite = new List<string> { "/¯T¯\\", "| | |", "\\_|_/" };

            _melonColors = new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.DarkGreen };

            _pepperSprite = new List<string> { "/\\ ", "// ", "J  " };

            _pepperColors = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.DarkGreen };

            _missileSpriteDown = new List<string> { "*", "|", "v" };

            _missileSpriteUp = new List<string> { "^", "|", "*" };

            _missileColorsDown = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.DarkGray, ConsoleColor.Red};

            _missileColorsUp = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.DarkGray, ConsoleColor.DarkYellow };

            _HitColors = new List<ConsoleColor> { ConsoleColor.DarkRed, ConsoleColor.DarkRed };

            _explosionSprite1 = new List<string> { "  ", " * ", "  " };

            _explosionSprite2 = new List<string> { "' ' '", "- * -", ", . ," };

            _explosionSprite3 = new List<string> { "\\  |  /", ">  #  <", "/  |  \\" };

            _explosionColors1 = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.DarkRed };

            _explosionColors2 = new List<ConsoleColor> { ConsoleColor.DarkRed, ConsoleColor.DarkYellow };

            _explosionColors3 = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.DarkRed };
        }

        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(GameSettings.WINDOW_WIDTH, GameSettings.WINDOW_HEIGHT);
            Console.SetBufferSize(GameSettings.WINDOW_WIDTH,GameSettings.WINDOW_HEIGHT);
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static void DrawEnemies(List<Enemy> enemies)
        {
            List<string> currentEnemySprite = new List<string> { };
            List<ConsoleColor> currentEnemyColors = new List<ConsoleColor> { };
            if (enemies == null) return;
            for (int i = 0; i < enemies.Count; i++)
            {
                switch (enemies[i].Type)
                {
                    case EnemyType.Strawberry:
                    currentEnemySprite = _strawberrySprite;
                    currentEnemyColors = _strawberryColors;
                        break;
                    case EnemyType.Banana:
                        currentEnemySprite = _bananaSprite;
                        currentEnemyColors = _bananaColors;
                        break;
                    case EnemyType.Grape:
                        currentEnemySprite = _grapeSprite;
                        currentEnemyColors = _grapeColors;
                        break;
                    case EnemyType.Melon:
                        currentEnemySprite = _melonSprite;
                        currentEnemyColors = _melonColors;
                        break;

                }
                if (enemies[i].ShowHitAnimation)
                {
                    currentEnemyColors = _HitColors;
                }
                if (enemies[i].IsAlive == false)
                {
                    switch (enemies[i].ExplosionLevel)
                    {
                        case 1:
                            currentEnemySprite = _explosionSprite1;
                            currentEnemyColors = _explosionColors1;
                            break;
                        case 2:
                            currentEnemySprite = _explosionSprite2;
                            currentEnemyColors = _explosionColors2;
                            break;
                        case 3:
                            currentEnemySprite = _explosionSprite3;
                            currentEnemyColors = _explosionColors3;
                            break;
                    }
                }
                for (int j = 0; j < currentEnemySprite.Count; j++)
                {
                    switch (j)
                    {
                        default:
                            Console.ForegroundColor = currentEnemyColors[0];
                            break;
                        case 0:
                            Console.ForegroundColor = currentEnemyColors[1];
                            break;
                    }
                    Console.SetCursorPosition(enemies[i].Position.X, enemies[i].Position.Y + j);
                    Console.Write(currentEnemySprite[j]);
                }

            }
            Console.ResetColor();
        }
        public static void DrawPlayer(PlayerShip myPlayer)
        {
            List<ConsoleColor> currentColors = new List<ConsoleColor> { };
            if (myPlayer.ShowHitAnimation)
            {
                currentColors = _HitColors;
            }
            else
                        {
                currentColors = _pepperColors;
            }

            for (int i = 0; i < _pepperSprite.Count; i++)
            {
                switch (i)
                {
                    default:
                        Console.ForegroundColor = currentColors[0];
                        break;
                    case 2:
                        Console.ForegroundColor = currentColors[1];
                        break;
                }
                Console.SetCursorPosition(myPlayer.Position.X, myPlayer.Position.Y + i);
                Console.Write(_pepperSprite[i]);
            }
            Console.ResetColor();
        }
        public static void DrawProjectiles(List<Projectile> projectiles)
        {
            List<string> currentMissileSprite = new List<string> { };
            List<ConsoleColor> currentMissileColors = new List<ConsoleColor> { };
            if (projectiles == null) return;
            for (int i = 0; i < projectiles.Count; i++) 
            {
                Console.SetCursorPosition(projectiles[i].Position.X, projectiles[i].Position.Y);
                switch (projectiles[i])
                {
                    case Bullet:
                        Console.Write("|");
                        break;
                    case Laser:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("¦");
                        Console.ResetColor();
                        break;
                    case Missile:
                        switch (projectiles[i].TravelDirection)
                        {
                            case Direction.Up:
                                currentMissileColors = _missileColorsUp;
                                currentMissileSprite = _missileSpriteUp;
                                break;
                            case Direction.Down:
                                currentMissileColors = _missileColorsDown;
                                currentMissileSprite = _missileSpriteDown;
                                break;
                        }
                        for (int j = 0; j < currentMissileSprite.Count; j++)
                        {
                            Console.SetCursorPosition(projectiles[i].Position.X, projectiles[i].Position.Y + j);
                            Console.ForegroundColor = currentMissileColors[j];
                            Console.Write(currentMissileSprite[j]);
                            Console.ResetColor();
                        }
                        break;
                }
            }
        }
        
        public static void ExplodePlayer(int frame, PlayerShip myPlayer)
        {
            List<string> currentSprite = new List<string> { };
            List<ConsoleColor> currentColors = new List<ConsoleColor> { };

            switch (frame)
            {
                case 1:
                    currentSprite = _explosionSprite1;
                    currentColors = _explosionColors1;
                    break;
                case 2:
                    currentSprite = _explosionSprite2;
                    currentColors = _explosionColors2;
                    break;
                case 3:
                    currentSprite = _explosionSprite3;
                    currentColors = _explosionColors3;
                    break;
            }
            for (int i = 0; i < currentSprite.Count; i++)
            {
                switch (i)
                {
                    default:
                        Console.ForegroundColor = currentColors[0];
                        break;
                    case 2:
                        Console.ForegroundColor = currentColors[1];
                        break;
                }
                Console.SetCursorPosition(myPlayer.Position.X, myPlayer.Position.Y + i);
                Console.Write(currentSprite[i]);
            }
            Console.ResetColor();
        }
    }
}
