using Services.Config;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Services
{
    public class AutomapperTests
    {
        [Fact]
        public void ShouldAutoMap()
        {
            //configuration is asserted in the constructor.
            //var next = new MapperConfig();
            var teamMapper = new TeamMapper(); //currently we map everything in each map            
            Assert.True(true);
        }
    }
}
