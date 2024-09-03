using System;
using System.Reflection.Metadata;

public class Circle : Shape
{
    // Old data for calculations
    private double CenterX;
    private double CenterY;
    private double Radius;

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

    public Circle(String[] data)
	{
        // Get the correct data from the array i.e.( [0] = "CenterX" [1] = 2.2321 ...)
        this.CenterX = Convert.ToDouble(data[1]);
        this.CenterY = Convert.ToDouble(data[3]);
        this.Radius = Convert.ToDouble(data[5]);

        // Run the calculations methods below, which calculate the new data we want
        calculations();
    }

    public override void calculateArea()
    {
        // PI * r^2 for the area of a circle
        area = Math.PI * (Radius * Radius);
    }

    public override void calculatePerimeter()
    {
        // 2PI * r for the perimeter of a circle
        perimeter = 2 * Math.PI * Radius;
    }

    public override void calculateCentroid()
    {
        // The center of a circle is the centroid
        centroidX = CenterX;
        centroidY = CenterY;
    }
}
