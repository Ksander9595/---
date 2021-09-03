using System;

namespace Websait_beta
{
    class Program
    {
        static void Main(string[] args)
        {            
            Player gamer1 = new Player();
            Player gamer2 = new Player();
            
            int FirstClassPlayer = 0;
            string FirstNamePlayer = null;
            int SecondClassPlayer = 0;
            string SecondNamePlayer = null;
            Console.WriteLine("Первый игрок выбирает класс: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Warrior");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("2. Paladin");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("3. Necromant");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4. Druid");
            Console.ResetColor();
            Class player1 = null;
            try
            {
                FirstClassPlayer = int.Parse(Console.ReadLine());
                Console.Write("Введите имя персонажа: ");
                FirstNamePlayer = Console.ReadLine();
                player1 = gamer1.GetClass(FirstClassPlayer, FirstNamePlayer);
                Console.WriteLine(player1.Name);
               
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при создании персонажа");
                Environment.Exit(0);
            }

            Console.Clear();

            Console.WriteLine("Второй игрок выбирает класс: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Warrior");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("2. Paladin");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("3. Necromant");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4. Druid");
            Console.ResetColor();
            Class player2 = null;
            try
            {
                SecondClassPlayer = int.Parse(Console.ReadLine());
                Console.Write("Введите имя персонажа: ");
                SecondNamePlayer = Console.ReadLine();
                player2 = gamer2.GetClass(SecondClassPlayer, SecondNamePlayer);
                Console.WriteLine(player2.Name);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при создании персонажа");
                Environment.Exit(0);
            }
            Console.Clear();

            Player.ColorPlayerName(FirstNamePlayer, FirstClassPlayer);
            Console.ResetColor();
            Console.Write(" VS ");
            Player.ColorPlayerName(SecondNamePlayer, SecondClassPlayer);
            Console.WriteLine("\n \n \n");
            Console.ResetColor();

            Random random = new Random();
            int FirstStep = random.Next(1, 3);
            if (FirstStep == 1)
            {              
                Console.Write($"Первый ход за ");
                Player.ColorPlayerName(FirstNamePlayer, FirstClassPlayer);
                Console.ResetColor();
                while (player1.HP > 0 && player2.HP > 0)
                {
                    if (FirstStep == 1)
                    {
                        try
                        {
                            player1.GetClassSkills();
                            Console.Write("Ходит ");
                            Player.ColorPlayerName(FirstNamePlayer, FirstClassPlayer);
                            int numberSkill = int.Parse(Console.ReadLine());
                        
                            switch (numberSkill)
                            {
                                case 1:
                                    player1.Skill1(player2);
                                    break;
                                case 2:
                                    player1.Skill2(player2);
                                    break;
                                case 3:
                                    player1.Skill3(player2);
                                    break;
                                default:
                                    player1.AvtoAttack(player2);
                                    break;
                            }                           
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Неверный ввод данных");
                        }
                        FirstStep = 2;
                        player1.Specifications(player2);
                        //player1.EndOfMove();
                    }
                    else
                    {
                        try 
                        { 
                            player2.GetClassSkills();
                            Console.Write($"Ходит ");
                            Player.ColorPlayerName(SecondNamePlayer, SecondClassPlayer);
                            int numberSkill = int.Parse(Console.ReadLine());
                            switch (numberSkill)
                            {
                                case 1:
                                    player2.Skill1(player1);
                                    break;
                                case 2:
                                    player2.Skill2(player1);
                                    break;
                                case 3:
                                    player2.Skill3(player1);
                                    break;
                                default:
                                    player2.AvtoAttack(player1);
                                    break;

                            }
                        }
                        catch (Exception)
                        {
                             Console.WriteLine("Неверный ввод данных");
                        }
                        FirstStep = 1;
                        player2.Specifications(player1);
                        player1.EndOfMove();
                        player2.EndOfMove();
                        player1.DeleteHealingAndDamage(player2);
                        player2.DeleteHealingAndDamage(player1);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Первый ход за ");
                Player.ColorPlayerName(SecondNamePlayer, SecondClassPlayer);
                Console.ResetColor();
                while (player1.HP > 0 && player2.HP > 0)
                {
                    if (FirstStep == 2)
                    {
                        try
                        {
                            player2.GetClassSkills();
                            int numberSkill = int.Parse(Console.ReadLine());
                            Console.Write($"Ходит ");
                            Player.ColorPlayerName(SecondNamePlayer, SecondClassPlayer);
                            switch (numberSkill)
                            {
                                case 1:
                                    player2.Skill1(player1);                                    
                                    break;
                                case 2:
                                    player2.Skill2(player1);
                                    break;
                                case 3:
                                    player2.Skill3(player1);
                                    break;
                                default:
                                    player2.AvtoAttack(player1);
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Неверный ввод данных");
                        }
                        FirstStep = 1;
                        player2.Specifications(player1);
                        //player2.EndOfMove();
                    }
                    else
                    {
                        try
                        {
                            player1.GetClassSkills();
                            Console.Write("Ходит ");
                            Player.ColorPlayerName(FirstNamePlayer, FirstClassPlayer);
                            int numberSkill = int.Parse(Console.ReadLine());
                            switch (numberSkill)
                            {
                                case 1:
                                    player1.Skill1(player2);
                                    break;
                                case 2:
                                    player1.Skill2(player2);
                                    break;
                                case 3:
                                    player1.Skill3(player2);
                                    break;
                                default:
                                    player1.AvtoAttack(player2);
                                    break;
                            }                            
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Неверный ввод данных");
                        }
                        FirstStep = 2;
                        player1.Specifications(player2);
                        player2.EndOfMove();
                        player1.EndOfMove();
                        player1.DeleteHealingAndDamage(player2);
                        player2.DeleteHealingAndDamage(player1);
                    }
                }
               
            }
            if (player1.HP > 0)
            {
                player1.GameOver(player2);
            }
            else
            {
                player2.GameOver(player1);
            }
        }
    }
}
