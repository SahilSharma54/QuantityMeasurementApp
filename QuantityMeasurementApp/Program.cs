using QuantityMeasurementApp.Models;

class Program
{
    static void Main()
    {
        QuantityLength length1 = new QuantityLength(1, LengthUnit.Feet);
        QuantityLength length2 = new QuantityLength(12, LengthUnit.Inch);

        QuantityLength result = length1.Add(length2);

        Console.WriteLine(result); 
        // Output: 2 Feet
    }
}