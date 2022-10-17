using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class UIntGenerator : Generator
{
    Random random = new Random();
    public override object Generate() => (uint) random.Next(0, int.MaxValue);
    public UIntGenerator() => GeneratingType = typeof(uint);
}