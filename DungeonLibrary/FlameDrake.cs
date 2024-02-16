using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class FlameDrake : Monster
    {

        //FIELDS

        //PROPERTIES
        public bool IsScaly { get; set; }
        //CONSTRUCTORS
        public FlameDrake(string name, int hitChance, int dodge, int maxLife, int maxDamage, int minDamage, string description,
            bool isScaly) 
            : base(name, hitChance, dodge, maxLife, maxDamage, minDamage, description)
        {
            IsScaly = isScaly;
            if (isScaly == true)
            {
                MaxLife += 20;
                Life = MaxLife;
                Dodge += 15;
                HitChance += 10;
                Description = "A Drake with a flaming tail, capable of breathing fire, Bite wounds will become instantly cauterized";
            }
        }

        //METHODS
        public override string ToString()
        {
            return $"{base.ToString()}\nEnhancements: Flaming\n+20 Life Cap\n+15 Dodge\n+10 Hit Chance";
        }
    }
}
