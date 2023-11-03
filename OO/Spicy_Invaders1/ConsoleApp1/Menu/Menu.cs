namespace ConsoleMenu
{
    public class Menu
    {
        private MenuItem _menuPrompt;
        public MenuItem MenuPrompt
        {
            get { return _menuPrompt; }
            set { _menuPrompt = value; }
        }

        private List<MenuItem> _menuItems;
        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        private int _verticalpadding;
        public int VerticalPadding
        {
            get { return _verticalpadding; }
            set { _verticalpadding = value; }
        }

        private int _horizontalpadding;
        public int HorizontalPadding
        {
            get { return _horizontalpadding; }
            set { _horizontalpadding = value; }
        }

        private int _xPos;
        public int XPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }

        private int _yPos;
        public int YPos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }

        private int _promptSpacer;
        public int PromptSpacer
        {
            get { return _promptSpacer; }
            set { _promptSpacer = value; }
        }

        private bool _clearAll;
        public bool ClearAll
        {
            get { return _clearAll; }
            set { _clearAll = value; }
        }

        private ConsoleColor _defaultForegroundColor;
        public ConsoleColor DefaultForegroundColor
        {
            get { return _defaultForegroundColor; }
            set { _defaultForegroundColor = value; }
        }

        private ConsoleColor _defaultBackgroundColor;
        public ConsoleColor DefaultBackgroundColor
        {
            get { return _defaultForegroundColor; }
            set { _defaultForegroundColor = value; }
        }
        public Menu(MenuItem prompt, List<MenuItem> items, int x, int y)
        {
            _xPos = x;
            _yPos = y;
            _menuPrompt = prompt;
            _menuItems = items;
            _promptSpacer = 1;
            _verticalpadding = 1;
            _horizontalpadding = 0;
            _clearAll = true;
            _defaultForegroundColor = ConsoleColor.White;
            _defaultBackgroundColor = ConsoleColor.Black;
        }
        public Menu(List<MenuItem> items, int x, int y)
        {
            _xPos = x;
            _yPos = y;
            _menuItems = items;
            _promptSpacer = 1;
            _verticalpadding = 1;
            _horizontalpadding = 0;
            _clearAll = true;
            _defaultForegroundColor = ConsoleColor.White;
            _defaultBackgroundColor = ConsoleColor.Black;
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                MenuWriter.Write(_menuPrompt, _menuItems, _defaultForegroundColor, _defaultBackgroundColor, _selectedIndex, _xPos, _yPos);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;


                int indexChange = GetIndexChange(keyPressed);
                _selectedIndex += indexChange;

                // Ensure selected index is within bounds of menu options
                if (_selectedIndex < 0)
                {
                    _selectedIndex = _menuItems.Count - 1;
                }
                else if (_selectedIndex >= _menuItems.Count)
                {
                    _selectedIndex = 0;
                }

            } while (!(keyPressed == ConsoleKey.Spacebar || keyPressed == ConsoleKey.Enter));
            if (_clearAll)
            {
                Console.Clear();
            }
            else
            {
                MenuWriter.Clear(_menuPrompt, _menuItems, _selectedIndex, _xPos, _yPos, _verticalpadding, _horizontalpadding, _promptSpacer);
            }
            return _selectedIndex;
        }
        private int GetIndexChange(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return -1;
                case ConsoleKey.DownArrow:
                    return 1;
            }
            return 0;
        }
    }
}