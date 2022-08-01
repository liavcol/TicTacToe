using UnityEngine;

/*
 This abstract class is used to determine the basic functionality for a player.
By inherting this class and implementing the ChooseSquare function, it's possible to create many
different types of players controlled by different methods.
I thought about creating some kind of "Plater Controller" which could be injected to this class but
liked the inheritance better since it gives more freedom when actually implementing the player.
 */

public abstract class Player1 : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] protected BoardGame boardGame;

    private Mark assignedMark;
    
    public string Name { get { return name; } }
    public BoardGame BoardGame { set { boardGame = value; } }

    public Mark AssignedMark
    { 
        get { return assignedMark; }  
        set { assignedMark = value; }
    }

    protected virtual void Update()
    {
        int choice = ChooseSquare();
        if (choice != -1)
            boardGame.MarkSquare(choice);
        
    }

    protected abstract int ChooseSquare();
}
