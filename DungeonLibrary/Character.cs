using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS
        private string _name = null!;
        private int _maxLife;
        private int _life;
        private int _hitChance;
        private int _dodge;

        //PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Dodge
        {
            get { return _dodge; }
            set { _dodge = value; }
        }


        //CONSTRUCTORS
        public Character(string name, int hitChance, int dodge, int maxLife)
        {
            //we did not account for Life in the parameter list because we are going to assign it manually.
            //Property
            Name = name;
            HitChance = hitChance;
            Dodge = dodge;
            MaxLife = maxLife;
            Life = maxLife;//Start all characters at max health.
        }

        public Character()
        {
            //added so we can have default ctors in our monster classes later.
        }
        //METHODS
        public override string ToString()
        {
            //return base.ToString();//Namespace.ClassName -> DungeonLibrary.Character
            return $"----- {Name} -----\n" +
                   $"Life: {Life}/{MaxLife}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Dodge: {Dodge}%\n";
        }

        //Because we intend to use Character as a base class for other, more specific types,
        //We want those classes to have their own version of the below code.
        //Anything marked as 'virtual' CAN be overridden in a child class.
        public virtual int CalcDodge()
        {
            return Dodge;//Return Dodge for player class, overridden for the monster subtypes
        }
        public virtual int CalcHitChance()
        {
            return HitChance;//Return HitChance for monster classes and HitChance + weapon bonus hit chance for player
        }

        //We don't really have ANY functionality defined here, so we can make this method abstract.
        //Abstract methods cannot have a { body }.
        //Abstract methods create a contract. Any child classes MUST complete (implement) this method to be considered a type of "Character"
        //Abstract members can only be created in abstract classes.
        public abstract int CalcDamage();
    }
}
