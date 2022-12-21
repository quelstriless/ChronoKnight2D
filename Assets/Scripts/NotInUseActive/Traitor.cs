using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Traitor : MonoBehaviour
{

    public bool notSpeaking;
    public float runSpeed;

    [SerializeField] GameObject smoke, walk1,walk2,dash,healthBar;

    Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        notSpeaking = false;
        m_anim = GetComponent<Animator>();
        runSpeed = 1.1f;
        if(walk1 != null && walk2 != null && dash != null)
        {
            walk2.SetActive(false);
            walk1.SetActive(false);
            dash.SetActive(false);
        }
    }
    public void lookPlayer()
    {
        if (gameObject.transform.position.x > FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (FindObjectOfType<Player>().GetComponent<Transform>().position.x < transform.position.x && notSpeaking)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            m_anim.SetBool("isWalking", true);
        }
        else
        {
            m_anim.SetBool("isWalking", false);
            lookPlayer();
        }

    }
    void newPlace()
    {

        Instantiate(smoke, new Vector2(-37.02f, 80.91044f), transform.rotation);
    }
    public void beBoss()
    {
        healthBar.SetActive(true);
        walk2.SetActive(true);
        walk1.SetActive(true);
        dash.SetActive(true);
        m_anim.SetBool("beBoss", true);
    }

}
