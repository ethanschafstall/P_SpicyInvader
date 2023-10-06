using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class GameSettings
    {
        public enum EnemySpeed
        {
            normal = 1,
            fast = 2,
        }

        public const int GAMEBOARD_X_START = 0;

        public const int GAMEBOARD_Y_START = 0;

        public const int GAMEBOARD_X_LIMIT = 100;

        public const int GAMEBOARD_Y_LIMIT = 26;

        public const int WINDOW_HEIGHT = 50;

        public const int WINDOW_WIDTH = 170;

        public const int ENEMYVELOCITY = 1;

        public const int ENEMYMOVERATE = ENEMYVELOCITY*2;

        public const int ENEMYSPAWNRATE = ENEMYMOVERATE*5;

        public const int PROJECTILEMOVERATE = 3;

        public const int PROJECTILESPAWNRATE = PROJECTILEMOVERATE*2;

        public static Vector ENEMY_START_POS = new Vector(1, 1);

        public static Vector PLAYER_START_POS = new Vector((GAMEBOARD_X_LIMIT - GAMEBOARD_X_START) / 2, GAMEBOARD_Y_LIMIT - 3);

        public static Language Language { get; set; }


    }
}
