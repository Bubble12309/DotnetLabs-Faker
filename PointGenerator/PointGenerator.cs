using System.Drawing;
namespace University.DotnetLabs.Lab2.FakerLibrary;

public class PointGenerator : Generator
{
    Random random = new Random();

    public int MaxX { get; } = 50;
    public int MaxY { get; } = 50;
    public override object? Generate()
    {
        return new Point(random.Next(0, MaxX), random.Next(0, MaxY));
    }

    public PointGenerator() : this(50, 50) { }
    public PointGenerator(int maxX, int maxY)
    {
        GeneratingType = typeof(Point);
        MaxX = maxX;
        MaxY = maxY;
    }
}