public class Costume
{
    // attributes
    public string _headwear;
    public string _upperGarment;
    public string _lowerGarment;
    public string _footwear;
    public string _accessories;
    // behavior
    public void Output()
    {
        // put that john out
        Console.WriteLine("Costume Spec:");
        Console.WriteLine($"Head: {_headwear}");
        Console.WriteLine($"Shoulders: {_upperGarment}");
        Console.WriteLine($"Knees: {_lowerGarment}");
        Console.WriteLine($"Toes: {_footwear}");
        Console.WriteLine($"Extra: {_accessories}");
    }
}