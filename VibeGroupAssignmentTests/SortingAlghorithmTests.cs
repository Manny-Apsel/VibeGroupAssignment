using VibeGroupAssignment.Classes;
using Xunit;

namespace VibeGroupAssignmentTests
{
    public class SortingAlghorithmTests
    {
        [Fact]
        public void CreateInstanceFooBar()
        {
            var sa = new SortingAlghorithm(new string[] {"foo", "bar", "foobar"}, 6);
            Assert.NotEmpty(sa.Input);
            Assert.NotEmpty(sa.AllowedCombinations);
            Assert.Contains("bar", sa.Input);
            Assert.Contains("foobar", sa.AllowedCombinations);
        }

        [Fact]
        public void CreateInstanceBarFoo()
        {
            var sa = new SortingAlghorithm(new string[] { "foo", "bar", "barfoo" }, 6);
            Assert.NotEmpty(sa.Input);
            Assert.NotEmpty(sa.AllowedCombinations);
            Assert.Contains("bar", sa.Input);
            Assert.Contains("barfoo", sa.AllowedCombinations);
        }

        [Theory]
        [InlineData("foo", "bar", "foobar")]
        [InlineData("foo", "foobar", "bar")]
        [InlineData("bar", "foo", "foobar")]
        [InlineData("bar", "foobar", "foo")]
        [InlineData("foobar", "foo", "bar")]
        [InlineData("foobar", "bar", "foo")]


        public void TestAlghorithmFoobar(params string[] input)
        {
            var sa = new SortingAlghorithm(input, 6);
            sa.FindCombinations();
            Assert.Equal(new List<string>() { "foo", "bar" }, sa.Results.FirstOrDefault());
        }

        [Theory]
        [InlineData("foo", "bar", "barfoo")]
        [InlineData("foo", "barfoo", "bar")]
        [InlineData("bar", "foo", "barfoo")]
        [InlineData("bar", "barfoo", "foo")]
        [InlineData("barfoo", "foo", "bar")]
        [InlineData("barfoo", "bar", "foo")]

        public void TestAlghorithmBarfoo(params string[] input)
        {
            var sa = new SortingAlghorithm(input, 6);
            sa.FindCombinations();
            Assert.Equal(new List<string>() { "bar", "foo" }, sa.Results.FirstOrDefault());
        }

    }
}