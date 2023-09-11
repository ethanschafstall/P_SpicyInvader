using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_Class
{
    public class Enemy
    {
        /// <summary>
        /// Int value for delimiting the enemy's top position.
        /// </summary>
        private int _topDelimitation;

        /// <summary>
        /// Int value for delimiting the enemy's bottom position.
        /// </summary>
        private int _bottomDelimitation;

        /// <summary>
        /// Int value for delimiting the enemy's left position.
        /// </summary>
        private int _leftDelimitation;

        /// <summary>
        /// Int value for delimiting the enemy's right position.
        /// </summary>
        private int _rightDelimitation;

        private string _enemy = "x";

        public int CurrentXPosition { get; set; }
        public int CurrentYPosition { get; set; }

        private char _moveDirection = 'r';
        //private bool _isAlive = true;

        //private int _health;
        public Enemy(int top, int bottom, int left, int right)
        {
            _bottomDelimitation = bottom;
            _leftDelimitation = left;
            _rightDelimitation = right;
            _topDelimitation = top;
            CurrentXPosition = top;
            CurrentYPosition = left;
        }
        public void MoveUp() 
        { 
        
        }
        public void MoveLeft() 
        { }
        public void MoveDown() 
        { }
        public void MoveRight() 
        { }

        public void Move() 
        {
            if (CurrentXPosition == _bottomDelimitation)
            {
                return;
            }
            switch (_moveDirection)
            {
                case 'l':
                    Console.SetCursorPosition(CurrentYPosition, CurrentXPosition);
                    Console.Write(_enemy);
                    CurrentYPosition -= 1;
                    if (CheckPosition(CurrentYPosition))
                    {
                        CurrentXPosition++;
                    }
                    Console.Write(new String(' ', _enemy.Length));
                    break;
                case 'r':
                    Console.SetCursorPosition(CurrentYPosition, CurrentXPosition);
                    Console.Write(new String(' ', _enemy.Length));
                    CurrentYPosition += 1;
                    if (CheckPosition(CurrentYPosition))
                    {
                        CurrentXPosition++;
                    }
                    Console.Write(_enemy);
                    break;
            }

        }
        private bool CheckPosition(int currentYPos) 
        {

            if (currentYPos == _rightDelimitation - 1)
            {
                _moveDirection = 'l';
                return true;
            }
            if (currentYPos == _leftDelimitation)
            {
                _moveDirection = 'r';
                return true;
            }
            return false;
        }
    }
    public class Enemy1
    {
        
        private int _nextYPosition;

        private int _nextXPosition;

        private int _limitXPosition;
        
        private int _limitYPosition;

        private int _currentXPosition;

        private int _currentYPosition;

        private int _initialXPosition;

        string _enemy = "{@@}\n/\"\"\\";

        public int _enemyHeight = 3;
        public int CurrentXPosition { get; set; }
        public int CurrentYPosition { get; set; }

        private char _moveDirection = 'r';

        private bool _firstPrint = false;

        private int counter = 0;
        //private bool _isAlive = true;

        //private int _health;
        public Enemy1(int XInitial, int YInitial, int xLimit, int yLimit)
        {
            _currentXPosition = XInitial;
            _currentYPosition = YInitial;

            _initialXPosition = XInitial;

            _limitXPosition = xLimit;
            _limitYPosition = yLimit;

            _nextXPosition = XInitial;
            _nextYPosition = YInitial;


        }
        public void Print()
        {
            if (_currentYPosition == _limitYPosition-1) return;
            if (!_firstPrint) { 
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.SetCursorPosition(_currentXPosition, _currentYPosition); 
                Console.Write(_enemy); _firstPrint = true; 
                Console.ResetColor();
            }

            Console.MoveBufferArea(_currentXPosition, _currentYPosition, _enemy.Length, _enemyHeight, _nextXPosition, _nextYPosition);

            ChangePosition();
        }
        public void ChangePosition()
        {
            _currentXPosition = _nextXPosition;
            _currentYPosition = _nextYPosition;

            switch (_moveDirection)
            {
                case 'l':
                    if (_currentXPosition + _enemy.Length >= _initialXPosition + _enemy.Length+1)
                    {
                        _nextXPosition--;
                        return;
                    }
                    if (_currentXPosition - _enemy.Length <= _initialXPosition)
                    {
                        _nextYPosition++;
                        _moveDirection = 'r';
                        return;
                    }
                    break;
                
                case 'r':
                    if (_currentXPosition + _enemy.Length >= _limitXPosition)
                    {
                        _nextYPosition++;
                        _moveDirection = 'l';
                        return;
                    }
                    if (_currentXPosition - _enemy.Length <= _limitXPosition)
                    {
                        _nextXPosition++;
                        return;
                    }
                    break;
            }
            
        }
        
    }
}
