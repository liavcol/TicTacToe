using System.Collections.Generic;
/*
 Making the hint feature easily testable in edit mode.
 */
public class HintGenerator
{
    private readonly List<int> validIndexes;

    public HintGenerator(int initPossibilites = 9)
    {
        validIndexes = new List<int>(initPossibilites);
        for (int i = 0; i < initPossibilites; i++)
            validIndexes.Add(i);
    }

    public void UpdateValidIndexes(int i)
    {
        if (!validIndexes.Remove(i))
            validIndexes.Add(i);
    }

    public int? GenerateHint()
    {
        if (validIndexes.Count == 0)
            return null;
     
        System.Random rnd = new System.Random();
        return validIndexes[rnd.Next(validIndexes.Count)];
    }

    public int[] GetAllValidIndexes() => validIndexes.ToArray();
}
