namespace Entity
{

    /// <summary>
    /// Drop Class which is an MoveableEntity which drops from certain enemies. Use for upgrading players weapon, firerate, etc.
    /// </summary>
    public class Drop : MovableEntity
    {
        /// <summary>
        /// The type of weapon drop
        /// </summary>
        public DropType Type { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">It's current x pos</param>
        /// <param name="y">It's current x pos</param>
        /// <param name="dropType">The type of drop it is.</param>
        public Drop(int x, int y, DropType dropType)
        {
            Position = new Vector(x, y);
            Velocity = new Vector(2, 2);
            TravelDirection = Direction.Down;
            Type = dropType;
        }
    }
}
