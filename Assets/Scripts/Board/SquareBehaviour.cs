using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
This class is used to controll the different squares on the board visually.
*/
public class SquareBehaviour : MonoBehaviour
{
    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    public void MarkSquare(Mark mark)
    {
        if (!mark.MarkSprite)
        {
            _button.image.color = Color.clear;
            _button.image.sprite = null;
        }
        else
        {
            _button.image.color = Color.white;
            _button.image.sprite = mark.MarkSprite;
        }
    }

    public void HighlightSquare() => StartCoroutine(HighlightFlash());

    private IEnumerator HighlightFlash()
    {
        while (_button.image.color != Color.red)
        {
            _button.image.color = Color.Lerp(_button.image.color, Color.red, 0.05f);
            yield return null;
        }
        while (_button.image.color != Color.clear)
        {
            _button.image.color = Color.Lerp(_button.image.color, Color.clear, 0.05f);
            yield return null;
        }
    }
}
