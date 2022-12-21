using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterball : MonoBehaviour
{
    [SerializeField] GameObject effect;
    public float speed;
    public float timeBtwAttack = 10;
    public int damage;
    public Transform target;
    float X;
    float Y;
    float q;
    float w;
    void Start()
    {
        target = FindObjectOfType<Player>().gameObject.GetComponent<Transform>();
        X = target.position.x;
        Y = target.position.y;
        look();
        q = transform.position.y - Y;
        w = transform.position.x - X;
    }
    private void Update()
    {
        timeBtwAttack -= Time.deltaTime;
        if (timeBtwAttack <= 0)
        {
            Destroy(gameObject);

        }
        if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().waterBallSpeed)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(X - 100 * (w), Y - 100 * (q)), (speed / 2) * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(X - 100 * (w), Y - 100 * (q)), speed * Time.deltaTime);
        }

    }

    public void look()
    {
        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, (rotationZ - 180));
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

            Instantiate(effect, transform.position, transform.rotation);

            Destroy(gameObject);
        }


    }
    public void playerAttack()
    {

        Instantiate(effect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}


