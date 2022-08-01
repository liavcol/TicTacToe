using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Test_Undo
{
    [Test]
    public void When_Played_123_Returns_3_then_2()
    {
        //Arrange
        TurnHistory history = new TurnHistory();

        //Act
        history.RecordTurn(1);
        history.RecordTurn(2);
        history.RecordTurn(3);

        //Assert
        (int? t1, int? t2) = history.UndoRound();
        Assert.AreEqual(3, t1);
        Assert.AreEqual(2, t2);
    }

    [Test]
    public void When_Played_1_Returns_Only_1_Then_Null()
    {
        //Arrange
        TurnHistory history = new TurnHistory();

        //Act
        history.RecordTurn(1);

        //Assert
        (int? t1, int? t2) = history.UndoRound();
        Assert.AreEqual(1, t1);
        Assert.AreEqual(null, t2);
    }

    [Test]
    public void When_Played_1342_And_Doing_Undo_Round_Twice_Returns_2_4_3_1_In_That_Order()
    {
        //Arrange
        TurnHistory history = new TurnHistory();

        //Act
        history.RecordTurn(1);
        history.RecordTurn(3);
        history.RecordTurn(4);
        history.RecordTurn(2);

        //Assert
        (int? t1, int? t2) = history.UndoRound();
        Assert.AreEqual(2, t1);
        Assert.AreEqual(4, t2);
        
        (t1, t2) = history.UndoRound();
        Assert.AreEqual(3, t1);
        Assert.AreEqual(1, t2);
    }

    [Test]
    public void When_Not_Played_Returns_Only_Null()
    {
        //Arrange
        TurnHistory history = new TurnHistory();

        //Act
        
        //Assert
        (int? t1, int? t2) = history.UndoRound();
        Assert.AreEqual(null, t1);
        Assert.AreEqual(null, t2);
    }
}
