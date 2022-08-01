using System;
using TMPro;
using UnityEngine;


/*
 A class to log messages using UI text elements.
 */
[Serializable]
public class GameLogger
{
    [SerializeField] private TMP_Text currentPlayerText;
    [SerializeField] private TMP_Text endGameMessage;

    public void ClearLogs()
    {
        if (currentPlayerText != null)
            currentPlayerText.text = "";
        if (endGameMessage != null)
            endGameMessage.text = "";
    }

    public void LogCurrentPlayer(Player p)
    {
        if (currentPlayerText != null)
            currentPlayerText.text = p.Name;
    }

    public void LogEndMessage(string msg)
    {
        if (endGameMessage != null)
            endGameMessage.text = msg;
    }
}
