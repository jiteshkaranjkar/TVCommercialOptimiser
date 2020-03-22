using System;
using Xunit;
using TVCommercialOptimiser;

namespace TVCommercialOptimiserTest
{
    public class TVCommercialOptimiserBase : IDisposable
    {
        public Commercials commercial { get; set; }
        public TVCommercialOptimiserBase()
        {
            commercial = new Commercials();
        }

        public void Dispose()
        {
            commercial = null;
        }
    }

    public class CommercialsTest : IClassFixture<TVCommercialOptimiserBase>
    {

        Commercials commercial { get; set; }
        public CommercialsTest(TVCommercialOptimiserBase data)
        {
            commercial = data.commercial;
        }

        [Fact]
        public void ValidateTotalCommercials()
        {
            int totalBreaks = 9;
            commercial.PlaceCommercials();
            Assert.Equal(commercial.breks.Count, totalBreaks);
        }

        [Fact]
        public void CreateBreak()
        {
            CommercialsEnum comm1 = CommercialsEnum.Commercial1;
            Brek brek1 = new Brek(CommercialsEnum.Commercial1, CommercialTypeEnum.Automotive, DemographicsEnum.Women2530, 80);
            Assert.Equal(brek1.Commercial, comm1);
        }
    }
}
