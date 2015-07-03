using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BetterAutoMapper.Tests
{
    public class PropertyCasing
    {
        [Fact]
        public void MapShouldIgnoreCasing()
        {
            var john = new John { FirstName = "John", LastName = "Test" };
            var camelCase = BAM.BOOM.Map<John, CamelCaseProperties>(john);

            Assert.Equal("John", camelCase.firstName);
            Assert.Equal("Test", camelCase.lastName);
        }
    }
}
