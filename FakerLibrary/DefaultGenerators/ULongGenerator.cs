using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class ULongGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => (ulong) random.NextInt64(0, long.MaxValue);
}
