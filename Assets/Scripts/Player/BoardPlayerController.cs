public enum PlayerType
{
    INPUT_CONTROLLED,
    AI_CONTROLLED
}

public abstract class BoardPlayerController
{
    public static BoardPlayerController GetController(PlayerType type, BoardGame board)
    {
        return type switch
        {
            PlayerType.INPUT_CONTROLLED => new InputBoardPlayerController(board),
            PlayerType.AI_CONTROLLED => new AIBoardPlayerController(board),
            _ => null,
        };
    }

    protected BoardGame boardGame;
    public BoardPlayerController(BoardGame boardGame)
    {
        this.boardGame = boardGame;
        EnableController();
    }

    public abstract void EnableController();
    public abstract void DisableController();
    public abstract int ChooseSquare();
}