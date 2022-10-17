using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class LongGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => random.NextInt64(long.MinValue, long.MaxValue);
}
