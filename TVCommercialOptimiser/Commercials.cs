using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace TVCommercialOptimiser
{
    public class Commercials
    {
        private Tuple<string, string, int>[] breakDemographicRatings;

        private List<List<Brek>> breaksNestedList;
        List<Brek> breks;

        public Commercials()
        {
            breaksNestedList = new List<List<Brek>>();
            breks = new List<Brek>();
            breakDemographicRatings = GetBreakDemographicRatings();
        }

        public Tuple<string, string, int>[] GetBreakDemographicRatings()
        {
            Tuple<string, string, int>[] breakDemographicRatings =
            {
                Tuple.Create("Break1", "Women2530", 80),
                Tuple.Create("Break1", "Men1835", 100),
                Tuple.Create("Break1", "Total1840", 250),
                Tuple.Create("Break2", "Women2530", 50),
                Tuple.Create("Break2", "Men1835", 120),
                Tuple.Create("Break2", "Total1840", 200),
                Tuple.Create("Break3", "Women2530", 350),
                Tuple.Create("Break3", "Men1835", 150),
                Tuple.Create("Break3", "Total1840", 500),
            };
            return breakDemographicRatings;
        }

        public void PlaceCommercials()
        {
            Console.WriteLine("\n Press Enter key to Place commercials in the breaks");
            Console.ReadLine();

            Brek brek1 = new Brek(CommercialsEnum.Commercial1, CommercialTypeEnum.Automotive, DemographicsEnum.Women2530, 80);
            breks.Add(brek1);
            Brek brek2 = new Brek(CommercialsEnum.Commercial2, CommercialTypeEnum.Travel, DemographicsEnum.Men1835, 100);
            breks.Add(brek2);
            Brek brek3 = new Brek(CommercialsEnum.Commercial3, CommercialTypeEnum.Travel, DemographicsEnum.Total1840, 250);
            breks.Add(brek3);
            CalculateRatingsAchieved("Break1", brek1, brek2, brek3);

            Brek brek4 = new Brek(CommercialsEnum.Commercial4, CommercialTypeEnum.Automotive, DemographicsEnum.Men1835, 50);
            breks.Add(brek4);
            Brek brek5 = new Brek(CommercialsEnum.Commercial5, CommercialTypeEnum.Automotive, DemographicsEnum.Men1835, 120);
            breks.Add(brek5);
            Brek brek6 = new Brek(CommercialsEnum.Commercial6, CommercialTypeEnum.Finance, DemographicsEnum.Women2530, 200);
            breks.Add(brek6);
            CalculateRatingsAchieved("Break2", brek4, brek5, brek6);

            Brek brek7 = new Brek(CommercialsEnum.Commercial7, CommercialTypeEnum.Finance, DemographicsEnum.Men1835, 350);
            breks.Add(brek7);

            Brek brek8 = new Brek(CommercialsEnum.Commercial8, CommercialTypeEnum.Automotive, DemographicsEnum.Total1840, 150);
            breks.Add(brek8);
            Brek brek9 = new Brek(CommercialsEnum.Commercial9, CommercialTypeEnum.Travel, DemographicsEnum.Women2530, 500);
            breks.Add(brek9);
            CalculateRatingsAchieved("Break3", brek7, brek8, brek9);
        }

        public void CalculateRatingsAchieved(string breakName, Brek brek1, Brek brek2, Brek brek3)
        {
            Console.WriteLine($"In {breakName} Total ratings of the three commercials before optimisation is {brek1.Rating + brek2.Rating + brek3.Rating}");
        }

        public void ValidateMaximiseTotalRatings(int break1Cap, int break2Cap, int break3Cap)
        {
            List<Brek> optBreaks1 = new List<Brek>(break1Cap);

            List<Brek> optBreaks2 = new List<Brek>(break2Cap);

            List<Brek> optBreaks3 = new List<Brek>(break3Cap);

            foreach (Brek brek in breks)
            {
                bool isOpen = true;
                while (isOpen)
                {
                    Random random = new Random();
                    var num = random.Next(1, 4);
                    if (brek.CommercialType == CommercialTypeEnum.Finance)
                    {
                        if (num == 1 && optBreaks1.Count < break1Cap && brek.BreakSameTypeCommercials(optBreaks1, break1Cap))
                        {
                            brek.BreakType = BreakTypesEnum.Break1;
                            optBreaks1.Add(brek);
                            isOpen = false;
                        }
                        else if (num == 3 && optBreaks3.Count < break3Cap && brek.BreakSameTypeCommercials(optBreaks3, break3Cap))
                        {
                            brek.BreakType = BreakTypesEnum.Break3;
                            optBreaks3.Add(brek);
                            isOpen = false;
                        }
                    }
                    else
                    {
                        if (num == 1 && optBreaks1.Count < break1Cap && brek.BreakSameTypeCommercials(optBreaks1, break1Cap))
                        {
                            brek.BreakType = BreakTypesEnum.Break1;
                            optBreaks1.Add(brek);
                            isOpen = false;
                        }
                        else if (num == 2 && optBreaks2.Count < break2Cap && brek.BreakSameTypeCommercials(optBreaks2, break2Cap))
                        {
                            brek.BreakType = BreakTypesEnum.Break2;
                            optBreaks2.Add(brek);
                            isOpen = false;
                        }
                        else if (num == 3 && optBreaks3.Count < break3Cap && brek.BreakSameTypeCommercials(optBreaks3, break3Cap))
                        {
                            brek.BreakType = BreakTypesEnum.Break3;
                            optBreaks3.Add(brek);
                            isOpen = false;
                        }
                        else if (optBreaks3.Count + optBreaks2.Count + optBreaks1.Count == 9)
                        {
                            isOpen = false;
                        }
                    }
                }
            }

            GetOptimsedRatings(optBreaks1);
            GetOptimsedRatings(optBreaks2);
            GetOptimsedRatings(optBreaks3);

            breaksNestedList.Add(optBreaks1);
            breaksNestedList.Add(optBreaks2);
            breaksNestedList.Add(optBreaks3);
        }

        public void GetOptimsedRatings(List<Brek> optBreaks)
        {
            foreach (Brek brek in optBreaks)
            {
                foreach (var breakRatings in breakDemographicRatings)
                {
                    if (brek.BreakType.ToString() == breakRatings.Item1 && brek.Demographic.ToString() == breakRatings.Item2)
                    {
                        brek.OptimisedRating = breakRatings.Item3;
                    }
                }
            }
        }

        public void AdditionalBonusPoints()
        {
            Brek brek10 = new Brek(CommercialsEnum.Commercial10, CommercialTypeEnum.Finance, DemographicsEnum.Total1840, 500);
            breks.Insert(0, brek10);
            breks.RemoveAt(breks.FindIndex(x => x.Rating == 50));
            breaksNestedList = new List<List<Brek>>();
        }

        public void PrintPlacementStructure()
        {
            Console.WriteLine("\n The optimal rating achieved is");

            int totalSum = 0;
            int totalOptimisedRatingSum = 0;
            foreach (List<Brek> breaks in breaksNestedList)
            {
                totalSum += breaks.Sum(x => x.Rating);
                totalOptimisedRatingSum += breaks.Sum(x => x.OptimisedRating);
                foreach (Brek brek in breaks)
                {
                    Console.WriteLine($" This is {brek.BreakType} with {brek.Commercial} of type {brek.CommercialType} with Demographic {brek.Demographic} and rating {brek.Rating} and Optimised rating {brek.OptimisedRating}");
                }
                Console.WriteLine($" In {breaks[0].BreakType} Maximum Total ratings of the three commercials is {breaks.Sum(x => x.Rating)}");
                Console.WriteLine("\n");
            }
            Console.WriteLine($" So Total ratings is {totalSum}");
            Console.WriteLine($" So Total Optimised Ratings is {totalOptimisedRatingSum}");
        }
    }
}
