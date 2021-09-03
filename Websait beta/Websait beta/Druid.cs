using System;
using System.Collections.Generic;
using System.Text;

namespace Websait_beta
{
    class Druid : Class
    {
        
        private string name;        
        public override string Name
        {
            get
            {
                return "Druid " + name;
            }
            set => name = value;
        }
        public Druid(string name)
        {
            Name = name;
        }
        private bool catForm = true;
        public bool CatForm { get { return catForm; } private set { catForm = value; } }
        private bool bearForm = false;
        public bool BearForm { get { return bearForm; } private set { bearForm = value; } }           
        private int hp = 100;
        public override int HP 
        {
            get
            {              
                if (bearForm == true && hp > 130)
                {
                    hp = 130;
                    Console.WriteLine("Здоровье медведя полное");
                    return hp;
                    
                }
                else if (catForm == true && hp  > 100)
                {
                    hp = 100;
                    Console.WriteLine("Здоровье кошки полное");
                    return hp;
                }
                return hp;
            }
            set => hp = value;        
        }                           
          
        private int damage = 5;
        public override int Damage { get { return damage; } set { damage = value; } }
        private int rage = 100;
        public override int Rage { get { return rage; } set { rage = value; } }
        private int mana = 100;
        public override int Mana { 
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
            Console.ForegroundColor = ConsoleColor.Green;

            if (catForm == true && Mana > 30)
            {
                catForm = false;
                bearForm = true;
                Damage = 3;
                HP += 30;
                Console.WriteLine("Смена формы на медведя");
                Mana -= 30;
            }
            else if (catForm == false && Mana > 30)
            {
                catForm = true;
                bearForm = false;
                Damage = 5;
                Console.WriteLine("Смена формы на кота");
                Mana -= 30;
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
            if (Rage > 10)
            {
                int Dam = this.Damage * 2;
                player.HP -= Dam;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Удар когтями в спину");                
                Rage -= 10;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{this.Name}: Недосточно ярости");
            }
            Console.ResetColor();
        }
        public override void Skill3(Class player)
        {
            if (Mana >= 15)
            {
                HealAndDamage -= Healing;
                count = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Изцеление друида");
                Mana -= 15;
                HealAndDamage += Healing;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{this.Name}: Недосточно маны");
            }
            Console.ResetColor();
        }    
        public void Healing(Class player)
        {
            
            HP += 7;            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Исцеление природой {count}й тик");
            count++;
            Console.ResetColor();
            
        }
        public override void GetClassSkills()
        {
            Console.WriteLine();
            Console.WriteLine("1. Смена формы - 30 Маны");
            Console.WriteLine("2. Удар когтями в спину - 10 Ярости (Урон 10)");
            Console.WriteLine("3. Исцеление природой(Дота) - 15 Маны (Здоровье +7)");
        }   
        public override void DeleteHealingAndDamage(Class player)
        {
            if (count > 5)
            {
                HealAndDamage -= Healing;
                count = 0;
            }
        }
    }
}
