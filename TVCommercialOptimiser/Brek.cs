using System;
using System.Collections.Generic;
using System.Linq;

namespace TVCommercialOptimiser
{
    public class Brek
    {
        public BreakTypesEnum BreakType { get; set; }
        public DemographicsEnum Demographic { get; set; }
        public int Rating { get; set; }
        public int OptimisedRating { get; set; }
        public CommercialsEnum Commercial { get; set; }
        public CommercialTypeEnum CommercialType { get; set; }

        public Brek(CommercialsEnum commercial, CommercialTypeEnum commercialType, DemographicsEnum demo, int rating)
        {
            BreakType = BreakTypesEnum.NoBreak;
            Demographic = demo;
            Rating = rating;
            Commercial = commercial;
            CommercialType = commercialType;
        }

        //Commercials of the same type cannot be next to each other within a break
        public bool BreakSameTypeCommercials(List<Brek> breaks, int breakCapacity)
        {
            bool flag = true;
            if (breaks.Count == breakCapacity)
            {
                flag = false;
            }
            if (breaks.Count > 0)
            {
                int currentIndex = breaks.Count - 1;
                int index = breaks.FindIndex(x => x.CommercialType == CommercialType);
                if (index > -1)
                {
                    if (index == currentIndex)
                    {
                        if (index == 1)
                        {
                            breaks.Reverse();
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }

            return flag;
        }

    }
}
