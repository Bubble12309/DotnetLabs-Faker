using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class IntGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => random.Next(int.MinValue, int.MaxValue);
    public IntGenerator() => GeneratingType = typeof(int);
}
