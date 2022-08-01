public class InputBoardPlayerController : BoardPlayerController
{
    private int choice = -1;
    public InputBoardPlayerController(BoardGame boardGame) : base(boardGame) { }

    public override void EnableController()
    {
        choice = -1;
        boardGame.OnButtonClicked += HandleClick;
    }

    public override void DisableController()
    {
        boardGame.OnButtonClicked -= HandleClick;
    }

    public override int ChooseSquare() => choice;
    private void HandleClick(int i) => choice = i;
}
