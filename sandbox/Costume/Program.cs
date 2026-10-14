class Program
{
    static void Main()
    {
        List<Costume> myCostumes = new List<Costume>();

        Costume detective = new Costume();
        detective._headwear = "fedora";
        detective._upperGarment = "trenchcoat";
        detective._lowerGarment = "slacks";
        detective._footwear = "dress shoes";
        detective._accessories = "magnifying glass";
        myCostumes.Add(detective);

        Costume snorkler = new Costume();
        snorkler._headwear = "goggles";
        snorkler._upperGarment = "rash guard";
        snorkler._lowerGarment = "trunks";
        snorkler._footwear = "flippers";
        snorkler._accessories = "snorkel";
        myCostumes.Add(snorkler);

        foreach (Costume c in myCostumes)
        {
            c.Output();
        }
    }
}