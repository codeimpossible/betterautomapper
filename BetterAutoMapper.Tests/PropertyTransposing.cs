using Xunit;

namespace BetterAutoMapper.Tests
{
    public class PropertyTransposing
    {
        [Fact]
        public void MapShouldAllowPropertyTransposing()
        {
            var john = new John { FirstName = "John", LastName = "Test" };

            var simplePerson = BAM.BOOM.Map<John, SimplePerson>(john, (j) =>
            {
                return new
                {
                    FullName = j.FirstName + " " + j.LastName
                };
            });

            Assert.Equal(simplePerson.FullName, "John Test");
        }

        [Fact]
        public void MapShouldTransposeNestedProperties()
        {
            var john = new John { FirstName = "John", LastName = "Test" };

            var people = BAM.BOOM.Map<John, People>(john, (j) =>
            {
                return new
                {
                    Jared = new
                    {
                        FirstName = j.FirstName
                    },
                    John = new
                    {
                        FirstName = j.FirstName,
                        LastName = j.LastName
                    },
                    Simple = new
                    {
                        FullName = j.FirstName + " " + j.LastName
                    }
                };
            });

            Assert.Equal(people.Jared.FirstName, "John");
            Assert.Equal(people.John.FirstName, "John");
            Assert.Equal(people.John.LastName, "Test");
            Assert.Equal(people.Simple.FullName, "John Test");
        }
    }
}
