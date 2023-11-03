using Data;
using ConsoleMenu;
using Language;
using Entity;

namespace Spicy_Invaders
{

    public class Program
    {
        /// <summary>
        /// enum for keeping track of menu navigation in MenuNav method.
        /// </summary>
        enum MenuName
        {
            MainMenu = 0,
            OptionsMenu = 1,
            LanguageMenu = 2,
            ControlsMenu = 3,
            WeaponsMenu = 4,
            ColorsMenu = 5
        }
        static void Main(string[] args)
        {
            // Default game/menu options
            ILanguage language = new English();
            ConsoleColor color = ConsoleColor.Red;
            List<ConsoleKey> controls = new List<ConsoleKey>() { ConsoleKey.LeftArrow, ConsoleKey.RightArrow };
            WeaponType weapon = WeaponType.Gun;
            List<Menu> menuList = CreateMenuList(language, color);

            bool runGame = false;
            int currentMenu = 0;
            int selectedOption;
            bool changedSettings = false;
            bool showCredits = false;
            View.Init(false);
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                View.DrawWindow(GameSettings.MENU_WINDOW_WIDTH - 2, GameSettings.MENU_WINDOW_HEIGHT - 2, color);
                
                if (showCredits) 
                { 
                    View.Credits(30,1,color);
                    Console.ReadKey();
                    showCredits = false;
                }
                
                selectedOption = menuList[currentMenu].Run();
                MenuNav(ref showCredits, ref runGame, ref currentMenu, ref language, ref changedSettings, ref weapon, ref color, ref controls, selectedOption);
                
                if (changedSettings) { menuList = CreateMenuList(language, color); }
                changedSettings = false;
                
                if (runGame)
                {
                    View.Init(true);
                    new Game(language, weapon, color, controls).Run();

                }
            }

        }

        /// <summary>
        /// menunav for navigating through the different menu screens
        /// </summary>
        /// <param name="showCredits">ref bool is credit screen should be displayed</param>
        /// <param name="runGame">ref bool if game is to be run</param>
        /// <param name="currentMenu">ref int which menu the user is on</param>
        /// <param name="language">ref Ilanguage which language the program is in</param>
        /// <param name="changedSettings">ref bool if game settings are to be changed</param>
        /// <param name="weapon">ref weapontype for changing the players weapon</param>
        /// <param name="color">ref consolecolor for changing the color theme</param>
        /// <param name="controlKeys">ref consolekey for changing the game controls</param>
        /// <param name="selectedOption">selected option which menu option the user choose</param>
        static void MenuNav(ref bool showCredits, ref bool runGame, ref int currentMenu, ref ILanguage language, ref bool changedSettings, ref WeaponType weapon, ref ConsoleColor color, ref List<ConsoleKey> controlKeys, int selectedOption)
        {

            switch (currentMenu)
            {
                case (int)MenuName.MainMenu:
                    switch (selectedOption)
                    {
                        case 0:
                            runGame = true;
                            break;
                        case 1:
                            currentMenu = 1;
                            break;
                        case 2:
                            if (Data.Data.Init())
                            {
                                while (!Console.KeyAvailable)
                                {
                                    List<string> dbText = language.DBText();
                                    Data.Data.GetPlayerScores(2, 30, 20, dbText[0], dbText[1], true);
                                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                                    if (keyInfo.Key == ConsoleKey.D0)
                                    {
                                    }
                                    else { break; }
                                }

                            }
                            break;
                        case 3:
                            showCredits = true;
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }
                    break;
                case (int)MenuName.OptionsMenu:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = (int)MenuName.MainMenu;
                            break;
                        case 1:
                            currentMenu = (int)MenuName.LanguageMenu;
                            break;
                        case 2:
                            currentMenu = (int)MenuName.ControlsMenu;
                            break;
                        case 3:
                            currentMenu = (int)MenuName.WeaponsMenu;
                            break;
                        case 4:
                            currentMenu = (int)MenuName.ColorsMenu;
                            break;
                    }
                    break;
                case (int)MenuName.LanguageMenu:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = (int)MenuName.OptionsMenu;
                            break;
                        case 1:
                            language = new English();
                            changedSettings = true;
                            break;
                        case 2:
                            language = new French();
                            changedSettings = true;
                            break;
                        case 3:
                            language = new Spanish();
                            changedSettings = true;
                            break;
                    }
                    currentMenu = (int)MenuName.OptionsMenu;
                    break;
                case (int)MenuName.ControlsMenu:
                    switch (selectedOption)
                    {
                        case 1:
                            controlKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.RightArrow };
                            break;
                        case 2:
                            controlKeys = new List<ConsoleKey> { ConsoleKey.A, ConsoleKey.D };
                            break;
                    }
                    currentMenu = (int)MenuName.OptionsMenu;
                    break;
                case (int)MenuName.WeaponsMenu:
                    switch (selectedOption)
                    {
                        case 1:
                            weapon = WeaponType.Gun;

                            break;
                        case 2:
                            weapon = WeaponType.LaserGun;
                            break;
                        case 3:
                            weapon = WeaponType.MissileLauncher;
                            break;
                    }
                    currentMenu = (int)MenuName.OptionsMenu;
                    break;
                case (int)MenuName.ColorsMenu:
                    switch (selectedOption)
                    {

                        case 1:
                            color = ConsoleColor.Red;
                            changedSettings = true;
                            break;
                        case 2:
                            color = ConsoleColor.Blue;
                            changedSettings = true;
                            break;
                        case 3:
                            color = ConsoleColor.Green;
                            changedSettings = true;
                            break;
                        case 4:
                            color = ConsoleColor.Cyan;
                            changedSettings = true;
                            break;
                        case 5:
                            color = ConsoleColor.Magenta;
                            changedSettings = true;
                            break;
                    }
                    currentMenu = (int)MenuName.OptionsMenu;
                    break;

            }
        }
        /// <summary>
        /// Method using to create the menu list for menu navigation
        /// </summary>
        /// <param name="language"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        static List<Menu> CreateMenuList(ILanguage language, ConsoleColor color)
        {
            MenuCreator creator = new MenuCreator();
            creator.Prompt.SelectedFore = color;
            List<Menu> menuList = new List<Menu>();
            creator.Language = language;
            creator.Color = color;
            menuList.Add(creator.MainMenu());
            menuList.Add(creator.OpitionsMenu());
            menuList.Add(creator.LanguageMenu());
            menuList.Add(creator.ControlsMenu());
            menuList.Add(creator.WeaponMenu());
            menuList.Add(creator.ColorMenu());
            return menuList;
        }
    }
}