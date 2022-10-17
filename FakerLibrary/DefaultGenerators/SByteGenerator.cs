using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class SByteGenerator : IGenerator
{
    Random random = new Random();
    public object Generate() => (sbyte) random.Next(sbyte.MinValue, sbyte.MaxValue);
}
