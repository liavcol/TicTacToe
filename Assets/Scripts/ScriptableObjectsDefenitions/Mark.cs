using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mark", menuName = "Mark")]
public class Mark : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private Sprite markSprite;

    public string Name { get { return name; } }
    public Sprite MarkSprite 
    { 
        get { return markSprite; } 
        set { markSprite = value; }
    }

    //For testing capabilities.
    public static Mark InstantiateMark(string name)
    {
        Mark toRet = CreateInstance<Mark>();
        toRet.name = name;
        return toRet;
    }
}
