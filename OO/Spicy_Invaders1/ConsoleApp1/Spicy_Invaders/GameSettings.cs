using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Spicy_Invaders
{
    public class GameSettings
    {
        public const int MENU_OPTIONS_VERTICAL_PADDING = 1;

        public const int MENU_OPTIONS_HORIZONTAL_PADDING = 5;

        public const int MENU_PROMPT_VERTICAL_PADDING = 3;

        public const int MENU_X_POS = 15;

        public const int MENU_Y_POS = 1;

        public const int GAMEBOARD_X_START = 7;

        public const int GAMEBOARD_Y_START = 7;

        public const int GAMEBOARD_X_LIMIT = 115;

        public const int GAMEBOARD_Y_LIMIT = 40;

        public const int WINDOW_HEIGHT = 44;

        public const int WINDOW_WIDTH = 120;

        public const int MENU_WINDOW_HEIGHT = 50;

        public const int MENU_WINDOW_WIDTH = 96;

        public const int ENEMYVELOCITY = 1;

        public const int ENEMYMOVERATE = ENEMYVELOCITY * 2;

        public const int ENEMYSPAWNRATE = ENEMYMOVERATE * 7;

        public const int PROJECTILEMOVERATE = 3;

        public const int PROJECTILESPAWNRATE = PROJECTILEMOVERATE * 2;

        public static Vector ENEMY_START_POS = new Vector(7, 11);

        public static Vector PLAYER_START_POS = new Vector((GAMEBOARD_X_LIMIT - GAMEBOARD_X_START) / 2, GAMEBOARD_Y_LIMIT - 3);


    }
}
