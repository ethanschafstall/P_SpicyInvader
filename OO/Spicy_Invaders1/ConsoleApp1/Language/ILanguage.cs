using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public interface ILanguage

    {
        public List<string> Logo();
        public List<string> MainMenuText(int optionNumber);

        public List<string> OpitionsMenuText(int optionNumber);

        public List<string> ChooseLanguageMenuText(int optionNumber);

        public List<string> GameplayText();

        public List<string> GameplayMenuText(int optionNumber);

        public List<string> WeaponMenuText(int optionNumber);


    }
}
