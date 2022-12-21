using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaBar : MonoBehaviour
{
    private Transform bar;
    public float reload;
    public bool check;
    public float speed;
    [SerializeField] GameObject sounds;
    public float speed2;
    // Start is called before the first frame update
    private void Start()
    {
        speed2 = 0.4f;
        speed = 1.5f;
        bar = transform.Find("Bar");
        reload = 10f;
        check = false;
    }

    private void Update()
    {
        if(reload <= 10f && check == false)
        {
            reload +=  speed2 * Time.deltaTime;
        }
        if(check && reload >= 0)
        {
            reload -= speed * Time.deltaTime;
        }
        if(reload <= 0 )
        {
            FindObjectOfType<TimeControl>().GetComponent<TimeControl>().timeStopButton2();
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().Play();

           if(FindObjectOfType<TimeStopSound>())
            FindObjectOfType<TimeStopSound>().GetComponent<AudioSource>().Stop();
            
            check = false;
        }
        bar.localScale = new Vector3(reload/10f, 1f);


    }

    public void timeStopButton()
    {
        if(reload > 0f && !check)
        {
            FindObjectOfType<TimeControl>().GetComponent<TimeControl>().timeStopButton1();
            Instantiate(sounds, transform.position, transform.rotation);
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().Pause();
            check = true;
        }

    }
    
}
