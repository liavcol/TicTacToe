using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_Hint
{
    [Test]
    public void When_7_Taken_Not_Return_7()
    {
        //Arrange
        HintGenerator hintGenerator = new HintGenerator();

        //Act
        hintGenerator.UpdateValidIndexes(7);

        //Assert
        Assert.AreNotEqual(7, hintGenerator.GenerateHint());
    }

    [Test]
    public void When_Only_5_Free_Return_5()
    {
        //Arrange
        HintGenerator hintGenerator = new HintGenerator();

        //Act
        hintGenerator.UpdateValidIndexes(0);
        hintGenerator.UpdateValidIndexes(1);
        hintGenerator.UpdateValidIndexes(2);
        hintGenerator.UpdateValidIndexes(3);
        hintGenerator.UpdateValidIndexes(4);
        hintGenerator.UpdateValidIndexes(6);
        hintGenerator.UpdateValidIndexes(7);
        hintGenerator.UpdateValidIndexes(8);

        //Assert
        Assert.AreEqual(5, hintGenerator.GenerateHint());
    }

    [Test]
    public void After_Updating_3_Once_3_Not_Available()
    {
        //Arrange
        HintGenerator hintGenerator = new HintGenerator();

        //Act
        hintGenerator.UpdateValidIndexes(3);

        //Assert
        int[] valids = hintGenerator.GetAllValidIndexes();
        foreach (int i in valids)
            Assert.AreNotEqual(3, i);
    }

    [Test]
    public void After_Updating_1_Twice_1_Available()
    {
        //Arrange
        HintGenerator hintGenerator = new HintGenerator();

        //Act
        hintGenerator.UpdateValidIndexes(1);
        hintGenerator.UpdateValidIndexes(1);

        //Assert
        int[] valids = hintGenerator.GetAllValidIndexes();
        bool contains = false;
        foreach (int i in valids)
            if (i == 1)
                contains = true;

        Assert.IsTrue(contains);
    }
}
