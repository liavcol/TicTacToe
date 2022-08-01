
/*
 This class is responsible for the board logic.
And also makes it possible to test the win and draw conditions more easily.
 */
public class TicTacToeBoard
{
    private readonly Mark[] squares;
    private readonly Mark theEmptyMark;

    private int freeSquares;
    
    public TicTacToeBoard(Mark theEmptyMark)
    {
        squares = new Mark[9];
        this.theEmptyMark = theEmptyMark;
        freeSquares = 9;

        for (int i = 0; i < 9; i++)
            squares[i] = theEmptyMark;
    }

    public void Reset()
    {
        for (int i = 0; i < 9; i++)
            squares[i] = theEmptyMark;
        freeSquares = 9;
    }

    public bool MarkSquare(int i, Mark mark)
    {
        if (squares[i].Name == theEmptyMark.Name && mark.Name != theEmptyMark.Name)
        {
            squares[i] = mark;
            freeSquares--;
            return true;
        }
        return false;
    }

    public bool ClearSquare(int i)
    {
        if (squares[i].Name != theEmptyMark.Name)
        {
            squares[i] = theEmptyMark;
            freeSquares++;
            return true;
        }
        return false;
    }

    public bool CheckWinningFormation()
    {
        //Check rows
        if (CheckSameMark(0, 1, 2) || CheckSameMark(3, 4, 5) || CheckSameMark(6, 7, 8))
            return true;
        //Check cols
        if (CheckSameMark(0, 3, 6) || CheckSameMark(1, 4, 7) || CheckSameMark(2, 5, 8))
            return true;
        //Check adj
        return CheckSameMark(0, 4, 8) || CheckSameMark(2, 4, 6);
    }
    public bool CheckDraw() => freeSquares == 0;

    private bool CheckSameMark(int i, int j, int k) =>
        squares[i].Name == squares[j].Name && squares[j].Name == squares[k].Name && squares[k].Name != theEmptyMark.Name;

}
