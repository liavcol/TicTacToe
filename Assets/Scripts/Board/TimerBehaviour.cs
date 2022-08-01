using System.Collections;
using UnityEngine;
using TMPro;

/*
This is the timer extension to the board.
*/
[RequireComponent(typeof(BoardGame))]
public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private float timeLimit = 5;
    [SerializeField] private TMP_Text displayText;

    private BoardGame _boardGame;

    private readonly Timer timer = new Timer();

    private void Awake()
    {
        _boardGame = GetComponent<BoardGame>();
    }
    private void Start()
    {
        _boardGame.OnGameBegin += StartTimer;
        _boardGame.OnTurnSwap += (Player p, int i) => StartTimer();
        _boardGame.OnGameEnd += () => StopCoroutine(nameof(Wait));
        StartTimer();
    }

    private void StartTimer()
    {
        StopCoroutine(nameof(Wait));
        StartCoroutine(nameof(Wait));
    }

    private IEnumerator Wait()
    {
        //Not using yield return new WaitForSeconds() so I could update text.
        timer.Start(timeLimit);
        if (displayText)
            displayText.text = string.Format("{0:0.###}", timeLimit);
        while (timer.TimeRemaining > 0)
        {
            yield return new WaitForSeconds(0.1f);
            if (displayText)
                displayText.text = string.Format("{0:0.###}", timer.TimeRemaining);
        }
        //Will get here if turn didn't change (coroutine stopped) on time.
        _boardGame.PlayerLost(_boardGame.CurrPlayer);
    }
}
