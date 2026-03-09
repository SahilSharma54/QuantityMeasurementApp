using QuantityMeasurementApp.Models;

class Program
{
    static void Main()
    {
        QuantityLength a = new QuantityLength(1, LengthUnit.Feet);
        QuantityLength b = new QuantityLength(12, LengthUnit.Inch);

        QuantityLength resultFeet = a.Add(b, LengthUnit.Feet);
        QuantityLength resultInch = a.Add(b, LengthUnit.Inch);
        QuantityLength resultYard = a.Add(b, LengthUnit.Yards);

        Console.WriteLine(resultFeet);   // 2 Feet
        Console.WriteLine(resultInch);   // 24 Inch
        Console.WriteLine(resultYard);   // 0.667 Yards
    }
}