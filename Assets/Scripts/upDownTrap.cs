using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDownTrap : MonoBehaviour
{
    private float FirstX;
    private float FirstY;
    [SerializeField] float goTOX;
    private bool goDown;
    private float timer;
    private bool wait;
    public bool checkGround;
    [SerializeField] float speed2,speed;
    Collider2D myCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        goDown = false;
        myCollider2D = GetComponent<Collider2D>();
        wait = false;
        checkGround = true;
        timer = 0.4f;
        FirstX = transform.position.x;
        FirstY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(checkGround)
        {
            if(Mathf.Abs(transform.position.x - FindObjectOfType<Player>().GetComponent<Transform>().position.x) < 1.9f && transform.position.y - FindObjectOfType<Player>().GetComponent<Transform>().position.y > 0)
            {
                goDown = true;
               
            }
            if(goDown)
            {

                if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().fireBallSpeed)
                {
                    transform.Translate(Vector3.down * ( speed2 / 2 ) * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.down * speed2 * Time.deltaTime);
                }
                    
            }
               if((Mathf.Abs(FirstY - transform.position.y) >= goTOX))
            {
                checkGround = false;
                wait = true;
            }
        }
        else
        {
            if(wait)
            {
                if (timer >= 0)
                {
                    timer -= Time.deltaTime;
                }
                if (timer < 0)
                {
                    wait = false;
                }
            }
            if(timer <= 0)
            {

                if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().fireBallSpeed)
                {
                    transform.Translate(Vector3.up * (speed / 2)  * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }

                if (transform.position.y >= FirstY)
                {
                    goDown = false;
                    wait = true;
                    checkGround = true;
                    timer = 0.4f;

                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(6);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(6);
        }
    }
}
