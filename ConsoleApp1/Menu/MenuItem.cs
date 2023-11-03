using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    /// <summary>
    /// Menu item for menu options needed to create a menu.
    /// </summary>
    public class MenuItem
    {
        private List<string> _text;
        public List<string> Text { get { return _text; } set { _text = value; } }

        private int _verticalPadding = 0;
        public int VerticalPadding { get { return _verticalPadding; } set { _verticalPadding = value; } }

        private int _horizontalPadding;
        public int HorizontalPadding { get { return _horizontalPadding; } set { _horizontalPadding = value; } }

        private ConsoleColor _selectedfore;

        private ConsoleColor _selectedback;
        public ConsoleColor SelectedFore
        {
            get { return _selectedfore; }
            set { _selectedfore = value; }
        }
        public ConsoleColor SelectedBack
        {
            get { return _selectedback; }
            set { _selectedback = value; }
        }
        public MenuItem(List<string> text)
        {
            _text = text;
            _selectedback = ConsoleColor.White;
            _selectedfore = ConsoleColor.Black;
        }
        public MenuItem(List<string> text, ConsoleColor defFore, ConsoleColor defBack, ConsoleColor selFore, ConsoleColor selBack)
        {
            _text = text;
            _selectedback = selBack;
            _selectedfore = selFore;
        }
        public MenuItem(List<string> text, ConsoleColor selFore, ConsoleColor selBack, int verPadding, int horiPadding)
        {
            _text = text;
            _selectedback = selBack;
            _selectedfore = selFore;
            _verticalPadding = verPadding;
            _horizontalPadding = horiPadding;
        }
        public MenuItem(List<string> text, ConsoleColor selFore, ConsoleColor selBack)
        {
            _text = text;
            _selectedback = selBack;
            _selectedfore = selFore;
        }
        public MenuItem() { }
    }
}
