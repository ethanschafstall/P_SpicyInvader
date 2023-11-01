using SQL_connection;
using ConsoleMenu;
namespace Spicy_Invaders
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILanguage language = new English();
            List<Menu> menuList = CreateMenuList(language);

            WeaponType weapon = WeaponType.Gun;
            bool runGame = false;
            int currentMenu = 0;
            int selectedOption;
            bool changeLanguage = false;
            View.Init(false);
            while (!runGame)
            {
                Console.Clear();
                selectedOption = menuList[currentMenu].Run();
                MenuNav(ref runGame, ref currentMenu, ref language, ref changeLanguage, ref weapon, selectedOption);
                if (changeLanguage) { menuList = CreateMenuList(language); }
            }
            View.Init(true);
            new Game(language, weapon).Run();

        }
        static void MenuNav(ref bool runGame, ref int currentMenu, ref ILanguage language, ref bool changeLanguage, ref WeaponType weapon,int selectedOption) 
        {
            switch (currentMenu)
            {
                case 0:
                    switch (selectedOption)
                    {
                        case 0:
                            runGame = true;
                            break;
                        case 1:
                            currentMenu = 1;
                            break;
                        case 2:
                            Data.Init();
                            while (!Console.KeyAvailable)
                            {
                                Data.GetPlayerScores(2, 30, 20, true);
                                ConsoleKeyInfo keyInfo = Console.ReadKey();
                                if (keyInfo.Key == ConsoleKey.D0)
                                {
                                }
                                else { break; }
                            }
                            break;
                    }
                    break;
                case 1:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = 0;
                            break;
                        case 1:
                            currentMenu = 2;
                            break;
                        case 3:
                            currentMenu = 3;
                            break;
                    }
                    break;
                case 2:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = 1;
                            break;
                        case 1:
                            language = new English();
                            changeLanguage = true;
                            break;
                        case 2:
                            language = new French();
                            changeLanguage = true;
                            break;
                        case 3:
                            language = new Spanish();
                            changeLanguage = true;
                            break;
                    }
                    break;
                case 3:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = 1;
                            break;
                        case 1:
                            currentMenu = 4;
                            break;

                    }
                    break;
                case 4:
                    switch (selectedOption)
                    {
                        case 0:
                            currentMenu = 3;
                            break;
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
                    break;
            }
        }

        static List<Menu> CreateMenuList(ILanguage newLanguage) 
        {
            MenuCreator creator = new MenuCreator();
            List<Menu> menuList = new List<Menu>();
            creator.Language = newLanguage;
            menuList.Add(creator.MainMenu());
            menuList.Add(creator.OpitionsMenu());
            menuList.Add(creator.LanguageMenu());
            menuList.Add(creator.GameplayMenu());
            menuList.Add(creator.WeaponMenu());
            return menuList;
        }
    }
}