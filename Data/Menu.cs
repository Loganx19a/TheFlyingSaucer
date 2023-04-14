using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Sides;

namespace TheFlyingSaucer.Data
{
    public static class Menu
    {
        /// <summary>
        /// All the available entrees in their default configuration
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees 
        {
            get 
            {
                List<Entree> entrees = new List<Entree>();
                entrees.Add(new FlyingSaucer());
                entrees.Add(new CrashedSaucer());
                entrees.Add(new LivestockMutilation());
                entrees.Add(new OuterOmlette());
                return entrees;
            } 
        }

        /// <summary>
        /// An instance of all available sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<Side> sides = new List<Side>();
                sides.Add(new CropCircle());
                sides.Add(new EvisceratedEggs() { Style = Enumerations.EggStyle.Scrambled });
                #region other egg styles
                /*
                sides.Add(new EvisceratedEggs() { Style = Enumerations.EggStyle.SoftBoiled});
                sides.Add(new EvisceratedEggs() { Style = Enumerations.EggStyle.HardBoiled });
                sides.Add(new EvisceratedEggs() { Style = Enumerations.EggStyle.OverEasy });
                sides.Add(new EvisceratedEggs() { Style = Enumerations.EggStyle.SunnySideUp });
                sides.Add(new EvisceratedEggs() { Style = Enumerations.EggStyle.Poached });
                */
                #endregion
                sides.Add(new GlowingHaystack());
                sides.Add(new MissingLinks());
                sides.Add(new TakenBacon());
                sides.Add(new YouAreToast());
                return sides;
            }
        }

        /// <summary>
        /// All available drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<Drink> drinks = new List<Drink>();

                drinks.Add(new InorganicSubstance() { Size = Enumerations.ServingSize.Small });
                drinks.Add(new InorganicSubstance() { Size = Enumerations.ServingSize.Medium });
                drinks.Add(new InorganicSubstance() { Size = Enumerations.ServingSize.Large });

                drinks.Add(new LiquifiedVegetation() { Size = Enumerations.ServingSize.Small });
                drinks.Add(new LiquifiedVegetation() { Size = Enumerations.ServingSize.Medium });
                drinks.Add(new LiquifiedVegetation() { Size = Enumerations.ServingSize.Large });

                drinks.Add(new SaucerFuel() { Size = Enumerations.ServingSize.Small });
                drinks.Add(new SaucerFuel() { Size = Enumerations.ServingSize.Medium });
                drinks.Add(new SaucerFuel() { Size = Enumerations.ServingSize.Large });
                return drinks;
            }
        }

        /// <summary>
        /// All of the items on the menu (one of each of the items found in the categories above)
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> allItems = new List<IMenuItem>();
                allItems = Entrees.Concat(Sides).Concat(Drinks).ToList();
                return allItems;     
            }
        }
    }
}
