using System;
using System.Collections.Generic;
using System.Text;

namespace Websait_beta
{
    
    public enum ClassPlayer
    {
        Warrior,
        Druid,
        Paladin,
        Necromant
    }
    public interface IPlayer
    {      
        string Name { get; set; }
        int HP { get; set; }
        int Damage { get; set; }
        int Mana { get; set; }
        int Rage { get; set; }

        

       
        
    }
    
}
