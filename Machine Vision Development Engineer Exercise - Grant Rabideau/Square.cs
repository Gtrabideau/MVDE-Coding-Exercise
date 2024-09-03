using System;

public class Square : Shape
{
    // Old data for calculations
    private double CenterX;
    private double CenterY;
    private double SideLength;
    private double Orientation;

    // New data we are calculating
    private double perimeter;
    private double area;
    private double centroidX;
    private double centroidY;

    // Properties to send back data to Shape parent for use in getValues()
    public override double Perimeter { get { return perimeter; } }
    public override double Area { get { return area; } }
    public override double CentroidX { get { return centroidX; } }
    public override double CentroidY { get { return centroidY; } }

    public Square(String[] data)
	{
        // Get the correct data from the array i.e.( [0] = "CenterX" [1] = 2.2321 ...)
        this.CenterX = Convert.ToDouble(data[1]);
        this.CenterY = Convert.ToDouble(data[3]);
        this.SideLength = Convert.ToDouble(data[5]);
        this.Orientation = Convert.ToDouble(data[7]);

        // Run the calculations methods below, which calculate the new data we want
        calculations();
    }

    public override void calculateArea()
    {
        // sideLength^2 for area of a square
        area = SideLength * SideLength;
    }

    public override void calculatePerimeter()
    {
        // Perimeter of a square
        perimeter = 4 * SideLength;
    }

    public override void calculateCentroid()
    {
        // The center of a square is its centroid
        centroidX = CenterX;
        centroidY = CenterY;
    }
}
