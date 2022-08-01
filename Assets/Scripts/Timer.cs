using UnityEngine;
/*
Making the timer easily testable.
*/
public class Timer
{
    private float timeLimit;
    private float t0;

    public void Start(float timeLimit)
    {
        this.timeLimit = timeLimit;
        t0 = Time.time;
    }

    public float TimeRemaining => Mathf.Max(timeLimit - (Time.time - t0), 0);
}
