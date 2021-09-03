using System;
using System.Collections.Generic;
using System.Text;

namespace Websait_beta
{
    class Paladin : Class
    {       
        private string name;
        public override string Name
        {
            get
            {
                return "Paladin " + name;
            }
            set => name = value;
        }
        public Paladin(string name)
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
                else if(hp > 100)
                    hp = 100;
                return hp;
            }
            set => hp = value;
        }
        private int damage = 6;
        public override int Damage { get => damage; set => damage = value; }
        private int mana = 100;
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
        public override void Skill1(Class player)
        {
            if (mana > 10)
            {
                int Dam = this.Damage * 2;
                player.HP -= Dam;
                this.Mana -= 10;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Удар война Света!");
                Console.ResetColor();
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
            if (mana > 10)
            {
                Random random = new Random();
                int crit = random.Next(1, 100);
                if (crit <= 20)
                    this.HP += 15;
                else
                    this.HP += 5;
                this.Mana -= 10;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Вспышка света!");                
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
            if (mana > 35)
            {
                int Dam = this.Damage * 5;
                player.HP -= Dam;
                player.Mana -= 25;
                this.Mana -= 35;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("ПРАВОСУДИЕ СВЕРШИЛОСЬ!!!");               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{this.Name}: Недосточно маны");
            }
            Console.ResetColor();
        }    
        public override void GetClassSkills()
        {
            Console.WriteLine();
            Console.WriteLine("1. Удар война света - 10 Маны");
            Console.WriteLine("2. Вспышка света - 10 Маны");
            Console.WriteLine("3. Правосудие света!(Ulta) - 35 Маны");
        }
        public override void DeleteHealingAndDamage(Class player)
        {
            // наверно так не правильно оставлять метод)
        }
    }
}
