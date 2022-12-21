using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class TimeControl : MonoBehaviour
{
    [SerializeField] GameObject background;
    public bool fireBallSpeed;
    public bool waterBallSpeed;
    public bool rockSpeed;
    public bool vikingSpeed;
    public bool knightAttackSpeed;
    public bool vikingAttackSpeed;
    public bool blueFire;
    public float timeStop;
    public bool timeC;
    public bool timeStopButton;
    public bool witchSpeed;
    private void Start()
    {
        witchSpeed = false;
        timeStopButton = false;
        vikingAttackSpeed = false;
        blueFire = false;
        timeC = false;
        timeStop = 4f;
        fireBallSpeed = false;
        vikingSpeed = false;
        knightAttackSpeed = false;
        waterBallSpeed = false;
        rockSpeed = false;
    }
    void Update()
    {

        // Get the Enemies global clock
        Clock clock = Timekeeper.instance.Clock("Enemy");
        Clock clock2 = Timekeeper.instance.Clock("FireBall");
        // Change its time scale on key press
        if (Input.GetKeyDown(KeyCode.O))
        {
            clock.localTimeScale = -1; // Rewind
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            clock.localTimeScale = 0; // Pause
        }
        else if (timeStopButton )
        {
            clock.localTimeScale = 0.5f; // Slow
            clock2.localTimeScale = 0.5f;
            if (background != null)
                background.SetActive(true);
            fireBallSpeed = true;
            vikingSpeed = true;
            knightAttackSpeed = true;
            vikingAttackSpeed = true;
            blueFire = true;
            waterBallSpeed = true;
            rockSpeed = true;
            witchSpeed = true;
        }
        else if (!timeStopButton)
        {
            clock.localTimeScale = 1; // Normal
            clock2.localTimeScale = 1;
            if(background != null)
                background.SetActive(false);
            fireBallSpeed = false;
            vikingSpeed = false;
            blueFire = false;
            knightAttackSpeed = false;
            vikingAttackSpeed = false;
            waterBallSpeed = false;
            witchSpeed = false;
            rockSpeed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            clock.localTimeScale = 2; // Accelerate
        }
    }
    public void timeStopButton1()
    {
        timeStopButton = true;
    }
    public void timeStopButton2()
    {
        timeStopButton = false;
    }
}
