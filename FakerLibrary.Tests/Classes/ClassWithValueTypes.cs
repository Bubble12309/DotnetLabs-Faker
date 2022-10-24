using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DotnetLabs.Lab2.FakerLibrary.Tests;

internal class ClassWithValueTypes
{
    public int a1 = 15;
    public int a2 = 16;
    public int a3;
    public double a4;
    public byte a5;

    public ClassWithValueTypes(int a1, int a2, int a3, double a4, byte a5 = 10)
    {
        this.a1 = a1;
        this.a2 = a2;
        this.a3 = a3;
        this.a4 = a4;
        this.a5 = a5;
    }
}
