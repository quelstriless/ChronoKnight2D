using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfcloseAppear : MonoBehaviour
{
    [SerializeField] GameObject attack, jump, doubleJump, bird;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - attack.GetComponent<Transform>().position.x) >= 6f)
        {
            attack.SetActive(false);
        }
        else
        {
            attack.SetActive(true);
        }
        if (Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - jump.GetComponent<Transform>().position.x) >= 6f)
        {
            jump.SetActive(false);
        }
        else
        {
            jump.SetActive(true);
        }
        if (Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - doubleJump.GetComponent<Transform>().position.x) >= 6f && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - bird.GetComponent<Transform>().position.x) >= 6f)
        {
            doubleJump.SetActive(false);
        }
        else
        {
            doubleJump.SetActive(true);
        }

    }
}
