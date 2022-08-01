using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Initializes the game scene based on values recieved from the main menu through 
the Game Settings Scriptable Object
 */
public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private BoardGame board;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private GameObject UndoOption;
    [SerializeField] private GameObject HintOption;

    
    private void Awake()
    {
        background.sprite = gameSettings.BGSprite;

        board.gameObject.SetActive(false);
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);

        switch (gameSettings.GameMode)
        {
            case GameMode.PLAYER_VS_PLAYER:
                InitializePlayerVSPlayerGame();
                break;
            case GameMode.PLAYER_VS_COMPUTER:
                InitializePlayerVSComputerGame();
                break;
            case GameMode.COMPUTER_VS_COMPUTER:
                InitiallizeComputerVSComputerGame();
                break;
        }

        board.gameObject.SetActive(true);
    }


    private void InitializePlayerVSPlayerGame()
    {
        if (board.gameObject.TryGetComponent(out HistoryBehaviour history))
            history.enabled = false;
        if (board.gameObject.TryGetComponent(out HintBehaviour hint))
            hint.enabled = false;
        if (UndoOption)
            UndoOption.SetActive(false);
        if (HintOption)
            HintOption.SetActive(false);

        player1.ChangeController(PlayerType.INPUT_CONTROLLED);
        player2.ChangeController(PlayerType.INPUT_CONTROLLED);
    }

    private void InitializePlayerVSComputerGame()
    {
        player1.ChangeController(PlayerType.INPUT_CONTROLLED);
        player2.ChangeController(PlayerType.AI_CONTROLLED);
    }

    private void InitiallizeComputerVSComputerGame()
    {
        if (board.gameObject.TryGetComponent(out HistoryBehaviour history))
            history.enabled = false;
        if (board.gameObject.TryGetComponent(out HintBehaviour hint))
            hint.enabled = false;
        if (UndoOption)
            UndoOption.SetActive(false);
        if (HintOption)
            HintOption.SetActive(false);

        player1.ChangeController(PlayerType.AI_CONTROLLED);
        player2.ChangeController(PlayerType.AI_CONTROLLED);
    }
}
