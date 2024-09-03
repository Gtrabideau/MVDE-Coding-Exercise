using System;

public class Polygon : Shape
{
    // A list of tuples to store the coordinates of each point in the polygon
    private List<Tuple<double, double>> points = new List<Tuple<double, double>>();

    // New data we are calculating
    private double perimeter;
    private double area;
    private double centroidX;
    private double centroidY;

    // Variables used in the calculations
    private double x1;
    private double y1;
    private double x2;
    private double y2;

    // Properties to send back data to Shape parent for use in getValues()
    public override double Perimeter { get { return perimeter; } }
    public override double Area { get { return area; } }
    public override double CentroidX { get { return centroidX; } }
    public override double CentroidY { get { return centroidY; } }

    public Polygon(String[] points)
    {
        // Add points to the tuple list
        for (int i = 1; i < points.Length; i += 4) 
        {
            this.points.Add(Tuple.Create(Convert.ToDouble(points[i]), Convert.ToDouble(points[i + 2])));
        }

        // Run the calculations methods below, which calculate the new data we want
        calculations();
    }

    public override void calculateArea()
    {
        // Shoelace Method
        // [ (x1 * y2) - (y1 * x2) ] + [ (x2 * y3) - (y2 * x3) ]...

        for (int i = 0; i < points.Count - 1; i++)
        { 
            // Define points to make equation more readable
            x1 = points[i].Item1;
            y1 = points[i].Item2;
            x2 = points[i + 1].Item1;
            y2 = points[i + 1].Item2;

            // Calculate part of equation and add to whole
            area += (x1 * y2) - (y1 * x2);
        }

        // Finish equation by dividing in half
        area = area / 2;
    }

    public override void calculatePerimeter()
    {
        // Use line distance formula and add each length of line to the perimeter
        // sqrt[ (x2 - x1)^2 + (y2 - y1)^2 ] + sqrt[ (x3 - x2)^2 + (y3 - y2)^2 ]...

        for (int i = 0; i < points.Count - 1; i++)
        {
            // Define points to make equation more readable
            x1 = points[i].Item1;
            y1 = points[i].Item2;
            x2 = points[i + 1].Item1;
            y2 = points[i + 1].Item2;

            // Calculate distance of the line segment using the distance formula, then add it to the whole perimeter
            perimeter += Math.Sqrt(Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));
        }
    }

    public override void calculateCentroid()
    {
        // Do the shoelace method again, but use the temporary areas calculated in the centroid formula
        double tempArea = 0;

        for (int i = 0; i < points.Count - 1; i++)
        {
            // Define points to make equation more readable
            x1 = points[i].Item1;
            y1 = points[i].Item2;
            x2 = points[i + 1].Item1;
            y2 = points[i + 1].Item2;

            tempArea = (x1 * y2) - (y1 * x2);

            // Get the summation of the X's multiplied by the area defined in the shoelace method
            centroidX += (x1 + x2) * tempArea;
            centroidY += (y1 + y2) * tempArea;
        }
        // Finish the equation using the signed area that has already been calculated in calculateArea()
        centroidX /= 6 * area;
        centroidY /= 6 * area;
    }
}
