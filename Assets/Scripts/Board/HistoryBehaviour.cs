using UnityEngine;

/*
This is the undo extension to the board.
*/
[RequireComponent(typeof(BoardGame))]
public class HistoryBehaviour : MonoBehaviour
{
    private TurnHistory history = new TurnHistory();
    private BoardGame _boardGame;

    private void Awake() => _boardGame = GetComponent<BoardGame>();

    private void Start()
    {
        _boardGame.OnTurnSwap += RecordTurn;
        _boardGame.OnGameEnd += () => history = new TurnHistory();
    }

    public void UndoRound()
    {
        _boardGame.OnTurnSwap -= RecordTurn;

        (int? t1, int? t2) = history.UndoRound();
        if (t1 != null)
            _boardGame.ClearSquare((int)t1);
        if (t2 != null)
            _boardGame.ClearSquare((int)t2);

        _boardGame.OnTurnSwap += RecordTurn;
    }

    private void RecordTurn(Player p, int i) => history.RecordTurn(i);
}
