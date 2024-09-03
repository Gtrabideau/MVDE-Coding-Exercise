using System;
using System.Text;

public class MainMethod
{

    public static void Main(String[] args)
    {
        // Path to the original CSV file 
        String csvPath = "Machine Vision Development Engineer Coding Exercise _ ShapeList2.csv";
        csvPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", csvPath);

        // Lists for storing the raw string data and the objects created from that data 
        List<String> shapeData = new List<String>();
        List<Shape> shapeObjects = new List<Shape>();

        // StringBuilder for creating the new CSV file
        StringBuilder sb = new StringBuilder();

        // Get original CSV file from the CSV path
        using (var reader = new StreamReader(csvPath))
        {
            while (!reader.EndOfStream)
            {
                //Read the data, but get rid of any trailing apostrophes from empty data slots.
                var line = reader.ReadLine().TrimEnd(',');
                shapeData.Add(line);
            }
        }

        // Add shapes from original CSV to the shape object list
        foreach (var entry in shapeData)
        {
            // Split each line of the original data into its number, the type of shape, and the rest of the data
            String[] data = entry.Split(",", 3);
            String shapeNum  = data[0];
            String shapeType = data[1];
            String shapeValues = data[2];

            // Create an object based on the type of shape
            switch (shapeType)
            {
                // Finish splitting the data completely before sending it into the shape
                case "Circle":
                    shapeObjects.Add(new Circle(shapeValues.Split(",")));
                    break;
                case "Ellipse":
                    shapeObjects.Add(new Ellipse(shapeValues.Split(",")));
                    break;
                case "Equilateral Triangle":
                    shapeObjects.Add(new EquilateralTriangle(shapeValues.Split(",")));
                    break;
                case "Polygon":
                    shapeObjects.Add(new Polygon(shapeValues.Split(",")));
                    break;
                case "Square":
                    shapeObjects.Add(new Square(shapeValues.Split(",")));
                    break;
                default:
                    // Default message in case there is any unrecognized shape 
                    Console.WriteLine("There is a non-recognized shape type in this data, please check entry " + shapeNum.ToString() + ".");
                    break;
            }

            // Header to sandwich the new information between the basic information and the detailed information
            String header = shapeNum + ',' + shapeType + ',';
            // Create new csv with calculated area, perimeter, and centroid point data. Start with the header, then the current finished object data, the remaining old data
            sb.Append(header + shapeObjects[shapeObjects.Count - 1].getValues() + shapeValues + '\n');
        }
        // Write the finished CSV data to the Data folder
        String outputFile = "output.csv";
        File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", outputFile), sb.ToString());
    }
}
