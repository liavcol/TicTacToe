using UnityEngine;

/*
 This class represents a player in the game. Using the Depedancy Injection pattern
I can easily build different implementations of the Player Controller and inject them at runtime. 
 */
public class Player : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] protected BoardGame boardGame;

    [SerializeField] PlayerType controllerType;
    private BoardPlayerController controller;

    private Mark assignedMark;

    public string Name { get { return name; } }
    public BoardGame BoardGame { set { boardGame = value; } }

    public void ChangeController(PlayerType playerType)
    {
        controllerType = playerType;
        controller = BoardPlayerController.GetController(playerType, boardGame);
    }

    public Mark AssignedMark
    {
        get { return assignedMark; }
        set { assignedMark = value; }
    }

    private void Awake() => controller = BoardPlayerController.GetController(controllerType, boardGame);
    

    private void OnEnable() => controller.EnableController();
    private void OnDisable() => controller.DisableController();

    private void Update()
    {
        int choice = controller.ChooseSquare();
        if (choice != -1)
            boardGame.MarkSquare(choice);

    }
}
