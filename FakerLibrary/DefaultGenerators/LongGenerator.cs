using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class LongGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => random.NextInt64(long.MinValue, long.MaxValue);
    public LongGenerator() => GeneratingType = typeof(long);
}
