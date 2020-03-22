using System;

namespace TVCommercialOptimiser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" -- Welcome to TV Commercial Optimiser! -- ");
            Commercials commercials = new Commercials();

            //Place 3 commercials in each of the breaks with no violations of the restrictions
            commercials.PlaceCommercials();
            Console.WriteLine("\n Press Enter key to start Optimisation");

            //Find the optimal placement that maximises the total ratings
            commercials.ValidateMaximiseTotalRatings(3, 3, 3);

            //Print the final placement structure along with the sum of the ratings achieved
            commercials.PrintPlacementStructure();

            Console.WriteLine("\n Press Enter key to Add Additonal Bonus Points with Commercial 10");
            Console.ReadKey();

            //You have an additional commercial with one break takes 2, one takes 3 and one takes 4 commercials
            commercials.AdditionalBonusPoints();

            //Find the optimal placement that maximises the total ratings
            commercials.ValidateMaximiseTotalRatings(2, 3, 4);

            //Print the final placement structure along with the sum of the ratings achieved
            commercials.PrintPlacementStructure();

            //return;
        }


    }
}
