using System.Collections;
using UnityEngine;

/*
 This is a player that is controlled by the computer.
Not doing anything smart, just choosing a square on the board by random.
 */
public class AIControlledPlayer : Player1
{
    bool canChoose = false;

    private void OnEnable()
    {
        canChoose = false;
        StartCoroutine(nameof(Delay));
    }

    private void OnDisable() => StopCoroutine(nameof(Delay));

    protected override int ChooseSquare()
    {
        if (!canChoose)
            return -1;
        System.Random rnd = new System.Random();
        return rnd.Next(9);
}

    //Delay befor choosing, to give a more realistic feel ;).
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        canChoose = true;
    }
}
