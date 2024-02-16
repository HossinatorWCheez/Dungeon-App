using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Banshee : Monster
    {

        //FIELDS

        //PROPERTIES
        public bool IsLoud { get; set; }
        //CONSTRUCTORS
        public Banshee(string name, int hitChance, int dodge, int maxLife, int maxDamage, int minDamage, string description, 
            bool isLoud) 
            : base(name, hitChance, dodge, maxLife, maxDamage, minDamage, description)
        {
            IsLoud = isLoud;
            if (isLoud == true)
            {
                MaxDamage += 7;
                MaxLife += 15;
                Life = MaxLife;
                HitChance += 10;
                Description = "A Dreaful Banshee who lived a horrifying past and is now vengeful, looking to make anyone experience her pain.";
            }
        }

        //METHODS
        public override string ToString()
        {
            return $"{base.ToString()}\nEnhancement: Dreadful\n+15 Life cap\n+7 Damage cap\n+10 Hit Chance";
        }
    }
}
