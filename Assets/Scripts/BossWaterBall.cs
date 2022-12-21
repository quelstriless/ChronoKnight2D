using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWaterBall : MonoBehaviour
{
    public float speed;
    public float timeBtwAttack = 10;
    public int damage;
    public Transform target;
    float X;
    float Y;
    float q;
    float w;
    bool check;
    public float wait;
    bool once;
    [SerializeField] GameObject sound;
    void Start()
    {
        check = true;
        once = false;
    }
    private void Update()
    {
        wait -= Time.deltaTime;
        if(check)
        {
            target = FindObjectOfType<Player>().gameObject.GetComponent<Transform>();
            X = target.position.x;
            Y = target.position.y;
            look();
        }
        if (wait <= 0 && check)
        {
            target = FindObjectOfType<Player>().gameObject.GetComponent<Transform>();
            X = target.position.x;
            Y = target.position.y;
            look();
            q = transform.position.y - Y;
            w = transform.position.x - X;
            check = false;
        }
        if (timeBtwAttack <= 0)
        {
            Destroy(gameObject);
        }

        if (!check)
        { 
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(X - 100 * (w), Y - 100 * (q)), speed * Time.deltaTime);
        }
        if(!check && !once)
        {
            once = true;
            Instantiate(sound, transform.position, transform.rotation);
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

            Destroy(gameObject);
        }


    }
}
