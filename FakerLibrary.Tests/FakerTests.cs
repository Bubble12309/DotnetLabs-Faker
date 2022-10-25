using System.Drawing;
using University.DotnetLabs.Lab2.FakerLibrary;
using University.DotnetLabs.Lab2.FakerLibrary.Exceptions;

namespace University.DotnetLabs.Lab2.FakerLibrary.Tests;

[TestClass]
public class FakerTests
{
    private Faker _faker;
    [TestInitialize]
    public void TestInitialize()
    {
        _faker = new Faker();
    }

    [DataTestMethod]
    [DataRow(typeof(bool))]
    [DataRow(typeof(byte))]
    [DataRow(typeof(char))]
    [DataRow(typeof(decimal))]
    [DataRow(typeof(double))]
    [DataRow(typeof(float))]
    [DataRow(typeof(int))]
    [DataRow(typeof(long))]
    [DataRow(typeof(object))]
    [DataRow(typeof(sbyte))]
    [DataRow(typeof(short))]
    [DataRow(typeof(uint))]
    [DataRow(typeof(ulong))]
    [DataRow(typeof(ushort))]
    public void TestDefaultGenerators(Type type)
    {
        _faker.Create(type);
    }

    [TestMethod]
    public void TestDependencyLock()
    {
        _faker.Create<A>();
    }

    [TestMethod]
    public void TestGenerateUnknown()
    {
        _faker.Create<ClassWithValueTypes>();
    }

    [TestMethod]
    public void TestGenerateGeneric()
    {
        _faker.Create<List<List<double>>>();
    }

    [TestMethod]
    public void TestGenerateUnknownGeneric()
    {
        _faker.Create<List<Point>>();
    }

    [TestMethod]
    [ExpectedException(typeof(NotInstanceableException))]
    public void TestNonInstanceable()
    {
        _faker.Create<Generator>();
    }

    [TestMethod]
    public void TestConfig() 
    {
        FakerConfig configs = new FakerConfig();
        configs.Add<Point, int>(p => p.X, new IntValueGenerator(-10));
        Faker newFaker = new Faker(configs);
        Point p = newFaker.Create<Point>();
    }

}
