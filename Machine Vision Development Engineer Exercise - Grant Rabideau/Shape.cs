public abstract class Shape
{
    // Abstract properties of the information we want from every shape
    public abstract double Perimeter { get; }
    public abstract double Area { get; }
    public abstract double CentroidX { get; }
    public abstract double CentroidY { get; }

    // Methods that we want every child class to have
    public abstract void calculatePerimeter();
    public abstract void calculateArea();
    public abstract void calculateCentroid();

    // Default virtual method to run the methods above
    public virtual void calculations()
    {
        calculatePerimeter();
        calculateArea();
        calculateCentroid();
    }

    // Return our desired data in the format we want it
    public virtual String getValues()
    {
        String returnString = $"Area,"+Area.ToString()+",Perimeter,"+Perimeter.ToString() + ",CentroidX,"+ CentroidX.ToString() + ",CentroidY,"+CentroidY.ToString() + ",";
        return returnString;
    }
}