using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    /// <summary>
    /// Language interface blueprint for different language classes needed for program text.
    /// </summary>
    public interface ILanguage

    {
        /// <summary>
        /// Game Logo Method, needed for the menu prompts. 
        /// </summary>
        /// <returns>Returns ascii art for the game logo</returns>
        public List<string> Logo();

        /// <summary>
        /// Main Menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the main menu options</returns>
        public List<string> MainMenuText(int optionNumber);

        /// <summary>
        /// Options menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the options menu options</returns>
        public List<string> OpitionsMenuText(int optionNumber);

        /// <summary>
        /// Language Menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the main menu options</returns>
        public List<string> ChooseLanguageMenuText(int optionNumber);

        /// <summary>
        /// Text which is displayed during active gameplay.
        /// </summary>
        /// <returns>Returns text which is displayed during active gameplay</returns>
        public List<string> GameplayText();

        /// <summary>
        /// Gameplay menu text options based on the option number.
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the gameplay menu options</returns>
        public List<string> GameplayMenuText(int optionNumber);

        /// <summary>
        /// Weapon menu text options based on the option number
        /// </summary>
        /// <param name="optionNumber">which option is needed</param>
        /// <returns>Returns ascii art for the weapon menu options</returns>
        public List<string> WeaponMenuText(int optionNumber);


    }
}
