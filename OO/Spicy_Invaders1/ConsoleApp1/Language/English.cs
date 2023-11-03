using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
    /// <summary>
    /// English Language class for menu and gameplay text.
    /// </summary>
    public class English : ILanguage
    {
        public English() { }

        /// <summary>
        /// Language Menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the Language options</returns>
        public List<string> ChooseLanguageMenuText(int optionNumber)
        {
            switch (optionNumber)
            {
                case 0:
                    return new List<string>{"   ___            _    ",
                                            "  / __\\ __ _  ___| | __",
                                            " /__\\/// _` |/ __| |/ /",
                                            "/ \\/  \\ (_| | (__|   < ",
                                            "\\_____/\\__,_|\\___|_|\\_\\"};
                case 1:
                    return new List<string>{"   __            _ _     _     ",
                                            "  /__\\ __   __ _| (_)___| |__  ",
                                            " /_\\| '_ \\ / _` | | / __| '_ \\ ",
                                            "//__| | | | (_| | | \\__ \\ | | |",
                                            "\\__/|_| |_|\\__, |_|_|___/_| |_|",
                                            "           |___/               "};
                case 2:
                    return new List<string> {"   ___                          _     ",
                                            "  / __\\ __ __ _ _ __   ___ __ _(_)___ ",
                                            " / _\\| '__/ _` | '_ \\ / __/ _` | / __|",
                                            "/ /  | | | (_| | | | | (_| (_| | \\__ \\",
                                            "\\/   |_|  \\__,_|_| |_|\\___\\__,_|_|___/",
                                            "                                      "};
                case 3:
                    return new List<string>{"   __                                  _ ",
                                            "  /__\\__ _ __   __ _  __ _ _ __   ___ | |",
                                            " /_\\/ __| '_ \\ / _` |/ _` | '_ \\ / _ \\| |",
                                            "//__\\__ \\ |_) | (_| | (_| | | | | (_) | |",
                                            "\\__/|___/ .__/ \\__,_|\\__, |_| |_|\\___/|_|",
                                            "        |_|          |___/               "};
                default:
                    return new List<string> { };
            }
        }
        /// <summary>
        /// Color menu text options based on the option number
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the color menu options</returns>
        public List<string> ColorMenuText(int optionNumber)
        {
            switch (optionNumber)
            {
                case 0:
                    return new List<string>{"   __      _                   ",
                                            "  /__\\ ___| |_ ___  _   _ _ __ ",
                                            " / \\/// _ \\ __/ _ \\| | | | '__|",
                                            "/ _  \\  __/ || (_) | |_| | |   ",
                                            "\\/ \\_/\\___|\\__\\___/ \\__,_|_|   "};
                case 1:
                    return new List<string> {"   __          _  ",
                                            "  /__\\ ___  __| | ",
                                            " / \\/// _ \\/ _` | ",
                                            "/ _  \\  __/ (_| | ",
                                            "\\/ \\_/\\___|\\__,_| "};
                case 2:
                    return new List<string>{"   ___ _             ",
                                            "  / __\\ |_   _  ___  ",
                                            " /__\\// | | | |/ _ \\ ",
                                            "/ \\/  \\ | |_| |  __/ ",
                                            "\\_____/_|\\__,_|\\___| "};
                case 3:
                    return new List<string>{"   ___                      ",
                                            "  / _ \\_ __ ___  ___ _ __   ",
                                            " / /_\\/ '__/ _ \\/ _ \\ '_ \\  ",
                                            "/ /_\\\\| | |  __/  __/ | | | ",
                                            "\\____/|_|  \\___|\\___|_| |_| "};
                case 4:
                    return new List<string>{"   ___                    ",
                                            "  / __\\   _  __ _ _ __    ",
                                            " / / | | | |/ _` | '_ \\   ",
                                            "/ /__| |_| | (_| | | | |  ",
                                            "\\____/\\__, |\\__,_|_| |_|  ",
                                            "      |___/                "};
                case 5:
                    return new List<string>{"                               _         ",
                                            "  /\\/\\   __ _  __ _  ___ _ __ | |_ __ _  ",
                                            " /    \\ / _` |/ _` |/ _ \\ '_ \\| __/ _` | ",
                                            "/ /\\/\\ \\ (_| | (_| |  __/ | | | || (_| | ",
                                            "\\/    \\/\\__,_|\\__, |\\___|_| |_|\\__\\__,_| ",
                                            "              |___/                       "};
                default:
                    return new List<string> { };
            }
        }

        /// <summary>
        /// Controls Menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the Controls menu options</returns>
        public List<string> ControlsMenuText(int optionNumber)
        {
            switch (optionNumber)
            {
                case 0:
                    return new List<string>{"   ___            _    ",
                                            "  / __\\ __ _  ___| | __",
                                            " /__\\/// _` |/ __| |/ /",
                                            "/ \\/  \\ (_| | (__|   < ",
                                            "\\_____/\\__,_|\\___|_|\\_\\"};
                case 1:
                    return new List<string>{"  __          __      __  ",
                                            " / /         / /      \\ \\ ",
                                            "/ /_____    / /   _____\\ \\",
                                            "\\ \\_____|  / /   |_____/ /",
                                            " \\_\\      /_/         /_/ "};
                case 2:
                    return new List<string> {"   _        __     ___    ",
                                            "  /_\\      / /    /   \\   ",
                                            " //_\\\\    / /    / /\\ /   ",
                                            "/  _  \\  / /    / /_//    ",
                                            "\\_/ \\_/ /_/    /___,'     "};
                default:
                    return new List<string> { };
            }
        }
        /// <summary>
        /// DB text for scoreboard screen
        /// </summary>
        /// <returns>Returns list of strings containing the text</returns>
        public List<string> DBText()
        {
            return new List<string> { "Alias", "Points"};
        }
        /// <summary>
        /// Text which is displayed during active gameplay.
        /// </summary>
        /// <returns>Returns text which is displayed during active gameplay</returns>
        public List<string> GameplayText()
        {
            return new List<string> { "Wave", "Options", "Player 1" };
        }

        /// <summary>
        /// Game Logo Method, needed for the menu prompts. 
        /// </summary>
        /// <returns>Returns ascii art for the game logo</returns>
        public List<string> Logo()
        {
            return new List<string> {  "   _____       _            _____                     _               ",
                                                    "  / ____|     (_)          |_   _|                   | |              " ,
                                                    " | (___  _ __  _  ___ _   _  | |  _ ____   ____ _  __| | ___ _ __ ___ " ,
                                                    "  \\___ \\| '_ \\| |/ __| | | | | | | '_ \\ \\ / / _` |/ _` |/ _ \\ '__/ __|" ,
                                                    "  ____) | |_) | | (__| |_| |_| |_| | | \\ V / (_| | (_| |  __/ |  \\__ \\",
                                                    " |_____/| .__/|_|\\___|\\__, |_____|_| |_|\\_/ \\__,_|\\__,_|\\___|_|  |___/",
                                                    "        | |            __/ |                                          ",
                                                    "        |_|           |___/                                           " };
        }
        /// <summary>
        /// Main Menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the main menu options</returns>
        public List<string> MainMenuText(int optionNumber)
        {
            switch (optionNumber)
            {
                case 0:
                    return new List<string>{" __ _             _   ",
                                            "/ _\\ |_ __ _ _ __| |_ ",
                                            "\\ \\| __/ _` | '__| __|",
                                            "_\\ \\ || (_| | |  | |_ ",
                                            "\\__/\\__\\__,_|_|   \\__|"};
                case 1:
                    return new List<string>{ "   ___       _   _                 ",
                                            "  /___\\_ __ | |_(_) ___  _ __  ___ ",
                                            " //  // '_ \\| __| |/ _ \\| '_ \\/ __|",
                                            "/ \\_//| |_) | |_| | (_) | | | \\__ \\",
                                            "\\___/ | .__/ \\__|_|\\___/|_| |_|___/",
                                            "      |_|                          "};
                case 2:
                    return new List<string>{" __                         ",
                                            "/ _\\ ___ ___  _ __ ___  ___ ",
                                            "\\ \\ / __/ _ \\| '__/ _ \\/ __|",
                                            "_\\ \\ (_| (_) | | |  __/\\__ \\",
                                            "\\__/\\___\\___/|_|  \\___||___/" };
                case 3:
                    return new List<string> {"   ___             _ _ _       ",
                                            "  / __\\ __ ___  __| (_) |_ ___ ",
                                            " / / | '__/ _ \\/ _` | | __/ __|",
                                            "/ /__| | |  __/ (_| | | |_\\__ \\",
                                            "\\____/_|  \\___|\\__,_|_|\\__|___/"};
                case 4:
                    return new List<string>{"   __      _ _   ",
                                            "  /__\\_  _(_) |_ ",
                                            " /_\\ \\ \\/ / | __|",
                                            "//__  >  <| | |_ ",
                                            "\\__/ /_/\\_\\_|\\__|"};
                default:
                    return new List<string> { };
            }
        }
        /// <summary>
        /// Options menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the options menu options</returns>
        public List<string> OpitionsMenuText(int optionNumber)
        {
            switch (optionNumber)
            {
                case 0:
                    return new List<string>{"   ___            _    ",
                                            "  / __\\ __ _  ___| | __",
                                            " /__\\/// _` |/ __| |/ /",
                                            "/ \\/  \\ (_| | (__|   < ",
                                            "\\_____/\\__,_|\\___|_|\\_\\"};
                case 1:
                    return new List<string>{"   __                                          ",
                                            "  / /  __ _ _ __   __ _ _   _  __ _  __ _  ___ ",
                                            " / /  / _` | '_ \\ / _` | | | |/ _` |/ _` |/ _ \\",
                                            "/ /__| (_| | | | | (_| | |_| | (_| | (_| |  __/",
                                            "\\____/\\__,_|_| |_|\\__, |\\__,_|\\__,_|\\__, |\\___|",
                                            "                  |___/             |___/      "};
                case 2:
                    return new List<string>{"   ___            _             _     ",
                                            "  / __\\___  _ __ | |_ _ __ ___ | |___ ",
                                            " / /  / _ \\| '_ \\| __| '__/ _ \\| / __|",
                                            "/ /__| (_) | | | | |_| | | (_) | \\__ \\",
                                            "\\____/\\___/|_| |_|\\__|_|  \\___/|_|___/"};
                case 3:
                    return new List<string> {" __    __                             ",
                                            "/ / /\\ \\ \\___  __ _ _ __   ___  _ __  ",
                                            "\\ \\/  \\/ / _ \\/ _` | '_ \\ / _ \\| '_ \\ ",
                                            " \\  /\\  /  __/ (_| | |_) | (_) | | | |",
                                            "  \\/  \\/ \\___|\\__,_| .__/ \\___/|_| |_|",
                                            "                   |_|                "};
                case 4:
                    return new List<string>{"   ___      _           _____ _                         ",
                                            "  / __\\___ | | ___  _ _/__   \\ |__   ___ _ __ ___   ___ ",
                                            " / /  / _ \\| |/ _ \\| '__|/ /\\/ '_ \\ / _ \\ '_ ` _ \\ / _ \\",
                                            "/ /__| (_) | | (_) | |  / /  | | | |  __/ | | | | |  __/",
                                            "\\____/\\___/|_|\\___/|_|  \\/   |_| |_|\\___|_| |_| |_|\\___|"};
                case 5:
                    return new List<string>{"    ___ _  __  __ _            _ _         ",
                                            "   /   (_)/ _|/ _(_) ___ _   _| | |_ _   _ ",
                                            "  / /\\ / | |_| |_| |/ __| | | | | __| | | |",
                                            " / /_//| |  _|  _| | (__| |_| | | |_| |_| |",
                                            "/___,' |_|_| |_| |_|\\___|\\__,_|_|\\__|\\__, |",
                                            "                                     |___/ "};
                default:
                    return new List<string> { };
            }
        }
        /// <summary>
        /// Weapon menu text options based on the option number
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the weapon menu options</returns>
        public List<string> WeaponMenuText(int optionNumber)
        {
            switch (optionNumber)
            {
                case 0:
                    return new List<string>{"   ___            _    ",
                                            "  / __\\ __ _  ___| | __",
                                            " /__\\/// _` |/ __| |/ /",
                                            "/ \\/  \\ (_| | (__|   < ",
                                            "\\_____/\\__,_|\\___|_|\\_\\"};
                case 1:
                    return new List<string>{"   ___             ",
                                            "  / _ \\_   _ _ __  ",
                                            " / /_\\/ | | | '_ \\ ",
                                            "/ /_\\\\| |_| | | | |",
                                            "\\____/ \\__,_|_| |_|"};
                case 2:
                    return new List<string> {"   __                                      ",
                                            "  / /  __ _ ___  ___ _ __ __ _ _   _ _ __  ",
                                            " / /  / _` / __|/ _ \\ '__/ _` | | | | '_ \\ ",
                                            "/ /__| (_| \\__ \\  __/ | | (_| | |_| | | | |",
                                            "\\____/\\__,_|___/\\___|_|  \\__, |\\__,_|_| |_|",
                                            "                         |___/             "};
                case 3:
                    return new List<string> {"        _         _ _          __                        _               ",
                                            "  /\\/\\ (_)___ ___(_) | ___    / /  __ _ _   _ _ __   ___| |__   ___ _ __ ",
                                            " /    \\| / __/ __| | |/ _ \\  / /  / _` | | | | '_ \\ / __| '_ \\ / _ \\ '__|",
                                            "/ /\\/\\ \\ \\__ \\__ \\ | |  __/ / /__| (_| | |_| | | | | (__| | | |  __/ |   ",
                                            "\\/    \\/_|___/___/_|_|\\___| \\____/\\__,_|\\__,_|_| |_|\\___|_| |_|\\___|_|   "};
                default:
                    return new List<string> { };
            }
        }


        /// <summary>
        /// text for small menu that user can open during gameplay
        /// </summary>
        /// /// <param name="menuNumber">which menu is needed</param>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns text</returns>
        public List<string> GameplayMenuOption(int optionNumber, int menuNumber)
        {
            if (menuNumber == 0)
            {

                switch (optionNumber)
                {
                    case 0:
                        return new List<string> { "Close Menu (O)" };
                    case 1:
                        return new List<string> { "Color Theme" };
                    case 2:
                        return new List<string> { "Weapon" };
                    case 3:
                        return new List<string> { "Quit Game" };
                }
            }
            if (menuNumber == 1)
            {
                switch (optionNumber)
                {
                    case 0:
                        return new List<string> { "Red" };
                    case 1:
                        return new List<string> { "Blue" };
                    case 2:
                        return new List<string> { "Green" };
                    case 3:
                        return new List<string> { "Cyan" };
                    case 4:
                        return new List<string> { "Magenta" };
                }
            }
            else
            {
                switch (optionNumber)
                {
                    case 0:
                        return new List<string> { "Gun" };
                    case 1:
                        return new List<string> { "Laser Gun" };
                    case 2:
                        return new List<string> { "Missile Launcher" };

                }
            }
            return new List<string> { };

        }
    }
}
