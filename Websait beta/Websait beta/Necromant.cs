using System;
using System.Collections.Generic;
using System.Text;

namespace Websait_beta
{
    class Necromant : Class
    {       
        private string name;
        public override string Name
        {
            get
            {
                return "Necromant " + name;
            }
            set => name = value;
        }
        public Necromant(string name)
        {
            Name = name;
        }
        private int hp = 100;
        public override int HP
        {
            get
            {
                if (hp < 0)
                    hp = 0;
                return hp;
            }
            set => hp = value;
        }
        private int damage = 5;
        public override int Damage { get => damage; set => damage = value; }       
        private int mana = 120;
        public override int Mana
        {
            get
            {
                if (mana < 0)
                    mana = 0;
                return mana;
            }
            set => mana = value;
        }
        private static int count = 1;
        public override void Skill1(Class player)
        {
            if (mana >= 15)
            {
                player.HealAndDamage -= BloodPoisoning;
                count = 1;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Заражение крови на {player.Name}");
                Mana -= 15;
                player.HealAndDamage += BloodPoisoning;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{this.Name}: Недосточно маны");
            }
            Console.ResetColor();
        }
        public override void Skill2(Class player)
        {
            if (mana >= 10)
            {
                int Dam = this.Damage * 2;
                player.HP -= Dam;
                Mana -= 10;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Удар косой смерти");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{this.Name}: Недосточно маны");
            }
            Console.ResetColor();            
        }
        public override void Skill3(Class player)
        {
            if (mana >= 10)
            {
                player.Damage -= 1;
                this.Mana -= 10;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Оружие {player.Name} проклято");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{this.Name}: Недосточно маны");
            }
            Console.ResetColor();
        }       
        public void BloodPoisoning(Class player)
        {         
            int Dam = Damage / 2;
            player.HP -= Dam;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Заражение крови {count}й тик");
            count++;
            Console.ResetColor();            
        }
        public override void GetClassSkills()
        {
            Console.WriteLine();
            Console.WriteLine("1. Заражение крови(Дота) - 15 Маны");
            Console.WriteLine("2. Удар косой смерти - 10 Маны");
            Console.WriteLine("3. Проклятие на оружие - 10 Маны");
        }
        public override void DeleteHealingAndDamage(Class player)
        {
            if (count == 5)
            {
                player.HealAndDamage -= BloodPoisoning;
                count = 0;
            }
        }

    }
}
