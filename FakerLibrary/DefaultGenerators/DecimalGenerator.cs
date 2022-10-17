using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class DecimalGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => Convert.ToDecimal(random.Next(0,  Convert.ToInt32(decimal.MaxValue)));
}
