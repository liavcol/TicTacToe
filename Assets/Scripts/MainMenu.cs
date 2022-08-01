using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Handles Main Menu functions.
Possible Skins:
moonactive
handdrawn
 */

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Mark XMark;
    [SerializeField] private Mark OMark;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private TMP_Text messages;

    private void Start()
    {
        gameSettings.GameMode = 0;
        background.sprite = gameSettings.BGSprite;
    }

    public void ChangeGameMode(int gameMode) => gameSettings.GameMode = (GameMode)gameMode;

    public void StartGame() => SceneManager.LoadScene(1);

    public void Reskin(TMP_InputField input)
    {
        string path = Path.Combine(Application.streamingAssetsPath, input.text);
        if (!File.Exists(path))
        {
            messages.text = $"Didn't found Asset Bundle {input.text}.";
            messages.color = Color.red;
            return;
        }
        AssetBundle ab = AssetBundle.LoadFromFile(path);
        messages.text = $"Asset Bundle {input.text} loaded successfuly.";
        messages.color = Color.green;

        foreach (UnityEngine.Object s in ab.LoadAllAssets(typeof(Sprite)))
        {
            if (s.name == "BackgroundSprite")
            {
                background.sprite = (Sprite)s;
                gameSettings.BGSprite = (Sprite)s;
            }
            else if (s.name == "XMarkSprite")
                XMark.MarkSprite = (Sprite)s;
            else if (s.name == "OMarkSprite")
                OMark.MarkSprite = (Sprite)s;
        }

        ab.Unload(false);
    }
}
