using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    [SerializeField] GameObject[] arr;
    private float rofl;
    private Color textcolor;
    public float disappearSpeed;
    public bool comeAgain;
    public float creatingSpeed;
    public bool check;
    private float timer;
    private bool allDead;
    public bool wantallDead;
    public bool makeEnemyFall;
    private bool dec;
    private int num;
    private int counter;
    Collider2D collider;
    void Start()
    {
        dec = false;
        collider = GetComponent<Collider2D>();
        rofl = 1f;
        textcolor = GetComponent<SpriteRenderer>().color;
        counter = 0;
        timer = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(wantallDead)
        {

            
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == null)
                {             
                    counter++;
                }
            }
            if(counter != arr.Length)
            {
                counter = 0;
            }
            if(arr.Length == counter)
            {
                allDead = true;
            }
            
               if (allDead)
            {         
                check = true;
                wantallDead = false;
            }

        }

        
        
        if(check)
        {
            if(rofl >= 0 )
            {
                textcolor.a -= disappearSpeed * Time.deltaTime;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, rofl);
                rofl -= disappearSpeed * Time.deltaTime;
                
            }
            if(rofl < 0)
            {
                timer = 2f;
                dec = true;
                collider.isTrigger = true;
                check = false;
                rofl = 0;
            }
        }
        if(comeAgain && rofl < 1f && dec && timer <= 0)
        {
            textcolor.a += creatingSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, rofl);
            rofl += creatingSpeed * Time.deltaTime;
            if(rofl >= 1f)
            {
                dec = false;
            }
        }
        if (rofl >= 0.1)
        {
            collider.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() && FindObjectOfType<Player>().GetComponent<Transform>().position.y - transform.position.y >= 0.05f &&!wantallDead && !dec)
        {
            check = true;
        }
        if(makeEnemyFall && collision.gameObject.GetComponent<Enemy>() )
        {
            check = true;
        }
    }
}
