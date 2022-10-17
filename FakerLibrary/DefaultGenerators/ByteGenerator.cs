using System;

namespace University.DotnetLabs.Lab2.FakerLibrary.DefualtGenerators;

public class ByteGenerator : IGenerator
{   
    Random random = new Random();
    public object Generate() => (byte) random.Next(byte.MinValue, byte.MaxValue);
}
