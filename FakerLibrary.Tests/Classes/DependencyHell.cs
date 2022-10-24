using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DotnetLabs.Lab2.FakerLibrary.Tests;

internal class A
{
    public int x;
    public int y;
    public char c;

    public A() { }

    public B b;

    public override string ToString()
    {
        StringBuilder sb = new($"{this.GetType().Name} has x = {x}, y = {y}, c = {c}, B is ");
        sb.Append((b == null) ? "null" : b.ToString());
        return sb.ToString();
    }
}

internal class B
{
    public char c;

    public B() { }
    public A a;

    public override string ToString()
    {
        StringBuilder sb = new($"{this.GetType().Name} has c = {c}, A is ");
        sb.Append((a == null) ? "null" : a.ToString());
        return sb.ToString();
    }
}