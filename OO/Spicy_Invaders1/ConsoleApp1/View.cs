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

        private static string[] _explosionSprite1;

        private static string[] _explosionSprite2;

        private static string[] _explosionSprite3;

        private static List<ConsoleColor> _explosionColors;
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

            _explosionSprite1 = new string[] { "     ", "  *  ", "     " };

            _explosionSprite2 = new string[] { " ,., "," - - ", " `¨´ " };

            _explosionSprite3 = new string[] { "` ¨ ´", "-   -", ", . ,"};

            _explosionColors = new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.DarkYellow, ConsoleColor.Red };

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
                    DrawExplosion(enemies[i].ExplosionLevel, enemies[i]);
                    break;
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
        public static void DrawExplosion(int frame, MovableEntity entity)
        {
            ConsoleColor color = _explosionColors[0];
            int xPos = entity.Position.X;
            int yPos = entity.Position.Y;

            switch (frame)
            {
                case 1:
                    
                    Console.ForegroundColor = _explosionColors[0];
                    for (int i = 0; i < _explosionSprite1.Length; i++)
                    {
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write(_explosionSprite1[i]);
                        yPos++;
                    }
                    break;
                case 2:
                    for (int i = 0; i < _explosionSprite2.Length; i++)
                    {
                        Console.SetCursorPosition(xPos, yPos);
                        for (int j = 0; j < _explosionSprite2[i].Length; j++)
                        {
                            if ((i == 0 || i == _explosionSprite2.Length - 1) && (j == 1 || j == _explosionSprite2.Length))
                            {
                                color = _explosionColors[1];
                            }
                            else
                            {
                                color = _explosionColors[2];
                            }
                            Console.ForegroundColor = color;
                            Console.Write(_explosionSprite2[i][j]);
                         
                        }
                        yPos++;
                    }
                    break;
                case 3:

                    for (int i = 0; i < _explosionSprite3.Length; i++)
                    {
                        Console.SetCursorPosition(xPos, yPos);
                        for (int j = 0; j < _explosionSprite3[i].Length; j++)
                        {
                            if ((i == 0 || i == _explosionSprite3.Length - 1) && (j == 0 || j == _explosionSprite3[i].Length - 1))
                            {
                                color = _explosionColors[2];
                            }
                            else
                            {
                                color = _explosionColors[1];
                            }
                            Console.ForegroundColor = color;
                            Console.Write(_explosionSprite3[i][j]);
                        }
                        yPos++;

                    }

                    // Reset the foreground color to the default
                    Console.ResetColor();
                    break;
            }
        }
        public static void DrawWindow(int width, int height, ConsoleColor color) 
        {
            Console.ForegroundColor = color;

            Console.SetCursorPosition(0, 0);
            Console.Write(@"╔" + new string('═', width) + "╗");
            for (int i = 0; i < height; i++)
            {
                Console.Write(@"║" + new string(' ', width) + "║");
            }
            Console.Write(@"╚" + new string('═', width) + "╝");
            Console.ResetColor();
        }
        public static void DrawScore(int score, string name, int xpos, int ypos) 
        {
            string text = "";
            if (name is null)
            {
                text = $"Player1 : {score}";
            }
            else
            {
                text = $"{name} : {score}";
            }
            Console.SetCursorPosition(xpos-text.Length-3, ypos);
            Console.Write(text);

        }
        public static void DrawInfo(int xpos, int ypos, int level = 0)
        {
            Console.SetCursorPosition(xpos, ypos);
            Console.Write($"Level : {level}");
            Console.SetCursorPosition(xpos, ypos + 2);
            Console.Write("Options(O)");

        }
        public static void DrawGameTitle(int xpos, int ypos)
        {
            List<string> logo = new List<string> {  "   _____       _            _____                     _               ",
                                                    "  / ____|     (_)          |_   _|                   | |              " ,
                                                    " | (___  _ __  _  ___ _   _  | |  _ ____   ____ _  __| | ___ _ __ ___ " ,
                                                    "  \\___ \\| '_ \\| |/ __| | | | | | | '_ \\ \\ / / _` |/ _` |/ _ \\ '__/ __|" ,
                                                    "  ____) | |_) | | (__| |_| |_| |_| | | \\ V / (_| | (_| |  __/ |  \\__ \\",
                                                    " |_____/| .__/|_|\\___|\\__, |_____|_| |_|\\_/ \\__,_|\\__,_|\\___|_|  |___/",
                                                    "        | |            __/ |                                          ",
                                                    "        |_|           |___/                                           " };
            for (int i = 0; i < logo.Count; i++)
            {
                Console.SetCursorPosition(xpos, ypos + i);
                Console.Write(logo[i]);

            }
        }

    }
}
