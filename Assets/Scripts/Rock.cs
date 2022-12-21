using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public GameObject target;
    [SerializeField] GameObject effect;
    public float speed = 7f;
    public float speed2;
    public bool go;
    private float targetX;
    private float targetY;
    private int damage = 6;

    void Start()
    {
        go = true;
        target = FindObjectOfType<Player>().gameObject;
        targetY = transform.position.y;
    }


    void Update()
    {
        targetX = target.transform.position.x;
        if (Mathf.Abs(transform.position.x - targetX) <= 0.14f)
        {
            go = false;
        }
        if (go)
        {
            if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().rockSpeed)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, targetY), speed / 2 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, targetY), speed * Time.deltaTime);
            }

        }
        else
        {
            if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().waterBallSpeed)
            {
                transform.Translate(Vector3.down * speed2 / 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * speed2 * Time.deltaTime);
            }

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
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void playerAttack()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
