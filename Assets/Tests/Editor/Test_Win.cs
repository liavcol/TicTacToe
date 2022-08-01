using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Test_Win
{

    [Test]
    public void Empty_Board_Not_Win()
    {
        //Arange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));

        //Act

        //Assert
        Assert.IsFalse(board.CheckWinningFormation());
    }

    [Test]
    public void Filling_Same_Mark_On_046_Not_Win()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark XMark = Mark.InstantiateMark("X");
        
        //Act
        board.MarkSquare(0, XMark);
        board.MarkSquare(4, XMark);
        board.MarkSquare(6, XMark);

        //Assert
        Assert.IsFalse(board.CheckWinningFormation());
    }

    [Test]
    public void Only_012_Filled_With_Different_Marks_Not_Win()
    {
        //Arange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark XMark = Mark.InstantiateMark("X");
        Mark OMark = Mark.InstantiateMark("O");

        //Act
        board.MarkSquare(0, OMark);
        board.MarkSquare(1, OMark);
        board.MarkSquare(2, XMark);

        //Assert
        Assert.IsFalse(board.CheckWinningFormation());
    }

    [Test]
    public void Filling_Same_Mark_On_147_Win()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark OMark = Mark.InstantiateMark("O");

        //Act
        board.MarkSquare(1, OMark);
        board.MarkSquare(4, OMark);
        board.MarkSquare(7, OMark);

        //Assert
        Assert.IsTrue(board.CheckWinningFormation());
    }

    [Test]
    public void Filling_Same_Mark_On_14_Clear_4_Fill_7_Not_Win()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark OMark = Mark.InstantiateMark("O");

        //Act
        board.MarkSquare(1, OMark);
        board.MarkSquare(4, OMark);
        board.ClearSquare(4);
        board.MarkSquare(7, OMark);

        //Assert
        Assert.IsFalse(board.CheckWinningFormation());
    }

    [Test]
    public void Filling_Same_Mark_On_14_Try_Mark_4_Different_Mark_Fill_7_Win()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark OMark = Mark.InstantiateMark("O");
        Mark XMark = Mark.InstantiateMark("X");

        //Act
        board.MarkSquare(1, OMark);
        board.MarkSquare(4, OMark);
        board.MarkSquare(4, XMark);
        board.MarkSquare(7, OMark);

        //Assert
        Assert.IsTrue(board.CheckWinningFormation());
    }

}
