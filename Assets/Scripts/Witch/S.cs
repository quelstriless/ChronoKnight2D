using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{
    [SerializeField] GameObject speak;
    private float time1;
    private float time2;
    private float time3;
    private float time4;
    private float time5;
    private float time6;
    private float time7;
    private float time8;
    private float time9;
    private float time10;
    private float time11;

    private bool start;
    private bool start2;
    private bool start3;
    private bool start4;
    private bool start5;
    private bool start6;
    private bool start7;
    private bool start8;
    private bool start9;
    private bool start10;
    private bool start11;
    private bool start12;
    // Start is called before the first frame update
    void Start()
    {

        start2 = false;
        start = false;
        start3 = false;
        start4 = false;
        start5 = false;
        start6 = false;
        start7 = false;
        start8 = false;
        start9 = false;
        start10 = false;
        start11 = false;
        start12 = false;

        time1 = 7.5f;
        time2 = 9f;
        time3 = 7f;
        time4 = 10f;
        time5 = 8f;
        time6 = 8f;
        time7 = 8f;
        time8 = 10f;
        time9 = 10f;
        time10 = 10f;
        time11 = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        if (time1 >= 0 && start)
        {
            time1 -= Time.deltaTime;
        }
        if (time2 >= 0 && start2)
        {
            time2 -= Time.deltaTime;
        }
        if (time3 >= 0 && start3)
        {
            time3 -= Time.deltaTime;
        }
        if (time4 >= 0 && start4)
        {
            time4 -= Time.deltaTime;
        }
        if (time5 >= 0 && start5)
        {
            time5 -= Time.deltaTime;
        }
        if (time6 >= 0 && start6)
        {
            time6 -= Time.deltaTime;
        }
        if (time7 >= 0 && start7)
        {
            time7 -= Time.deltaTime;
        }
        if (time8 >= 0 && start8)
        {
            time8 -= Time.deltaTime;
        }
        if (time9 >= 0 && start9)
        {
            time9 -= Time.deltaTime;
        }
        SpeakingStep();
    }
    public void SpeakingStep()
    {
        if (!start)
        {
            var speak1 = Instantiate(speak, transform.position, transform.rotation);
            speak1.SetActive(false);
            speak1.GetComponent<ChatBubble>().Speech4();
            time1 = 5.2f;
            start = true;
            speak1.SetActive(true);
        }
        else if (time1 <= 0 && !start2)
        {
            var speak2 = Instantiate(speak, transform.position, transform.rotation);
            speak2.SetActive(false);

            speak2.GetComponent<ChatBubble>().enemy = true;
            speak2.GetComponent<ChatBubble>().Speech5();
            start2 = true;
            time2 = 6.5f;
            speak2.SetActive(true);

        }
        else if (time2 <= 0 && !start3)
        {
            var speak3 = Instantiate(speak, transform.position, transform.rotation);
            speak3.SetActive(false);

            speak3.GetComponent<ChatBubble>().player = true;
            speak3.GetComponent<ChatBubble>().Speech6();
            start3 = true;
            time3 = 6.5f;
            speak3.SetActive(true);

        }
        else if (time3 <= 0 && !start4)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);
            speak4.SetActive(false);

            speak4.GetComponent<ChatBubble>().enemy = true;
            speak4.GetComponent<ChatBubble>().Speech7();
            start4 = true;
            time4 = 7f;
            speak4.SetActive(true);

        }
        else if (time4 <= 0 && !start5)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);
            speak4.SetActive(false);

            speak4.GetComponent<ChatBubble>().enemy = true;
            speak4.GetComponent<ChatBubble>().Speech8();
            start5 = true;
            time5 = 13.5f;
            speak4.SetActive(true);

        }
        else if (time5 <= 0 && !start6)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);

            speak4.GetComponent<ChatBubble>().enemy = true;
            speak4.GetComponent<ChatBubble>().Speech9();
            start6 = true;
            time6 = 8f;

        }
        /*
        else if (time6 <= 0 && !start7)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);
 

            speak4.GetComponent<ChatBubble>().enemy = true;
            speak4.GetComponent<ChatBubble>().Speech10();
            start7 = true;
            time8 = 8f;

        }
        else if (time8 <= 0 && !start9)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);

            speak4.GetComponent<ChatBubble>().Speech11();
            start9 = true;
            time9 = 8f;

        }
        
        else if (time9 <= 0 && !start10)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);

            speak4.GetComponent<ChatBubble>().Speech12();
            start10 = true;
            time10 = 8f;
        }
        else if (time10 <= 0 && !start11)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);

            speak4.GetComponent<ChatBubble>().Speech13();
            start11 = true;
            time11 = 8f;
        }
        else if (time11 <= 0 && !start12)
        {
            var speak4 = Instantiate(speak, transform.position, transform.rotation);

            speak4.GetComponent<ChatBubble>().Speech14();
            start12 = true;
        }
        */
    }
}
