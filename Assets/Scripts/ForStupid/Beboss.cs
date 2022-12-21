using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beboss : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    private bool check,check2;
    [SerializeField] GameObject speak;
    void Start()
    {
        check2 = false;
        check = false;
        timer = 9f;
        if(!check2)
        {
           var talk = Instantiate(speak, new Vector2(-37.02f, 79.65f), transform.rotation);
            talk.GetComponent<ChatBubble>().bossSpeech();
            check2 = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > 0)
            timer -= Time.deltaTime;
        if(timer <= 0 && !check)
        {
            check = true;
            FindObjectOfType<Traitor>().GetComponent<Traitor>().beBoss();
        }
    }

}
