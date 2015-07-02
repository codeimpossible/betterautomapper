using Xunit;

namespace BetterAutoMapper.Tests
{
    public class John
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Jared
    {
        public string FirstName { get; set; }
    }


    public class BetterAutoMapperTests
    {
        [Fact]
        public void ShouldMapClasses()
        {
            var john = new John { FirstName = "John!", LastName = "Bubriski!" };

            var jared = new BetterAutoMapper().Map<John, Jared>(john);

            Assert.Equal(jared.FirstName, "John!");
        }

        [Fact]
        public void ShouldMapClassesTheOtherWay()
        {
            var jared = new Jared { FirstName = "Jared!" };

            var john = new BetterAutoMapper().Map<Jared, John>(jared);

            Assert.Equal(john.FirstName, "Jared!");
            Assert.Equal(john.LastName, null);
        }
    }
}
