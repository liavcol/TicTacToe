using System;
using UnityEngine;

/*
 This is the big brain of the game. It keeps track of the flow of the game. 
In order to reduce it's responsibilty I split different functions into different MonoBehaviours.
This way we can just add or remove features from the game just by adding or removing components to the Board Game Object. Something like a Dependancy Injection.
I decided to rely heavily on the Observer pattern so the BoardGame class won't have to know the other features it has.
I though about making this class a Singleton, it seems like a good use case for it, but Singletons can be harder to expand on
(what if I wanted to have a scene with 2 boards at the same time?) and I was able to achieve good results using events.

The board is responsible to assign the playes, and expose events for things happening in the game.
It is connected to all of it's SquaresBehaviours in order to handle the visual flow of the board 
and uses the TicTacToeBoard to handle the actual logic of the squares.
 */
public class BoardGame : MonoBehaviour
{
    //Players
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    private Player currPlayer;

    //Marks
    [SerializeField] private Mark emptyMark;
    [SerializeField] private Mark XMark;
    [SerializeField] private Mark OMark;

    //Squares
    [SerializeField] private SquareBehaviour[] squares;
    
    private TicTacToeBoard board;

    //Events
    public event Action<int> OnButtonClicked;
    public event Action OnGameBegin;
    public event Action<Player, int> OnTurnSwap;
    public event Action OnGameEnd;

    [SerializeField] private GameLogger gameLogger;

    public void ButtonClicked(int i) => OnButtonClicked?.Invoke(i);
    public Player CurrPlayer { get { return currPlayer; } }

    private void Awake()
    {
        board = new TicTacToeBoard(emptyMark);

        player1.BoardGame = this;
        player2.BoardGame = this;
    }

    private void Start() => BeginGame();

    public void MarkSquare(int i)
    {

        if (!board.MarkSquare(i, currPlayer.AssignedMark))
            return;
        squares[i].MarkSquare(currPlayer.AssignedMark);
        if (board.CheckWinningFormation())
        {
            PlayerWon(currPlayer);
            return;
        }
        if (board.CheckDraw())
        {
            GameDraw();
            return;
        }
        SwitchTurn(i);
    }

    public void ClearSquare(int i)
    {
        if (board.ClearSquare(i))
        {
            squares[i].MarkSquare(emptyMark);
            SwitchTurn(i);        
        }
    }

    public void HighlightSquare(int i) => squares[i].HighlightSquare();

    public void PlayerWon(Player p) => EndGame($"{p.Name} won!");

    public void PlayerLost(Player p) => PlayerWon(p == player1 ? player2 : player1);

    public void GameDraw() => EndGame("Draw");

    private void SwitchTurn(int choiceMade)
    {

        currPlayer.gameObject.SetActive(false);
        Player from = currPlayer;
        currPlayer = currPlayer == player1 ? player2 : player1;
        currPlayer.gameObject.SetActive(true);
        gameLogger.LogCurrentPlayer(currPlayer);
        OnTurnSwap?.Invoke(from, choiceMade);
    }

    private void BeginGame()
    {
        foreach (SquareBehaviour square in squares)
            square.MarkSquare(emptyMark);
        gameLogger.ClearLogs();
        AssignPlayers();
        gameLogger.LogCurrentPlayer(currPlayer);
        OnGameBegin?.Invoke();
    }

    private void EndGame(string msg)
    {
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        gameLogger.LogEndMessage(msg);
        OnGameEnd?.Invoke();
    }

    public void RestartGame()
    {
        EndGame("");
        board.Reset();
        BeginGame();
    }

    private void AssignPlayers()
    {
        if (!(player1 && player2))
            return;

        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);

        System.Random rnd = new System.Random();
        if (rnd.Next() % 2 == 0)
        {
            player1.AssignedMark = XMark;
            player2.AssignedMark = OMark;
            currPlayer = player1;
        }
        else
        {
            player1.AssignedMark = OMark;
            player2.AssignedMark = XMark;
            currPlayer = player2;
        }
        currPlayer.gameObject.SetActive(true);
    }
}
