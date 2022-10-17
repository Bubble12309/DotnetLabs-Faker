using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class DecimalGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => Convert.ToDecimal(random.Next(0,  Convert.ToInt32(decimal.MaxValue)));
    public DecimalGenerator() => GeneratingType = typeof(decimal);
}
