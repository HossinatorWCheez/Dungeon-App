using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Properties
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }

        //Construcors
        public Player(string name, int hitChance, int dodge, int maxLife,
            Race playerRace, Weapon equippedWeapon)
            : base(name, hitChance, dodge, maxLife)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            #region Potential Expansion -Racial Bonuses
            switch (PlayerRace)
            {
                case Race.Human:
                    Life = MaxLife += 5;
                    Dodge += 5;
                    break;
                case Race.Orc:
                    Life = MaxLife += 10;
                    Dodge -= 5;
                    break;
                case Race.Elf: //=========================================== FIX LIFE VALUES ===========================================
                    Life = MaxLife -= 5;
                    HitChance += 10;
                    Dodge += 5;
                    break;
                case Race.Goblin:
                    Dodge += 10;
                    break;
                case Race.Giant:
                    Life = MaxLife += 20;
                    Dodge -= 20;
                    break;
                case Race.Nymph:
                    Life = MaxLife += 15;
                    HitChance -= 10;
                    break;
                case Race.Dwarf:
                    HitChance += 15;
                    break;
                case Race.Dragonborn:
                    Life = MaxLife += 5;
                    HitChance += 5;
                    break;
            }
            #endregion
        }

        //Methods
        public override string ToString()
        {
            #region Potential Expansion - Race/Class descriptions
            string description = "";
            switch (PlayerRace)
            {
                case Race.Human:
                    description = "Just like you and me!";
                    break;
                case Race.Orc:
                    description = "Burely, mean, and simply ugly. However extremely powerful";
                    break;
                case Race.Elf:
                    description = "Nimble and dexterous, extensively trained";
                    break;
                case Race.Goblin:
                    description = "Cheeky and unpleasant to deal with, extremely evasive";
                    break;
                case Race.Giant:
                    description = "Very large and extremely slow, incredibly durable";
                    break;
                case Race.Nymph:
                    description = "Protectors of the wilderness, not the greatest at combat however they live a very healthy life-style";
                    break;
                case Race.Dwarf:
                    description = "Short yet impactful, masters of manipulating metals";
                    break;
                case Race.Dragonborn:
                    description = "Human in their form but possess the blood and soul of a Dragon, referred to as 'Dovahkiin' in their native tongue";
                    break;
                default:
                    break;
            }
            #endregion
            return base.ToString() + $"\nWeapon: {EquippedWeapon}\n" +
                                     $"Player Score: {Score}\n\n" +
                                     $"Selected Race: {PlayerRace}\n" +
                                     $"Description: {description}";
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;
        }
        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }
        //attacker.CalcHitChance() - defender.CalcDodge() = 55%
        //if random.Next(1, 100) < 55, then they hit. Call CalcDamage, apply damage to defender.
    }
}
