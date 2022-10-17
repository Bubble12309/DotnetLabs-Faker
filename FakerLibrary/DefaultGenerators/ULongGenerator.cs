using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class ULongGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => (ulong) random.NextInt64(0, long.MaxValue);
    public ULongGenerator() => GeneratingType = typeof(ulong);
}
