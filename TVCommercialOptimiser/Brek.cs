using System;
using System.Collections.Generic;
using System.Linq;

namespace TVCommercialOptimiser
{
    public class Brek
    {
        public string BreakName { get; set; }
        public BreakTypesEnum BreakType { get; set; }
        public DemographicsEnum Demographic { get; set; }
        public int Rating { get; set; }
        public CommercialsEnum Commercial { get; set; }
        public CommercialTypeEnum CommercialType { get; set; }

        public Brek(string name, CommercialsEnum commercial, CommercialTypeEnum commercialType, DemographicsEnum demo, int rating)
        {
            BreakName = name;
            BreakType = BreakTypesEnum.NoBreak;
            Demographic = demo;
            Rating = rating;
            Commercial = commercial;
            CommercialType = commercialType;
        }

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

                    //if (breaks[index + 1].CommercialType == CommercialType)
                    //{
                    //    flag = false;
                    //}

                    //else if (index > -1 && (index - 1) == 0)
                    //{
                    //    if (breaks[index + 1].CommercialType == CommercialType)
                    //    {
                    //        flag = false;
                    //    }
                    //}
                }
                //if (index + 2 >= 3)
                //{
                //    flag = false;
                //}
            }

            return flag;
        }

    }
}
