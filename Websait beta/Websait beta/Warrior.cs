using System;
using System.Collections.Generic;
using System.Text;

namespace Websait_beta
{   
    class Warrior : Class
    {      
        private string name;
        public override string Name
        {
            get
            {
                return "Warrior " + name;
            }
            set => name = value;
        }
        public Warrior(string name)
        {
            Name = name;
        }
        private int hp = 120;
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
        private int damage = 6;
        public override int Damage { get { return damage; } set { damage = value; } }
        private int mana = 0;
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
        private int rage = 100;
        public override int Rage
        {
            get
            {
                if (rage < 0)
                    rage = 0;
                return rage;
            }
            set => rage = value;
        }
        private static int count = 1;
        public override void Skill1(Class player)
        {
            if (Rage >= 10)
            {
                int Dam = this.Damage * 2;
                player.HP -= Dam;
                this.Rage -= 10;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Сокрушительный удар");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{this.Name}: Недосточно ярости");
            }
            Console.ResetColor();

        }
        public override void Skill2(Class player)
        {
            if (Rage >= 15)
            {
                player.HealAndDamage -= Bleeding;
                count = 1;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Кровотечение на {player.Name}");
                Rage -= 15;
                player.HealAndDamage += Bleeding;
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{this.Name}: Недосточно ярости");
            }
            Console.ResetColor();
        }
            
        public override void Skill3(Class player)
        {
            if (Rage >= 30)
            {
                int Dam = this.Damage * 5;
                player.HP -= Dam;
                player.Mana -= 20;
                this.Rage -= 30;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Смертельный рывок");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{this.Name}: Недосточно ярости");
            }
            Console.ResetColor();
        }       
        public void Bleeding (Class player)
        {            
            player.HP -= Damage;           
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Кровотечение {count}й тик");
            count++;
            Console.ResetColor();           
        }
        public override void GetClassSkills()
        {
            Console.WriteLine();
            Console.WriteLine("1. Сокрушительный удар - 10 Ярости (Урон 12)");
            Console.WriteLine("2. Кровотечение - 15 Ярости (Урон 6)");
            Console.WriteLine("3. Смертельный рывок - 30 Ярости (Урон 30)");               
        }
        public override void DeleteHealingAndDamage(Class player)
        {
            if (count > 5)
            {
                player.HealAndDamage -= Bleeding;
                count = 0;
            }
        }
       
            
        
    }
}
