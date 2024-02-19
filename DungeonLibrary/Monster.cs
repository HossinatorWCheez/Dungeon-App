using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //FIELDS
        private int _minDamage;

        //PROPERTIES
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //CONSTRUCTORS
        public Monster(string name, int hitChance, int dodge, int maxLife,
            int maxDamage, int minDamage, string description)
            : base(name, hitChance, dodge, maxLife)
        {
            //MaxDamage must be set before minDamage
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }
        //Default ctor for default monsters later
        //If your parent class does NOT have a parameterless ctor, you CANNOT have one in the child classes.
        public Monster() : base()
        {

        }

        //METHODS
        public override string ToString()
        {
            return "******************* MONSTER *******************\n" +
                base.ToString() +
                $"Damage: {MinDamage} - {MaxDamage}\n" +
                $"Description: {Description}";
        }


        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }

        public static Monster GetMonster()
        {
            //TODO - Come back and customize this list with your own monster subtypes.
            Monster m1 = new Monster("Goblin", 30, 20, 18, 8, 1, "A mischievous creature with sharp claws.");
            Monster m2 = new Monster("Skeleton Warrior", 40, 10, 20, 10, 1, "A reanimated skeleton wielding a rusty sword.");
            Monster m3 = new Monster("Cave Troll", 60, 5, 35, 5, 1, "A massive and hulking creature dwelling in dark caverns.");
            Monster m4 = new Monster("Cave Spider", 55, 15, 30, 12, 3, "A human-sized spider large enough it has audible steps");
            Monster m5 = new Monster("Banshee", 50, 15, 25, 15, 1, "A wailing spirit capable of haunting nightmares and rupturing ear drums with just screams");
            Monster m6 = new Monster("Drake", 50, 25, 35, 13, 2, "A fearsome scaled creature resembling the shape of a Lion, possesses sharp teeth and a bone crushing bite force");
            Monster m7 = new Monster("Dark Necromancer", 75, 30, 28, 13, 4, "A sinister sorcerer commanding the undead with dark magic.");
            SpiderQueen s1 = new SpiderQueen("Spider Queen", 55, 15, 30, 15, 3, "A human-sized spider large enough it has audible steps", true);
            Banshee b1 = new Banshee("Dreadful Banshee", 50, 30, 25, 12, 5, "A wailing spirit capable of haunting nightmares and rupturing ear drums with just screams", true);
            FlameDrake f1 = new FlameDrake("Flame Drake", 50, 20, 35, 15, 4, "A fearsome scaled creature resembling the shape of a Lion, possesses sharp teeth and a bone crushing bite force", true);

            List<Monster> monsters = new List<Monster>()
            {
                m1, m1, m1, m1, m1, m1, m1, m1, m1, m1, m1, m1,
                m2, m2, m2, m2, m2, m2, m2, m2, m2, m2, m2, m2,
                m3, m3, m3, m3,
                m4, m4,
                m5, m5,
                m6, m6,
                m7, m7,
                s1, 
                b1,
                f1,

            };

            int randomIndex = new Random().Next(monsters.Count);
            Monster monster = monsters[randomIndex];
            return monster;

        }
    }
}
