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

        public const EnemySpeed ENEMYSPEED = EnemySpeed.fast;

        public static Vector ENEMY_START_POS = new Vector(1,1);

        public static Vector PLAYER_START_POS = new Vector((GAMEBOARD_X_LIMIT- GAMEBOARD_X_START)/2, GAMEBOARD_Y_LIMIT+1);

    }
}
