using Data;
using ConsoleMenu;
using Language;
using Entity;

namespace Spicy_Invaders
{
    public class Program
    {
        enum MenuList
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
            View.Init(false);
            while (!runGame)
            {
                Console.Clear();
                selectedOption = menuList[currentMenu].Run();
                MenuNav(ref runGame, ref currentMenu, ref language, ref changedSettings, ref weapon, ref color, ref controls, selectedOption);
                if (changedSettings) { menuList = CreateMenuList(language, color); }
                changedSettings = false;
            }
            View.Init(true);
            new Game(language, weapon, color, controls).Run();

        }
        static void MenuNav(ref bool runGame, ref int currentMenu, ref ILanguage language, ref bool changedSettings, ref WeaponType weapon, ref ConsoleColor color, ref List<ConsoleKey> controlKeys, int selectedOption)
        {

            switch (currentMenu)
            {
                case (int)MenuList.MainMenu:
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
                    }
                    break;
                case (int)MenuList.OptionsMenu:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = (int)MenuList.MainMenu;
                            break;
                        case 1:
                            currentMenu = (int)MenuList.LanguageMenu;
                            break;
                        case 2:
                            currentMenu = (int)MenuList.ControlsMenu;
                            break;
                        case 3:
                            currentMenu = (int)MenuList.WeaponsMenu;
                            break;
                        case 4:
                            currentMenu = (int)MenuList.ColorsMenu;
                            break;
                    }
                    break;
                case (int)MenuList.LanguageMenu:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = (int)MenuList.OptionsMenu;
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
                    currentMenu = (int)MenuList.OptionsMenu;
                    break;
                case (int)MenuList.ControlsMenu:
                    switch (selectedOption)
                    {
                        case 1:
                            controlKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.RightArrow };
                            break;
                        case 2:
                            controlKeys = new List<ConsoleKey> { ConsoleKey.A, ConsoleKey.D };
                            break;
                    }
                    currentMenu = (int)MenuList.OptionsMenu;
                    break;
                case (int)MenuList.WeaponsMenu:
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
                    currentMenu = (int)MenuList.OptionsMenu;
                    break;
                case (int)MenuList.ColorsMenu:
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
                    currentMenu = (int)MenuList.OptionsMenu;
                    break;

            }
        }

        static List<Menu> CreateMenuList(ILanguage language, ConsoleColor color)
        {
            MenuCreator creator = new MenuCreator();
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