using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;
using Language;


namespace Spicy_Invaders
{
    /// <summary>
    /// Class for creating all the different menus used throught the game
    /// </summary>
    public class MenuCreator
    {
        private MenuItem _prompt;
        public MenuItem Prompt { get { return _prompt; } set { _prompt = value; } }
        public MenuCreator()
        {
            Language = new English();
            Color = ConsoleColor.White;
            _prompt = new MenuItem(Language.Logo(), ConsoleColor.White, ConsoleColor.Black, GameSettings.MENU_PROMPT_VERTICAL_PADDING, 0);
        }
        public ILanguage Language { get; set; }
        public ConsoleColor Color { get; set; }

        public Menu MainMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();
            for (int i = 0; i < 5; i++)
            {
                myMenuItems.Add(new MenuItem(Language.MainMenuText(i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }

            return new Menu(_prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
        public Menu OpitionsMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();

            for (int i = 0; i < 5; i++)
            {
                myMenuItems.Add(new MenuItem(Language.OpitionsMenuText(i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }
            return new Menu(_prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }

        public Menu LanguageMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();

            for (int i = 0; i < 4; i++)
            {
                myMenuItems.Add(new MenuItem(Language.ChooseLanguageMenuText(i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }
            return new Menu(_prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }

        public Menu WeaponMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();
            for (int i = 0; i < 4; i++)
            {
                myMenuItems.Add(new MenuItem(Language.WeaponMenuText(i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }

            return new Menu(_prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
        public Menu ColorMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();

            for (int i = 0; i < 6; i++)
            {
                myMenuItems.Add(new MenuItem(Language.ColorMenuText(i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }
            return new Menu(_prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
        public Menu ControlsMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();

            for (int i = 0; i < 3; i++)
            {
                myMenuItems.Add(new MenuItem(Language.ControlsMenuText(0), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }
            return new Menu(_prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
        public Menu GameplayOpitionsMenu(int whichMenu)
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();

            if (whichMenu == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    myMenuItems.Add(new MenuItem(Language.GameplayMenuOption(0, i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
                }
                return new Menu(myMenuItems, 2, 4);
            }
            else if (whichMenu == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    myMenuItems.Add(new MenuItem(Language.GameplayMenuOption(1, i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
                }
                return new Menu(myMenuItems, 2, 4);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    myMenuItems.Add(new MenuItem(Language.GameplayMenuOption(2, i), Color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
                }
                return new Menu(myMenuItems, 2, 4);
            }

        }
    }
}
