using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    /// <summary>
    /// menu writer class which handles the displaying of menus.
    /// </summary>
    public class MenuWriter
    {
        /// <summary>
        /// write method used for displaying menus.
        /// </summary>
        /// <param name="prompt">The prompt to be shown above menu</param>
        /// <param name="options">The list of menu options</param>
        /// <param name="defaultFore">default text color</param>
        /// <param name="defaultBack">default background color</param>
        /// <param name="index">index for which menu option is selected</param>
        /// <param name="xPos">x position to display</param>
        /// <param name="yPos">y position to display</param>
        public static void Write(MenuItem prompt, List<MenuItem> options, ConsoleColor defaultFore, ConsoleColor defaultBack, int index, int xPos, int yPos)
        {
            if (!(prompt is null))
            {
                Console.BackgroundColor = prompt.SelectedBack;
                Console.ForegroundColor = prompt.SelectedFore;
                for (int i = 0; i < prompt.Text.Count; i++)
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(prompt.Text[i]);
                    yPos++;
                }
                yPos += prompt.VerticalPadding;
                Console.ResetColor();

            }
            for (int i = 0; i < options.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = options[i].SelectedBack;
                    Console.ForegroundColor = options[i].SelectedFore;
                }
                else
                {
                    Console.BackgroundColor = defaultBack;
                    Console.ForegroundColor = defaultFore;
                }
                for (int j = 0; j < options[i].Text.Count; j++)
                {
                    if (!(options[i].Text[j] is null))
                    {
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write(new String(' ', options[i].HorizontalPadding) + options[i].Text[j]);
                        yPos++;
                    }
                }
                yPos += options[i].VerticalPadding;
            }
            Console.ResetColor();
        }
        /// <summary>
        /// Clear method menu is to be cleared without doing a clear screen
        /// </summary>
        /// <param name="prompt">The prompt to be shown above menu</param>
        /// <param name="options">The list of menu options</param>
        /// <param name="index">index for which menu option is selected</param>
        /// <param name="xPos">x position</param>
        /// <param name="yPos">y position to</param>
        /// <param name="verticalpadding">menu options vertical padding</param>
        /// <param name="horizontalpadding">menu options horizontal padding</param>
        /// <param name="promptSpacer">space between prompts</param>
        public static void Clear(MenuItem prompt, List<MenuItem> options, int index, int xPos, int yPos, int verticalpadding, int horizontalpadding, int promptSpacer)
        {
            if (!(prompt is null))
            {
                for (int i = 0; i < prompt.Text.Count; i++)
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(new String(' ', prompt.Text[i].Length));
                    xPos++;
                }

            }
            for (int i = 0; i < options.Count; i++)
            {
                for (int j = 0; j < options[i].Text.Count; j++)
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(new String(' ', horizontalpadding * i + options[i].Text[j].Length));
                    yPos++;
                }
                yPos += verticalpadding;
            }
            Console.ResetColor();
        }
    }
}
