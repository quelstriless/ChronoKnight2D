using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class Fireball : BaseBehaviour
{
    [SerializeField] GameObject effect;
    public bool right;
    public float speed;
    public float wait;
    public int damage;
    public bool goLeft;
    public bool fakeFireball;
    private float timer;
    TimeControl timeControl;
    
    // Start is called before the first frame update
 
    void Start()
    {

        timer = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(goLeft)
        {
            if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().fireBallSpeed)
            {
                transform.Translate(Vector2.right * (speed / 2) * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        
        if(FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().fireBallSpeed && !goLeft)
        {
            transform.Translate(Vector2.left * (speed / 2) * Time.deltaTime);
        }
        else if(!goLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (timer > 0)
            timer -= Time.deltaTime;

        if(timer <= 0 && fakeFireball)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {

            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                collision.gameObject.GetComponent<Player>().rightDamage = true;
            }
            else
            {
                collision.gameObject.GetComponent<Player>().rightDamage = false;
            }
            FindObjectOfType<Player>().GetComponent<Player>().TakeDamage(damage);
        }
        if (right)
        {
            Instantiate(effect, new Vector3(transform.position.x - 0.45f, transform.position.y - 0.84f), transform.rotation); 
        }
        else
        {
            Instantiate(effect, new Vector3(transform.position.x + 0.7f, transform.position.y - 0.84f), transform.rotation);
        }
        
        Destroy(gameObject);
    }
    public void playerAttack()
    {
        if (right)
        {
            Instantiate(effect, new Vector3(transform.position.x - 0.45f, transform.position.y - 0.84f), transform.rotation);
        }
        else
        {
            Instantiate(effect, new Vector3(transform.position.x + 0.7f, transform.position.y - 0.84f), transform.rotation);
        }

        Destroy(gameObject);
    }
}
