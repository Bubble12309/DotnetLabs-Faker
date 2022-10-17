using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public sealed class ByteGenerator : Generator
{   
    Random random = new Random();
    public override object Generate() => (byte)random.Next(byte.MinValue, byte.MaxValue);
    public ByteGenerator() => GeneratingType = typeof(byte);
}
