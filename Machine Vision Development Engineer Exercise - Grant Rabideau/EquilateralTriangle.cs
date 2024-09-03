using System;

public class EquilateralTriangle : Shape
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

    public EquilateralTriangle(String[] data)
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
        // sqrt(3)/4 * sideLength^2 for the area of an equilateral triangle 
        area = (Math.Sqrt(3)/4) * (SideLength * SideLength);
    }

    public override void calculatePerimeter()
    {
        // All three sides of an equilateral triangle to get the perimeter
        perimeter = 3 * SideLength;
    }

    public override void calculateCentroid()
    {
        // The center of an equilateral triangle is the centroid
        centroidX = CenterX;
        centroidY = CenterY;
    }
}
