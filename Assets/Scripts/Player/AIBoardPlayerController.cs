public class AIBoardPlayerController : BoardPlayerController
{
    private readonly Timer timer = new Timer();

    public AIBoardPlayerController(BoardGame boardGame) : base(boardGame) { }

    public override void EnableController() => timer.Start(2);
    public override void DisableController() { }
    public override int ChooseSquare() => timer.TimeRemaining > 0 ? -1 : new System.Random().Next(9);
}
