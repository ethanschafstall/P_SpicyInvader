using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spicy_Invaders.Projectiles;

namespace Spicy_Invaders
{
    public class Sprite
    {
        public char MoveDirection { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int HorizontalMoveSpeed { get; set; } = 1;
        public int VerticalMoveSpeed { get; set; } = 1;
        protected Sprite() { }
        public void Move(char moveDirection = 'n')
        {
            // if parameter == 'n' for null then default to global MoveDirection variable
            if (moveDirection == 'n')
            {
                moveDirection = MoveDirection;
            }
                switch (moveDirection)
                {
                    case 'u':
                        YPos -= VerticalMoveSpeed;
                        break;
                    case 'd':
                        YPos += VerticalMoveSpeed;
                        break;
                    case 'l':
                        XPos -= HorizontalMoveSpeed;
                        break;
                    case 'r':
                        XPos += HorizontalMoveSpeed;
                        break;
                }
        }
    }
}
