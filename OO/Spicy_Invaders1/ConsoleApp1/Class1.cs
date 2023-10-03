using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class GameText
    {
        private Language _language;
        public GameText(Language language)
        {
            _language = language;
        }
        public string[] MainMenuText()
        {
            string[] text = new string[0];

            switch (_language)
            {
                case Language.English:
                    text = new string[] { "Start", "Options", "Scores", "Quit"};
                    break;
                case Language.French:
                    text = new string[] { "Start", "Options", "Scores", "Quit" };
                    break;
            }
            return text;
        }
        public string[] OptionsText()
        {
            string[] text = new string[0];

            switch (_language)
            {
                case Language.English:
                    text = new string[] { "Back", "Language", "Controls" };
                    break;
                case Language.French:
                    text = new string[] { "Back", "Language", "Controls" };
                    break;
            }
            return text;
        }
        public string[] LanguageText()
        {
            string[] text = new string[0];

            switch (_language)
            {
                case Language.English:
                    text = new string[] { "Back", "English", "French" };
                    break;
                case Language.French:
                    text = new string[] { "Back", "English", "French" };
                    break;
            }
            return text;
        }
        public string[] ScoresText()
        {
            string[] text = new string[0];

            switch (_language)
            {
                case Language.English:
                    text = new string[] { "Back", "Username", "Score" };
                    break;
                case Language.French:
                    text = new string[] { "Back", "Username", "Score" };
                    break;
            }
            return text;
        }

    }
}
