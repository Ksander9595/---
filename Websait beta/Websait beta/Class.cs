using System;
using System.Collections.Generic;
using System.Text;

namespace Websait_beta
{


    abstract class Class : IPlayer
    {
        internal delegate void GradualHealandDamage(Class player);
        internal GradualHealandDamage HealAndDamage;

        public int progress = 0;
        public virtual string Name { get; set; }
        public virtual int HP { get; set; }
        public virtual int Rage { get; set; }
        public virtual int Mana { get; set; }
        public virtual int Damage { get; set; }

        public void AvtoAttack(IPlayer player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            player.HP -= this.Damage;
            Console.WriteLine("Выполнена автоатака");
            Console.ResetColor();
        }
        public void EndOfMove()
        {
            HealAndDamage?.Invoke(this);
        }
        public void Specifications(Class player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {player.Name} HP: {player.HP} Damage: {player.Damage} Rage: {player.Rage} Mana: {player.Mana}");
            Console.WriteLine($" {this.Name} HP: {this.HP} Damage: {this.Damage} Rage: {this.Rage} Mana: {this.Mana}");
            Console.ResetColor();
        }
        public abstract void GetClassSkills();
        public abstract void Skill1(Class player);
        public abstract void Skill2(Class player);
        public abstract void Skill3(Class player);
        public void GameOver(Class player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{this.Name} WIN!!!");
            Console.WriteLine($"HP: {this.HP} Damage {this.Damage} Mana {this.Mana} Rage {this.Rage}");
            Console.WriteLine($"{player.Name} LOSE");
            Console.WriteLine($"HP: {player.HP} Damage {player.Damage} Mana {player.Mana} Rage {player.Rage}");
            Console.ResetColor();
        }
        public abstract void DeleteHealingAndDamage(Class player);
    }
}
