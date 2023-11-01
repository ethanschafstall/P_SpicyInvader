using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;

namespace Spicy_Invaders
{
    public class MenuCreator
    {
        private MenuItem prompt;
        public MenuCreator() 
        {
            Language = new English();
            prompt = new MenuItem(Language.Logo(), ConsoleColor.Red, ConsoleColor.Black, GameSettings.MENU_PROMPT_VERTICAL_PADDING, 0) ;
            color = ConsoleColor.Red;
        }
        public ILanguage Language { get; set; }
        public ConsoleColor color { get; set; } 
        public Menu MainMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();
            for (int i = 0; i < 5; i++)
            {
                myMenuItems.Add(new MenuItem(Language.MainMenuText(i), color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            } 

            return new Menu(prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
        public Menu OpitionsMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();

            for (int i = 0; i < 5; i++)
            {
                myMenuItems.Add(new MenuItem(Language.OpitionsMenuText(i), color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }
            return new Menu(prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }

        public Menu LanguageMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();

            for (int i = 0; i < 5; i++)
            {
                myMenuItems.Add(new MenuItem(Language.ChooseLanguageMenuText(i), color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }
            return new Menu(prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
        public Menu GameplayMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();
            for (int i = 0; i < 2; i++)
            {
                myMenuItems.Add(new MenuItem(Language.GameplayMenuText(i), color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }

            return new Menu(prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
        public Menu WeaponMenu()
        {
            List<MenuItem> myMenuItems = new List<MenuItem>();
            for (int i = 0; i < 4; i++)
            {
                myMenuItems.Add(new MenuItem(Language.WeaponMenuText(i), color, ConsoleColor.Black, GameSettings.MENU_OPTIONS_VERTICAL_PADDING, GameSettings.MENU_OPTIONS_HORIZONTAL_PADDING));
            }

            return new Menu(prompt, myMenuItems, GameSettings.MENU_X_POS, GameSettings.MENU_Y_POS);
        }
    }
}
