using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_Lose
{
    //The only way to lose the game is if the other player won (which we have edit mode tests for) or if the timer runs out of time.
    //This is why this test actually tests the timer.
    [UnityTest]
    public IEnumerator Timer_Run_Out_Of_Time_5_Secs()
    {
        Timer timer = new Timer();
        timer.Start(5);

        yield return new WaitForSeconds(5);

        Assert.AreEqual(0, timer.TimeRemaining);
    }
}
