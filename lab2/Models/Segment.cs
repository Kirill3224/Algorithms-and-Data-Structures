namespace lab2;

public class Segment
{
    public double StartX { get; set; }
    public double StartY { get; set; }
    public double EndX { get; set; }
    public double EndY { get; set; }

    public Segment(double startX, double startY, double endX, double endY)
    {
        StartX = startX;
        StartY = startY;
        EndX = endX;
        EndY = endY;
    }

    public double CalculateLength()
    {
        return Math.Sqrt(Math.Pow(EndX - StartX, 2) + Math.Pow(EndY - StartY, 2));
    }

    public override string ToString()
    {
        return $"Відрізок [({StartX:F1}, {StartY:F1}) - ({EndX:F1}, {EndY:F1})], Довжина: {CalculateLength():F2}";
    }
}