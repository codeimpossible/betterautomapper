using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BetterAutoMapper.Tests
{
    public class StrictMapping
    {
        [Fact]
        public void ShouldThrowAnExceptionIfDataWouldBeLost()
        {
            var john = new John { FirstName = "John", LastName = "Test" };
            Assert.Throws<BAMStrictMapViolationException>(() =>
            {
                var jared = BAM.BOOM.Map<John, Jared>(john, true);
            });
        }
    }
}
