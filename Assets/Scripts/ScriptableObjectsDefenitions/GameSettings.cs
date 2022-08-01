using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    PLAYER_VS_PLAYER,
    PLAYER_VS_COMPUTER,
    COMPUTER_VS_COMPUTER
}

[CreateAssetMenu(fileName = "New Game Settings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private GameMode gameMode;
    [SerializeField] private Sprite bgSprite;
    public GameMode GameMode 
    { 
        get { return gameMode; } 
        set { gameMode = value; }
    }

    public Sprite BGSprite
    {
        get { return bgSprite; }
        set { bgSprite = value; }
    }
}
