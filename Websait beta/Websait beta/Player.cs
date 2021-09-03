using System;
using System.Collections.Generic;
using System.Text;

namespace Websait_beta
{
    class Player
    {
        public Class GetClass(int unit, string Name)
        {
            switch (unit)
            {
                case 1:
                    return new Warrior(Name);
                case 2:
                    return new Paladin(Name);
                case 3:
                    return new Necromant(Name);
                case 4:
                    return new Druid(Name);
                default:
                    throw new Exception("Данного класса в игре несуществует");
            }
        }       
        public static void ColorPlayerName(string NamePlayer, int ClassPlayer)
        {
            if (ClassPlayer == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Warrior " + NamePlayer + " ");
                Console.ResetColor();
            }
            else if (ClassPlayer == 2)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Paladin " + NamePlayer + " ");
                Console.ResetColor();
            }
            else if (ClassPlayer == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" Necromant " + NamePlayer + " ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Druid " + NamePlayer + " ");
                Console.ResetColor();
            }
        }
    }
}
