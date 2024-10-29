using NUnit.Framework;
using project1;

namespace test1;

[TestFixture]
public class HelloTests
{
    [TestCase("John", "Hello, John!")]
    [TestCase("Jane", "Hello, Jane!")]
    [TestCase("", "Hello, my friend!")]
    [TestCase("BOB", "HELLO, BOB!")]
    public static void Test(string input, string expectedResult)
    {
        var actualResult = Hello.Greed(input);
        
        Assert.AreEqual(expectedResult, actualResult);
    }
}
