using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class SByteGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => (sbyte) random.Next(sbyte.MinValue, sbyte.MaxValue);
    public SByteGenerator() => GeneratingType = typeof(sbyte);
}
