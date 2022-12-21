using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portalling : MonoBehaviour
{
    [SerializeField] GameObject text , magic, left, right,dash,attack,jump;
    // Start is called before the first frame update
    public bool make;
    private bool teleport;
    private float timer;
    private bool teleport2;
    Animator m_Animator;
    private bool write3;
    private bool write1;
    private bool write2;
    private bool write4;
    private bool portalTimer;
    private bool portal2;
    private float timer2;
    private float portalTime;
    void Start()
    {
        portal2 = false;
        write1 = false;
        write2 = false;
        write3 = false;
        teleport = false;
        teleport2 = false;
        portalTimer = false;

        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >0)
        {
            timer -= Time.deltaTime;
        }
        if (timer2 > 0)
        {
            timer2 -= Time.deltaTime;
        }
        if (portalTime >0)
        {
            portalTime -= Time.deltaTime;
        }
        if (make)
        {
            if(!write3)
            {
                var tex = Instantiate(text, transform.position, transform.rotation);
                tex.GetComponent<ChatBubble>().Speech3();
                write3 = true;
            }
            if (!write1 && Mathf.Abs(FindObjectOfType<OldPlayer>().GetComponent<Transform>().position.x - FindObjectOfType<ChestFirstRoom>().GetComponent<Transform>().position.x) < 7f)
            {
                write1 = true;
                var tex = Instantiate(text, transform.position, transform.rotation);
                tex.GetComponent<ChatBubble>().Speech1();
            }
            if (!write2 && FindObjectOfType<ChestFirstRoom>().GetComponent<ChestFirstRoom>().opened)
            {
                write2 = true;
                var tex = Instantiate(text, transform.position, transform.rotation);
                tex.GetComponent<ChatBubble>().Speech2();

            }
            if (teleport && Mathf.Abs(FindObjectOfType<OldPlayer>().GetComponent<Transform>().position.x - transform.position.x) < 1.3f)
            {
                SceneManager.LoadScene(21);
            }
        }
        if (teleport2 && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - transform.position.x) < 0.7f)
        {
            if(!portalTimer)
            {
                var tex = Instantiate(text, transform.position, transform.rotation);
                tex.GetComponent<ChatBubble>().Speech10();
                portalTime = 14f;
                portalTimer = true;

                FindObjectOfType<Player>().GetComponent<Player>().runSpeed = 0;
                FindObjectOfType<Player>().GetComponent<Animator>().speed = 0;

                attack.SetActive(false);
                jump.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                dash.SetActive(false);
                timer2 = 7f;
            }
            if(timer2<= 0 && !portal2)
            {
                portal2 = true;
                var tex = Instantiate(text, transform.position, transform.rotation);
                tex.GetComponent<ChatBubble>().Speech11();
            }

            if(portalTime <= 0)
            SceneManager.LoadScene(2);
        }
    }
    public void startShow()
    {
        m_Animator.SetBool("Working", true);
        GetComponent<SpriteRenderer>().color = new Color(0.1448914f, 0.3099433f, 0.8301887f, 1);
        teleport = true;

    }
    public void startShow2()
    {
        m_Animator.SetBool("Working", true);
        GetComponent<SpriteRenderer>().color = new Color(0.8679245f, 0f, 0f, 1);
        teleport2 = true;

    }
    public void startShow3()
    {

        var buyu = Instantiate(magic, FindObjectOfType<Traitor>().GetComponent<Transform>().position, transform.rotation);
        buyu.GetComponent<MagicTime>().forth = true;
        
        //Konuşmayı başlat
        //büyücü büyüyü göndermeden önce

    }
}
