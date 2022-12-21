using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireBall : MonoBehaviour
{
    [SerializeField] GameObject effect,sound;
    public bool right;
    public float speed = 4f;
    public float wait;
    public int damage;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        damage = 6;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
        if(wait <= 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(wait<=0.1 && !once)
        {
            once = true;
            Instantiate(sound, transform.position, transform.rotation);
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
            Instantiate(effect, new Vector3(transform.position.x - 0.2f, transform.position.y - 0.84f), transform.rotation);
        }
        else
        {
            Instantiate(effect, new Vector3(transform.position.x - 0.2f , transform.position.y - 0.84f), transform.rotation);
        }

        Destroy(gameObject);
    }
}
