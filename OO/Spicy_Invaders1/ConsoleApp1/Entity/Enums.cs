using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// enum for the different enemy types
    /// </summary>
    public enum EnemyType
    {
        Strawberry = 1,
        Banana = 2,
        Grape = 3,
        Melon = 4
    }
    /// <summary>
    /// enum for the different weapon types
    /// </summary>
    public enum WeaponType
    {
        Gun,
        LaserGun,
        MissileLauncher
    }
    /// <summary>
    /// enum for the different drop types
    /// </summary>
    public enum DropType
    {
        weaponUpgrade,
    }
    /// <summary>
    /// enum for the different facing/moving directions
    /// </summary>
    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }
}
