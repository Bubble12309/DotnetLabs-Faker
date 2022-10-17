using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class DoubleGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => random.NextDouble() * double.MaxValue;
    public DoubleGenerator() => GeneratingType = typeof(double);
}
