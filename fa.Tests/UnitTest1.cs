using fans; 

namespace fa.Tests;

[TestClass]
public class FA1Tests
{
    private FA1 _fa1 = null!;

    [TestInitialize]
    public void Setup()
    {
        _fa1 = new FA1();
    }

    [TestMethod]
    public void TestMethod1_01_ShouldBeTrue()
    {
        var result = _fa1.Run("01");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod2_10_ShouldBeTrue()
    {
        var result = _fa1.Run("10");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod3_011_ShouldBeTrue()
    {
        var result = _fa1.Run("011");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod4_001_ShouldBeFalse()
    {
        var result = _fa1.Run("001");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod5_0_ShouldBeFalse()
    {
        var result = _fa1.Run("0");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod6_1_ShouldBeFalse()
    {
        var result = _fa1.Run("1");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod7_111_ShouldBeFalse()
    {
        var result = _fa1.Run("111");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod8_010_ShouldBeFalse()
    {
        var result = _fa1.Run("010");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod9_0111_ShouldBeTrue()
    {
        var result = _fa1.Run("0111");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod10_EmptyString_ShouldBeFalse()
    {
        var result = _fa1.Run("");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod11_101_ShouldBeTrue()
    {
        var result = _fa1.Run("101");
        Assert.IsTrue(result == true);
    }
}

[TestClass]
public class FA2Tests
{
    private FA2 _fa2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _fa2 = new FA2();
    }

    [TestMethod]
    public void TestMethod1_01_ShouldBeTrue()
    {
        var result = _fa2.Run("01");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod2_10_ShouldBeTrue()
    {
        var result = _fa2.Run("10");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod3_0011_ShouldBeTrue()
    {
        var result = _fa2.Run("0011");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod4_0_ShouldBeFalse()
    {
        var result = _fa2.Run("0");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod5_1_ShouldBeFalse()
    {
        var result = _fa2.Run("1");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod6_00_ShouldBeFalse()
    {
        var result = _fa2.Run("00");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod7_11_ShouldBeFalse()
    {
        var result = _fa2.Run("11");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod8_000111_ShouldBeTrue()
    {
        var result = _fa2.Run("000111");
        Assert.IsTrue(result == true);
    }
}

[TestClass]
public class FA3Tests
{
    private FA3 _fa3 = null!;

    [TestInitialize]
    public void Setup()
    {
        _fa3 = new FA3();
    }

    [TestMethod]
    public void TestMethod1_11_ShouldBeTrue()
    {
        var result = _fa3.Run("11");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod2_011_ShouldBeTrue()
    {
        var result = _fa3.Run("011");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod3_110_ShouldBeTrue()
    {
        var result = _fa3.Run("110");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod4_10_ShouldBeFalse()
    {
        var result = _fa3.Run("10");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod5_01_ShouldBeFalse()
    {
        var result = _fa3.Run("01");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod6_101_ShouldBeFalse()
    {
        var result = _fa3.Run("101");
        Assert.IsTrue(result == false);
    }

    [TestMethod]
    public void TestMethod7_111_ShouldBeTrue()
    {
        var result = _fa3.Run("111");
        Assert.IsTrue(result == true);
    }

    [TestMethod]
    public void TestMethod8_000_ShouldBeFalse()
    {
        var result = _fa3.Run("000");
        Assert.IsTrue(result == false);
    }
}