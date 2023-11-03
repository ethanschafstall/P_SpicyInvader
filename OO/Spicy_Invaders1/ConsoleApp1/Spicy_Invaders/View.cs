using Entity;
using System.Drawing;
using Language;

namespace Spicy_Invaders
{
    /// <summary>
    /// View Class which Handles all visual aspects of the game. 
    /// </summary>
    public class View
    {
        /// <summary>
        /// string list for strawberry enemy sprite.
        /// </summary>
        private static List<string> _strawberrySprite;

        /// <summary>
        /// consolecolor list for strawberry enemy sprite colors.
        /// </summary>
        private static List<ConsoleColor> _strawberryColors;

        /// <summary>
        /// string list for banana enemy sprite.
        /// </summary>
        private static List<string> _bananaSprite;

        /// <summary>
        /// consolecolor list for banana enemy sprite colors.
        /// </summary>
        private static List<ConsoleColor> _bananaColors;

        /// <summary>
        /// string list for grape enemy sprite.
        /// </summary>
        private static List<string> _grapeSprite;

        /// <summary>
        /// consolecolor list for grape enemy sprite colors.
        /// </summary>
        private static List<ConsoleColor> _grapeColors;

        /// <summary>
        /// string list for melon enemy sprite.
        /// </summary>
        private static List<string> _melonSprite;

        /// <summary>
        /// consolecolor list for melon enemy sprite colors.
        /// </summary>
        private static List<ConsoleColor> _melonColors;

        /// <summary>
        /// string list for pepper(player) enemy sprite.
        /// </summary>
        private static List<string> _pepperSprite;

        /// <summary>
        /// consolecolor list for pepper(the player) enemy sprite colors.
        /// </summary>
        private static List<ConsoleColor> _pepperColors;

        /// <summary>
        /// string list for missile projectile sprite moving down.
        /// </summary>
        private static List<string> _missileSpriteDown;

        /// <summary>
        /// consolecolor list for missile projectile sprite moving down.
        /// </summary>
        private static List<ConsoleColor> _missileColorsDown;

        /// <summary>
        /// string list for missile projectile sprite moving up.
        /// </summary>
        private static List<string> _missileSpriteUp;

        /// <summary>
        /// consolecolor list for missile projectile sprite moving up.
        /// </summary>
        private static List<ConsoleColor> _missileColorsUp;

        /// <summary>
        /// consolecolor list for entites that have been hit.
        /// </summary>
        private static List<ConsoleColor> _HitColors;

        /// <summary>
        /// string list for entites on explosion level 1 sprite.
        /// </summary>
        private static string[] _explosionSprite1;

        /// <summary>
        /// string list for entites on explosion level 2 sprite.
        /// </summary>
        private static string[] _explosionSprite2;

        /// <summary>
        /// string list for entites on explosion level 3 sprite.
        /// </summary>
        private static string[] _explosionSprite3;

        /// <summary>
        /// consolecolor list for explosion level sprites.
        /// </summary>
        private static List<ConsoleColor> _explosionColors;

        /// <summary>
        /// static constructor, which initializes all class variables.
        /// </summary>
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

            _missileColorsDown = new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.DarkGray, ConsoleColor.Red };

            _missileColorsUp = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.DarkGray, ConsoleColor.DarkYellow };

            _HitColors = new List<ConsoleColor> { ConsoleColor.DarkRed, ConsoleColor.DarkRed };

            _explosionSprite1 = new string[] { "     ", "  *  ", "     " };

            _explosionSprite2 = new string[] { " ,., ", " - - ", " `¨´ " };

            _explosionSprite3 = new string[] { "` ¨ ´", "-   -", ", . ," };

            _explosionColors = new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.DarkYellow, ConsoleColor.Red };

        }

        /// <summary>
        /// Method Init for hiding the cursor and setting window/buffer sizes.
        /// </summary>
        /// <param name="game">bool game para if the window is for the game or for the program(menus screens)</param>
        public static void Init(bool game)
        {
            Console.CursorVisible = false;
            if (game)
            {
                Console.SetWindowSize(GameSettings.WINDOW_WIDTH, GameSettings.WINDOW_HEIGHT);
                Console.SetBufferSize(GameSettings.WINDOW_WIDTH, GameSettings.WINDOW_HEIGHT);
                return;
            }
            Console.SetWindowSize(GameSettings.MENU_WINDOW_WIDTH, GameSettings.MENU_WINDOW_HEIGHT);
            Console.SetBufferSize(GameSettings.MENU_WINDOW_WIDTH, GameSettings.MENU_WINDOW_HEIGHT);
        }
        /// <summary>
        /// Clear method for clearing the screen.
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }
        /// <summary>
        /// Method responsible for for drawing/displaying enemies from a list, based on the each enemy's type.
        /// The method also changes the color for hit enemies, and displays exploded enemies (although its a different method which handles the explode writing)
        /// </summary>
        /// <param name="enemies">the list of enemies to be displayed</param>
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
                if (enemies[i].IsHit)
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
        /// <summary>
        /// Method responsible for for drawing/displaying the player ship (pepper), also handles hit colors.
        /// </summary>
        /// <param name="myPlayer">The player which is to to be displayed</param>
        public static void DrawPlayer(PlayerShip myPlayer)
        {
            List<ConsoleColor> currentColors = new List<ConsoleColor> { };
            if (myPlayer.IsHit)
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

        /// <summary>
        /// Method responsible for drawing/displaying all projectiles (both player and enemy), based on projectile type and travel direction (for certain projectiles)
        /// </summary>
        /// <param name="projectiles"></param>
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
        /// <summary>
        /// Method responsible for drawing/displaying the explosion based on the entity's current explosion frame(level).
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="entity"></param>
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

                    Console.ResetColor();
                    break;
            }
        }
        /// <summary>
        /// Method responsible for drawing/displaying the the window frame for the game.
        /// </summary>
        /// <param name="width">The frame's width.</param>
        /// <param name="height">The frame's width.</param>
        /// <param name="color">The frame's color.</param>
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
        /// <summary>
        /// Method responsible for drawing/display game info during gameplay.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="score"></param>
        /// <param name="name"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="level"></param>
        public static void DrawGameInfo(List<string> text, int score, string name, int xpos, int ypos, int level)
        {
            string nameAndScore = "";
            string levelText = $"{text[0]} : {level}";
            string optionsText = $"{text[1]}(O)";

            Console.SetCursorPosition(2, ypos);

            Console.Write(levelText);
            Console.SetCursorPosition(2, ypos + 2);
            Console.Write(optionsText);

            if (name is null)
            {
                nameAndScore = $"{text[2]} : {score}";
            }
            else
            {
                nameAndScore = $"{name} : {score}";
            }
            Console.SetCursorPosition(xpos - nameAndScore.Length - 3, ypos);
            Console.Write(nameAndScore);
        }
        /// <summary>
        /// Method responsible for drawing/displaying the game title.
        /// </summary>
        /// <param name="xpos">x position where to start displaying the title</param>
        /// <param name="ypos">y position where to start displaying the title</param>
        public static void DrawGameTitle(int xpos, int ypos, ConsoleColor color, ILanguage language)
        {
            List<string> logo = language.Logo();
            Console.ForegroundColor = color;
            for (int i = 0; i < logo.Count; i++)
            {
                Console.SetCursorPosition(xpos, ypos + i);
                Console.Write(logo[i]);

            }
            Console.ResetColor();
        }

    }
}
