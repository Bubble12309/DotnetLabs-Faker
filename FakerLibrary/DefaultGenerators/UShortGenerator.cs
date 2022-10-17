using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class UShortGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => (ushort)random.Next(ushort.MinValue, ushort.MaxValue);
    public UShortGenerator() => GeneratingType = typeof(ushort);
}
