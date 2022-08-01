using System.Collections.Generic;
/*
Making The undo function testable in edit mode.
*/
public class TurnHistory
{
    private readonly Stack<int> turnsChoices = new Stack<int>(); 
    
    public void RecordTurn(int choice) => turnsChoices.Push(choice);

    public (int?, int?) UndoRound()
    {
        int? choice1 = null;
        if (turnsChoices.Count > 0)
            choice1 = turnsChoices.Pop();
        int? choice2 = null;
        if(turnsChoices.Count > 0)
            choice2 = turnsChoices.Pop();

        return (choice1, choice2);
    }   
}
