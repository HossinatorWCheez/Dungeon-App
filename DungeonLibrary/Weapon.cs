namespace DungeonLibrary
{
    public class Weapon
    {
        //FIELDS
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private WeaponType _type;

        //PROPERTIES
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Cost { get; set; }
        //CONSTRUCTORS
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded, WeaponType type, int cost)
        {
            if (minDamage >= maxDamage)
            {
                throw new ArgumentException("Min damage must be less than max damage.");
            }
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;
            Cost = cost;
        }

        //public Weapon(string choice)
        //{
        //    switch (choice)
        //    {
        //        case "sword":
        //            MinDamage = 2;
        //            MaxDamage = 5;
        //            Name = "Sword";
        //            BonusHitChance = 1;
        //            IsTwoHanded = false;
        //            Type = WeaponType.Sword;
        //            break;
        //        case "dagger":
        //            MinDamage = 1;
        //            MaxDamage = 3;
        //            Name = "Dagger";
        //            BonusHitChance = 3;
        //            IsTwoHanded = false;
        //            Type = WeaponType.Dagger;
        //            break;
        //        case "hammer":
        //            MinDamage = 5;
        //            MaxDamage = 10;
        //            Name = "Hammer";
        //            BonusHitChance = 0;
        //            IsTwoHanded = true;
        //            Type = WeaponType.Hammer;
        //            break;
        //        case "axe":
        //            MinDamage = 3;
        //            MaxDamage = 8;
        //            Name = "Axe";
        //            BonusHitChance = 2;
        //            IsTwoHanded = true;
        //            Type = WeaponType.Axe;
        //            break;
        //        case "staff":
        //            MinDamage = 3;
        //            MaxDamage = 10;
        //            Name = "Staff";
        //            BonusHitChance = 0;
        //            IsTwoHanded = true;
        //            Type = WeaponType.Staff;
        //            break;
        //        case "legendary":
        //            MinDamage = 10;
        //            MaxDamage = 20;
        //            Name = "Legendary Sword";
        //            BonusHitChance = 0;
        //            IsTwoHanded = true;
        //            Type = WeaponType.Legendary;
        //            break;
        //    }
        //}
        //METHODS
        public override string ToString()
        {
            return $"{Name}\n" +
                $"Damage: {MinDamage} - {MaxDamage}\n" +
                $"Bonus Hit: {BonusHitChance}%\n" +
                $"{(IsTwoHanded ? "Two" : "One")}-Handed {Type}\n" +
                $"Price: {Cost} Score";
        }

        //public static Weapon GetStarterWeapon(List<Weapon> weapons)
        //{
        //    Weapon rustSword = new Weapon("Rusted Sword",1, 4, 0,false,WeaponType.Sword);
        //    Weapon rustDagger = new Weapon("Rusted Dagger", 1, 3, 2, false,WeaponType.Dagger);
        //    return weapons;
        //}


        

    }
}


    
    








    




