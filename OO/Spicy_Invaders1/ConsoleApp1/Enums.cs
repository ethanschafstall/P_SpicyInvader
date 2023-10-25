using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public enum EnemyType
    {
        Strawberry = 1,
        Banana = 2,
        Grape = 3,
        Melon = 4
    }
    public enum WeaponType
    {
        Gun,
        LaserGun,
        MissileLauncher
    }
    public enum DropType
    {
        weaponUpgrade,
    }
    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }
    public enum Language
    {
        English,
        French
    }
}
