using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.BaseClasses;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Sides;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Enumerations;


namespace TheFlyingSaucer.DataTests
{
    public class MenuUnitTests
    {
        #region Checking the count of items in a category matches the expectation
        [Fact]
        public void NumberOfEntreeMenuItemsShouldEqualFour()
        {
            Assert.Equal(4, Menu.Entrees.Count());
        }

        [Fact]
        public void NumberOfSideMenuItemsShouldEqualEleven()
        {
            Assert.Equal(11, Menu.Sides.Count());
        }

        [Fact]
        public void NumberOfDrinkMenuItemsShouldEqualNine()
        {
            Assert.Equal(9, Menu.Drinks.Count());
        }

        #endregion

        #region Check that each unique combination exists in each category

        [Fact]
        public void EachUniqueCombinationShouldExistInEntreesCategory()
        {
            List<Entree> entrees = new List<Entree>();

            entrees.Add(new FlyingSaucer());
            entrees.Add(new CrashedSaucer());
            entrees.Add(new LivestockMutilation());
            entrees.Add(new OuterOmlette());

            for(int i = 0; i < entrees.Count; i++)
            {
                Assert.Contains(Menu.Entrees, (x) => { return entrees[i].GetType() == x.GetType(); });
            }
            Assert.Equal(entrees.Count, Menu.Entrees.Count());
        }

        [Fact]
        public void EachUniqueCombinationShouldExistInSidesCategory()
        {
            List<Side> sides = new List<Side>();

            sides.Add(new CropCircle());
            sides.Add(new EvisceratedEggs() { Style = EggStyle.Scrambled });
            sides.Add(new EvisceratedEggs() { Style = EggStyle.OverEasy });
            sides.Add(new EvisceratedEggs() { Style = EggStyle.SunnySideUp });
            sides.Add(new EvisceratedEggs() { Style = EggStyle.SoftBoiled });
            sides.Add(new EvisceratedEggs() { Style = EggStyle.HardBoiled });
            sides.Add(new EvisceratedEggs() { Style = EggStyle.Poached });
            sides.Add(new GlowingHaystack());
            sides.Add(new MissingLinks());
            sides.Add(new TakenBacon());
            sides.Add(new YouAreToast());

            for (int i = 0; i < sides.Count; i++)
            {
                Assert.Contains(Menu.Sides, (x) => { return sides[i].GetType() == x.GetType(); });
            }
            Assert.Equal(sides.Count, Menu.Sides.Count());
        }

        [Fact]
        public void EachUniqueCombinationShouldExistInDrinksCategory()
        {
            List<Drink> drinks = new List<Drink>();

            drinks.Add(new InorganicSubstance() { Size = ServingSize.Small });
            drinks.Add(new InorganicSubstance() { Size = ServingSize.Medium });
            drinks.Add(new InorganicSubstance() { Size = ServingSize.Large });

            drinks.Add(new LiquifiedVegetation() { Size = ServingSize.Small });
            drinks.Add(new LiquifiedVegetation() { Size = ServingSize.Medium });
            drinks.Add(new LiquifiedVegetation() { Size = ServingSize.Large });

            drinks.Add(new SaucerFuel() { Size = ServingSize.Small });
            drinks.Add(new SaucerFuel() { Size = ServingSize.Medium });
            drinks.Add(new SaucerFuel() { Size = ServingSize.Large });

            for (int i = 0; i < drinks.Count; i++)
            {
                Assert.Contains(Menu.Drinks, (x) => { return drinks[i].GetType() == x.GetType(); });
                Assert.Equal(drinks[i].Size, ((Drink)Menu.Drinks.ElementAt(i)).Size);
            }
            Assert.Equal(drinks.Count, Menu.Drinks.Count());
        }



        #endregion
    }
}
