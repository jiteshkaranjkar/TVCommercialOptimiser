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

        [Fact]
        public void Test1()
        {

        }
    }
}
