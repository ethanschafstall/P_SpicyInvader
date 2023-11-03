using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public class MenuWriter
    {
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
