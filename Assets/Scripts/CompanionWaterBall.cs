using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionWaterBall : MonoBehaviour
{
    public float speed;
    public float timeBtwAttack = 10;
    public int damage;
    public GameObject raven;
    public Transform target;
    public GameObject enemy;


    void Start()
    {
        raven = FindObjectOfType<Raven1>().gameObject;
        target = raven.GetComponent<Raven1>().close;
        enemy = raven.GetComponent<Raven1>().enemy;

        look();

    }
    private void Update()
    {
        timeBtwAttack -= Time.deltaTime;
        if (timeBtwAttack <= 0)
        {
            Destroy(gameObject);

        }
        if(enemy == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

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
        if(collision.GetComponent<Enemy>())
        {
            collision.GetComponent<Enemy>().TakeDamage(damage, new Vector2(0, 3));
            Destroy(gameObject);
        }

    }
}
