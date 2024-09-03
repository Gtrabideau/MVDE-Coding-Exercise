using System;
using System.Reflection.Metadata;

public class Ellipse : Shape
{
    // Old data for calculations
    private double CenterX;
    private double CenterY;
    private double R1;
    private double R2;
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

    public Ellipse(String[] data)
	{
        // Get the correct data from the array i.e.( [0] = "CenterX" [1] = 2.2321 ...)
        this.CenterX = Convert.ToDouble(data[1]);
        this.CenterY = Convert.ToDouble(data[3]);
        this.R1 = Convert.ToDouble(data[5]);
        this.R2 = Convert.ToDouble(data[7]);
        this.Orientation = Convert.ToDouble(data[9]);

        // Run the calculations methods below, which calculate the new data we want
        calculations();
    }

    public override void calculateArea()
    {
        // PI * Radius1 * Radius2 for ellipse's Area
        area = Math.PI * R1 * R2;
    }

    public override void calculatePerimeter()
    {
        // Ramanujan Formula for the perimeter of an ellipse
        // PI( 3(R1 * R2) - sqrt[(3R1 + R2) * (R1 + 3R2)] )
        perimeter = Math.PI * (3 * (R1 * R2) - Math.Sqrt((3 * R1 + R2) * (R1 + 3 * R2)));
    }

    public override void calculateCentroid()
    {
        // The center of an ellipse is the centroid
        centroidX = CenterX;
        centroidY = CenterY;
    }
}
