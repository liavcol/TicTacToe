/*
This is a player that is controlled by user input.
Or more specifically, controlled by clicking the buttons of the UI board.
*/
public class InputControlledPlayer : Player1
{
    private int choice = -1;
   
    //Listen to the board clicking event when enabled.
    private void OnEnable()
    {
        choice = -1;
        boardGame.OnButtonClicked += HandleClick;
    }

    //Don't listen to the board clicking event when disabled.
    private void OnDisable() => boardGame.OnButtonClicked -= HandleClick;

    private void HandleClick(int i) => choice = i;

    protected override int ChooseSquare()
    {
        return choice;
    }
}
