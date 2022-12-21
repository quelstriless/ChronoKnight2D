using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuPanel : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    Animator anim;
    private int first, second;
    private float timer;
    private bool one, two, third,rofl, basla;
    private void Start()
    {
        rofl = false;
        timer = 2.3f;
        first = 10;
        anim = GetComponent<Animator>();
        one = false;
        third = true;
        two = false;
    }
    public void set()
    {
    
        FindObjectOfType<Portalling>().GetComponent<Portalling>().make = true;
    }
    public void click()
    {
        basla = FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.firstPlay;
        if (!FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.firstPlay)
        {
            loadingScreen.SetActive(true);
            FindObjectOfType<StartMenuMusic>().GetComponent<AudioSource>().mute = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().Basla();
            rofl = true;
        }
        else
        {
            FindObjectOfType<StartMenuMusic>().GetComponent<AudioSource>().mute = true;
            loadingScreen.SetActive(true);
            basla = true;
            rofl = true;
        }

    }
    private void Update()
    {
        if(rofl)
        {
            timer -= Time.deltaTime;
        }
        if(timer<=0)
        {
            if (basla)
            {
                SceneManager.LoadScene(20);
            }
            else
            {

                SceneManager.LoadScene(1);
            }
        }
    
        if (Input.touchCount > 0 && !one && third)
        {
            one = true;
            two = false;
            third = true;
        }
        else if (Input.touchCount > 0 && !two && !third)
        {
            FindObjectOfType<TimeControl>().GetComponent<TimeControl>().timeStopButton2();
            FindObjectOfType<StartMenuMusic>().GetComponent<StartMenuMusic>().pitch2();
            two = true;
            one = false;
            third = false;
        }

        if (Input.touchCount == 0 && third && one)
        {
            FindObjectOfType<TimeControl>().GetComponent<TimeControl>().timeStopButton1();
            FindObjectOfType<StartMenuMusic>().GetComponent<StartMenuMusic>().pitch();
            third = false;
        }
        else if (Input.touchCount == 0 && !third && two)
        {
            FindObjectOfType<TimeControl>().GetComponent<TimeControl>().timeStopButton2();
            FindObjectOfType<StartMenuMusic>().GetComponent<StartMenuMusic>().pitch2();
            third = true;
        }

    }

}
