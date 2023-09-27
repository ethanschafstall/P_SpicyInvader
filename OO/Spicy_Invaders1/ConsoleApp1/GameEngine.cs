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
    public class GameEngine
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

        static GameEngine()
        {
            _strawberrySprite = new List<string> { " w ", "\\ /" };

            _strawberryColors = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Green };

            _bananaSprite = new List<string> { "  ,", " /|", "/ /", "// " };

            _bananaColors = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.DarkGreen };

            _grapeSprite = new List<string> { " ? ", "OoO", "oOo", " o " };

            _grapeColors = new List<ConsoleColor> { ConsoleColor.DarkMagenta, ConsoleColor.Green };

            _melonSprite = new List<string> { "/¯¯¯\\", "|   |", "\\___/" };

            _melonColors = new List<ConsoleColor> { ConsoleColor.DarkGreen, ConsoleColor.DarkGreen };

            _pepperSprite = new List<string> { "/\\ ", "// ", "J  " };

            _pepperColors = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.DarkGreen };
        }

        public static void Init()
        {
            Console.CursorVisible = false;
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
                switch (enemies[i].enemyType)
                {
                    case Enemy.EnemyType.Strawberry:
                        currentEnemySprite = _strawberrySprite;
                        currentEnemyColors = _strawberryColors;
                        break;
                    case Enemy.EnemyType.Melon:
                        currentEnemySprite = _melonSprite;
                        currentEnemyColors = _melonColors;
                        break;
                    case Enemy.EnemyType.Banana:
                        currentEnemySprite = _bananaSprite;
                        currentEnemyColors = _bananaColors;
                        break;
                    case Enemy.EnemyType.Grape:
                        currentEnemySprite = _grapeSprite;
                        currentEnemyColors = _grapeColors;
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
                    Console.SetCursorPosition(enemies[i].XPos, enemies[i].YPos + j);
                    Console.Write(currentEnemySprite[j]);
                }

            }
            Console.ResetColor();
        }
        public static void DrawPlayer(Player myPlayer)
        {
            for (int i = 0; i < _pepperSprite.Count; i++)
            {
                switch (i)
                {
                    default:
                        Console.ForegroundColor = _pepperColors[0];
                        break;
                    case 2:
                        Console.ForegroundColor = _pepperColors[1];
                        break;
                }
                Console.SetCursorPosition(myPlayer.XPos, myPlayer.YPos + i);
                Console.Write(_pepperSprite[i]);
            }
            Console.ResetColor();
        }
        public static void DrawProjectiles(List<Projectile> projectiles)
        {
            if (projectiles == null) return;
            for (int i = 0; i < projectiles.Count; i++) 
            {
                Console.SetCursorPosition(projectiles[i].XPos, projectiles[i].YPos);
                Console.Write("|");
            }
        }
        
        public static void Explode(SmartEntity entityToExplode) 
        {
        }
    }
}
