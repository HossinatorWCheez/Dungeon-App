using DungeonLibrary;

namespace DungeonTests
{
    public class DungeonTests
    {
        //Assert.InRange(actual, min, max)
        //Life+=20
        //Assert.Equal(MaxLife, Life)
        [Fact]
        public void Test_WeaponDamage()
        {
            Weapon wT = new("Sword", 5, 25, 20, false, WeaponType.Sword, 20);
            Player pT = new("",100,0,0,Race.Elf, wT);

            var actual = pT.CalcDamage();

            Assert.InRange(actual, 5, 25);
        }
        [Fact]
        public void Test_MaxLife()
        {
            Player player = new("", 0,0,70, Race.Elf, new("",0,1,0,false,WeaponType.Dagger, 0));
            int expected = 65;

            player.Life += 20;
            Assert.Equal(expected, player.Life);
        }
    }
}