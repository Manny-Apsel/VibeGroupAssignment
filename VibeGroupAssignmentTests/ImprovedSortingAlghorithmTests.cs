using VibeGroupAssignment.Classes;
using Xunit;

namespace VibeGroupAssignmentTests
{
    public class ImprovedSortingAlghorithmTests
    {
        [Fact]
        public void CreateInstanceFooBar()
        {
            var sa = new ImprovedSortingAlghorithm(new string[] { "foo", "bar", "foobar" });
            Assert.NotEmpty(sa.Input);
            Assert.NotEmpty(sa.AllowedCombinations);
            Assert.Contains("bar", sa.Input);
            Assert.Contains("foobar", sa.AllowedCombinations);
        }

        [Fact]
        public void CreateInstanceBarFoo()
        {
            var sa = new ImprovedSortingAlghorithm(new string[] { "foo", "bar", "barfoo" });
            Assert.NotEmpty(sa.Input);
            Assert.NotEmpty(sa.AllowedCombinations);
            Assert.Contains("bar", sa.Input);
            Assert.Contains("barfoo", sa.AllowedCombinations);
        }

        [Theory]
        [InlineData("a", "z", "e", "r", "t", "y", "azerty")]
        [InlineData("y", "t", "r", "e", "z", "a", "azerty")]
        [InlineData("a", "y", "e", "r", "t", "z", "azerty")]
        [InlineData("a", "t", "r", "z", "e", "y", "azerty")]

        public void TestAlghorithmAZERTY(params string[] input)
        {
            var sa = new ImprovedSortingAlghorithm(input);
            sa.FindCombinations();
            Assert.Equal(new List<string> { "a", "z", "e", "r", "t", "y" }, sa.Results.FirstOrDefault());
        }

        [Theory]
        [InlineData("az", "er", "ty", "azerty")]
        [InlineData("ty", "er", "az", "azerty")]
        [InlineData("ty", "az", "er", "azerty")]
        [InlineData("az", "ty", "er", "azerty")]
        [InlineData("er", "az", "ty", "azerty")]
        public void TestAlghorithmAzErTy(params string[] input)
        {
            var sa = new ImprovedSortingAlghorithm(input);
            sa.FindCombinations();
            Assert.Equal(new List<string> { "az","er", "ty" }, sa.Results.FirstOrDefault());
        }

        [Theory]
        [InlineData("az", "er", "azerty")]
        public void TestAlghorithmAzErShouldFail(params string[] input)
        {
            var sa = new ImprovedSortingAlghorithm(input);
            sa.FindCombinations();
            Assert.Empty(sa.Results);
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
            var sa = new ImprovedSortingAlghorithm(input);
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
            var sa = new ImprovedSortingAlghorithm(input);
            sa.FindCombinations();
            Assert.Equal(new List<string>() { "bar", "foo" }, sa.Results.FirstOrDefault());
        }
    }
}
