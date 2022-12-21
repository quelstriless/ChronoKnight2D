using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
using UnityEngine.SceneManagement;

public class WaterSpirit : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float timeBtwAttack;
    float X;
    float Y;
    public int damage = 10;
    private float specialTime;
    private bool startTime;
    [SerializeField] public GameObject blueFire;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(target.position.y - transform.position.y) < 30)
        {
 
            if (timeBtwAttack == 0.8f)
            {
                target = FindObjectOfType<Player>().gameObject.GetComponent<Transform>();
                X = target.position.x;
                Y = target.position.y;
            }
            timeBtwAttack -= Time.deltaTime;

            if (timeBtwAttack <= 0)
            {
                timeBtwAttack = 0.8f;
            }
            if (timeBtwAttack < 0.8f)
            {
                if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().blueFire)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(X, Y), (speed / 2) *Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(X, Y), speed * Time.deltaTime);
                }

            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.position.x > collision.gameObject.transform.position.x)
        {
            collision.gameObject.GetComponent<Player>().rightDamage = true;
        }
        else
        {
            collision.gameObject.GetComponent<Player>().rightDamage = false;
        }
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (transform.position.x > collision.gameObject.transform.position.x)
        {
            collision.gameObject.GetComponent<Player>().rightDamage = true;
        }
        else
        {
            collision.gameObject.GetComponent<Player>().rightDamage = false;
        }
        collision.gameObject.GetComponent<Player>().TakeDamage(damage);

    }
    private void spawnFire()
    {
        float number = Random.Range(0, 10);
        if( number <= 1.4f)
        Instantiate(blueFire, transform.position, transform.rotation);
    }
    public void world3()
    {
        SceneManager.LoadScene("UpgradeScreen");
    }
}
