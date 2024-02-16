using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class SpiderQueen : Monster
    {


        //FIELDS

        //PROPERTIES
        public bool IsEvasive { get; set; }
        //CONSTRUCTORS
        public SpiderQueen(string name, int hitChance, int dodge, int maxLife, int maxDamage, int minDamage, string description, 
            bool isEvasive) 
            : base(name, hitChance, dodge, maxLife, maxDamage, minDamage, description)
        {
            IsEvasive = isEvasive;
            if (isEvasive == true)
            {
                Dodge += 20;
                MaxLife += 15;
                Life = MaxLife;
                MinDamage += 3;
                Description = "A monstrous spider, surrounded by webbing and her young";
            }
        }
        //METHODS
        public override string ToString()
        {
            return $"{base.ToString()}\nEnhancements: Evasive\n+20 Dodge\n+15 Life Cap\n+3 Minimum Damage";
        }
    }        
}
