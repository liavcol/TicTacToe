using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_Draw
{
    [Test]
    public void Empty_Board_Not_Draw()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));

        //Act

        //Assert
        Assert.IsFalse(board.CheckDraw());
    }

    [Test]
    public void Filled_013_X_28_O_Not_Draw()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark XMark = Mark.InstantiateMark("X");
        Mark OMark = Mark.InstantiateMark("O");

        //Act
        board.MarkSquare(0, XMark);
        board.MarkSquare(1, XMark);
        board.MarkSquare(3, XMark);
        board.MarkSquare(2, OMark);
        board.MarkSquare(8, OMark);

        //Assert
        Assert.IsFalse(board.CheckDraw());
    }

    [Test]
    public void Filled_Board_Draw()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark XMark = Mark.InstantiateMark("X");
        Mark OMark = Mark.InstantiateMark("O");

        //Act
        board.MarkSquare(0, XMark);
        board.MarkSquare(1, XMark);
        board.MarkSquare(2, OMark);
        board.MarkSquare(3, XMark);
        board.MarkSquare(4, XMark);
        board.MarkSquare(5, OMark);
        board.MarkSquare(6, XMark);
        board.MarkSquare(7, OMark);
        board.MarkSquare(8, OMark);

        //Assert
        Assert.IsTrue(board.CheckDraw());
    }

    [Test]
    public void Filled_Board_Draw_And_Clear_Not_Draw()
    {
        //Arrange
        TicTacToeBoard board = new TicTacToeBoard(Mark.InstantiateMark(""));
        Mark XMark = Mark.InstantiateMark("X");
        Mark OMark = Mark.InstantiateMark("O");

        //Act
        board.MarkSquare(0, XMark);
        board.MarkSquare(1, XMark);
        board.MarkSquare(2, OMark);
        board.MarkSquare(3, XMark);
        board.MarkSquare(4, XMark);
        board.MarkSquare(5, OMark);
        board.MarkSquare(6, XMark);
        board.MarkSquare(7, OMark);
        board.MarkSquare(8, OMark);
        board.ClearSquare(8);

        //Assert
        Assert.IsFalse(board.CheckDraw());
    }
}
