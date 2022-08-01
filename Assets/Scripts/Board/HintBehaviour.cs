using UnityEngine;

/*
 This is the hint feature of the game.
 */

[RequireComponent(typeof(BoardGame))]
public class HintBehaviour : MonoBehaviour
{
    private BoardGame _boardGame;

    private HintGenerator hintGenerator = new HintGenerator();

    private void Awake() => _boardGame = GetComponent<BoardGame>();

    private void Start()
    {
        _boardGame.OnGameBegin += () => hintGenerator = new HintGenerator();
        _boardGame.OnTurnSwap += (Player p, int i) => hintGenerator.UpdateValidIndexes(i);
    }

    public void GetHint()
    {
        int? i = hintGenerator.GenerateHint();
        if (i != null)
            _boardGame.HighlightSquare((int)i);
    }
}
